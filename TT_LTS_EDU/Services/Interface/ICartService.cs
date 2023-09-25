using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.CartRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Services.Interface
{
    public interface ICartService
    {
        public Task<ResponseObject<CartDTO>> AddToCart(AddToCartRequest request);
        public Task<ResponseObject<CartDTO>> GetAllCartItemWhereCartExist();
        public Task<ResponseObject<CartDTO>> UpdateQuantityCartItemExistInCart(UpdateQuantityCartItemRequest request);
        public Task<ResponseObject<string>> RemoveCartItem(int cartItemID);

    }
}
