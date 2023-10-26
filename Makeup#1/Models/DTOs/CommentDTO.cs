using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Makeup_1.Models.DTOs
{
    public class CommentDTO
    {
        [Display(Name = "Заголовок")]
        public string title { get; set; }
        [Display(Name = "Коментар")]
        public string content { get; set; }
        public int productId { get; set; } 
        public string returnUrl { get; set; }
    }
}
