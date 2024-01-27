namespace AASSPP.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name{ get; set; }
        public int PIN { get; set; }
        public int CVV { get; set; }
        public DateTime ExpireDate { get; set; }
        public Account Account { get; set; }
        public ICollection<Cashin> Cashins { get; set; }
        public ICollection<Cashout> Cashouts { get; set; }
    }
}
