﻿namespace TT_LTS_EDU.Handle.Request.ProductReviewRequest
{
    public class CreateProductReviewRequest
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string? ContentRated { get; set; }
        public int PointEvaluation { get; set; }
    }
}
