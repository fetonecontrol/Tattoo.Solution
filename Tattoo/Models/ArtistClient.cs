namespace Tattoo.Models
{
  public class ArtistClient
  {
    public int ArtistClientId { get; set; }
    public int ClientId { get; set; }
    public int ArtistId { get; set; }
    public Client Client { get; set; }
    public Artist Artist { get; set; }
  }
}