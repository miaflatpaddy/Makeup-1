using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakeupClassLibrary.DomainModels;
using Makeup_1.Database;
using Makeup_1.Models.ViewModels.ImageViewModels;

namespace Makeup_1.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ShopContext _context;

        public ImagesController(ShopContext context)
        {
            _context = context;
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
            //      return _context.Images.Count() !=0 ? 
            //                  View(await _context.Images.ToListAsync()) :
            //                  Problem("Entity set 'ShopContext.Images'  is null.");
            return View( await _context.Images.ToListAsync());
        }

        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            CreateImageViewModel model = new CreateImageViewModel();
            SelectList categories = new SelectList(_context.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));
            model.Categories = categories;
            return View(model);
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Filename,Image, ProductId")] CreateImageViewModel createVM)
        {
   

            if (ModelState.IsValid)
            {
                if(await _context.Images.FirstOrDefaultAsync(m => m.Filename == createVM.Filename) != null)
                {
                    return View(createVM);
                }
                foreach (IFormFile img in createVM.Image)
                {
                    byte[]? data = null;
                    using (BinaryReader br = new BinaryReader(img.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)img.Length);

                    }
                    Image image = new Image() { File = data, Filename = img.FileName, ProductId = createVM.ProductId };
                    _context.Add(image);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createVM);
        }

        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }
            EditImageVM editimage = new EditImageVM()
            {
                File = image.File,
                Filename = image.Filename,
                Id = image.Id
            };
            return View(editimage);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id ,[Bind("Id,File,Filename, formFile")] EditImageVM VM)
        {
            if (id != VM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Image image = new Image();
                image.Filename = VM.Filename;
                image.Id = VM.Id;
                image.File = VM.File;
                if (VM.formFile != null)
                {
                    byte[]? data = null;
                    using (BinaryReader br = new BinaryReader(VM.formFile.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)VM.formFile.Length);
                        image.File = data;
                    }
                }
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.Id))
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
            return View(VM);
        }

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Images == null)
            {
                return Problem("Entity set 'ShopContext.Images'  is null.");
            }
            var image = await _context.Images.FindAsync(id);
            if (image != null)
            {
                _context.Images.Remove(image);

            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(int id)
        {
          return (_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> getProductByCategory(int id)
        {
            var selectedCategory = await _context.Categories.FindAsync(id);
            if (selectedCategory != null) {
                var products = _context.Products.Where(t => t.Categories.Contains(selectedCategory));
                return PartialView(products);
            }
            else { return NotFound(); }
        }
    }
}
