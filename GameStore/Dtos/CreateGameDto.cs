using System.ComponentModel.DataAnnotations;

namespace GameStore.CreateGameDto;

public record class CreateGameDto(
    [Required][StringLength(50)] string name, 
    int genre_id, 
    [Range(1, 100)]decimal price, 
    DateOnly release_date
    );
