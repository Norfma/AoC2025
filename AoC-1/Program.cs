string filePath = "/Users/lhernoux/MyGithubProjects/AoC2025/AoC-1/input.csv";
Console.WriteLine($"Reading file: {filePath}");
List<(char Direction, int Distance)> commands = [];

if (File.Exists(filePath))
{
    Console.WriteLine("Number of lines in file: " + File.ReadAllLines(filePath).Length);
    foreach (string line in File.ReadAllLines(filePath))
    {
        if (string.IsNullOrWhiteSpace(line)) continue;
        
        char direction = line[0]; // First character: 'R' or 'L'
        if (int.TryParse(line.Substring(1), out int distance))
        {
            commands.Add((direction, distance));
        }
    }
}

int pointer = 50;
int numberOfZero = 0;
foreach (var (dir,dist) in commands)
{
    if (dir == 'R')
    {
        pointer += dist;
    }
    else if (dir == 'L')
    {
        pointer -= dist;
    }
    pointer = pointer % 100;
    if (pointer == 0) numberOfZero++;
}
Console.WriteLine($"\nFinal pointer position: {pointer}");
Console.WriteLine($"Number of times pointer was at 0: {numberOfZero}");