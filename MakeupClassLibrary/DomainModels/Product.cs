using System.Text.Json;

namespace MakeupClassLibrary.DomainModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Rating { get; set; }
        public List<Comment>? Comments { get; set; }
        public double Price { get; set; }
        public string? MethodOfUse { get; set; }
        public List<Image>? Images { get; set; }
        public List<Category>? Categories { get; set; }
        public Brand Brand { get; set; } =default!;

        public int BrandId { get; set; }
    }
}
