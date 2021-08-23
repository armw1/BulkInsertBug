using BulkInsertBug.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkInsertBug.DataAccess
{
  internal class PersonConfig_NoBug : IEntityTypeConfiguration<Person_NoBug>
  {
    public void Configure(EntityTypeBuilder<Person_NoBug> builder)
    {
      builder.ToTable("People_NoBug");

      builder.HasKey(p => p.Id);

      builder.Property(p => p.Id);

      builder.OwnsOne(p => p.Name, ConfigureName);
    }

    private static void ConfigureName(OwnedNavigationBuilder<Person_NoBug, Name> builder)
    {
      builder.Property(p => p.First)
        .HasColumnName("FirstName")
        .IsRequired();

      builder.Property(p => p.Last)
        .HasColumnName("LastName")
        .IsRequired();
    }
  }
}
