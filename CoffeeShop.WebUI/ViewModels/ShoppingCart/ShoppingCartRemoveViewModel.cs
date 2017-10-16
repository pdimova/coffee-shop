namespace CoffeeShop.WebUI.ViewModels.ShoppingCart
{
    public class ShoppingCartRemoveViewModel
    {
        public virtual string Message { get; set; }
        public virtual decimal CartTotal { get; set; }
        public virtual int CartCount { get; set; }
        public virtual int ItemCount { get; set; }
        public virtual string DeleteId { get; set; }
    }
}