using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Xml.Linq;

namespace MakeupClassLibrary.DomainModels
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; } = default!;
        [Display(Name = "Описание")]
        public string Description { get; set; } = default!;
        [Display(Name = "Рейтинг")]
        public int Rating { get; set; }
        public List<Comment>? Comments { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Display(Name = "Способ применения")]
        public string? MethodOfUse { get; set; }
        public List<Image>? Images { get; set; }
        public List<Category>? Categories { get; set; }
        [Display(Name = "Брэнд")]
        public Brand Brand { get; set; } =default!;

        public int BrandId { get; set; }
    }
}
