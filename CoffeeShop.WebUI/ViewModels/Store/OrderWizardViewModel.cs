namespace CoffeeShop.WebUI.ViewModels.Store
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using CoffeeShop.Logic.Menu.Abstract;
    using CoffeeShop.Logic.Order.Abstract;

    public class OrderWizardViewModel
    {
        private IMenuProvider menuProvider;

        public OrderWizardViewModel(IMenuProvider menuProvider)
        {
            this.menuProvider = menuProvider;

            this.CoffeeTypes = this.menuProvider.GetCoffeeTypes();
            this.CoffeeSizes = this.menuProvider.GetCoffeeSizes();
            this.CoffeeCondiments = new Dictionary<string, bool>();

            IEnumerable<string> condimentList = this.menuProvider.GetCoffeeCondiments();

            foreach (string condiment in condimentList)
            {
                this.CoffeeCondiments.Add(condiment, false);
            }
        }

        [Required]
        [StringLength(9999, MinimumLength = 1)]
        public string SelectedCoffeeType { get; set; }

        public IEnumerable<string> CoffeeTypes { get; set; }

        [Required]
        [StringLength(9999, MinimumLength = 1)]
        public string SelectedCoffeeSize { set; get; }

        public IEnumerable<string> CoffeeSizes { set; get; }

        //[Required]
        public Dictionary<string, bool> CoffeeCondiments { get; set; }

        public IProcessingOrder TransferDataTo(IProcessingOrder order)
        {
            order.SelectedCoffeeType = this.SelectedCoffeeType;
            order.SelectedCoffeeSize = this.SelectedCoffeeSize;
            order.SelectedCoffeeCodimentsList = this.CoffeeCondiments
                .Where(c => c.Value == true)
                .Select(c => c.Key)
                .ToList();

            return order;
        }
    }
}