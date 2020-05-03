using System.Threading.Tasks;
using domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComitenteController : ControllerBase
    {
        private readonly IRepository _repo;

        public ComitenteController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllComitenteAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpGet("{ComitenteId}")]
        public async Task<ActionResult> Get(int ComitenteId)
        {
            try
            {
                var results = await _repo.GetComitenteByIdAsync(ComitenteId);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(Comitente model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/comitente/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpPut("{ComitenteId}")]
        public async Task<ActionResult> Put(int comitenteId, Comitente model)
        {
            try
            {
                var comitente = await _repo.GetComitenteByIdAsync(comitenteId);
                if(comitente == null) return NotFound();

                _repo.Update(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/comitente/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpDelete("{ComitenteId}")]
        public async Task<ActionResult> Delete(int comitenteId)
        {
            try
            {
                var comitente = await _repo.GetComitenteByIdAsync(comitenteId);
                if(comitente == null) return NotFound();
                
                _repo.Delete(comitente);
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