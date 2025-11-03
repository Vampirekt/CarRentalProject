using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;   
        }
        [HttpGet]
        public ActionResult GetAll() {
            var result = _colorService.GetAll();
            if(!result.Success) return BadRequest(result.Message);

            return Ok(result.Data);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.Get(c => c.Id == id);

            if (!result.Success || result.Data == null)
                return NotFound(result.Message ?? "Car not found.");

            return Ok(result.Data);
        }
    }
}
