using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test2.Entities;

namespace test2.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(u => u.Name)
            .HasMaxLength(30);

        builder
            .HasQueryFilter(u => !u.Deleted);
        
        // builder
        //     .HasMany(p => p.Posts)
        //     .WithOne(post => post.User)
        //     .OnDelete(DeleteBehavior.Cascade);
    }
}