bool listingIngredients = false;

List<Range> ranges = new List<Range>();
int CountFreshIngredients = 0;
foreach (var line in File.ReadLines(@"C:\Users\Administrator\Documents\AoC2025\AoC-5\input.txt"))
{
    if (line == "") 
    {
        listingIngredients = true;
        continue;
    }   
    if (!listingIngredients)
    {
        ranges.Add(new Range(long.Parse(line.Split('-')[0]), long.Parse(line.Split('-')[1])));
    }
    else
    {
        long ingredientId = long.Parse(line.Trim());
        if (ranges.Any(r => r.Contains(ingredientId)))
        {
            CountFreshIngredients++;
            // Console.WriteLine($"Fresh ingredient found: {ingredientId}");
        }
        // else Console.WriteLine($"Ingredient is not fresh: {ingredientId}");
    }
}
long count = 0;
for (int i = 0; i < ranges.Count; i++)
{
    count += ranges[i].Size();
    count -= ranges.Take(i).Sum(r => r.Intersect(ranges[i]));
}
Console.WriteLine($"Total number of fresh IDs in ranges: {count}");
Console.WriteLine($"Number of fresh ingredients: {CountFreshIngredients}");