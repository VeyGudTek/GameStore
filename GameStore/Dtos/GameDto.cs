namespace GameStore.Dtos;

public record class GameDto(
    int id, 
    string name, 
    string genre, 
    decimal price, 
    DateOnly release_date
    );
