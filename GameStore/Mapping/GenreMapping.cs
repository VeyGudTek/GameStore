using System;
using GameStore.Dtos;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GenreMapping
{
    public static GenreDTO toDTO(this Genre genre)
    {
        return new GenreDTO(genre.id, genre.name);
    }
}
