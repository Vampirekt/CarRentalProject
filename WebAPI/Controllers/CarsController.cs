using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CarsController : ControllerBase
    {
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public List<Car> Get()
        {

            var result = _carService.GetAll();
            return result.Data;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateCarDTO carDTO)
        {

            var result = _carService.Add(carDTO);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);

        }
    }
}
