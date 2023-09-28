using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class PaymentConverter
    {
        public PaymentDTO EntityPaymentToDTO(Payment payment)
        {
            return new PaymentDTO
            {
                PaymentID = payment.ID,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status
            };
        }
    }
}
