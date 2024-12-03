using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tasks.Infrastructure.Data.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Tasks.Domain.Models.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Task> builder)
    {
        builder.HasKey(x=> x.Id);

        builder.Property(x => x.Text).IsRequired();
    }
}
