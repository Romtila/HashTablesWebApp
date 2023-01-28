namespace HashTablesWebApp.Models;

public class HashTableLinearProbing
{
    public int NumBuckets { get; set; }
    public int NumUsed { get; set; }
    public Cell[] Buckets { get; set; }

    public HashTableLinearProbing(int numBuckets)
    {
        NumBuckets = numBuckets;
        NumUsed = 0;
        Buckets = new Cell[numBuckets];
        for (var i = 0; i < numBuckets; i++)
        {
            Buckets[i] = new Cell(i, null, null);
        }
    }

    public void Add(int key, int value, out int numProbes)
    {
        if (FindCell(key, out numProbes) != null)
            throw new ArgumentException($"{key} is already in hash table");

        var bucketNum = key % NumBuckets;
        var sentinel = Buckets[bucketNum];

        var newCell = new Cell(key, value, sentinel.Next);
        sentinel.Next = newCell;

        NumUsed++;
    }

    public Cell? FindCell(int key, out int numProbes)
    {
        var cellBefore = FindCellBefore(key, out numProbes);
        return cellBefore?.Next;
    }

    public Cell? FindCellBefore(int key, out int numProbes)
    {
        var bucketNum = key % NumBuckets;
        var sentinel = Buckets[bucketNum];

        numProbes = 0;

        for (var cell = sentinel; cell.Next != null; cell = cell.Next)
        {
            numProbes++;
            if (cell.Next.Key == key)
                return cell;
        }

        return null;
    }

    public void Delete(int key, out int numProbes)
    {
        var cellBefore = FindCellBefore(key, out numProbes);
        if (cellBefore == null)
            throw new ArgumentException($"{key} not founded in hash table");

        cellBefore.Next = cellBefore.Next?.Next;

        NumUsed--;
    }

    public float AverageBucketSize()
    {
        return NumUsed / (float) NumBuckets;
    }

    public void GetSequenceLength(int minValue, int maxValue, out float aveLength, out float maxLength)
    {
        var totalProbes = 0;
        maxLength = 0;

        for (var key = minValue; key <= maxValue; key++)
        {
            FindCell(key, out var numProbes);
            totalProbes += numProbes;
            if (numProbes > maxLength)
                maxLength = numProbes;
        }

        aveLength = totalProbes / (float) (maxValue - minValue);
    }
}