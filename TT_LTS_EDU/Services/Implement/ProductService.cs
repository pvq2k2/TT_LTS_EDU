using Microsoft.EntityFrameworkCore;
using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Enums;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.ProductRequest;
using TT_LTS_EDU.Handle.Response;
using TT_LTS_EDU.Helpers;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Services.Implement
{
    public class ProductService : BaseService, IProductService
    {
        private readonly ResponseObject<ProductDTO> _response;
        private readonly CloudinaryHelper _cloundinaryHelper;
        public ProductService(ResponseObject<ProductDTO> response, CloudinaryHelper cloudinaryHelper)
        {
            _response = response;
            _cloundinaryHelper = cloudinaryHelper;
        }
        public async Task<ResponseObject<ProductDTO>> CreateProduct(CreateProductRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.NameProduct)
                    || string.IsNullOrWhiteSpace(request.Title))
                {
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập đầy đủ thông tin !", null!);
                }
                if (request.Price < 0)
                {
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập giá tiền lớn hơn !", null!);
                }
                if (request.Discount != null && request.Discount < 0)
                {
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập giảm giá lớn hơn !", null!);
                }
                if (!await _context.ProductType.AnyAsync(x => x.ID == request.ProductTypeID))
                {
                    return _response.ResponseError(StatusCodes.Status404NotFound, "Danh mục không tồn tại !", null!);
                }
                InputHelper.IsImage(request.AvatarImageProduct!);

                string imgage = await _cloundinaryHelper.UploadImage(request.AvatarImageProduct!, "pizza/product", "product");
                var product = new Product
                {
                    NameProduct = request.NameProduct,
                    Price = request.Price,
                    AvatarImageProduct = imgage,
                    Discount = request.Discount,
                    Title = request.Title,
                    Status = (int)Status.Active,
                    ProductTypeID = request.ProductTypeID
                };

                await _context.Product.AddAsync(product);
                await _context.SaveChangesAsync();

                return _response.ResponseSuccess("Thêm sản phẩm thành công !", _productConverter.EntityProductToDTO(product));
            }
            catch (Exception e)
            {
                return _response.ResponseError(StatusCodes.Status500InternalServerError, e.Message, null!);
            }
        }

        public async Task<PageResult<ProductDTO>> GetAllProduct(Pagination pagination)
        {
            var query = _context.Product.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<Product>.ToPageResult(pagination, query);
            pagination.TotalCount = await query.CountAsync();

            var list = result.ToList();

            return new PageResult<ProductDTO>(pagination, _productConverter.ListEntityProductToDTO(result.ToList()));
        }

        public async Task<ResponseObject<ProductDTO>> GetProductByID(int productID)
        {
            var product = await _context.Product.FirstOrDefaultAsync(x => x.ID == productID);
            if (product == null)
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "Sản phẩm không tồn tại !", null!);
            }
            product.NumberOfViews++;
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return _response.ResponseSuccess("Thành công !", _productConverter.EntityProductToDTO(product));
        }

        public async Task<ResponseObject<string>> RemoveProduct(int productID)
        {
            var response = new ResponseObject<string>();
            var product = await _context.Product.FirstOrDefaultAsync(x => x.ID == productID);
            if (product == null)
            {
                return response.ResponseError(StatusCodes.Status400BadRequest, "Sảm phẩm không tồn tại !", null!);
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return response.ResponseSuccess("Xóa sản phẩm thành công !", null!);
        }

        public async Task<ResponseObject<ProductDTO>> UpdateProduct(int productID, UpdateProductRequest request)
        {
            try
            {
                var product = await _context.Product.FirstOrDefaultAsync(x => x.ID == productID);
                if (product == null)
                {
                    return _response.ResponseError(StatusCodes.Status404NotFound, "Sản phẩm không tồn tại !", null!);
                }

                if (string.IsNullOrWhiteSpace(request.NameProduct)
                   || string.IsNullOrWhiteSpace(request.Title))
                {
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập đầy đủ thông tin !", null!);
                }
                if (request.Price < 0)
                {
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập giá tiền lớn hơn !", null!);
                }
                if (request.Discount != null && request.Discount < 0)
                {
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập giảm giá lớn hơn !", null!);
                }
                if (!await _context.ProductType.AnyAsync(x => x.ID == request.ProductTypeID))
                {
                    return _response.ResponseError(StatusCodes.Status404NotFound, "Danh mục không tồn tại !", null!);
                }

                string img;
                if (request.AvatarImageProduct == null || request.AvatarImageProduct.Length == 0)
                {
                    img = product.AvatarImageProduct!;
                }
                else
                {
                    InputHelper.IsImage(request.AvatarImageProduct!);
                    img = await _cloundinaryHelper.UploadImage(request.AvatarImageProduct, "pizza/product", "product");
                    await _cloundinaryHelper.DeleteImageByUrl(product.AvatarImageProduct!);
                }

                product.NameProduct = request.NameProduct;
                product.Price = request.Price;
                product.Title = request.Title;
                product.AvatarImageProduct = img;
                product.Discount = request.Discount;
                product.Status = request.Status;
                product.ProductTypeID = request.ProductTypeID;
                product.UpdatedAt = DateTime.Now;

                _context.Product.Update(product);
                await _context.SaveChangesAsync();

                return _response.ResponseSuccess("Cập nhật sản phẩm thành công !", _productConverter.EntityProductToDTO(product));
            }
            catch (Exception e)
            {
                return _response.ResponseError(StatusCodes.Status500InternalServerError, e.Message, null!);
            }
        }
    }
}
