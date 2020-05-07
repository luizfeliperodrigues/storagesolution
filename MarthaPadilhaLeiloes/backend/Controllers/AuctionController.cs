using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DTOs;
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
        private readonly IMapper _mapper;

        public AuctionController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var auctions = await _repo.GetAllAuctionByAsync();

                var results = _mapper.Map<IEnumerable<AuctionDTO>>(auctions);
                
                // return Ok(auctions);
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

                var result = _mapper.Map<AuctionDTO>(auctionById);

                return Ok(result);
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
                var auctions = await _repo.GetAllAuctionByNegotiationAsync(negotiation);

                var results = _mapper.Map<IEnumerable<AuctionDTO>>(auctions);
                
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
                var auctions = await _repo.GetAllAuctionByDateAsync(initialDate, null);

                if(finalDate != null)
                {
                    auctions = await _repo.GetAllAuctionByDateAsync(initialDate, finalDate);
                }

                var results = _mapper.Map<IEnumerable<AuctionDTO>>(auctions);
                
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(AuctionDTO model)
        {
            try
            {
                var auction = _mapper.Map<Auction>(model);

                _repo.Add(auction);

                if(await _repo.SaveChangesAsync()){
                    return Created($"api/auction/{auction.Id}", _mapper.Map<AuctionDTO>(auction));
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpPut("{auctionId}")]
        public async Task<ActionResult> Put(int auctionId, AuctionDTO model)
        {
            try
            {
                var auction = await _repo.GetAuctionByIdAsync(auctionId);
                if(auction == null) return NotFound();

                _mapper.Map(auction, model);
                
                _repo.Update(auction);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/auction/{auction.Id}", _mapper.Map<AuctionDTO>(auction));
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