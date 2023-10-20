using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MakeupClassLibrary.DomainModels
{
    public class Image
    {
        public int Id { get; set; }
        [Display(Name = "Зображення")]
        public byte[]? File { get; set; }
        [Display(Name = "Ім'я файлу")]
        public string Filename { get; set; } = default!;

        public int ProductId { get; set; }

        public Product Product { get; set; } = default!;

    }
}
