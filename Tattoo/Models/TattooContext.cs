using Microsoft.EntityFrameworkCore;

namespace Tattoo.Models
{
  public class TattooContext : DbContext
  {

    public virtual DbSet<Artist> Artists { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Style> Styles { get; set; }
    public DbSet<ArtistClient> ArtistClients { get; set; }
    public DbSet<ArtistClientStyle> ArtistClientStyles { get; set; }

    public TattooContext(DbContextOptions options) : base(options) { }
  }
}