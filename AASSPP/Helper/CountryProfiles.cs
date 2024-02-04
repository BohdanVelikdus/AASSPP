using AASSPP.Dto;
using AutoMapper;
using AASSPP.Models;

namespace AASSPP.Helper
{
    public class CountryProfiles:Profile
    {
        public CountryProfiles()
        {
            CreateMap<Country,CountryDto>();
        }
       
    }
}
