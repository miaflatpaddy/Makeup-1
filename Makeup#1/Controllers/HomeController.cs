using Makeup_1.Models;
using MakeupClassLibrary.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Makeup_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
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
        public void Add(Product product) { }
        public void Remove(Product product) { }
        public void AddToCart(Product product) { }
        public void RemoveFromCart(Product product) { }
        public void Buy(Order order) { }
        public void Clear() { }
        public void Update(Product product) { }
        public void LogIn()
        {

        }
        public void LogOut() { }
        public void SendPM(string message, User user) { 
        }
        public void ReadPM(string message, User user) { 
        }
    }
}