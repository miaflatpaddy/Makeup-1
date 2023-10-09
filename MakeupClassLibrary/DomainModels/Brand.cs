using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MakeupClassLibrary.DomainModels
{
    public class Brand
    {
        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; } = default!;
        [Display(Name = "Країна")]
        public string Country { get; set; } = default!;
        public List<Product>? Products { get; set; }
    }
}
