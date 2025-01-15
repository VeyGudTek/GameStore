namespace GameStore.Entities;

public class Game
{
    public int id { get; set; }
    public required string name { get; set; }

    public int genreId { get; set; }
    public Genre? genre { get; set; }

    public decimal price { get; set; }
    public DateOnly release_date { get; set; }
}
