namespace GameStore.Dtos;

public record class GameSummaryDto(
    int id, 
    string name, 
    string genre, 
    decimal price, 
    DateOnly release_date
    );
