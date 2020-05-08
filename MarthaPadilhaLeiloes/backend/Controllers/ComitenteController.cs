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
    public class ComitenteController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ComitenteController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var comitentes = await _repo.GetAllComitenteAsync();
                var results = _mapper.Map<IEnumerable<ComitenteDTO>>(comitentes);
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
                var comitente = await _repo.GetComitenteByIdAsync(ComitenteId);
                var results = _mapper.Map<ComitenteDTO>(comitente);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(ComitenteDTO model)
        {
            try
            {
                var comitente = _mapper.Map<Comitente>(model);
                _repo.Add(comitente);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/comitente/{comitente.Id}", _mapper.Map<ComitenteDTO>(comitente));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpPut("{ComitenteId}")]
        public async Task<ActionResult> Put(int comitenteId, ComitenteDTO model)
        {
            try
            {
                var comitente = await _repo.GetComitenteByIdAsync(comitenteId);
                if(comitente == null) return NotFound();

                _mapper.Map(model, comitente);

                _repo.Update(comitente);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/comitente/{comitente.Id}", _mapper.Map<ComitenteDTO>(comitente));
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