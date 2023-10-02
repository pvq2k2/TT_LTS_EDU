using Microsoft.AspNetCore.Mvc;
using TT_LTS_EDU.Handle.Request.VNPayRequest;
using TT_LTS_EDU.Helpers;

namespace TT_LTS_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VNPayController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VNPayController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("CreatePaymentUrl")]
        public IActionResult CreatePaymentUrl(CreateVNPayRequest request)
        {
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration.GetSection("AppSettings:VNPaySettings:TimeZoneId").Value!);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VnPayLibrary();
            var urlCallBack = _configuration.GetSection("AppSettings:VNPaySettings:ReturnUrl").Value!;

            pay.AddRequestData("vnp_Version", _configuration.GetSection("AppSettings:VNPaySettings:Version").Value!);
            pay.AddRequestData("vnp_Command", _configuration.GetSection("AppSettings:VNPaySettings:Command").Value!);
            pay.AddRequestData("vnp_TmnCode", _configuration.GetSection("AppSettings:VNPaySettings:TmnCode").Value!);
            pay.AddRequestData("vnp_Amount", ((int)request.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration.GetSection("AppSettings:VNPaySettings:CurrCode").Value!);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(HttpContext));
            pay.AddRequestData("vnp_Locale", _configuration.GetSection("AppSettings:VNPaySettings:Locale").Value!);
            pay.AddRequestData("vnp_OrderInfo", $"{request.Name} {request.OrderDescription} {request.Amount}");
            pay.AddRequestData("vnp_OrderType", request.OrderType!);
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_configuration.GetSection("AppSettings:VNPaySettings:BaseUrl").Value!, _configuration.GetSection("AppSettings:VNPaySettings:HashSecret").Value!);

            return Ok(paymentUrl);
        }

        //[HttpGet("PaymentExecute")]
        //public IActionResult PaymentExecute(IQueryCollection collections)
        //{
        //    var pay = new VnPayLibrary();
        //    var response = pay.GetFullResponseData(collections, _configuration.GetSection("AppSettings:VNPaySettings:HashSecret").Value!);

        //    return Ok(response);
        //}

        [HttpPost("PaymentExecute")]
        public IActionResult PaymentCallback(PaymentResultRequest request)
        {
            var pay = new VnPayLibrary();
            var response = pay.GetFullResponseData(request, _configuration.GetSection("AppSettings:VNPaySettings:HashSecret").Value!);

            return Ok(response);
        }
    }
}
