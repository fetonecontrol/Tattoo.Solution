using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Tattoo.Models
{
  public class Client
  {
    public Client()
    {
      this.Artists = new HashSet<ArtistClient>();
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ApptDate { get; set; }
    public string Services { get; set; }
    public int ArtistId { get; set; }
    public virtual Artist Artist { get; set; }

    public ICollection<ArtistClient> A

  }
}