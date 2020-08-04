namespace Tattoo.Models
{
  public class ArtistClientStyle
  {
    public int ArtistClientStyleId { get; set; }
    public int? ArtistId { get; set; }
    public virtual Artist Artist { get; set; }
    public int? ClientId { get; set; }
  }
}