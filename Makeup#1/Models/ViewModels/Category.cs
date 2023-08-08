using System.ComponentModel;

namespace Makeup_1.Models.ViewModels
{
    public class Category
    {
        public Category parentCategory { get; set; }
        public List<Category> childCategories { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
