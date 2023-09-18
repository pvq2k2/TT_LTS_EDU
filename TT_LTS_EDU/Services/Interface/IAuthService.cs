using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.AuthRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Services.Interface
{
    public interface IAuthService
    {
        public Task<ResponseObject<AccountDTO>> Register(RegisterRequest request);
        public Task<ResponseObject<TokenDTO>> Login(LoginRequest request);
        public ResponseObject<TokenDTO> ReNewToken(string refreshToken);
        public Task<ResponseObject<string>> VerifyEmail(string token);
        public Task<ResponseObject<string>> ForgotPassword(string email);
        public Task<ResponseObject<string>> ResetPassword(ResetPasswordRequest request);
        public Task<ResponseObject<string>> ChangePassword(ChangePasswordRequest request);
    }
}
