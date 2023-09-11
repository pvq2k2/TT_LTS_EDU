namespace TT_LTS_EDU.Entities
{
    public class Decentralization : BaseEntity
    {
        public string AuthorityName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Account>? ListAccount { get; set; }
    }
}
