namespace TT_LTS_EDU.Entities
{
    public class ProductImage : BaseEntity
    {
        public string? Title { get; set; }
        public string? ImageProduct { get; set; }
        public int ProductID { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public Product? Product { get; set; }
    }
}
