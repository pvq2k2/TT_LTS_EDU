namespace TT_LTS_EDU.Entities
{
    public class ProductType : BaseEntity
    {
        public string? NameProductType { get; set; }
        public string? ImageTypeProduct { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public List<Product>? ListProduct { get; set; }
    }
}
