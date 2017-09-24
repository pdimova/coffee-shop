namespace CoffeeShop.WebUI.ViewModels.Store
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderWizardViewModel
    {
        public string SelectedCoffeeType { get; set; }

        public IEnumerable<string> CoffeeTypes { get; set; }

        public string SelectedCoffeeSize { set; get; }

        public IEnumerable<string> CoffeeSizes { set; get; }

        public Dictionary<string, bool> CoffeeCondiments { get; set; }

        //public string SelectedCoffeeType { get; set; }
        //public string SelectedCoffeeSize { get; set; }
        //public IEnumerable<string> SelectedCoffeeCodimentsList { get; set; }
    }
}
