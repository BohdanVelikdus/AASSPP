using AASSPP.Models;

namespace AASSPP.Interfaces
{
    public interface ITransferRepository
    {
        ICollection<Transfer> GetTransfers();
        ICollection<Transfer> GetMyTransfersById(int id);
    }
}
