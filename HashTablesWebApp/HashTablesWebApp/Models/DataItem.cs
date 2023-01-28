namespace HashTablesWebApp.Models;

public class DataItem
{
    public int Key { get; set; }
    public string Value { get; set; }

    public DataItem(int key, string value)
    {
        Key = key;
        Value = value;
    }

    public IEnumerable<int> Return()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return i;
        }
    }
    
    public IEnumerable<int> ReturnA()
    {
        var a = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            a.Add(i);
        }

        return a;
    }
}