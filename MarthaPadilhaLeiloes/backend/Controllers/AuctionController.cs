using System;
using System.Threading.Tasks;
using domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IRepository _repo;

        public AuctionController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllAuctionByAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

         [HttpGet("{auctionId}")]
        public async Task<ActionResult> Get(int auctionId)
        {
            try
            {
                var auctionById = await _repo.GetAuctionByIdAsync(auctionId);
                var auctionByBusinessCode = await _repo.GetAuctionByBusinessCodeAsync(auctionId);
                if(auctionById == null)
                {
                    return Ok(auctionByBusinessCode);
                }
                else
                {
                    return Ok(auctionById);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("getByNegotiation/{negotiation}")]
        public async Task<ActionResult> Get(Negotiation negotiation)
        {
            try
            {
                var results = await _repo.GetAllAuctionByNegotiationAsync(negotiation);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("getByDate/{initialDate}")]
        public async Task<ActionResult> Get(DateTime initialDate, DateTime? finalDate)
        {
            try
            {
                var results = await _repo.GetAllAuctionByDateAsync(initialDate, null);

                if(finalDate != null)
                {
                    results = await _repo.GetAllAuctionByDateAsync(initialDate, finalDate);
                }
                
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(Auction model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/auction/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpPut("{auctionId}")]
        public async Task<ActionResult> Put(int auctionId, Auction model)
        {
            try
            {
                var auction = await _repo.GetAuctionByIdAsync(auctionId);
                if(auction == null) return NotFound();
                
                _repo.Update(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/auction/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpDelete("{auctionId}")]
        public async Task<ActionResult> Delete(int auctionId)
        {
            try
            {
                var auction = await _repo.GetAuctionByIdAsync(auctionId);
                if(auction == null) return NotFound();
                
                _repo.Delete(auction);
                if(await _repo.SaveChangesAsync()){
                    return Ok();
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }
    }
}