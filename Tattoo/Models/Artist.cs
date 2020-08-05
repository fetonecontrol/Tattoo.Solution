using System.Collections.Generic;

namespace Tattoo.Models
{
  public class Artist
  {
    public Artist()
    {
      this.RelationShips = new HashSet<ArtistClientStyle>();
    }

    public int ArtistId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string About { get; set; }
    public string Specialty { get; set; }
    public virtual ICollection<ArtistClientStyle> RelationShips { get; set; }
  }
}