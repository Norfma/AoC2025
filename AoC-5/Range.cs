class Range
{
    public long Start { get; }
    public long End { get; }

    public Range(long start, long end)
    {
        if (start > end)
            throw new ArgumentException("Start cannot be greater than End.");

        Start = start;
        End = end;
    }

    public bool Contains(long value)
    {
        return value >= Start && value <= End;
    }

    public long Size()
    {
        return End - Start + 1;
    }

    public long Intersect(Range other)
    {
        long intersectionStart = Math.Max(this.Start, other.Start);
        long intersectionEnd = Math.Min(this.End, other.End);

        if (intersectionStart <= intersectionEnd)
        {
            return intersectionEnd - intersectionStart + 1;
        }
        return 0;
    }

    public IEnumerable<long> GetAllValues()
    {
        for (long i = Start; i <= End; i++)
        {
            yield return i;
        }
    }

    public override string ToString()
    {
        return $"[{Start}, {End}]";
    }
}