using AASSPP.Data;
using AASSPP.Dto;
using AASSPP.Interfaces;
using AASSPP.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AASSPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryControllers:Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryControllers(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet("GetCountries")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries= _mapper.Map<List<CountryDto>>(_countryRepository.GetCountriesAll());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(countries);
        }

        [HttpGet("GetCountryExist")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult GetCountries(string name)
        {
            var exist = _countryRepository.CountryExistName(name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(exist);
        }

        [HttpGet("GetCountryById")]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryById(int id)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(country);
        }


    }
}
