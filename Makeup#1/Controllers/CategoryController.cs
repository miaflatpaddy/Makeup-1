using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MakeupClassLibrary.DomainModels;
using Makeup_1.Database;
using System.Xml.Linq;

namespace Makeup_1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ShopContext _shopContext;
        // GET: CategoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Name, int parentCategoryId = -1,List<Category> childCategories = null, List<Product> products = null)
        {
            try
            {
                Category category = new Category();
                category.Name = Name;
                category.ParentCategoryId = parentCategoryId;
                category.ChildCategories = childCategories;
                category.Products = products;
                _shopContext.Categories.Add(category);
                await _shopContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Name, int parentCategoryId = -1, List<Category> childCategories = null, List<Product> products = null)
        {
            try
            {
                Category category = new Category();
                category.Id = id;
                category.Name = Name;
                category.ParentCategoryId = parentCategoryId;
                category.ChildCategories = childCategories;
                category.Products = products;
                _shopContext.Categories.Update(category);
                await _shopContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if(Exists(id))
                {
                    Category category = await _shopContext.Categories.FindAsync(id);
                    _shopContext.Categories.Remove(category);
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
            return _shopContext.Categories.Any(p => p.Id == id);
        }
    }
}
