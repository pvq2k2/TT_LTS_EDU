using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.VoucherRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Services.Interface
{
    public interface IVoucherService
    {
        public Task<ResponseObject<VoucherDTO>> CreateVoucher(VoucherRequest request);
        public Task<PageResult<VoucherDTO>> GetAllVoucher(Pagination pagination);
        public Task<ResponseObject<VoucherDTO>> GetVoucherByID(int voucherID);
        public Task<ResponseObject<VoucherDTO>> UpdateVoucher(int voucherID, VoucherRequest request);
        public Task<ResponseObject<string>> RemoveVoucer(int voucherID);
        public Task<ResponseObject<VoucherDTO>> CheckVoucer(string code, int amount);
        public Task<ResponseObject<string>> RemoveVoucerByUser(int voucherID);

    }
}
