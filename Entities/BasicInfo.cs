namespace BulkInsertBug.Entities
{
  public class BasicInfo
  {
    public Name Name { get; }

    public BasicInfo(Name name)
    {
      Name = name;
    }

    private BasicInfo()
    {

    }
  }
}
