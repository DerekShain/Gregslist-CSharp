using System.ComponentModel.DataAnnotations;

namespace Gregslist.Models
{
  public class House
  {
    public int Id{ get; set;}
    [Required]
    [MinLength(3)]
    public string Description { get; set; }
    [Range (1, int.MaxValue)]
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int Levels { get; set; }
    public int Year { get; set; }
    public int Price { get; set; }
    internal bool Removed { get; set;} = false;
  }
}