using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRest.Controllers.Managers;
using CarRest.Controllers.Models;

namespace CarRest.Controllers.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Microsoft.AspNetCore.Mvc.Controller
    {
        private Manager _manager = new Manager();
        //GET: api/Cars?modelFilter<value>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] string? modelFilter, [FromQuery] int? priceFilter,
            [FromQuery] string? licensePlateFilter)
        {
            IEnumerable<Car> cars = _manager.GetAll(modelFilter, priceFilter, licensePlateFilter);

            if (cars.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(cars);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Car car = _manager.GetById(id);
            if (car == null) return NotFound("Id does not exist" + id);
            return Ok(car);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public Car Post(Car newCar)
        {
            return _manager.PostCar(newCar);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            Car car = _manager.GetById(id);
            return _manager.Delete(id);
        }
    }
}
