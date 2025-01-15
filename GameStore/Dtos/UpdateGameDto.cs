using System.ComponentModel.DataAnnotations;
namespace GameStore.UpdateGameDto;

public record class UpdateGameDto(
    [Required][StringLength(50)] string name, 
    [Required][StringLength(20)]string genre, 
    [Range(1, 100)]decimal price, 
    DateOnly release_date
    );
