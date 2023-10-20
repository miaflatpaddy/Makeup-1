﻿using MakeupClassLibrary.DomainModels;

namespace Makeup_1.Models
{
    public class CartItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }

    public class Cart
    {
        List<CartItem> cartItems;


        public Cart()
        {
            cartItems = new List<CartItem>();
        }

        public List<CartItem> CartItems => cartItems;


        public void AddItem(Product product, int count)
        {
            CartItem cartItem = cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
            if (cartItem != null)
                cartItem.Quantity += count;
            else
                cartItems.Add(new CartItem { Product = product, Quantity = count });
        }


        public void RemoveItem(Product product)
        {
            cartItems.RemoveAll(t => t.Product.Id == product.Id);
        }

        public void Clear()
        {
            cartItems.Clear();
        }

        public double GetTotalSum()
        {
            return cartItems.Sum(t => t.Quantity * t.Product.Price);
        }

        public void AddItems(IEnumerable<CartItem> items)
        {
            cartItems = items.ToList();
        }
    }
}
