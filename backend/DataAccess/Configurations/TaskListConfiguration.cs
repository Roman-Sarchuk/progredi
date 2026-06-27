using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Progredi.DataAccess.Entities;

namespace Progredi.DataAccess.Configurations;

public class TaskListConfiguration : IEntityTypeConfiguration<TaskList>
{
    public void Configure(EntityTypeBuilder<TaskList> builder)
    {
        builder.HasKey(tl => tl.Id);

        builder.Property(tl => tl.Name).IsRequired().HasMaxLength(100);
        builder.Property(tl => tl.BackgroundColorHex).IsRequired().HasMaxLength(7);

        builder.HasMany(tl => tl.TaskItems)
            .WithOne(ti => ti.TaskList)
            .HasForeignKey(ti => ti.TaskListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}