using System.ComponentModel.DataAnnotations;

namespace Makeup_1.Models.ViewModels.UserViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int Year { get; set; }
    }
}
