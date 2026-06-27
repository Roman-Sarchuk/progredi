using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Progredi.DataAccess.Entities;

namespace Progredi.DataAccess.Configurations;

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.HasKey(ti => ti.Id);

        builder.Property(ti => ti.Title).IsRequired().HasMaxLength(100);
        builder.Property(ti => ti.Description).HasMaxLength(500);
        builder.Property(ti => ti.IsCompleted).IsRequired();

        builder.HasMany(ti => ti.Categories)
            .WithMany(c => c.TaskItems);
    }
}