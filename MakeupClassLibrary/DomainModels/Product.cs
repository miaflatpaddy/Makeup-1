using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Xml.Linq;

namespace MakeupClassLibrary.DomainModels
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; } = default!;
        [Display(Name = "Опис")]
        public string Description { get; set; } = default!;
        [Display(Name = "Рейтинг")]
        public int Rating { get; set; }
        public List<Comment>? Comments { get; set; }
        [Display(Name = "Ціна")]
        public double Price { get; set; }
        [Display(Name = "Спосіб застосування")]
        public string? MethodOfUse { get; set; }
        public List<Image>? Images { get; set; }
        public List<Category>? Categories { get; set; }
        [Display(Name = "Бренд")]
        public Brand Brand { get; set; } =default!;
        [Display(Name = "ID Бренду")]
        public int BrandId { get; set; }
    }
}
