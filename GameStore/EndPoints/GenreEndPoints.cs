using System;
using GameStore.Data;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints;

public static class GenreEndPoints
{
    public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        group.MapGet("/", async (GameStoreContext dbContext) => 
            await dbContext.genres
            .Select((genre) => genre.toDTO())
            .AsNoTracking()
            .ToListAsync()
        );
        
        return group;
    }
}
