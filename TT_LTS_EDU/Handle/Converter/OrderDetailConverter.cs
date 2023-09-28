using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class OrderDetailConverter
    {
        private readonly ProductConverter _productConverter;
        public OrderDetailConverter()
        {
            _productConverter = new ProductConverter();
        }

        public OrderDetailDTO EntityOrderDetailToDTO(OrderDetail orderDetail)
        {
            return new OrderDetailDTO
            {
                OrderDetailID = orderDetail.ID,
                PriceTotal = orderDetail.PriceTotal,
                Quantity = orderDetail.Quantity,
                ProductDTO = _productConverter.EntityProductToDTO(orderDetail.Product!)
            };
        }

        public List<OrderDetailDTO> ListEntityOrderDetailToDTO(List<OrderDetail> orderDetailList)
        {
            var orderDetailListDTO = new List<OrderDetailDTO>();
            foreach (var orderDetail in orderDetailList)
            {
                orderDetailListDTO.Add(EntityOrderDetailToDTO(orderDetail));
            }

            return orderDetailListDTO;
        }
    }
}
