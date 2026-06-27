using Microsoft.EntityFrameworkCore;
using Progredi.DataAccess.Entities;
using Progredi.DataAccess.Configurations;

namespace Progredi.DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TaskListConfiguration());
        modelBuilder.ApplyConfiguration(new TaskItemConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}