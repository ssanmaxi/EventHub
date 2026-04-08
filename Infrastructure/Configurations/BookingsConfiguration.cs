using Microsoft.EntityFrameworkCore;
using EventBooking.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlanning.Infrastructure.Configurations;

public class BookingsConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserId);
        builder.Property(b => b.EventId);
        builder.Property(b => b.Status);
        builder.Property(b => b.CreatedAt);
    }
}