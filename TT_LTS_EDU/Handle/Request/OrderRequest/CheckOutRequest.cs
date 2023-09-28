using TT_LTS_EDU.Entities;

namespace TT_LTS_EDU.Handle.Request.OrderRequest
{
    public class CheckOutRequest
    {
        public int PaymentID { get; set; }
        //public int UserID { get; set; }
        //public double OriginalPrice { get; set; }
        //public double ActualPrice { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        //public int OrderStatusID { get; set; }
    }
}
