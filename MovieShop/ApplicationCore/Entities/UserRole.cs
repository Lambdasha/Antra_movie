namespace ApplicationCore.Entities;

public class UserRole
{
    // Composite key: (UserId, RoleId)
    public int UserId { get; set; }
    public int RoleId { get; set; }

    // ─── Navigation Properties ───
    public User User { get; set; }
    public Role Role { get; set; }
}