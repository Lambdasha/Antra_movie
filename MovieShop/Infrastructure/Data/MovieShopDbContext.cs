using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options)
            : base(options)
        {
        }

        // ─── DbSet Properties ───
        public DbSet<Movie>       Movies       { get; set; }
        public DbSet<Genre>       Genres       { get; set; }
        public DbSet<MovieGenre>  MovieGenres  { get; set; }
        public DbSet<Cast>        Casts        { get; set; }
        public DbSet<MovieCast>   MovieCasts   { get; set; }
        public DbSet<Trailer>     Trailers     { get; set; }
        public DbSet<Favorite>    Favorites    { get; set; }
        public DbSet<Review>      Reviews      { get; set; }
        public DbSet<Purchase>    Purchases    { get; set; }
        public DbSet<User>        Users        { get; set; }
        public DbSet<Role>        Roles        { get; set; }
        public DbSet<UserRole>    UserRoles    { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            // 1) Configure Composite Primary Keys for join tables
            //

            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieCast>()
                .HasKey(mc => new { mc.MovieId, mc.CastId });

            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.MovieId, f.UserId });

            modelBuilder.Entity<Review>()
                .HasKey(r => new { r.MovieId, r.UserId });

            modelBuilder.Entity<Purchase>()
                .HasKey(p => new { p.MovieId, p.UserId });

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            //
            // 2) Configure Relationships (Foreign Keys)
            //

            // MovieGenre ⟷ Movie (one Movie ⇄ many MovieGenres)
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);

            // MovieCast ⟷ Movie (one Movie ⇄ many MovieCasts)
            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCasts)
                .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Cast)
                .WithMany(c => c.MovieCasts)
                .HasForeignKey(mc => mc.CastId);

            // Trailer ⟷ Movie (one Movie ⇄ many Trailers)
            modelBuilder.Entity<Trailer>()
                .HasOne(t => t.Movie)
                .WithMany(m => m.Trailers)
                .HasForeignKey(t => t.MovieId);

            // Favorite ⟷ Movie (one Movie ⇄ many Favorites)
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Movie)
                .WithMany(m => m.Favorites)
                .HasForeignKey(f => f.MovieId);

            // Favorite ⟷ User (one User ⇄ many Favorites)
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);

            // Review ⟷ Movie (one Movie ⇄ many Reviews)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MovieId);

            // Review ⟷ User (one User ⇄ many Reviews)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            // Purchase ⟷ Movie (one Movie ⇄ many Purchases)
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Movie)
                .WithMany(m => m.Purchases)
                .HasForeignKey(p => p.MovieId);

            // Purchase ⟷ User (one User ⇄ many Purchases)
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.User)
                .WithMany(u => u.Purchases)
                .HasForeignKey(p => p.UserId);

            // UserRole ⟷ User (one User ⇄ many UserRoles)
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            // UserRole ⟷ Role (one Role ⇄ many UserRoles)
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            
        }
    }
}
