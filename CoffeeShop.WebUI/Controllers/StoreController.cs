using CoffeeShop.Logic.Menu.Abstract;
using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.Stores.Abstract;
using CoffeeShop.WebUI.ViewModels.Store;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.WebUI.Controllers
{
    public class StoreController : Controller
    {
        readonly IMenuProvider menuProvider;
        readonly IOrderFactory orderFactory;
        readonly ICoffeeStore store;

        public StoreController(ICoffeeStore store, IMenuProvider menuProvider, IOrderFactory orderFactory)
        {
            this.store = store;
            this.orderFactory = orderFactory;
            this.menuProvider = menuProvider;
        }

        public ActionResult Index(string city)
        {
            city = HttpUtility.HtmlEncode(city); // sanitize the user input if such

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

        [HttpPost]
        public ActionResult Index(OrderWizardViewModel data)
        {
            if (ModelState.IsValid)
            {
                var order = this.orderFactory.CreateOrder();
                order.SelectedCoffeeType = data.SelectedCoffeeType;
                order.SelectedCoffeeSize = data.SelectedCoffeeSize;
                order.SelectedCoffeeCodimentsList = data.CoffeeCondiments.Where(c => c.Value == true).Select(c => c.Key).ToList();

                var processedOrder = this.store.ProcessOrder(order);

                FinalOrderViewModel finalOrderViewModel = new FinalOrderViewModel();
                finalOrderViewModel.FullDescription = processedOrder.FullDescription;
                finalOrderViewModel.Price = processedOrder.Cost;

                return PartialView("Success", finalOrderViewModel);
            }

            return View(data);
        }
    }
}