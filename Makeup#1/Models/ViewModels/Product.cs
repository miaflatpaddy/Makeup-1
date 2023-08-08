using System.Text.Json;

namespace Makeup_1.Models.ViewModels
{
    public class ProductModel
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public int Rating { get; set; }
        public CommentModel Comment { get; set; }

    }
}
