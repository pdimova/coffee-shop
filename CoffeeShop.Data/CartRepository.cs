using CoffeeShop.Logic.Cart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeShop.Logic.Cart.Abstract;
using CoffeeShop.Data.Models;
using System.Data.Entity;

namespace CoffeeShop.Data
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<Cart> dbSet;

        public CartRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Carts;
        }

        public void Add(ICart cartItem)
        {
            var cartToAdd = new Cart();
            cartToAdd.CoffeeId = cartItem.CoffeeId;
            cartToAdd.CoffeeDescription = cartItem.CoffeeDescription;
            cartToAdd.CoffeeCost = cartItem.CoffeeCost;
            cartToAdd.Count = cartItem.Count;
            cartToAdd.ShoppingCartId = cartItem.ShoppingCartId;

            cartToAdd.DateCreated = DateTime.Now;

            this.dbSet.Add(cartToAdd);
            this.context.SaveChanges();
        }

        public IEnumerable<ICart> Filter(string shoppingCartId)
        {
            var result = this.dbSet.Where(c => c.ShoppingCartId == shoppingCartId);

            var list = new List<ICart>();
            foreach (var item in result)
            {
                var cart = new Logic.Cart.Cart();

                cart.CoffeeId = item.CoffeeId;
                cart.CoffeeDescription = item.CoffeeDescription;
                cart.CoffeeCost = item.CoffeeCost;
                cart.Count = item.Count;
                cart.ShoppingCartId = item.ShoppingCartId;

                list.Add(cart);
            }

            return list;
        }

        public bool IsCartItemAvailable(string shoppingCartId, string coffeId)
        {
            var item = this.dbSet.SingleOrDefault(c => c.ShoppingCartId == shoppingCartId && c.CoffeeId == coffeId);

            if (item == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ICart GetCartItemByCartId(string shoppingCartId, int cartId)
        {
            var item = this.dbSet.Single(c => c.ShoppingCartId == shoppingCartId && c.CartId == cartId);

            var cart = new Logic.Cart.Cart();

            cart.CoffeeId = item.CoffeeId;
            cart.CoffeeDescription = item.CoffeeDescription;
            cart.CoffeeCost = item.CoffeeCost;
            cart.Count = item.Count;
            cart.ShoppingCartId = item.ShoppingCartId;

            return cart;
        }

        public ICart GetCartItemByCoffeeId(string shoppingCartId, string coffeId)
        {
            var item = this.dbSet.Single(c => c.ShoppingCartId == shoppingCartId && c.CoffeeId == coffeId);

            var cart = new Logic.Cart.Cart();

            cart.CoffeeId = item.CoffeeId;
            cart.CoffeeDescription = item.CoffeeDescription;
            cart.CoffeeCost = item.CoffeeCost;
            cart.Count = item.Count;
            cart.ShoppingCartId = item.ShoppingCartId;

            return cart;
        }

        public void Update(ICart cartItem)
        {
            var item = this.dbSet.Single(c => c.ShoppingCartId == cartItem.ShoppingCartId && c.CoffeeId == cartItem.CoffeeId);

            item.CoffeeId = cartItem.CoffeeId;
            item.CoffeeDescription = cartItem.CoffeeDescription;
            item.CoffeeCost = cartItem.CoffeeCost;
            item.Count = cartItem.Count;
            item.ShoppingCartId = cartItem.ShoppingCartId;

            this.dbSet.Add(item);

            this.context.SaveChanges();
        }

        public void Remove(ICart cartItem)
        {
            var carItem = this.dbSet.Single(c => c.ShoppingCartId == cartItem.ShoppingCartId && c.CoffeeId == cartItem.CoffeeId);
            this.dbSet.Remove(carItem);
            this.context.SaveChanges();
        }

        public decimal GetSum(string shoppingCartId)
        {
            decimal? total = this.dbSet.Where(c => c.ShoppingCartId == shoppingCartId).Select(c => c.CoffeeCost).Sum();

            return total ?? decimal.Zero;
        }

        public int GetCount(string shoppingCartId)
        {
            return this.dbSet.Where(c => c.ShoppingCartId == shoppingCartId).Count();
        }

        public void Migrate(string shoppingCartId, string userName)
        {
            var shoppingCart = this.dbSet.Where(c => c.ShoppingCartId == shoppingCartId);

            foreach (var item in shoppingCart)
            {
                item.ShoppingCartId = userName;
            }

            this.context.SaveChanges();
        }
    }
}
