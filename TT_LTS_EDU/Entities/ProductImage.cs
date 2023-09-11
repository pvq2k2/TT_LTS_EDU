namespace TT_LTS_EDU.Entities
{
    public class ProductImage : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string ImageProduct { get; set; } = string.Empty;
        public int ProductID { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Product? Product { get; set; }
    }
}
