using TT_LTS_EDU.Entities;

namespace TT_LTS_EDU.Handle.DTOs
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public string? UserName { get; set; }
        public DecentralizationDTO? DecentralizationDTO { set; get; }
        public UserDTO? UserDTO { get; set; }
    }
}
