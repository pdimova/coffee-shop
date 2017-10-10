using CoffeeShop.WebUI.ViewModels.Checkout.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CoffeeShop.WebUI.ViewModels.Checkout
{
    public class PaymentAddressViewModel : IPaymentAddressViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        public SelectList City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Details { get; set; }
    }
}