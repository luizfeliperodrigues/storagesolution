using System.Collections.Generic;
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
    public class TipoItemController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public TipoItemController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var tipoItem = await _repo.GetAllTipoItemAsync();
                var results = _mapper.Map<IEnumerable<TipoItemDTO>>(tipoItem);
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
                var tipoItem = await _repo.GetTipoItemByIdAsync(TipoItemId);
                var results = _mapper.Map<TipoItemDTO>(tipoItem);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoItemDTO model)
        {
            try
            {
                var tipoItem = _mapper.Map<TipoItem>(model);
                _repo.Add(tipoItem);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/tipoitem/{tipoItem.Id}", _mapper.Map<TipoItemDTO>(tipoItem));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpPut("{TipoItemId}")]
        public async Task<ActionResult> Put(int tipoItemId, TipoItemDTO model)
        {
            try
            {
                var tipoItem = await _repo.GetTipoItemByIdAsync(tipoItemId);
                if(tipoItem == null) return NotFound();

                _mapper.Map(tipoItem, model);
                
                _repo.Update(tipoItem);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/tipoitem/{tipoItem.Id}", _mapper.Map<TipoItemDTO>(tipoItem));
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