using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeupClassLibrary.DomainModels
{
    public class Category
    {
        [Display(Name="Батьківська категорія")]
        public Category? ParentCategory { get; set; }
        [Display(Name = "ID Батьківської категорії")]
        [ForeignKey(nameof(ParentCategory))]
        public int? ParentCategoryId { get; set; }
        public List<Category>? ChildCategories { get; set; }
        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; } = default!;

        public List<Product>? Products { get; set; }
    }
}
