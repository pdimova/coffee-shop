using CoffeeShop.Logic.Cart.Abstract;
using CoffeeShop.Logic.Cart.Factory;
using CoffeeShop.Logic.Cart.Repository;
using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Logic.ShoppingCart
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ICartRepository cartRepository;
        private readonly ICartFactory cartFactory;

        private string shoppingCartId;

        public ShoppingCart(ICartRepository cartRepository, ICartFactory cartFactory)
        {
            this.cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            this.cartFactory = cartFactory;
        }

        public string ShoppingCartId
        {
            set
            {
                if (string.IsNullOrEmpty(this.shoppingCartId))
                {
                    this.shoppingCartId = value;
                }
            }
        }

        void IShoppingCart.AddToCart(ICoffee orderedCofee)
        {
            // Get the matching cart and album instances
            var isAvailable = cartRepository.IsCartItemAvailable(shoppingCartId, orderedCofee.Id);

            ICart cartItem;

            if (!isAvailable)
            {
                // Create a new cart item if no cart item exists
                cartItem = cartFactory.CreateCart();
                cartItem.CoffeeId = orderedCofee.Id;
                cartItem.CoffeeDescription = orderedCofee.FullDescription;
                cartItem.CoffeeCost = orderedCofee.Cost();
                cartItem.ShoppingCartId = this.shoppingCartId;
                cartItem.Count = 1;

                cartRepository.Add(cartItem);
            }
            else
            {
                // Pls refactor
                cartItem = cartRepository.GetCartItem(shoppingCartId, orderedCofee.Id);
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
                // Save changes
                cartRepository.Update(cartItem);
            }


        }

        void RemoveFromCart() { }

        public IEnumerable<ICart> GetCartItems()
        {
            return cartRepository.Filter(shoppingCartId);
        }

        public IShoppingCart GetShoppingCart(string shoppingCartId)
        {
            this.ShoppingCartId = shoppingCartId;

            return this;
        }

        public decimal GetTotal()
        {
            return 65;
        }
    }
}
