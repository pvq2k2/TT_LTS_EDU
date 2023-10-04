using QuanLyTrungTam_API.Helper;
using System;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.SlidesRequest;
using TT_LTS_EDU.Handle.Response;

namespace TT_LTS_EDU.Services.Interface
{
    public interface ISlidesService
    {
        public Task<PageResult<SlidesDTO>> GetAllSlides(Pagination pagination);
        public Task<ResponseObject<List<SlidesDTO>>> GetActiveSlides();
        public Task<ResponseObject<SlidesDTO>> GetSlidesByID(int slidesID);
        public Task<ResponseObject<SlidesDTO>> CreateSlides(CreateSlidesRequest request);
        public Task<ResponseObject<SlidesDTO>> UpdateSlides(int slidesID, UpdateSlidesRequest request);
        public Task<ResponseObject<string>> RemoveSlides(int slidesID);
    }
}
