using MakeupClassLibrary.DomainModels;

namespace Makeup_1.Models.ViewModels.ImageViewModels
{
    public class CreateImageViewModel
    {
        public string Filename { get; set; } = default!;
        public IFormFile Image { get; set; } = default!;    
    }


}
