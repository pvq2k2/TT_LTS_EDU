using AutoMapper;
using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<Account, AccountDTO>();
        }
    }
}
