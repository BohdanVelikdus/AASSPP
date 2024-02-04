namespace AASSPP.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public DateTime Born { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
    }

    public class SensitiveOwnerDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
        public string Home { get; set; }
        public string Phone { get; set; }
    }
}
