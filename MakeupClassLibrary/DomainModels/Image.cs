using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MakeupClassLibrary.DomainModels
{
    public class Image
    {
        public int Id { get; set; }
        [Display(Name = "Шлях до зображення")]
        public string ImagePath { get; set; } = default!;
        [Display(Name = "Ім'я файлу")]
        public string Filename { get; set; } = default!;
    }
}
