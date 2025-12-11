namespace AoC_1;
internal class Program
{
    private static void Main(string[] args)
    {
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
        foreach (var (dir, dist) in commands)
        {
            Console.WriteLine($"\nCurrent pointer position: {pointer}");
            Console.WriteLine($"\nProcessing command: {dir}{dist}");
            if (dir == 'R')
            {
                pointer += dist;
                numberOfZero += pointer / 100;
                Console.WriteLine($"Spinning positive and adding {pointer / 100} to numberOfZero");
            }
            else if (dir == 'L')
            {
                if (pointer != 0)
                {
                    pointer -= dist;
                    if (pointer <= 0)
                    {
                        numberOfZero++;
                        Console.WriteLine($"Pointer crossed 0 during left spin.");
                    }
                }
                else
                {
                    pointer -= dist;
                }
                numberOfZero += Math.Abs(pointer) / 100;
                Console.WriteLine($"Spinning negative and adding {Math.Abs(pointer) / 100} to numberOfZero");
            }
            //Resets pointer within 0-99 range
            pointer %= 100;
            if (pointer < 0)
            {
                pointer += 100;
            }
        }
        Console.WriteLine($"\nFinal pointer position: {pointer}");
        Console.WriteLine($"Number of times pointer was at 0: {numberOfZero}");
    }
}