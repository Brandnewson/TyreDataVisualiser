using Microsoft.EntityFrameworkCore;

namespace TyreDataVisualiser.Data;

public class Tyre
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Size { get; set; }
    

}

public class TyreContext : DbContext
{
    public TyreContext(DbContextOptions<TyreContext> options) : base(options)
    {
    }
    public DbSet<Tyre> Tyres => Set<Tyre>();
}