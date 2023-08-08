using System.Text.Json;

namespace Makeup_1.Models.ViewModels
{
    public class Product
    {
        public string ProductId { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public List<Comment>? Comments { get; set; }
        public double Price { get; set; }
        public string methodOfUse { get; set; }
        public List<Image> images { get; set; }
        public List<Category> categories { get; set; }
        public Brand brand { get; set; }
    }
}
