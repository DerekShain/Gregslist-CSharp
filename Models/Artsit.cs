using System.ComponentModel.DataAnnotations;

namespace Gregslist.Models
{
  public class Artist
  {
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    public string Genre { get; set; }
    internal bool Removed { get; set;} = false;
  }
}