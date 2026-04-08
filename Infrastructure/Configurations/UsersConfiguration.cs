using Microsoft.EntityFrameworkCore;
using EventBooking.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlanning.Infrastructure.Configurations;

public class UsersConfiguration : IEntityTypeConfiguration<User> 
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name);
        builder.Property(b => b.PasswordHash);
        builder.Property(b => b.Email);
    }
}