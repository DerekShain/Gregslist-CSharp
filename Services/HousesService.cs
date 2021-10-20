using System.Collections.Generic;
using System.Linq;
using Gregslist.Data;
using Gregslist.Models;

namespace Gregslist.Service
{
  public class HousesService
  {
    private readonly FakeDb _db;
    public HousesService(FakeDb db)
    {
      _db = db;
    }
    public House CreateHouse(House houseData)
    {
      houseData.Id = _db.GenerateId();
      _db.Houses.Add(houseData);
      return houseData;
    }
    public List<House> Get()
    {
      return _db.Houses.Where(c => c.Removed == false).ToList();
    }
    public House Get(int houseId)
    {
      var house = _db.Houses.Find(c => c.Id == houseId && c.Removed == false);
      if (house == null)
      {
        throw new System.Exception("Invalid House Id");
      }
      return house;
    }
    public House Edit(int houseId, House houseData)
    {
      var house = Get(houseId);
      house.Description = houseData.Description ?? house.Description;
      house.Bedrooms = houseData.Bedrooms;
      house.Bathrooms = houseData.Bathrooms;
      house.Levels = houseData.Levels;
      house.Year = houseData.Year;
      house.Price = houseData.Price;
      return house;
    }
    public House Delete(int houseId)
    {
      var house = Get(houseId);
      house.Removed = true;
      return house;
    }
  }
}