namespace GameStore.UpdateGameDto;

public record class UpdateGameDto(
    string name, 
    string genre, 
    decimal price, 
    DateOnly release_date
    );
