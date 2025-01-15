namespace GameStore.CreateGameDto;

public record class CreateGameDto(
    string name, 
    string genre, 
    decimal price, 
    DateOnly release_date
    );
