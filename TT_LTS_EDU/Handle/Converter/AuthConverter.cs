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
                UserName = account.UserName,
                UserDTO = _userConverter.EntityUserToDTO(account.User!),
                DecentralizationDTO = _decentralizationConverter.EntityDecentralizationToDTO(account.Decentralization!)
            };
        }
    }
}
