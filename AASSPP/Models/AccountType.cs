namespace AASSPP.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        public string AccountClass { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
