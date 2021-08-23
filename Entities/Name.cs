namespace BulkInsertBug.Entities
{
  public class Name
  {
    public string First { get; }
    public string Last { get; }

    public Name(string first, string last)
    {
      First = first;
      Last = last;
    }
  }
}
