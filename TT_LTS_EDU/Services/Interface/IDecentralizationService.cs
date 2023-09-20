using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.DecentralizationRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Services.Interface
{
    public interface IDecentralizationService
    {
        public Task<PageResult<DecentralizationDTO>> GetAllDecentralization(Pagination pagination);
        public Task<ResponseObject<DecentralizationDTO>> GetDecentralizationByID(int decentralizationID);
        public Task<ResponseObject<DecentralizationDTO>> CreateDecentralization(CreateDecentralizationRequest request);
        public Task<ResponseObject<DecentralizationDTO>> UpdateDecentralization(int decentralizationID, UpdateDecentralizationRequest request);
        public Task<ResponseObject<string>> RemoveDecentralization(int decentralizationID);
    }
}
