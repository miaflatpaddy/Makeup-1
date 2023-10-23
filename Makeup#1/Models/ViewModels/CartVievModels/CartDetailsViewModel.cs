using MakeupClassLibrary.DomainModels;

namespace Makeup_1.Models.ViewModels.CartVievModels
{
    public class CartDetailsViewModel
    {
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        public Product Product { get; set; }
    }
}
