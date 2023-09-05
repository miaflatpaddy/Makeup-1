using System.ComponentModel.DataAnnotations.Schema;

namespace MakeupClassLibrary.DomainModels
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime Date { get; set; }
        [ForeignKey(nameof(OrderItem.Id))]
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
    }
}
