using AASSPP.Models;

namespace AASSPP.Interfaces
{
    public interface ICashoutRepository
    {
        ICollection<Cashout> GetCashouts();
        ICollection<Cashout> GetCashoutByOwnerId(int id);
        Cashout GetCashoutByOwnerIdFirst(int id);
    }
}
