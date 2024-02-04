namespace AASSPP.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
        public string Sex { get; set; }
        public DateTime Born { get; set; }
        public string Email { get; set; }
        public string Home { get; set; }
        public string Phone { get; set; } 
        public int CountryId {  get; set; }
        public Country Country { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
