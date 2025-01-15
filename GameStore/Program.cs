using GameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

app.MapGet("/games", () => games);
app.MapGet("/", () => "Hello World!");

app.Run();
