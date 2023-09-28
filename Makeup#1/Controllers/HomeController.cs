﻿using Makeup_1.Database;
using Makeup_1.Models;
using MakeupClassLibrary.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Makeup_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopContext _shopContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ShopContext shopContext,ILogger<HomeController> logger)
        {
            _shopContext = shopContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public List<Product> Search(string request)
        {
            return new List<Product>();
        }
        public List<Product> Sort()
        {
            return new List<Product>();
        }
        public void SendComment(string comment)
        {

        }
       
        public void AddToCart(Product product,int count,string userid,CartModel cm) {
            cm.UserId = userid;
            OrderItem item = new OrderItem();
            item.ProductId = product.Id;
            item.quantity = count;
            item.Product = product;
            cm.items.Add(item);

        }
        public void RemoveFromCart(CartModel cm,Product product) {
            cm.items.ForEach(item => { if (item.ProductId == product.Id) { cm.items.Remove(item);return; } });
            return;
        }
        public async Task<IActionResult> Buy(string userid, CartModel cm) { 
            Order order = new Order();
            order.Items = cm.items;
            order.User = new User();
            order.UserId = userid;
            order.Date = DateTime.Now;
            _shopContext.Add(order);
            await _shopContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public void Clear(CartModel cm) {
            cm.items.Clear();
        }
        public void LogIn()
        {

        }
        public void LogOut() {
        
        }
        public void Register()
        {

        }
        public void SendPM(string message, User user) { 

        }
        public void ReadPM(string message, User user) { 

        }

    }
}