namespace GameStore.Entities;

public class Blog
{
    public int id { get; set; }
    public required string title { get; set; }
    public required string author { get; set; }
    public required string body { get; set; }
}
