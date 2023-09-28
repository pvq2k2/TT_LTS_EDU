using Azure;
using CloudinaryDotNet;
using Org.BouncyCastle.Asn1.X9;
using System;
using TT_LTS_EDU.Handle.Request.VNPayRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Helpers
{
    public class VNPayHelper
    {
        private readonly IConfiguration _configuration;

        public VNPayHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public void CreatePaymentUrl(CreateVNPayRequest request, HttpContext context)
        //{
        //    try
        //    {
        //        var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration.GetSection("AppSettings:VNPaySettings:TimeZoneId").Value!);
        //        var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
        //        var tick = DateTime.Now.Ticks.ToString();
        //        var pay = new VnPayLibrary();
        //        var urlCallBack = _configuration.GetSection("AppSettings:VNPaySettings:ReturnUrl").Value!;

        //        pay.AddRequestData("vnp_Version", _configuration.GetSection("AppSettings:VNPaySettings:Version").Value!);
        //        pay.AddRequestData("vnp_Command", _configuration.GetSection("AppSettings:VNPaySettings:Command").Value!);
        //        pay.AddRequestData("vnp_TmnCode", _configuration.GetSection("AppSettings:VNPaySettings:TmnCode").Value!);
        //        pay.AddRequestData("vnp_Amount", ((int)request.Amount * 100).ToString());
        //        pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
        //        pay.AddRequestData("vnp_CurrCode", _configuration.GetSection("AppSettings:VNPaySettings:CurrCode").Value!);
        //        pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
        //        pay.AddRequestData("vnp_Locale", _configuration.GetSection("AppSettings:VNPaySettings:Locale").Value!);
        //        pay.AddRequestData("vnp_OrderInfo", $"{request.Name} {request.OrderDescription} {request.Amount}");
        //        pay.AddRequestData("vnp_OrderType", request.OrderType!);
        //        pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
        //        pay.AddRequestData("vnp_TxnRef", tick);

        //        var paymentUrl =
        //            pay.CreateRequestUrl(_configuration.GetSection("AppSettings:VNPaySettings:BaseUrl").Value!, _configuration.GetSection("AppSettings:VNPaySettings:HashSecret").Value!);

        //        context.Response.Redirect(paymentUrl);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public ResponsePayment PaymentExecute(IQueryCollection collections)
        //{
        //    try
        //    {
        //        var pay = new VnPayLibrary();
        //        var response = pay.GetFullResponseData(collections, _configuration.GetSection("AppSettings:VNPaySettings:HashSecret").Value!);

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
