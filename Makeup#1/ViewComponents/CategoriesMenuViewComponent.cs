using Makeup_1.Database;
using MakeupClassLibrary.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Makeup_1.ViewComponents
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly ShopContext context;

        public CategoriesMenuViewComponent(ShopContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Category> categories = await context.Categories.Where(c=>c.ParentCategory == null). Include(t => t.ChildCategories)!.ThenInclude(a=>a.ChildCategories).ToListAsync();
            return View(categories);
        }
    }
}
