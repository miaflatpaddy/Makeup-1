using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakeupClassLibrary.DomainModels;
using Makeup_1.Database;
using Makeup_1.Models.DTOs;
using Makeup_1.Models.ViewModels.ProductViewModels;

namespace Makeup_1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Products.Include(p => p.Brand);
            return View(await shopContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(t=>t.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewBag.Categories = _context.Categories;
            CreateProductVM createProductVM = new CreateProductVM();
            createProductVM.Categories = await _context.Categories.ToListAsync();
            createProductVM.Brands = new SelectList(_context.Brands, "Id", "Name");
            return View(createProductVM);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Rating,Price,MethodOfUse,BrandId")] ProductDTO product,
            List<int> categories)
        {
            if (ModelState.IsValid)
            {
                Product _product = new Product() { 
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Rating = product.Rating,
                MethodOfUse = product.MethodOfUse,
                BrandId = product.BrandId,
                Price = product.Price,
                };
                //List<Category> _categories = new List<Category>();
                foreach(int categoryId in categories)
                {
                    Category? category = await _context.Categories. FindAsync(categoryId);
                    _product.Categories!.Add(category!);
                }
                _context.Add(_product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            CreateProductVM createProductVM = new CreateProductVM() { Product = new Product() };
            createProductVM.Categories = await _context.Categories.ToListAsync();
            createProductVM.Brands = new SelectList(_context.Brands, "Id", "Name");
            return View(createProductVM);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Rating,Price,MethodOfUse,BrandId")] ProductDTO product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Product _product = new Product()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        BrandId = product.BrandId,
                        Description = product.Description,
                        MethodOfUse = product.MethodOfUse,
                        Price = product.Price,
                        Rating = product.Rating
                    };

                    _context.Update(_product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ShopContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
