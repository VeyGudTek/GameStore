using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;
public record class CreateBlogDto(
    [Required] string title,
    [Required] string author,
    [Required] string body
);
    

