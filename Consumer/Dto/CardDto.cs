namespace AASSPP.Dto
{
    public class CardDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
    }

    public class CardSensitive {
        public string Number { get; set; }
        public string Name { get; set; }
        public int PIN { get; set; }
        public int CVV { get; set; }
        public DateTime ExpireDate { get; set; }
    }


}
