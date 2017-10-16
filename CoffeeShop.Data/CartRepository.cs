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
            cartToAdd.IsCheckedOut = false;
            cartToAdd.IsDeleted = false;

            cartToAdd.DateCreated = DateTime.Now;

            this.dbSet.Add(cartToAdd);
            this.context.SaveChanges();
        }

        public IEnumerable<ICart> Filter(string shoppingCartId)
        {
            var result = this.dbSet.Where(c => c.ShoppingCartId == shoppingCartId && c.IsCheckedOut == false && c.IsDeleted == false);

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
            var item = this.dbSet.SingleOrDefault(c => c.ShoppingCartId == shoppingCartId && c.CoffeeId == coffeId && c.IsCheckedOut == false && c.IsDeleted == false);

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
            var item = this.dbSet.Single(c => c.ShoppingCartId == shoppingCartId && c.CartId == cartId && c.IsCheckedOut == false && c.IsDeleted == false);

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
            var item = this.dbSet.Single(c => c.ShoppingCartId == shoppingCartId && c.CoffeeId == coffeId && c.IsCheckedOut == false && c.IsDeleted == false);

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
            var item = this.dbSet.Single(c => c.ShoppingCartId == cartItem.ShoppingCartId && c.CoffeeId == cartItem.CoffeeId && c.IsCheckedOut == false && c.IsDeleted == false);

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
            var carItem = this.dbSet.Single(c => c.ShoppingCartId == cartItem.ShoppingCartId && c.CoffeeId == cartItem.CoffeeId && c.IsCheckedOut == false && c.IsDeleted == false);
            carItem.IsDeleted = true;
            this.context.SaveChanges();
        }

        public decimal GetSum(string shoppingCartId)
        {
            decimal? total = this.dbSet.Where(c => c.ShoppingCartId == shoppingCartId && c.IsCheckedOut == false && c.IsDeleted == false).Select(c => c.CoffeeCost).Sum();

            return total ?? decimal.Zero;
        }

        public int GetCount(string shoppingCartId)
        {
            return this.dbSet.Where(c => c.ShoppingCartId == shoppingCartId && c.IsCheckedOut == false && c.IsDeleted == false).Count();
        }

        public void Migrate(string shoppingCartId, string userName)
        {
            var shoppingCart = this.dbSet.Where(c => c.ShoppingCartId == shoppingCartId && c.IsCheckedOut == false && c.IsDeleted == false);

            foreach (var item in shoppingCart)
            {
                item.ShoppingCartId = userName;
            }

            this.context.SaveChanges();
        }

        public void CheckOutAll(string shoppingCartId)
        {
            var result = this.dbSet.Where(c => c.ShoppingCartId == shoppingCartId && c.IsCheckedOut == false && c.IsDeleted == false);

            foreach (var item in result)
            {
                item.IsCheckedOut = true;
            }

            this.context.SaveChanges();
        }
    }
}
