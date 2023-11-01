using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupClassLibrary.DomainModels
{
    internal class Question
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = default!;
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Product Products { get; set; } = default!;

        public User User { get; set; } = default!;
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
