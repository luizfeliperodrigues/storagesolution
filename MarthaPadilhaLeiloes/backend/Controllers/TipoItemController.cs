using System.Threading.Tasks;
using domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoItemController : ControllerBase
    {
        private readonly IRepository _repo;

        public TipoItemController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllTipoItemAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpGet("{TipoItemId}")]
        public async Task<ActionResult> Get(int TipoItemId)
        {
            try
            {
                var results = await _repo.GetTipoItemByIdAsync(TipoItemId);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoItem model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/tipoitem/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpPut]
        public async Task<ActionResult> Put(int tipoItemId, Comitente model)
        {
            try
            {
                var tipoItem = await _repo.GetTipoItemByIdAsync(tipoItemId);
                if(tipoItem == null) return NotFound();

                _repo.Update(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/tipoitem/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpDelete("{TipoItemId}")]
        public async Task<ActionResult> Delete(int tipoItemId)
        {
            try
            {
                var tipoItem = await _repo.GetTipoItemByIdAsync(tipoItemId);
                if(tipoItem == null) return NotFound();
                
                _repo.Delete(tipoItem);
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