﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System.Security.Cryptography;
using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.AuthRequest;
using TT_LTS_EDU.Handle.Response;
using TT_LTS_EDU.Helpers;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Services.Implement
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly ResponseObject<AccountDTO> _responseAccount;
        private readonly IConfiguration _configuration;
        public AuthService(ResponseObject<AccountDTO> responseAccount, IConfiguration configuration)
        {
            _responseAccount = responseAccount;
            _configuration = configuration;
        }
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        private void SendEmail(EmailFormat request)
        {
            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("AppSettings:EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("AppSettings:EmailUserName").Value, _configuration.GetSection("AppSettings:EmailPassword").Value);
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse($"{_configuration.GetSection("AppSettings:ShopName").Value} <{_configuration.GetSection("AppSettings:EmailUserName").Value}>"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public async Task<ResponseObject<string>> VerifyEmail(string token)
        {
            var response = new ResponseObject<string>();
            var account = await _context.Account.FirstOrDefaultAsync(a => a.VerificationToken == token);
            if (account == null)
            {
                return response.ResponseError(StatusCodes.Status400BadRequest, "Mã xác thực không hợp lệ !", null);
            }
            account.Status = 1;
            account.VerifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return response.ResponseSuccess("Xác thực thành công !", null);
        }

        public async Task<ResponseObject<AccountDTO>> Register(RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName)
               || string.IsNullOrWhiteSpace(request.Password)
               || string.IsNullOrWhiteSpace(request.FullName)
               || string.IsNullOrWhiteSpace(request.Email)
               || string.IsNullOrWhiteSpace(request.Phone)
               || string.IsNullOrWhiteSpace(request.Address))
            {
                return _responseAccount.ResponseError(StatusCodes.Status404NotFound, "Bạn cần truyền vào đầy đủ thông tin", null);
            }
            if (InputHelper.CheckLengthOfCharacters(request.FullName))
            {
                return _responseAccount.ResponseError(StatusCodes.Status400BadRequest, "Họ và tên phải nhỏ hơn 20 ký tự !", null);
            }
            if (InputHelper.CheckWordCount(request.FullName))
            {
                return _responseAccount.ResponseError(StatusCodes.Status400BadRequest, "Họ và tên phải có trên 2 từ !", null);
            }
            if (!InputHelper.RegexUserName(request.UserName))
            {
                return _responseAccount.ResponseError(StatusCodes.Status400BadRequest, "Tên tài khoản không được chứa dấu cách và ký tự đặc biệt !", null);
            }
            if (!InputHelper.RegexPassword(request.Password))
            {
                return _responseAccount.ResponseError(StatusCodes.Status400BadRequest, "Mật khẩu phải có chữ hoa, chữ thường, chữ số và kí tự đặc biệt !", null);
            }
            if (!InputHelper.RegexEmail(request.Email))
            {
                return _responseAccount.ResponseError(StatusCodes.Status400BadRequest, "Không đúng định dạng email !", null);
            }
            if (!InputHelper.RegexPhoneNumber(request.Phone))
            {
                return _responseAccount.ResponseError(StatusCodes.Status400BadRequest, "Không đúng định dạng số điện thoại !", null);
            }
            if (await _context.Account.AnyAsync(x => x.UserName == request.UserName))
            {
                return _responseAccount.ResponseError(StatusCodes.Status400BadRequest, "Tên tài khoản đã được sử dụng !", null);
            }
            if (await _context.User.AnyAsync(x => x.Email == request.Email))
            {
                return _responseAccount.ResponseError(StatusCodes.Status400BadRequest, "Email đã được sử dụng !", null);
            }
            if (await _context.User.AnyAsync(x => x.Phone == request.Phone))
            {
                return _responseAccount.ResponseError(StatusCodes.Status400BadRequest, "Số điện thoại đã được sử dụng !", null);
            }
            var Account = new Account
            {
                UserName = request.UserName,
                Password = request.Password,
                Status = 0,
                DecentralizationID = 3,
                VerificationToken = CreateRandomToken()
            };

            await _context.Account.AddAsync(Account);
            await _context.SaveChangesAsync();

            var User = new User
            {
                FullName = InputHelper.NormalizeName(request.FullName),
                Phone = request.Phone,
                Email = request.Email,
                Address = request.Address,
                AccountID = Account.ID
            };
            await _context.User.AddAsync(User);
            await _context.SaveChangesAsync();

            var EmailContent = new EmailFormat
            {
                To = request.Email,
                Subject = "Xác thực tài khoản",
                Body = $"<p> Xin chào <b>{User.FullName}</b> vui lòng nhấp vào <a href=\"https://localhost:7299/api/Auth/Verify/{Account.VerificationToken}\"> Xác thực </a> để kích hoạt tài khoản ! </p>"
            };
            SendEmail(EmailContent);
            var currentAccount = await _context.Account
                .Include(x => x.User)
                .Include(x => x.Decentralization)
                .FirstOrDefaultAsync(x => x.ID == Account.ID);
            return _responseAccount.ResponseSuccess("Tạo tài khoản thành công !", _authConverter.EntityAccountToDTO(currentAccount));
        }
    }
}
