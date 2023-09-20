using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.ProductRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Services.Interface
{
    public interface IProductService
    {
        public Task<PageResult<ProductDTO>> GetAllProduct(Pagination pagination);
        public Task<ResponseObject<ProductDTO>> GetProductByID(int productID);
        public Task<ResponseObject<ProductDTO>> CreateProduct(CreateProductRequest request);
        public Task<ResponseObject<ProductDTO>> UpdateProduct(int productID, UpdateProductRequest request);
        public Task<ResponseObject<string>> RemoveProduct(int productID);
    }
}
