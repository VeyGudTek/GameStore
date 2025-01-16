using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) :DbContext(options)
{
    public DbSet<Game> games => Set<Game>();
    public DbSet<Genre> genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new {id = 1, name = "fighting"},
            new {id = 2, name = "sports"},
            new {id = 3, name = "adventure"},
            new {id = 4, name = "shooter"},
            new {id = 5, name = "racing"}
        );
    }
}
