using System.ComponentModel.DataAnnotations;
namespace Makeup_1.Models.ViewModels.UserViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
