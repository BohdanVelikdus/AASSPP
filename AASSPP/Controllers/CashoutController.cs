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
    public class CashoutController:Controller
    {
        private readonly ICashoutRepository _cashoutrepository;
        private readonly IMapper _mapper;

        public CashoutController(ICashoutRepository cashoutRepository, IMapper mapper)
        {
            _cashoutrepository = cashoutRepository;
            _mapper = mapper;
        }

        [HttpGet("GetCashouts")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cashout>))]
        public IActionResult GetCashouts()
        {
            var cashouts = _mapper.Map<List<CashoutDto>>(_cashoutrepository.GetCashouts());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(cashouts);
        }

        [HttpGet("GetCashoutByCardIdFirst")]
        [ProducesResponseType(200, Type = typeof(Cashout))]
        public IActionResult GetCashoutsByCardIdFirst(int id)
        {
            var cashout = _mapper.Map<CashoutDto>(_cashoutrepository.GetCashoutByOwnerIdFirst(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(cashout);
        }

        [HttpGet("GetCashoutsByCardId")]
        [ProducesResponseType(200, Type = typeof(List<Cashout>))]
        public IActionResult GetCashoutsByCardId(int id)
        {
            var cashouts= _mapper.Map<List<CashoutDto>>(_cashoutrepository.GetCashoutByOwnerId(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(cashouts);
        }

    }
}
