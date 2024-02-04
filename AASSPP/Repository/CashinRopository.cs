using AASSPP.Data;
using AASSPP.Interfaces;
using AASSPP.Models;

namespace AASSPP.Repository
{
    public class CashinRopository : ICashinRepository
    {

        private readonly DataContext _context;
        public CashinRopository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Cashin> GetCashinsByCardId(int id)
        {
            return _context.Cashins.Where(i => i.CardId == id).ToList();
        }

        public ICollection<Cashin> GetCashins()
        {
            return _context.Cashins.OrderBy(i => i.Id).ToList();
        }

        public Cashin GetFirstCashinByCardId(int id)
        {
            return _context.Cashins.Where(i => i.CardId == id).FirstOrDefault();
        }

        public bool CreateCashin(int sum, int id)
        {
            var cashin = new Cashin
            {
                Sum = sum,
                CardId = id
            };
            _context.Add(cashin);
            return Save();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
