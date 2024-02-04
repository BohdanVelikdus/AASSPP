using AASSPP.Models;

namespace AASSPP.Interfaces
{
    public interface ICardRepository
    {
        ICollection<Card> GetCards(); // used
        Card GetCardById(int id); // used
        Card GetCardByNumber(string number); //used
        Card GetCardByOwnerIdFirst(int ownerId); //used
        ICollection<Card> GetCardsByOwnerId(int ownerId);
        bool CardExistNumber(string number);
        bool CardExistId(int Id);
        public decimal GetCardMoney(string number);

        Card LogIn(string number, int PIN);
    }
}
