namespace AoC_2;
public class Range
{
    public long Start { get; set; }
    public long End { get; set; }

    public Range(long start, long end)
    {
        Start = start;
        End = end;
    }

    public List<Identifier> GetInvalidIds()
    {
        List<Identifier> invalidIds = new List<Identifier>();
        for (long i = Start; i <= End; i++)
        {
            Identifier id = new Identifier(i);
            if (!id.IsValid())
            {
                invalidIds.Add(id);
            }
        }
        return invalidIds;
    }
}