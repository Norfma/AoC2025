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

    public Range merge(Range other)
    {
        if (this.End < other.Start || other.End < this.Start)
            throw new ArgumentException("Ranges do not overlap and cannot be merged.");

        long mergedStart = Math.Min(this.Start, other.Start);
        long mergedEnd = Math.Max(this.End, other.End);
        return new Range(mergedStart, mergedEnd);
    }

    public bool Contains(long value)
    {
        return value >= Start && value <= End;
    }

    public long Size()
    {
        return End - Start + 1;
    }

    public bool Intersect(Range other)
    {
        long intersectionStart = Math.Max(this.Start, other.Start);
        long intersectionEnd = Math.Min(this.End, other.End);

        if (intersectionStart <= intersectionEnd)
        {
            return true;
        }
        return false;
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