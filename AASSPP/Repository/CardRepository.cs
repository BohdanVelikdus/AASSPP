using AASSPP.Data;
using AASSPP.Interfaces;
using AASSPP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AASSPP.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _context;
        public CardRepository(DataContext context)
        {
            _context = context;
        }
        public bool CardExistId(int Id)
        {
            return _context.Cards.Any(p => p.Id == Id);
        }

        public bool CardExistNumber(string number)
        {
            return _context.Cards.Any(p => p.Number == number);
        }

        public Card GetCardById(int id)
        {
            return _context.Cards.Where(p => p.Id == id).FirstOrDefault();
        }

        public Card GetCardByNumber(string number)
        {
            return _context.Cards.Where(p => p.Number == number).FirstOrDefault();
        }

        public Card GetCardByOwnerIdFirst(int ownerId)
        {
            return _context.Cards.Where(p => p.OwnerId == ownerId).FirstOrDefault();
        }

        public decimal GetCardMoney(string number)
        {
            var money = _context.Cards.Where(p => p.Number == number).FirstOrDefault();

            if (money == null)
                return 0;
            return (decimal)money.Money;
        }

        public ICollection<Card> GetCards()
        {
            return _context.Cards.OrderBy(k => k.Id).ToList();
        }

        public ICollection<Card> GetCardsByOwnerId(int ownerId)
        {
            return _context.Cards.Where(p => p.OwnerId == ownerId).ToList();
        }

        public Card LogIn(string number, int PIN)
        {
            string str = number.Substring(0, number.Length - 2);
            var query = _context.Cards.Where(i => i.Number == str && i.PIN == PIN).ToString();
            Debug.WriteLine(query);
            Card crd = _context.Cards.Where(i => i.Number == str && i.PIN == PIN).FirstOrDefault();
            Debug.WriteLine("\n\n" + crd);
            if (crd != null)
                return null;
            return crd;
        }
    }
}
