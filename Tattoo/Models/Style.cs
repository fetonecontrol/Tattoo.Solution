using System.Collections.Generic;

namespace Tattoo.Models
{
  public class Style
  {
    public Style()
    {
      this.Artists = new HashSet<ArtistClientStyle>();
    }

    public static List<string> StylesDescription { get; } = new List<string>() { "Traditional", "Neo-Traditional", "Bio-Mech" };
    public int StyleId { get; set; }
    public string Description { get; set; }
    public ICollection<ArtistClientStyle> Artists { get; set; }
  }
}
