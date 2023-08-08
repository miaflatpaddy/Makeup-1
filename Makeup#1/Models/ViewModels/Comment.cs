namespace Makeup_1.Models.ViewModels
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
