namespace AASSPP.Dto
{
    public class TransferDto
    {
        public int Id { get; set; }
        public string Sender { get; set; } // imie nazwisko
        public string Receiver { get; set; } // imie nazwisko
        public int CardId { get; set; }
        public int Sum { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}
