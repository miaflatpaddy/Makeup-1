using System.ComponentModel.DataAnnotations.Schema;

namespace MakeupClassLibrary.DomainModels
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product Product { get; set; } = default!;
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public int quantity { get; set; }
    }
}
