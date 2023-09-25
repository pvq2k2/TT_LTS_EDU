using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class AuthConverter
    {
        private readonly UserConverter _userConverter;
        private readonly DecentralizationConverter _decentralizationConverter;
        public AuthConverter() { 
            _userConverter = new UserConverter();
            _decentralizationConverter = new DecentralizationConverter();
        }
        public AccountDTO EntityAccountToDTO(Account account)
        {
            return new AccountDTO {
                AccountID = account.ID,
                UserName = account.UserName,
                UserDTO = _userConverter.EntityUserToDTO(account.User!),
                DecentralizationDTO = _decentralizationConverter.EntityDecentralizationToDTO(account.Decentralization!)
            };
        }

        public List<AccountDTO> ListEntityAccountToDTO(List<Account> listAccount)
        {
            var listAccountDTO = new List<AccountDTO>();
            foreach (var account in listAccount)
            {
                listAccountDTO.Add(EntityAccountToDTO(account));
            }

            return listAccountDTO;
        }
    }
}
