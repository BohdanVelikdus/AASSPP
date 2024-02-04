using AASSPP.Dto;
using AASSPP.Models;
using AutoMapper;

namespace AASSPP.Helper
{
    public class CardProfiles: Profile
    {
        public CardProfiles()
        {
            CreateMap<Card, CardDto>();
            CreateMap<Card, CardSensitive>();
        }
    }
}
