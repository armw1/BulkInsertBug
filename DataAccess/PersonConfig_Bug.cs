using BulkInsertBug.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkInsertBug.DataAccess
{
  internal class PersonConfig_Bug : IEntityTypeConfiguration<Person_Bug>
  {
    public void Configure(EntityTypeBuilder<Person_Bug> builder)
    {
      builder.ToTable("People_Bug");

      builder.HasKey(p => p.Id);

      builder.Property(p => p.Id);

      builder.OwnsOne(p => p.BasicInfo, ConfigureBasicInfo);
    }

    private static void ConfigureBasicInfo(OwnedNavigationBuilder<Person_Bug, BasicInfo> builder)
    {
      builder.OwnsOne(p => p.Name, ConfigureName);
    }

    private static void ConfigureName(OwnedNavigationBuilder<BasicInfo, Name> builder)
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
