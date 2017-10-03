using CoffeeShop.Logic.Menu.Abstract;
using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.Stores.Abstract;
using CoffeeShop.WebUI.ViewModels.Store;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;

namespace CoffeeShop.WebUI.Controllers
{
    public class StoreController : Controller
    {
        private readonly IMenuProvider menuProvider;
        private readonly IProcessingOrderFactory orderFactory;
        private readonly ICoffeeStore store;

        public StoreController(
            ICoffeeStore store,
            IMenuProvider menuProvider,
            IProcessingOrderFactory orderFactory)
        {
            if (store==null)
            {
                throw new ArgumentNullException();
            }
            if (menuProvider == null)
            {
                throw new ArgumentNullException();
            }
            if (orderFactory == null)
            {
                throw new ArgumentNullException();
            }

            this.store = store;
            this.orderFactory = orderFactory;
            this.menuProvider = menuProvider;
        }

        public ActionResult Index(string city)
        {
            city = HttpUtility.HtmlEncode(city);
            TempData["City"] = city;

            OrderWizardViewModel orderWizardVM = new OrderWizardViewModel();
            orderWizardVM.CoffeeTypes = this.menuProvider.GetCoffeeTypes();
            orderWizardVM.CoffeeSizes = this.menuProvider.GetCoffeeSizes();
            orderWizardVM.CoffeeCondiments = new Dictionary<string, bool>();

            var condimentList = this.menuProvider.GetCoffeeCondiments();

            foreach (var condiment in condimentList)
            {
                orderWizardVM.CoffeeCondiments.Add(condiment, false);
            }

            ViewBag.City = city;
            return View(orderWizardVM);
        }

        [HttpPost] //AJAX
        public ActionResult Index(OrderWizardViewModel data)
        {
            if (ModelState.IsValid)
            {
                var order = this.orderFactory.CreateOrder();
                order.SelectedCoffeeType = data.SelectedCoffeeType;
                order.SelectedCoffeeSize = data.SelectedCoffeeSize;
                order.SelectedCoffeeCodimentsList = data.CoffeeCondiments.Where(c => c.Value == true).Select(c => c.Key).ToList();

                var coffee = this.store.ProcessOrder(order);
                TempData["Order"] = coffee;

                FinalOrderViewModel finalOrderViewModel = new FinalOrderViewModel();
                finalOrderViewModel.FullDescription = coffee.FullDescription;
                finalOrderViewModel.Price = coffee.Cost();

                return PartialView("Success", finalOrderViewModel);
            }

            return View(data);
        }
    }
}