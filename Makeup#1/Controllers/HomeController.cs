using Makeup_1.Database;
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
        public async Task<IActionResult> Add(string name,string desc,double price,int brandid, string MoU = "") {
            Product product = new Product();
            product.Name = name;
            product.Description = desc;
            product.Price = price;
            product.BrandId = brandid;
            if (MoU != "")
            {
                product.MethodOfUse = MoU;
            }
            product.Brand = await _shopContext.Brands.FindAsync(brandid);
            _shopContext.Add(product);
            await _shopContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Remove(int? id) {
            if(id == null || _shopContext.Products == null)
            {
                return NotFound();
            }
            Product? product = await _shopContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _shopContext.Remove(product);
            await _shopContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id, string name, string desc, double price, int brandid, string MoU = "")
        {
            Product product = new Product();
            product.Id = id;
            product.Name = name;
            product.Description = desc;
            product.Price = price;
            product.BrandId = brandid;
            if (MoU != "")
            {
                product.MethodOfUse = MoU;
            }
            product.Brand = await _shopContext.Brands.FindAsync(brandid);
            try
            {
                _shopContext.Update(product);
                await _shopContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
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
        private bool ProductExists(int id)
        {
            return _shopContext.Products.Any(p => p.Id == id);
        }
    }
}