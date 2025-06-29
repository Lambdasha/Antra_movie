namespace ApplicationCore.Entities;

public class MovieGenre
{
    // Composite key: (MovieId, GenreId)
    public int MovieId { get; set; }
    public int GenreId { get; set; }

    // ─── Navigation Properties ───
    public Movie Movie { get; set; }
    public Genre Genre { get; set; }
}