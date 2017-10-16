using System.Web;

namespace CoffeeShop.WebUI
{
    public interface ICartIdentifier
    {
        string GetCardId(HttpContextBase context);
        void SetCartSessionKey(HttpContextBase context);
    }
}