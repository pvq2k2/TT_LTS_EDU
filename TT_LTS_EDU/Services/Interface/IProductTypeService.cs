using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.ProductTypeRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Services.Interface
{
    public interface IProductTypeService
    {
        public Task<PageResult<ProductTypeDTO>> GetAllProductType(Pagination pagination);
        public Task<ResponseObject<ProductTypeDTO>> GetProductTypeByID(int productTypeID);
        public Task<ResponseObject<ProductTypeDTO>> CreateProductType(CreateProductTypeRequest request);
        public Task<ResponseObject<ProductTypeDTO>> UpdateProductType(int productID, UpdateProductTypeRequest request);
        public Task<ResponseObject<string>> RemoveProductType(int productTypeID);
    }
}
