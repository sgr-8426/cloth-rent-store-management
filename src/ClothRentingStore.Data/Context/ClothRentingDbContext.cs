using Microsoft.EntityFrameworkCore;

namespace ClothRentingStore.Data.Context;

public class ClothRentingDbContext : DbContext
{
    public ClothRentingDbContext(DbContextOptions<ClothRentingDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClothRentingDbContext).Assembly);
    }
}
