using Microsoft.EntityFrameworkCore;
using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Enums;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.ProductReviewRequest;
using TT_LTS_EDU.Handle.Response;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Services.Implement
{
    public class ProductReviewService : BaseService, IProductReviewService
    {
        private readonly ResponseObject<ProductReviewDTO> _response;
        public ProductReviewService(ResponseObject<ProductReviewDTO> response)
        {
            _response = response;
        }
        public async Task<ResponseObject<ProductReviewDTO>> CreateProductReview(CreateProductReviewRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ContentRated))
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập đầy đủ thông tin !", null!);
            }

            if (request.PointEvaluation < 1 || request.PointEvaluation > 5)
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "Số sao không được nhỏ hơn 1 hoặc lớn hơn 5 !", null!);
            }

            if (!await _context.User.AnyAsync(x => x.ID == request.UserID))
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, "Người dùng không tồn tại !", null!);
            }

            var product = await _context.Product.FirstOrDefaultAsync(x => x.ID == request.ProductID);
            if (product == null)
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, "Sản phẩm không tồn tại !", null!);
            }

            var productReview = new ProductReview
            {
                ProductID = request.ProductID,
                UserID = request.UserID,
                ContentRated = request.ContentRated,
                PointEvaluation = request.PointEvaluation,
                ContentSeen = product.NameProduct,
                Status = (int)Status.Active,
            };

            return _response.ResponseSuccess("Thêm bình luận thành công !", _productReviewConverter.EntityProductReviewToDTO(productReview));
        }

        public async Task<PageResult<ProductReviewDTO>> GetAllProductReview(Pagination pagination)
        {
            var query = _context.ProductReview.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<ProductReview>.ToPageResult(pagination, query);
            pagination.TotalCount = await query.CountAsync();

            var list = result.ToList();

            return new PageResult<ProductReviewDTO>(pagination, _productReviewConverter.ListProductReviewToDTO(result.ToList()));
        }

        public async Task<ResponseObject<ProductReviewDTO>> GetProductReviewByID(int productReviewID)
        {
            var productReview = await _context.ProductReview.FirstOrDefaultAsync(x => x.ID == productReviewID);
            if (productReview == null)
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "Bình luận không tồn tại không tồn tại !", null!);
            }

            return _response.ResponseSuccess("Thành công !", _productReviewConverter.EntityProductReviewToDTO(productReview));
        }

        public async Task<ResponseObject<string>> RemoveProductReview(int productReviewID)
        {
            var response = new ResponseObject<string>();
            var productReview = await _context.ProductReview.FirstOrDefaultAsync(x => x.ID == productReviewID);
            if (productReview == null)
            {
                return response.ResponseError(StatusCodes.Status400BadRequest, "Bình luận không tồn tại !", null!);
            }

            _context.ProductReview.Remove(productReview);
            await _context.SaveChangesAsync();

            return response.ResponseSuccess("Xóa bình luận thành công !", null!);
        }

        public async Task<ResponseObject<ProductReviewDTO>> UpdateProductReview(int productReviewID, UpdateProductReviewRequest request)
        {
            var productReview = await _context.ProductReview.FirstOrDefaultAsync(x => x.ID == productReviewID);

            if (productReview == null)
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, "Bình luận không tồn tại !", null!);
            }
            if (string.IsNullOrWhiteSpace(request.ContentRated))
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập đầy đủ thông tin !", null!);
            }

            if (request.PointEvaluation < 1 || request.PointEvaluation > 5)
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "Số sao không được nhỏ hơn 1 hoặc lớn hơn 5 !", null!);
            }

            if (!await _context.User.AnyAsync(x => x.ID == request.UserID))
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, "Người dùng không tồn tại !", null!);
            }

            var product = await _context.Product.FirstOrDefaultAsync(x => x.ID == request.ProductID);
            if (product == null)
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, "Sản phẩm không tồn tại !", null!);
            }

            productReview.ProductID = request.ProductID;
            productReview.UserID = request.UserID;
            productReview.ContentRated = request.ContentRated;
            productReview.PointEvaluation = request.PointEvaluation;
            productReview.Status = request.Status;
            productReview.UpdatedAt = DateTime.Now;

            return _response.ResponseSuccess("Cập nhật bình luận thành công !", _productReviewConverter.EntityProductReviewToDTO(productReview));
        }
    }
}
