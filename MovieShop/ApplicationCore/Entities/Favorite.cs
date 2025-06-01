namespace ApplicationCore.Entities;

public class Favorite
{
    // Composite key: (MovieId, UserId)
    public int MovieId { get; set; }
    public int UserId  { get; set; }

    // ─── Navigation Properties ───
    public Movie Movie { get; set; }
    public User  User  { get; set; }
}