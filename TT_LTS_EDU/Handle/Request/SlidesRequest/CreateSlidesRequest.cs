namespace TT_LTS_EDU.Handle.Request.SlidesRequest
{
    public class CreateSlidesRequest
    {
        public IFormFile? Image { get; set; }
        public int ProductID { get; set; }
    }
}
