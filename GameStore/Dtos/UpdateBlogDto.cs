using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class UpdateBlogDto(
    [Required] string title,
    [Required] string body
);
