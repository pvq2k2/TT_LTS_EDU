using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.OrderRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Services.Interface
{
    public interface IOrderService
    {
        public Task<ResponseObject<OrderDTO>> CheckOut(CheckOutRequest request);
        public Task<PageResult<OrderDTO>> GetAllOrder(Pagination pagination);
        public Task<PageResult<OrderDTO>> GetAllOrderByUserID(Pagination pagination);
        public Task<ResponseObject<OrderDTO>> GetOrderByID(int orderID);
        public Task<ResponseObject<OrderDTO>> UpdateOrderStatus(int orderID, int orderStatusID);
        public Task<ResponseObject<OrderDTO>> UpdateOrder(int orderID, UpdateOrderRequest request);
        public Task<ResponseObject<string>> CancelOrder(int orderID);
    }
}
