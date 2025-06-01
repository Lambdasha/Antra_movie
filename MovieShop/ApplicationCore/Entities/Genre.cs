namespace ApplicationCore.Entities;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // ─── Navigation Properties ───
    public ICollection<MovieGenre> MovieGenres { get; set; }
}