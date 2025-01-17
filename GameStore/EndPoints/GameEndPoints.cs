namespace GameStore.EndPoints;
using GameStore.Data;
using GameStore.Dtos;
using GameStore.Entities;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

public static class GameEndPoints
{
    const string GetGameEndPointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        //Get Games /games
        group.MapGet("/", async (GameStoreContext dbContext) => 
            await dbContext.games
            .Include(game => game.genre)
            .Select((game) => game.ToGameSummaryDTO())
            .AsNoTracking()
            .ToListAsync()
        );

        //Get Game by ID  /games/<int:id>
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => {
            Game? game = await dbContext.games.FindAsync(id);
            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDTO());
            })
            .WithName(GetGameEndPointName);

        //Post Game /games
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) => {
            Game game = newGame.ToEntity();

            dbContext.games.Add(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetGameEndPointName, new {id = game.id}, game.ToGameDetailsDTO());
        });

        //Put Game /games/<int:id>
        group.MapPut("/{id}", async (int id, UpdateGameDto updated_game, GameStoreContext dbContext) => {
            var existingGame = await dbContext.games.FindAsync(id);

            if (existingGame == null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame).CurrentValues.SetValues(updated_game.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //Delete Game /games/<int:id>
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) => {
            await dbContext.games
            .Where((game) => game.id == id)
            .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
