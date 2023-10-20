using System.ComponentModel.DataAnnotations;

namespace Makeup_1.Models.ViewModels.UserViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
