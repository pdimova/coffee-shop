using CoffeeShop.Logic.Menu.Abstract;
using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.Stores.Abstract;
using CoffeeShop.WebUI.ViewModels.Store;
using System.Linq;
using System.Web.Mvc;
using System;

namespace CoffeeShop.WebUI.Controllers
{
    public class StoreController : Controller
    {
        private readonly string[] cityNames = new string[] { "Sofia", "Plovdiv" };

        private readonly IMenuProvider menuProvider;
        private readonly IProcessingOrderFactory orderFactory;
        private readonly ICoffeeStore store;



        public StoreController(
            ICoffeeStore store,
            IMenuProvider menuProvider,
            IProcessingOrderFactory orderFactory)
        {
            if (store == null)
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
            if (!this.cityNames.Contains(city))
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["City"] = city;
            ViewBag.City = city;

            OrderWizardViewModel orderWizardVM = new OrderWizardViewModel(this.menuProvider);

            return View(orderWizardVM);
        }

        [HttpPost] //AJAX
        public ActionResult Index()
        {
            OrderWizardViewModel orderWizardVM = new OrderWizardViewModel(this.menuProvider);

            if (TryUpdateModel(orderWizardVM) && ModelState.IsValid)
            {
                var emptyOrder = this.orderFactory.CreateOrder();
                var order = orderWizardVM.TransferDataTo(emptyOrder);

                var coffee = this.store.ProcessOrder(order);
                TempData["Order"] = coffee;

                FinalOrderViewModel finalOrderViewModel = new FinalOrderViewModel(coffee);

                return PartialView("Success", finalOrderViewModel);
            }

            return View(orderWizardVM);
        }
    }
}