using System.ComponentModel.DataAnnotations;

namespace Gregslist.Models
{
public class Job
{
  public int Id{get; set;}
  [Required]
  [MinLength(3)]
  public string JobTitle { get; set; }
  public string Company { get; set; }
  public string Description { get; set; }
  [Range (1, int.MaxValue)]
  public int Rate { get; set; }
  public int Hours { get; set; }
    internal bool Removed { get; set;} = false;
}
}