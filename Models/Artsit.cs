using System.ComponentModel.DataAnnotations;

namespace Gregslist.Models
{
  public class Artist
  {
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    [Range(1, 10)]
    public int Skill { get; set; }
    public string Era { get; set; }
    public string Country { get; set; }
    public string Type { get; set; }
    public bool IsAlive { get; set; }
    // internal bool Removed { get; set;} = false;
  }
}