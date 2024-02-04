using AASSPP.Dto;
using AASSPP.Interfaces;
using AASSPP.Models;
using AASSPP.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AASSPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashinController:Controller
    {
        private readonly ICashinRepository _cashinRepository;
        private readonly IMapper _mapper;

        public CashinController(ICashinRepository cashinRepository, IMapper mapper)
        {
            _cashinRepository = cashinRepository;
            _mapper = mapper;
        }

        [HttpGet("GetCashins")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cashin>))]
        public IActionResult GetCashins()
        {
            var cashins = _mapper.Map<List<CashinDto>>(_cashinRepository.GetCashins());
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(cashins);
        }

        [HttpGet("GetCashinByCardIdFirst")]
        [ProducesResponseType(200, Type = typeof(Cashin))]
        public IActionResult GetCashinsByCardIdFirst(int id)
        {
            var cashin = _mapper.Map<CashinDto>(_cashinRepository.GetFirstCashinByCardId(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(cashin);
        }

        [HttpGet("GetCashinByCardId")]
        [ProducesResponseType(200, Type = typeof(List<Cashin>))]
        public IActionResult GetCashinsByCardId(int id)
        {
            var cashins = _mapper.Map<List<CashinDto>>(_cashinRepository.GetCashinsByCardId(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(cashins);
        }

        //[HttpPost]
        //[ProducesResponseType(204)]
    }
}
