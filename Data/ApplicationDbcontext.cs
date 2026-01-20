
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ExamApi.Entites;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): DbContext(options)
{
    public DbSet<Author> Authors {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<Book> Books {get; set;}
    public DbSet<Bookloan> Bookloans {get; set;}
    public DbSet<Profile> Profiles {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasOne(u => u.Profile)
        .WithOne(p => p.User)
        .HasForeignKey<Profile>(p => p.UserId);
    }
}                                         