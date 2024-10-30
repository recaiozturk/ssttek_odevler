namespace Sample.Api.Models.Repositories.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
