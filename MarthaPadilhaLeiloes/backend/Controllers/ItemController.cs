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
    public class ItemController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ItemController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var items = await _repo.GetAllItemAsync();
                var results = _mapper.Map<IEnumerable<ItemDTO>>(items);
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
                var results = _mapper.Map<ItemDTO>(itemById);
                return Ok(results);
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
                var itemsByLocal = await _repo.GetAllItemByLocalAsync(local);
                var results = _mapper.Map<IEnumerable<ItemDTO>>(itemsByLocal);
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
                var itemsByTipo = await _repo.GetAllItemByTypeAsync(tipoItem);
                var results = _mapper.Map<IEnumerable<ItemDTO>>(itemsByTipo);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(ItemDTO model)
        {
            try
            {
                var item = _mapper.Map<Item>(model);
                _repo.Add(item);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/item/{item.Id}", _mapper.Map<ItemDTO>(item));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpPut("{ItemId}")]
        public async Task<ActionResult> Put(int itemId, ItemDTO model)
        {
            try
            {
                var item = await _repo.GetItemByIdAsync(itemId);
                if(item == null) return NotFound();

                _mapper.Map(item, model);
                
                _repo.Update(item);
                if(await _repo.SaveChangesAsync()){
                    return Created($"api/item/{item.Id}", _mapper.Map<ItemDTO>(item));
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