using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence.Entities;

namespace Urchin.Api.Persistence;

public class UrchinContext : DbContext
{
    public UrchinContext(DbContextOptions<UrchinContext> options) : base(options)
    {
        
    }

    public DbSet<President> Presidents { get; set; } = default!;
    public DbSet<Party> Parties { get; set; } = default!;
    public DbSet<Voter> Voters { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Model.SetDefaultSchema("urchin");

        var foreignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());

        foreach(var foreignKey in foreignKeys)
            foreignKey.DeleteBehavior=DeleteBehavior.Restrict;
            
    }
}