namespace MakeupClassLibrary.DomainModels
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Country { get; set; } = default!;
        public List<Product>? Products { get; set; }
    }
}
