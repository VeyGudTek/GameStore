using GameStore.Entities;
using GameStore.Dtos;

namespace GameStore.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game()
        {
            name = game.name,
            genreId = game.genre_id,
            price = game.price,
            release_date = game.release_date
        };
    }

    public static Game ToEntity(this UpdateGameDto game, int input_id)
    {
        return new Game()
        {
            id = input_id,
            name = game.name,
            genreId = game.genre_id,
            price = game.price,
            release_date = game.release_date
        };
    }

    public static GameSummaryDto ToGameSummaryDTO(this Game game)
    {
        return new (
            game.id,
            game.name,
            game.genre!.name,
            game.price,
            game.release_date
        );
    }

    public static GameDetailsDto ToGameDetailsDTO(this Game game)
    {
        return new (
            game.id,
            game.name,
            game.genreId,
            game.price,
            game.release_date
        );
    }
}
