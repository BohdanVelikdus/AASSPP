using AASSPP.Dto;
using AASSPP.Models;
using AutoMapper;

namespace AASSPP.Helper
{
    public class OwnerProfiles:Profile
    {
        public OwnerProfiles()
        {
            CreateMap<Owner, OwnerDto>(); 
            CreateMap<Owner, SensitiveOwnerDto>();
        }

    }
}
