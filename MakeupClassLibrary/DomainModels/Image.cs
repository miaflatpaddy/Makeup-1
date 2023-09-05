namespace MakeupClassLibrary.DomainModels
{
    public class Image
    {
        public int Id { get; set; }

        public string ImagePath { get; set; } = default!;

        public string Filename { get; set; } = default!;
    }
}
