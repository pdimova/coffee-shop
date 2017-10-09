using CoffeeShop.Logic.Cart.Abstract;
using CoffeeShop.Logic.Cart.Factory;
using CoffeeShop.Logic.Cart.Repository;
using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using System;
using System.Collections.Generic;
using CoffeeShop.Logic.Order.Abstract;
using CoffeeShop.Logic.Order.Repository;

namespace CoffeeShop.Logic.ShoppingCart
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ICartRepository cartRepository;
        private readonly ICartFactory cartFactory;
        private readonly IOrderRepository orderRepository;
        private string shoppingCartId;

        public ShoppingCart(ICartRepository cartRepository, ICartFactory cartFactory, IOrderRepository orderRepository)
        {
            this.cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            this.cartFactory = cartFactory;
            this.orderRepository = orderRepository;
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

        public void AddToCart(ICoffee orderedCofee)
        {

            var isAvailable = cartRepository.IsCartItemAvailable(shoppingCartId, orderedCofee.Id);

            ICart cartItem;

            if (!isAvailable)
            {

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
                cartItem = cartRepository.GetCartItemByCoffeeId(shoppingCartId, orderedCofee.Id);

                cartItem.Count++;

                cartRepository.Update(cartItem);
            }


        }

        public int RemoveFromCart(string coffeeId)
        {

            var cartItem = cartRepository.GetCartItemByCoffeeId(shoppingCartId, coffeeId);

            int itemCount = 0;
            if (cartItem == null)
            {

            }

            if (cartItem.Count > 1)
            {
                cartItem.Count--;
                itemCount = cartItem.Count;
            }
            else
            {
                cartRepository.Remove(cartItem);
            }

            return itemCount;
        }

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
            return cartRepository.GetSum(this.shoppingCartId);
        }

        public int GetCount()
        {
            return cartRepository.GetCount(this.shoppingCartId);
        }

        public int SaveOrder(IOrder order)
        {
            this.cartRepository.CheckOutAll(this.shoppingCartId);
            return this.orderRepository.AddOrder(order);
        }

        public void MigrateCart(string userName)
        {
            cartRepository.Migrate(this.shoppingCartId, userName);

            //hack
            this.shoppingCartId = userName;
        }
    }
}