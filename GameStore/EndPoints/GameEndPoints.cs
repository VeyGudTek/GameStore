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
        group.MapGet("/", (GameStoreContext dbContext) => 
            dbContext.games
            .Include(game => game.genre)
            .Select((game) => game.ToGameSummaryDTO())
            .AsNoTracking()
        );

        //Get Game by ID  /games/<int:id>
        group.MapGet("/{id}", (int id, GameStoreContext dbContext) => {
            Game? game = dbContext.games.Find(id);
            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDTO());
            })
            .WithName(GetGameEndPointName);

        //Post Game /games
        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) => {
            Game game = newGame.ToEntity();

            dbContext.games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndPointName, new {id = game.id}, game.ToGameDetailsDTO());
        });

        //Put Game /games/<int:id>
        group.MapPut("/{id}", (int id, UpdateGameDto updated_game, GameStoreContext dbContext) => {
            var existingGame = dbContext.games.Find(id);

            if (existingGame == null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame).CurrentValues.SetValues(updated_game.ToEntity(id));
            dbContext.SaveChanges();

            return Results.NoContent();
        });

        //Delete Game /games/<int:id>
        group.MapDelete("/{id}", (int id, GameStoreContext dbContext) => {
            dbContext.games
            .Where((game) => game.id == id)
            .ExecuteDelete();

            return Results.NoContent();
        });

        return group;
    }
}
