using System.Threading.Tasks;
using domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionItemController : ControllerBase
    {
        private readonly IRepository _repo;

        public AuctionItemController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllAuctionItemAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("{auctionItemId}")]
        public async Task<ActionResult> Get(int auctionItemId)
        {
            try
            {
                var auctionItemById = await _repo.GetAuctionItemByIdAsync(auctionItemId);
                
                return Ok(auctionItemById);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(AuctionItem model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/auctionitem/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpPut("{auctionItemId}")]
        public async Task<ActionResult> Put(int auctionItemId, AuctionItem model)
        {
            try
            {
                var auctionItem = await _repo.GetAuctionItemByIdAsync(auctionItemId);
                if(auctionItem == null) return NotFound();
                
                _repo.Update(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/auctionitem/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpDelete("{auctionItemId}")]
        public async Task<ActionResult> Delete(int auctionItemId)
        {
            try
            {
                var auctionItem = await _repo.GetAuctionItemByIdAsync(auctionItemId);
                if(auctionItem == null) return NotFound();
                
                _repo.Delete(auctionItem);
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