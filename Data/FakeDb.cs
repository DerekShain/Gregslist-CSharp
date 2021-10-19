using System;
using System.Collections.Generic;
using Gregslist.Models;

namespace Gregslist.Data
{
  public class FakeDb
  {
    private Random _random = new Random();
    public List<Car> Cars = new List<Car>();
    public List<Job> Jobs = new List<Job>();
    public List<House> Houses = new List<House>();
    public int GenerateId()
    {
      return _random.Next(1000, 10000000);
    }
  }
}