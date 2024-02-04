using AASSPP.Data;
using AASSPP.Interfaces;
using AASSPP.Models;

namespace AASSPP.Repository
{
    public class CashoutRepository : ICashoutRepository
    {
        private readonly DataContext _context;
        public CashoutRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Cashout> GetCashoutByOwnerId(int id)
        {
            return _context.Cashouts.Where(i => i.CardId == id).ToList();
        }

        public Cashout GetCashoutByOwnerIdFirst(int id)
        {
            return _context.Cashouts.Where(i => i.CardId == id).FirstOrDefault();
        }

        public ICollection<Cashout> GetCashouts()
        {
            return _context.Cashouts.OrderBy(i => i.Id).ToList();
        }
    }
}
