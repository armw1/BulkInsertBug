using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BulkInsertBug.DataAccess
{
  public class BugnDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var connectionString = new SqliteConnectionStringBuilder
      {
        DataSource = "PeopleBug.db",
        Mode = SqliteOpenMode.ReadWriteCreate,
      }.ToString();

      var conn = new SqliteConnection(connectionString);
      optionsBuilder.UseSqlite(conn);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new PersonConfig_Bug());
      builder.ApplyConfiguration(new PersonConfig_NoBug());
    }
  }
}
