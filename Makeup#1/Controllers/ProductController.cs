using Makeup_1.Database;
using MakeupClassLibrary.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Makeup_1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopContext _shopContext;
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, string desc, double price, int brandid, string MoU = "")
        {
            try
            {

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
                _shopContext.Products.Add(product);
                await _shopContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                _shopContext.Products.Update(product);
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
        

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            if(ProductExists(id))
            {
                Product? product = await _shopContext.Products.FindAsync(id);
                _shopContext.Products.Remove(product);
                await _shopContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
        private bool ProductExists(int id)
        {
            return _shopContext.Products.Any(p => p.Id == id);
        }
    }

}
