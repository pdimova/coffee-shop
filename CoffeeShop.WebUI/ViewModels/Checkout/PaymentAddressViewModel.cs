using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CoffeeShop.WebUI.ViewModels.Checkout
{
    public class PaymentAddressViewModel
    {
        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual string Address { get; set; }

        public SelectList City { get; set; }

        [Required]
        public virtual string PostalCode { get; set; }

        [Required]
        public virtual string Phone { get; set; }

        [Required]
        public virtual string Email { get; set; }

        public virtual string Details { get; set; }
    }
}