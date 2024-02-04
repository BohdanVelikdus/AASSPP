using AASSPP.Data;
using AASSPP.Interfaces;
using AASSPP.Models;

namespace AASSPP.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExistName(string name)
        {
            return _context.Countries.Any(i => i.Name == name);
        }

        public ICollection<Country> GetCountriesAll()
        {
            return _context.Countries.OrderBy(k => k.Id).ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.Where(i => i.Id == id).FirstOrDefault();
        }
    }
}
