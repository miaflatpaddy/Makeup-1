using MakeupClassLibrary.DomainModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Makeup_1.Models.ViewModels.ImageViewModels
{
    public class EditImageVM
    {
        public int Id { get; set; }
        [Display(Name = "Зображення")]
        public byte[]? File { get; set; }
        [Display(Name = "Ім'я файлу")]
        public string Filename { get; set; } = default!;
        public IFormFile? formFile { get; set; }
    }
}
