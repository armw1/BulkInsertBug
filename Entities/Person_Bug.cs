using System;

namespace BulkInsertBug.Entities
{
  public class Person_Bug
  {
    public Guid Id { get; }

    public BasicInfo BasicInfo { get; }

    public Person_Bug(Guid id, BasicInfo basicInfo)
    {
      Id = id;
      BasicInfo = basicInfo;
    }

    private Person_Bug(Guid id)
    {
      Id = id;
    }
  }
}
