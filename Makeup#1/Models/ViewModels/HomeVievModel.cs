using MakeupClassLibrary.DomainModels;
namespace Makeup_1.Models.ViewModels
{
    public class HomeVievModel
    {
        public IEnumerable<Product> products { get; set; }
        public Cart cart { get; set; }

    }
}
