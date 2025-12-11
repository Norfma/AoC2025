namespace AoC_2;
public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "/Users/lhernoux/MyGithubProjects/AoC2025/AoC-2/input.txt";
        Console.WriteLine($"Reading file: {filePath}");
        string content = File.ReadAllText(filePath);
        string[] lines = content.Split(',', StringSplitOptions.RemoveEmptyEntries);
        List<AoC_2.Range> ranges = new List<AoC_2.Range>();
        foreach (var line in lines)
        {
            AoC_2.Range range = new AoC_2.Range(long.Parse(line.Split('-')[0]), long.Parse(line.Split('-')[1]));
            ranges.Add(range);
        }
        List<AoC_2.Identifier> allInvalidIds = new List<AoC_2.Identifier>();
        foreach (var range in ranges)
        {
            allInvalidIds.AddRange(range.GetInvalidIds());
        }
        long sum = 0;
        foreach (var id in allInvalidIds){
            sum += id.Id;
        }
        Console.WriteLine($"Sum of all invalid IDs: {sum}");
    }
}