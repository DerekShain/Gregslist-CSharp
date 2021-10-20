using System.ComponentModel.DataAnnotations;

namespace Gregslist.Models
{
  public class Car
  {
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Make { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    [Range(1, int.MaxValue)]
    public int Year { get; set; }
    public int Price { get; set; }
    internal bool Removed { get; set; } = false;
  }
}