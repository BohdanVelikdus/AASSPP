namespace AASSPP.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int PIN { get; set; }
        public string Number {  get; set; }
        public AccountType Type { get; set; }
        public double Money { get; set; }
        public Owner Owner { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Transfer> Transfers { get; set; }
    }
}
