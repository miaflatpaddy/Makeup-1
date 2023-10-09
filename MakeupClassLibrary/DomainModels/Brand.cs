using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MakeupClassLibrary.DomainModels
{
    public class Brand
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; } = default!;
        [Display(Name = "Страна")]
        public string Country { get; set; } = default!;
        public List<Product>? Products { get; set; }
    }
}
