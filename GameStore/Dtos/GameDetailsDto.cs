namespace GameStore.Dtos;

public record class GameDetailsDto(
    int id, 
    string name, 
    int genre_id, 
    decimal price, 
    DateOnly release_date
    );
