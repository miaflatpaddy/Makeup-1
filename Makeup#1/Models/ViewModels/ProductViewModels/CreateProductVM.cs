using MakeupClassLibrary.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Makeup_1.Models.ViewModels.ProductViewModels
{
    public class CreateProductVM
    {
        public Product Product { get; set; } = default!;
        public SelectList Brands { get; set; } = default!;
        [Display(Name ="Категории")]
        public IEnumerable<Category> Categories { get; set; } = default!;

    }
}
