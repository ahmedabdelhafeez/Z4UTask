using Microsoft.AspNetCore.Mvc;

namespace FizooHelper.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract  class BaseAPI: ControllerBase
    {

    }


    public class BaseAPIController<TAdd, TGet, TGetAll, TUpdate, TDelete> : BaseAPI
    {
        private readonly IBaseInterface<TAdd, TGet, TGetAll, TUpdate, TDelete> baseService;
        public BaseAPIController(IBaseInterface<TAdd, TGet, TGetAll, TUpdate, TDelete> baseService)
        {
            this.baseService = baseService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await baseService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await baseService.Get(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(TAdd dto)
        {
            return Ok(await baseService.Add(dto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TUpdate dto)
        {
            return Ok(await baseService.Update(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await baseService.Delete(id));
        }
    }
}