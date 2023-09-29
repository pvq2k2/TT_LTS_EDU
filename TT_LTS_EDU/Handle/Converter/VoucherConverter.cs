using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class VoucherConverter
    {
        public VoucherDTO EntityVoucherToDTO(Voucher voucher)
        {
            return new VoucherDTO
            {
                Code = voucher.Code,
                Title = voucher.Title,
                DiscountPercentage = voucher.DiscountPercentage,
                MinimumPurchaseAmount = voucher.MinimumPurchaseAmount,
                ExpiryDate = voucher.ExpiryDate
            };
        }

        public List<VoucherDTO> ListEntityVoucherToDTO(List<Voucher> listVoucher)
        {
            var listVoucherDTO = new List<VoucherDTO>();
            foreach (var voucher in listVoucher)
            {
                listVoucherDTO.Add(EntityVoucherToDTO(voucher));
            }

            return listVoucherDTO;
        }
    }
}
