using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) :DbContext(options)
{
    public DbSet<Game> games => Set<Game>();
    public DbSet<Genre> genres => Set<Genre>();
}
