namespace TT_LTS_EDU.Entities
{
    public class ProductReview : BaseEntity
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string ContentRated { get; set; } = string.Empty;
        public int PointEvaluation { get; set; }
        public string ContentSeen { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Product? Product { get; set; }
        public User? User { get; set; }
    }
}
