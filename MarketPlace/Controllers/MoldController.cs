using MarketPlace.Entityes;
using MarketPlace.Generic;
using MarketPlace.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MoldController<TEntity, TRepository> : ControllerBase where TEntity : class, IEntity where TRepository : IGenericRepository<TEntity>
    {
        private readonly IGenericRepository<TEntity> _genericRepasitory;
        private FoodMarketRepository foodMarketRpository;

        public MoldController(IGenericRepository<TEntity> genericRepository) => _genericRepasitory = genericRepository;

        protected MoldController(FoodMarketRepository foodMarketRpository)
        {
            this.foodMarketRpository = foodMarketRpository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get() => await _genericRepasitory.GetAllAsync();
        [HttpGet("id")]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> Get(int id)
        {
            var get = await _genericRepasitory.GetById(id);
            if (get == null) return NotFound();
            return Ok(get);
        }
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromQuery] int id, TEntity entity)
        {
            if (id != entity.Id)
                return BadRequest();
            await _genericRepasitory.Update(id, entity);
            return NoContent();
        }
        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Post([FromQuery]TEntity entity)
        {
            await _genericRepasitory.Create(entity);
            return Created("", entity);
        }
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TEntity>> Delete([FromQuery] int id)
        {
            var movie = await _genericRepasitory.Delete(id);
            return movie;
        }






    }
}
