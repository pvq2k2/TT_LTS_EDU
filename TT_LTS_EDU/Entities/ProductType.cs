namespace TT_LTS_EDU.Entities
{
    public class ProductType : BaseEntity
    {
        public string NameProductType { get; set; } = string.Empty;
        public string ImageTypeProduct { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Product>? ListProduct { get; set; }
    }
}
