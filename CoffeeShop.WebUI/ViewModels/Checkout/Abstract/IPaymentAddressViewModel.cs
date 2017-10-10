using System.Web.Mvc;

namespace CoffeeShop.WebUI.ViewModels.Checkout.Abstract
{
    public interface IPaymentAddressViewModel
    {
        string Address { get; set; }
        SelectList City { get; set; }
        string Details { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string PostalCode { get; set; }
    }
}