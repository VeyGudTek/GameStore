namespace GameStore.EndPoints;
using GameStore.CreateGameDto;
using GameStore.Dtos;
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
        var group = app.MapGroup("games");

        //Get Games /games
        group.MapGet("/", () => games);

        //Get Game by ID  /games/<int:id>
        group.MapGet("/{id}", (int id) => {
            GameDto? game = games.Find((game) => game.id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
            })
            .WithName(GetGameEndPointName);

        //Post Game /games
        group.MapPost("/", (CreateGameDto newGame) => {
            GameDto game = new(
                games.Count + 1,
                newGame.name,
                newGame.genre,
                newGame.price,
                newGame.release_date
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndPointName, new {id = game.id}, game);
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
