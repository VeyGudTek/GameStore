using System.ComponentModel.DataAnnotations;
namespace GameStore.Dtos;

public record class UpdateGameDto(
    [Required][StringLength(50)] string name, 
    int genre_id, 
    [Range(1, 100)]decimal price, 
    DateOnly release_date
    );
