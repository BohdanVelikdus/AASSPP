using AASSPP.Dto;
using AASSPP.Models;
using AutoMapper;

namespace AASSPP.Helper
{
    public class CashinProfiles:Profile
    {
        public CashinProfiles()
        {
            CreateMap<Cashin, CashinDto>();
        }
    }
}
