namespace AASSPP.Models
{
    public class Cashin
    {
        public int Id { get; set; }
        public double Sum {  get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}