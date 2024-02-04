using AASSPP.Models;
using Microsoft.Identity.Client;

namespace AASSPP.Interfaces
{
    public interface ICountryRepository
    {
        public ICollection<Country> GetCountriesAll();
        public Country GetCountryById(int id);
        public bool CountryExistName(string name);
    }
}
