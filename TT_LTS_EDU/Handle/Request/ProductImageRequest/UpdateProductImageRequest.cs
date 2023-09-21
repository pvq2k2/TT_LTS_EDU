namespace TT_LTS_EDU.Handle.Request.ProductImageRequest
{
    public class UpdateProductImageRequest
    {
        public string? Title { get; set; }
        public IFormFile? ImageProduct { get; set; }
        public int ProductID { get; set; }
        public int Status { get; set; }
    }
}
