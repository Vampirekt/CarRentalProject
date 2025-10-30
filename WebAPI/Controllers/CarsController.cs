using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;
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
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _carService.Get(c => c.Id == id);

            if (!result.Success || result.Data == null)
                return NotFound(result.Message ?? "Car not found.");

            return Ok(result.Data);
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
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCarDTO carDTO, int id)
        {


            var result = _carService.Update(id,carDTO);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);

        }
    }
}
