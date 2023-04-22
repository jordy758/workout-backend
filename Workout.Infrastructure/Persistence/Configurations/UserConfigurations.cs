using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workout.Domain.UserAggregate;
using Workout.Domain.UserAggregate.ValueObjects;

namespace Workout.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(u => u.FirstName)
            .HasMaxLength(100);
        
        builder.Property(u => u.LastName)
            .HasMaxLength(100);
        
        builder.Property(u => u.Email)
            .HasMaxLength(100);
        
        builder.Property(u => u.Password)
            .HasMaxLength(100);
    }
}