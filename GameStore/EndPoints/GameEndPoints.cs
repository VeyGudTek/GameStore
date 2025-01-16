namespace GameStore.EndPoints;
using GameStore.CreateGameDto;
using GameStore.Data;
using GameStore.Dtos;
using GameStore.Entities;
using GameStore.UpdateGameDto;

public static class GameEndPoints
{
    const string GetGameEndPointName = "GetGame";

    private static readonly List<GameDto> games = [
        new(
            1,
            "Bob's Adventure",
            "action",
            17.00M,
            new DateOnly(2011, 2, 2)
        ),
            new(
            2,
            "Joe's Revolution",
            "fantasy",
            2.21M,
            new DateOnly(1990, 10, 5)
        )
    ];

    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        //Get Games /games
        group.MapGet("/", () => games);

        //Get Game by ID  /games/<int:id>
        group.MapGet("/{id}", (int id) => {
            GameDto? game = games.Find((game) => game.id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
            })
            .WithName(GetGameEndPointName);

        //Post Game /games
        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) => {
            Game game = new()
            {
                name = newGame.name,
                genre = dbContext.genres.Find(newGame.genre_id),
                genreId = newGame.genre_id,
                price = newGame.price,
                release_date = newGame.release_date
            };

            dbContext.games.Add(game);
            dbContext.SaveChanges();

            GameDto gamedto = new(
                game.id,
                game.name,
                game.genre!.name,
                game.price,
                game.release_date
            );

            return Results.CreatedAtRoute(GetGameEndPointName, new {id = game.id}, gamedto);
        });

        //Put Game /games/<int:id>
        group.MapPut("/{id}", (int id, UpdateGameDto updated_game) => {
            var index = games.FindIndex((game) => game.id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updated_game.name,
                updated_game.genre,
                updated_game.price,
                updated_game.release_date
                );

            return Results.NoContent();
        });

        //Delete Game /games/<int:id>
        group.MapDelete("/{id}", (int id) => {
            games.RemoveAll((game) => game.id == id);

            return Results.NoContent();
        });

        return group;
    }
}
