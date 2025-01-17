using GameStore.Data;
using GameStore.EndPoints;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<GameStoreContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("GameStoreContext")));
builder.Services.AddCors((options) => 
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy => {policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();}
    ));

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

app.MapGamesEndPoints();
app.MapGenreEndpoints();
app.MapBlogEndPoints();
await app.migrateDBAsync();

app.Run();
