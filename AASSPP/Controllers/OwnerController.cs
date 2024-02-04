using AASSPP.Dto;
using AASSPP.Interfaces;
using AASSPP.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AASSPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [HttpGet("GetOwners")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult getOwners() {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok(owners);
        }

        [HttpGet("GetOwnerById")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwnerById(int id)
        {
            var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwnerById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owner);
        }


        [HttpGet("GetOwnerByIdSensitive")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwnerByIdSensitive(int id)
        {
            var owner = _mapper.Map<SensitiveOwnerDto>(_ownerRepository.GetOwnerById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owner);
        }
    }
}
