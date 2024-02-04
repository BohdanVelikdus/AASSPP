using AASSPP.Models;

namespace AASSPP.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwnerById(int id);
    }
}
