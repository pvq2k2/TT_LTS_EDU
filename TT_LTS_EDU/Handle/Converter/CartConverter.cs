using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class CartConverter
    {
        private readonly CartItemConverter _cartItemConverter;
        public CartConverter()
        {
            _cartItemConverter = new CartItemConverter();
        }

        public CartDTO EntityCartToDTO(Cart cart)
        {
            return new CartDTO
            {
                CartID = cart.ID,
                UserID = cart.UserID,
                ListCartItemDTO = _cartItemConverter.ListCartItemToDTO(cart.ListCartItem!)
            };
        }

        public List<CartDTO> ListEntityCartToDTO(List<Cart> listCart)
        {
            var listCartDTO = new List<CartDTO>();
            foreach (var cart in listCart)
            {
                listCartDTO.Add(EntityCartToDTO(cart));
            }

            return listCartDTO;
        }
    }
}
