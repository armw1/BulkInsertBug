using System;
using System.Linq;
using BulkInsertBug.DataAccess;
using BulkInsertBug.Entities;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace bulkinsertbug
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new BugnDbContext();
            db.Database.EnsureDeleted();
            db.Database.Migrate();

            var name1 = new Name("John", "Doe");
            var name2 = new Name("Debby", "Smith");

            var people_noBug = new[]
            {
                new Person_NoBug(Guid.NewGuid(), name1)
            };

            var people_bug = new[]
            {
                new Person_Bug(Guid.NewGuid(), new BasicInfo(name2))
            };

            db.BulkInsert(people_noBug);
            db.BulkInsert(people_bug);

            var person_NoBug = db.Set<Person_NoBug>().First();
            var person_Bug = db.Set<Person_Bug>().First();

            if (person_NoBug.Name == null) throw new InvalidOperationException(nameof(Person_Bug));
            if (person_Bug.BasicInfo.Name == null) throw new InvalidOperationException(nameof(Person_Bug));
        }
    }
}
