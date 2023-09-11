using System;

namespace TT_LTS_EDU.Entities
{
    public class Account : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Status { set; get; }
        public int DecentralizationID { set; get; }
        public string ResetPasswordToken { set; get; } = string.Empty;
        public DateTime ResetPasswordTokenExpiry { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        public Decentralization? Decentralization { set; get; }
        public RefreshToken? RefreshToken { set; get; }
        public User? User { get; set; }
    }
}
