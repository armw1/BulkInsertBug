using System;

namespace BulkInsertBug.Entities
{
  public class Person_NoBug
  {
    public Guid Id { get; }

    public Name Name { get; }

    public Person_NoBug(Guid id, Name name)
    {
      Id = id;
      Name = name;
    }

    private Person_NoBug(Guid id)
    {
      Id = id;
    }
  }
}
