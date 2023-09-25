using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class ProductConverter
    {
        public ProductDTO EntityProductToDTO(Product product)
        {
            return new ProductDTO
            {
                ProductID = product.ID,
                NameProduct = product.NameProduct,
                Price = product.Price,
                AvatarImageProduct = product.AvatarImageProduct,
                Title = product.Title,
                Discount = product.Discount,
                Status = product.Status,
                NumberOfViews = product.NumberOfViews
            };
        }

        public List<ProductDTO> ListEntityProductToDTO(List<Product> listProduct) {
            var listProductDTO = new List<ProductDTO>();
            foreach (var item in listProduct)
            {
                listProductDTO.Add(EntityProductToDTO(item));
            }

            return listProductDTO;
        }
    }
}
