using MakeupClassLibrary.DomainModels;
namespace Makeup_1.Models.ViewModels.ImageViewModels
{
    public class EditImageVM
    {
        public Image image { get; set; } = default!;
        public IFormFile formFile { get; set; } = default!;
    }
}
