using System.ComponentModel.DataAnnotations.Schema;

namespace MakeupClassLibrary.DomainModels
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = default!;
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Product Products { get; set; } = default!;

        public User User { get; set; } = default!;
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
