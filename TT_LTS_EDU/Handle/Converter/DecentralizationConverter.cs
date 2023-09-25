using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class DecentralizationConverter
    {
        public DecentralizationDTO EntityDecentralizationToDTO(Decentralization decentralization)
        {
            return new DecentralizationDTO { 
                DecentralizationID = decentralization.ID,
                AuthorityName = decentralization.AuthorityName,
            };
        }

        public List<DecentralizationDTO> ListEntityDecentralizationToDTO(List<Decentralization> listDecentralization)
        {
            var listDecentralizationDTO = new List<DecentralizationDTO>();
            foreach (var item in listDecentralization)
            {
                listDecentralizationDTO.Add(EntityDecentralizationToDTO(item));
            }

            return listDecentralizationDTO;
        }
    }
}
