using AASSPP.Data;
using AASSPP.Interfaces;
using AASSPP.Models;

namespace AASSPP.Repository
{
    public class TransferRepository:ITransferRepository
    {

        private readonly DataContext _context;
        public TransferRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Transfer> GetMyTransfersById(int id)
        {
            return _context.Transfers.Where(i => i.CardId == id).ToList();
        }

        public ICollection<Transfer> GetTransfers()
        {
            return _context.Transfers.OrderBy(i => i.Id).ToList();
        }
    }
}
