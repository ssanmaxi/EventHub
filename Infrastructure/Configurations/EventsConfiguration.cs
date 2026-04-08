using Microsoft.EntityFrameworkCore;
using EventBooking.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlanning.Infrastructure.Configurations;

public class EventsConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.OrganizerId);
        builder.Property(b => b.Name);
        builder.Property(b => b.Description);
        builder.Property(b => b.Date);
        builder.Property(b => b.Place);
        builder.Property(b => b.MaxSeats);
        builder.Property(b => b.Status);
        builder.Property(b => b.PhotoUrl);
    }
}