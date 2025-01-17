using System;
using GameStore.Data;
using GameStore.Dtos;
using GameStore.Entities;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints;

public static class BlogEndPoints
{
    const string GetBlogEndPointName = "GetBlog";
    public static RouteGroupBuilder MapBlogEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("blogs").WithParameterValidation();

        group.MapGet("", async (GameStoreContext dbContext) => 
            await dbContext.blogs
            .Select((blog) => blog.toBlogSummaryDto())
            .AsNoTracking()
            .ToListAsync());

        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => {
            Blog ?blog = await dbContext.blogs.FindAsync(id);
            return blog is null ?Results.NotFound() : Results.Ok(blog.toBlogDetailsDto());
        }
        ).WithName(GetBlogEndPointName);

        group.MapPost("/", async (GameStoreContext dbContext, CreateBlogDto new_blog) => {
            Blog blog = new_blog.toEntity();
            await dbContext.AddAsync(blog);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetBlogEndPointName, new {id = blog.id}, blog.toBlogDetailsDto());
        }
        );

        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) => {
            await dbContext.blogs
            .Where((game) => game.id == id)
            .ExecuteDeleteAsync();

            return Results.NoContent();
        });


        return group;
    }
}
