using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class BlogDetailsDto(
    int id,
    string title,
    string author,
    string body
);
