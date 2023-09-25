using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class ProductImageConverter
    {
        public ProductImageDTO EntityProductImageToDTO(ProductImage productImage)
        {
            return new ProductImageDTO
            {
                ProductImageID = productImage.ID,
                Title = productImage.Title,
                ImageProduct = productImage.ImageProduct,
                Status = productImage.Status
            };
        }

        public List<ProductImageDTO> ListEntityProductImageToDTO(List<ProductImage> listProductImage)
        {
            var productImageDTO = new List<ProductImageDTO>();

            foreach (var item in listProductImage)
            {
                productImageDTO.Add(EntityProductImageToDTO(item));
            }

            return productImageDTO;
        }
    }
}
