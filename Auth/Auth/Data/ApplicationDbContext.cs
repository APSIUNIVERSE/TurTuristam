using Auth.Identity;
using Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserTur> UsersTur { get; set; }
    public DbSet<UserAgent> UsersAgent { get; set; }
    public DbSet<Turs> Turs { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
}