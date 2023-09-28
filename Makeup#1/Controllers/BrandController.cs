using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MakeupClassLibrary.DomainModels;
using Makeup_1.Database;

namespace Makeup_1.Controllers
{
    public class BrandController : Controller
    {
        private readonly ShopContext _shopContext;
        // GET: BrandController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BrandController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Name, string Country, List<Product> products = null)
        {
            try
            {
                Brand brand = new Brand();
                brand.Name = Name;
                brand.Country = Country;
                brand.Products = products;
                _shopContext.Brands.Add(brand);
                await _shopContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandController/Edit/5**
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Name, string Country, List<Product> products = null)
        {
            try
            {
                Brand brand = new Brand();
                brand.Id = id;
                brand.Name = Name;
                brand.Country = Country;
                brand.Products = products;
                _shopContext.Brands.Update(brand);
                await _shopContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BrandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if(Exists(id))
                {
                    Brand brand = await _shopContext.Brands.FindAsync(id);
                    _shopContext.Brands.Remove(brand);
                    await _shopContext.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool Exists(int id)
        {
            return _shopContext.Brands.Any(p => p.Id == id);
        }
    }
}
