using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class ProductTypeConverter
    {
        public ProductTypeDTO EntityProductTypeToDTO(ProductType productType)
        {
            return new ProductTypeDTO
            {
                ProductTypeID = productType.ID,
                NameProductType = productType.NameProductType,
                ImageTypeProduct = productType.ImageTypeProduct
            };
        }

        public List<ProductTypeDTO> ListEntityProductTypeToDTO(List<ProductType> listProductType)
        {
            var productTypeDTO = new List<ProductTypeDTO>();

            foreach (var item in listProductType)
            {
                productTypeDTO.Add(EntityProductTypeToDTO(item));
            }

            return productTypeDTO;
        }
    }
}
