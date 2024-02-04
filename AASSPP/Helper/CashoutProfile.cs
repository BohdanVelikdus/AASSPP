using AASSPP.Dto;
using AASSPP.Models;
using AutoMapper;

namespace AASSPP.Helper
{
    public class CashoutProfile:Profile
    {
        public CashoutProfile()
        {
            CreateMap<Cashout, CashoutDto>();
        }
    }
}
