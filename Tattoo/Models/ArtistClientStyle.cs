namespace Tattoo.Models
{
  public class ArtistClientStyle
  {
    public int ArtistClientStyleId { get; set; }
    public int? ArtistId { get; set; }
    public int? ClientId { get; set; }
    public int? StyleId { get; set; }
    public virtual Artist Artist { get; set; }
    public virtual Client Client { get; set; }
    public virtual Style Style { get; set; }
  }
}