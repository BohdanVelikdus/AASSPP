using AASSPP.Models;

namespace AASSPP.Interfaces
{
    public interface ICashinRepository
    {
        ICollection<Cashin> GetCashins();
        Cashin GetFirstCashinByCardId(int id); 
        ICollection<Cashin> GetCashinsByCardId(int id); 

        bool CreateCashin(int sum, int id);

        bool Save();
    }
}
