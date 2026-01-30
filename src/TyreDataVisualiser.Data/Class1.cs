using Microsoft.EntityFrameworkCore;

namespace TyreDataVisualiser.Data;

public class Tyre
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Size { get; set; }
    

}

public class TyreContext : DbContext
{
    public TyreContext(DbContextOptions<TyreContext> options) : base(options)
    {
    }
    public DbSet<Tyre> Tyres => Set<Tyre>();
}