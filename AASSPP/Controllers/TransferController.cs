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
    public class TransferController:Controller
    {
        private readonly ITransferRepository _tranferRepository;
        private readonly IMapper _mapper;
        public TransferController(ITransferRepository transferRepository, IMapper mapper)
        {
            _tranferRepository = transferRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAllTransfer")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Transfer>))]
        public IActionResult GetAllTransfers()
        {
            var transfers = _mapper.Map<List<TransferDto>>(_tranferRepository.GetTransfers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(transfers);
        }

        [HttpGet("GetTransfersById")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Transfer>))]
        public IActionResult GetTransfersById(int id)
        {
            var transfers = _mapper.Map<List<TransferDto>>(_tranferRepository.GetMyTransfersById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(transfers);
        }

    }
}
