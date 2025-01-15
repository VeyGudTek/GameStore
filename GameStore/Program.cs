using GameStore.CreateGameDto;
using GameStore.Dtos;
using GameStore.UpdateGameDto;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndPointName = "GetGame";

List<GameDto> games = [
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

//Get Games /games
app.MapGet("/games", () => games);

//Get Game by ID  /games/<int:id>
app.MapGet("/games/{id}", (int id) => games.Find((game) => game.id == id))
    .WithName(GetGameEndPointName);

//Post Game /games
app.MapPost("games", (CreateGameDto newGame) => {
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
app.MapPut("/games/{id}", (int id, UpdateGameDto updated_game) => {
    var index = games.FindIndex((game) => game.id == id);
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
app.MapDelete("games/{id}", (int id) => {
    games.RemoveAll((game) => game.id == id);

    return Results.NoContent();
});


app.Run();
