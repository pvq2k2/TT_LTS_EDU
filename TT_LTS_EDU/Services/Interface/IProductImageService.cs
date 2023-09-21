using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.ProductImageRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Services.Interface
{
    public interface IProductImageService
    {
        public Task<PageResult<ProductImageDTO>> GetAllProductImage(Pagination pagination);
        public Task<ResponseObject<ProductImageDTO>> GetProductImageByID(int productImageID);
        public Task<ResponseObject<ProductImageDTO>> CreateProductImage(CreateProductImageRequest request);
        public Task<ResponseObject<ProductImageDTO>> UpdateProductImage(int productImageID, UpdateProductImageRequest request);
        public Task<ResponseObject<string>> RemoveProductImage(int productImageID);
    }
}
