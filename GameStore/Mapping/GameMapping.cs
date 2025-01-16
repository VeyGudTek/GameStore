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

    public static GameDto ToDTO(this Game game)
    {
        return new (
            game.id,
            game.name,
            game.genre!.name,
            game.price,
            game.release_date
        );
    }
}
