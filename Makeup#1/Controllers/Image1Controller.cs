using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MakeupClassLibrary.DomainModels;
using Makeup_1.Database;

namespace Makeup_1.Controllers
{
    public class Image1Controller : Controller
    {
        private readonly ShopContext _shopContext;
        // GET: ImageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ImageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string imagepath,string filename)
        {
            try
            {
                Image image = new Image();
                image.Filename = filename;
//                image.ImagePath = imagepath;
                _shopContext.Images.Add(image);
                await _shopContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string imagepath, string filename)
        {
            try
            {
                Image image = new Image();
                image.Filename = filename;
//               image.ImagePath = imagepath;
                _shopContext.Images.Update(image);
                await _shopContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                Image image = await _shopContext.Images.FindAsync(id);
                _shopContext.Images.Remove(image);
                await _shopContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private List<Image> Show()
        {
            List<Image> Images = new List<Image>();
            foreach (var item in _shopContext.Images)
            {
                Images.Add(item);
            }
            return Images;
        }

        private bool Exists(int id)
        {
            return _shopContext.Images.Any(p => p.Id == id);
        }
    }
}
