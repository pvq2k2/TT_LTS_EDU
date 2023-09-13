using TT_LTS_EDU.Entities;

namespace TT_LTS_EDU.Handle.DTOs
{
    public class AccountDTO
    {
        public string? UserName { get; set; }
        public DecentralizationDTO? DecentralizationDTO { set; get; }
        public UserDTO? UserDTO { get; set; }
    }
}
