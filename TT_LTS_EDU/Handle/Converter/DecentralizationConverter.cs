using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class DecentralizationConverter
    {
        public DecentralizationDTO EntityDecentralizationToDTO(Decentralization decentralization)
        {
            return new DecentralizationDTO { 
                AuthorityName = decentralization.AuthorityName,
            };
        }
    }
}
