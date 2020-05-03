using System.Threading.Tasks;
using domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IRepository _repo;

        public ItemController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllItemAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpGet("{itemId}")]
        public async Task<ActionResult> Get(int itemId)
        {
            try
            {
                var itemById = await _repo.GetItemByIdAsync(itemId);
                var itemByBusinessCode = await _repo.GetItemByBusinessCodeAsync(itemId);
                if(itemById == null)
                {
                    return Ok(itemByBusinessCode);
                }
                else
                {
                    return Ok(itemById);
                }
                
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpGet("getByLocal/{local}")]
        public async Task<ActionResult> Get(string local)
        {
            try
            {
                var results = await _repo.GetAllItemByLocalAsync(local);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpGet("getByTipoItem/{tipoItem}")]
        public async Task<ActionResult> Get(TipoItem tipoItem)
        {
            try
            {
                var results = await _repo.GetAllItemByTypeAsync(tipoItem);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(Item model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/item/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpPut("{ItemId}")]
        public async Task<ActionResult> Put(int itemId, Item model)
        {
            try
            {
                var item = await _repo.GetItemByIdAsync(itemId);
                if(item == null) return NotFound();
                
                _repo.Update(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/item/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpDelete("{ItemId}")]
        public async Task<ActionResult> Delete(int itemId)
        {
            try
            {
                var item = await _repo.GetItemByIdAsync(itemId);
                if(item == null) return NotFound();
                
                _repo.Delete(item);
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