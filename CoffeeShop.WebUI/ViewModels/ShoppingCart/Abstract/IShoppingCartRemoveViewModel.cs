namespace CoffeeShop.WebUI.ViewModels.ShoppingCart.Abstract
{
    public interface IShoppingCartRemoveViewModel
    {
        int CartCount { get; set; }
        decimal CartTotal { get; set; }
        string DeleteId { get; set; }
        int ItemCount { get; set; }
        string Message { get; set; }
    }
}