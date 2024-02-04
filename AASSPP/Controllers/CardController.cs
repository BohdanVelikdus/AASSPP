using AASSPP.Dto;
using AASSPP.Interfaces;
using AASSPP.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AASSPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : Controller
    { 
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        public CardController(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllCards")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        public IActionResult getCards()
        {
            var cards = _mapper.Map<List<CardDto>>(_cardRepository.GetCards());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(cards);
        }

        [HttpGet("GetCarExistNumber")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CardExistNumber(string number)
        {
            return Ok(_cardRepository.CardExistNumber(number));
        }

        [HttpGet("GetCarExistId")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CardExistNumber(int id)
        {
            return Ok(_cardRepository.CardExistId(id));
        }

        [HttpGet("GetCardById")]
        [ProducesResponseType(200, Type = typeof(Card))]
        [ProducesResponseType(400)]
        public IActionResult GetCardById(int id)
        {
            if (!_cardRepository.CardExistId(id))
                return NotFound();
            var card = _cardRepository.GetCardById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(card);
        }

        [HttpGet("GetCardByNumber")]
        [ProducesResponseType(200, Type = typeof(Card))]
        [ProducesResponseType(400)]
        public IActionResult GetCardByNumber(string number)
        {
            if (!_cardRepository.CardExistNumber(number))
                return NotFound();
            var card = _cardRepository.GetCardByNumber(number);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(card);
        }

        [HttpGet("GetCardMoneyNumber")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetCardMoney(string number)
        {
            if (!_cardRepository.CardExistNumber(number))
                return NotFound();
            var money = _cardRepository.GetCardMoney(number);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(money);
        }

        [HttpGet("GetCardSensitive")]
        [ProducesResponseType(200, Type = typeof(Card))]
        [ProducesResponseType(400)]
        public IActionResult GetCardSensitive(string number)
        {
            if (!_cardRepository.CardExistNumber(number))
                return NotFound();
            var card = _cardRepository.GetCardByNumber(number);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var sens = _mapper.Map<CardSensitive>(card);
            return Ok(sens);
        }

        [HttpGet("GetCardByOwnerIdFirst")]
        [ProducesResponseType(200, Type = typeof(Card))]
        [ProducesResponseType(400)]
        public IActionResult GetCardByOwnerIdFirst(int id)
        {
            var card = _cardRepository.GetCardByOwnerIdFirst(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(card);
        }

        [HttpGet("GetCardByOwnerIdAll")]
        [ProducesResponseType(200, Type = typeof(ICollection<Card>))]
        [ProducesResponseType(400)]
        public IActionResult GetCardByOwnerIdAll(int id)
        {
            var cards = _cardRepository.GetCardsByOwnerId(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cards);
        }

        [HttpGet("LogIn")]
        [ProducesResponseType(200, Type = typeof(Card))]
        [ProducesResponseType(400)]
        public IActionResult LogIn(string number, int pin) {
            if (!_cardRepository.CardExistNumber(number))
                return NotFound();
            var card = _cardRepository.LogIn(number, pin);
            if (card == null)
                return NotFound();
           

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(card);
        }
    }
}
