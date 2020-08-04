using System.Collections.Generic;

namespace Tattoo.Models
{
  public class Style
  {
    public Style()
    {
      this.RelationShips = new HashSet<ArtistClientStyle>();
    }
    public int StyleId { get; set; }
    public string Description { get; set; }
    public ICollection<ArtistClientStyle> RelationShips { get; set; }
  }
}
