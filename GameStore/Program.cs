using GameStore.Data;
using GameStore.EndPoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<GameStoreContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("GameStoreContext")));

var app = builder.Build();

app.MapGamesEndPoints();
app.migrateDB();

app.Run();
