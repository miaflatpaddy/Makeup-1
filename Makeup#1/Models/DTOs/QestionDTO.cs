using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Makeup_1.Models.DTOs
{
    public class QestionDTO
    {
        [Display(Name = "Заголовок")]
        public string title { get; set; }
        [Display(Name = "Питання")]
        public string content { get; set; }
        public int productId { get; set; }
        public string returnUrl { get; set; }
    }
}
