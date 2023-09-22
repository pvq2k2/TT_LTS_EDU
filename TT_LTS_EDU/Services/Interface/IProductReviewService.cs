using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.ProductReviewRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Services.Interface
{
    public interface IProductReviewService
    {
        public Task<PageResult<ProductReviewDTO>> GetAllProductReview(Pagination pagination);
        public Task<ResponseObject<ProductReviewDTO>> GetProductReviewByID(int productReviewID);
        public Task<ResponseObject<ProductReviewDTO>> CreateProductReview(CreateProductReviewRequest request);
        public Task<ResponseObject<ProductReviewDTO>> UpdateProductReview(int productReviewID, UpdateProductReviewRequest request);
        public Task<ResponseObject<string>> RemoveProductReview(int productReviewID);
    }
}
