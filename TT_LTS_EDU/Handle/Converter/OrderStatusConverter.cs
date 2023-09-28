using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class OrderStatusConverter
    {
        public OrderStatusDTO EntityOrderStatusToDTO(OrderStatus orderStatus)
        {
            return new OrderStatusDTO
            {
                OrderStatusID = orderStatus.ID,
                StatusName = orderStatus.StatusName
            };
        }
    }
}
