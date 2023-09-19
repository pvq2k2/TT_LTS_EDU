using QuanLyTrungTam_API.Helper;
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
        public Task<PageResult<AccountDTO>> GetAllAccount(Pagination pagination);
        public Task<ResponseObject<AccountDTO>> GetAccountByID(int accountID);
        public Task<ResponseObject<AccountDTO>> ChangeInformation(ChangeInformationRequest request);
        public Task<ResponseObject<string>> RemoveAccount(int accountID);
        public Task<ResponseObject<string>> RecoverAccount(int accountID);
    }
}
