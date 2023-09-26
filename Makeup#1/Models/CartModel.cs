using MakeupClassLibrary.DomainModels;

namespace Makeup_1.Models
{
    public class CartModel
    {
        public string UserId { get; set; }
        public List<OrderItem> items = default!;
        
    }
}
