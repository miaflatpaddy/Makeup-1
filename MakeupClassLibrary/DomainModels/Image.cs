using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MakeupClassLibrary.DomainModels
{
    public class Image
    {
        public int Id { get; set; }
        [Display(Name = "Путь к изображению")]
        public string ImagePath { get; set; } = default!;
        [Display(Name = "Имя файла")]
        public string Filename { get; set; } = default!;
    }
}
