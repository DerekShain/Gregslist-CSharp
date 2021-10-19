using System.Collections.Generic;
using Gregslist.Models;
using Gregslist.Service;
using Microsoft.AspNetCore.Mvc;

namespace Gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    private readonly CarsService _cs;
    public CarsController(CarsService cs)
    {
      _cs = cs; 
    }
    [HttpGet]
    public ActionResult<List<Car>> GetCars()
    {
      try
      {
           var cars = _cs.Get();
           return Ok(cars);
      }
      catch (System.Exception error)
      {
         return BadRequest(error.Message);
      }
    }
    [HttpGet("{carId}")]
    public ActionResult<Car> GetCarById(int carId)
    {
      try
      {
           var car = _cs.Get(carId);
           return Ok(car);
      }
      catch (System.Exception error)
      {
          return BadRequest(error.Message);
      }
    }
    [HttpPost]
    public ActionResult<Car> CreateCar([FromBody] Car carData)
    {
      try
      {
           var car = _cs.CreateCar(carData);
           return Ok(car);
      }
      catch (System.Exception error)
      {
          return BadRequest(error.Message);
      }
    }
    [HttpPut("{carId}")]
    public ActionResult<Car> EditCar(int carId, [FromBody] Car carData)
    {
      try
      {
           var car = _cs.Edit(carId, carData);
           return Ok(car);
      }
      catch (System.Exception error)
      {
          return BadRequest(error.Message);
      }
    }
    [HttpDelete("{carId}")]
    public ActionResult<Car> DeleteCar(int carId)
    {
      try
      {
           var car = _cs.Delete(carId);
           return Ok(car);
      }
      catch (System.Exception error)
      {
         return BadRequest(error.Message);
      }
    }
  }
}