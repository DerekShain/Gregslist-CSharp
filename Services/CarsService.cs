using System.Collections.Generic;
using System.Linq;
using Gregslist.Data;
using Gregslist.Models;

namespace Gregslist.Service
{
  public class CarsService
  {
    private readonly FakeDb _db;
    public CarsService(FakeDb db)
    {
      _db = db;
    }
    public Car CreateCar(Car carData)
    {
      carData.Id = _db.GenerateId();
      _db.Cars.Add(carData);
      return carData;
    }
    public List<Car> Get()
    {
      return _db.Cars.Where(c => c.Removed == false).ToList();
    }
    public Car Get(int carId)
    {
      var car = _db.Cars.Find(c => c.Id == carId && c.Removed == false);
      if (car == null)
      {
        throw new System.Exception("Invalid Car Id");
      }
      return car;
    }
    public Car Edit(int carId, Car carData)
    {
      var car = Get(carId);
      car.Make = carData.Make ?? car.Make;
      car.Model = carData.Model ?? car.Model;
      car.Description = carData.Description ?? car.Description;
      car.Img = carData.Img ?? car.Img;
      car.Year = carData.Year;
      car.Price = carData.Price;
      return car;
    }
    public Car Delete(int carId)
    {
      var car = Get(carId);
      car.Removed = true;
      return car;
    }
  }
}