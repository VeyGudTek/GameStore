using System;
using GameStore.Dtos;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class BlogMapping
{
    public static Blog toEntity(this CreateBlogDto blog)
    {
        return new Blog(){
            title = blog.title,
            author = blog.author,
            body = blog.body
        };
    }

    public static BlogSummaryDto toBlogSummaryDto(this Blog blog)
    {
        return new BlogSummaryDto(
            blog.id,
            blog.title,
            blog.author
        );
    }

    public static BlogDetailsDto toBlogDetailsDto(this Blog blog)
    {
        return new BlogDetailsDto(
            blog.id,
            blog.title,
            blog.author,
            blog.body
        );
    }

    public static Blog toBlogEntity(this UpdateBlogDto blog, int id, string author)
    {
        return new Blog(){
            id = id,
            title = blog.title,
            author = author,
            body = blog.body
        };
    }
}
