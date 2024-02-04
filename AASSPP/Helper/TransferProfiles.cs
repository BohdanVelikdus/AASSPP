using AASSPP.Dto;
using AASSPP.Models;
using AutoMapper;

namespace AASSPP.Helper
{
    public class TransferProfiles:Profile
    {
        public TransferProfiles()
        { 
            CreateMap<Transfer, TransferDto>();
        }
    }
}
