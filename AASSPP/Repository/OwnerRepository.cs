using AASSPP.Data;
using AASSPP.Interfaces;
using AASSPP.Models;

namespace AASSPP.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.Where(o => o.Id == id).FirstOrDefault();
        }

        public ICollection<Owner> GetOwners() {
            return _context.Owners.OrderBy(p => p.Id).ToList();    
        }
    }
}
