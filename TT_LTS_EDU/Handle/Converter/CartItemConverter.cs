using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class CartItemConverter
    {
        private readonly ProductConverter _productConverter;
        public CartItemConverter()
        {
            _productConverter = new ProductConverter();
        }
        public CartItemDTO EntityCartItemToDTO(CartItem cartItem)
        {
            return new CartItemDTO {
                CartItemID = cartItem.ID,
                ProductDTO = _productConverter.EntityProductToDTO(cartItem.Product!),
                Quantity = cartItem.Quantity,
            };
        }

        public List<CartItemDTO> ListCartItemToDTO(List<CartItem> listCartItem) { 
            var listCartItemDTO = new List<CartItemDTO>();
            foreach (var cartItem in listCartItem)
            {
                listCartItemDTO.Add(EntityCartItemToDTO(cartItem));
            }

            return listCartItemDTO;
        }
    }
}
