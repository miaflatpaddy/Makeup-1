namespace Makeup_1.Models.ViewModels
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime date { get; set; }
        public string UserId { get; set; }
    }
}
