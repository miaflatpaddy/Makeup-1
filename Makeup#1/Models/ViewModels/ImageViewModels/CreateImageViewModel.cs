using MakeupClassLibrary.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Makeup_1.Models.ViewModels.ImageViewModels
{
    public class CreateImageViewModel
    {
        public string Filename { get; set; } = default!;
        public IFormFile[] Image { get; set; } = default!;
        [Display(Name ="Категория")]
        public SelectList? Categories { get; set; }
        //[Display(Name = "Товари")]
        //public SelectList? Products { get; set; }

        public int ProductId { get; set; }

    }


}
