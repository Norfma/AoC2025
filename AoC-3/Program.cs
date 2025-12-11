string [] lines = File.ReadAllLines("/Users/lhernoux/MyGithubProjects/AoC2025/AoC-3/input.csv");
long totalJolts = 0;

// Part 1
// foreach (string line in lines)
// {
//     char maxDigit = '0';
//     char secondMaxDigit = '0';
//     for (int i = 0; i < line.Length; i++)
//     {
//         if (line[i] > maxDigit && i != line.Length-1)
//         {
//             maxDigit = line[i];
//             secondMaxDigit = '0';
//         }
//         else if (line[i] > secondMaxDigit)
//         {
//             secondMaxDigit = line[i];
//         }
//     }
//     string result = $"{maxDigit}{secondMaxDigit}";
//     totalJolts += int.Parse(result);
//     Console.WriteLine(result);
// }
// Console.WriteLine($"Total jolts: {totalJolts}");

// Part 2
foreach (string line in lines)
{
    char [] digits = ['0','0','0','0','0','0','0','0','0','0','0','0'];
    
    for (int i = 0; i < line.Length; i++)
    {
        for (int j = 0; j < 12; j++)
        {
            if (line[i] > digits[j] && 11 - j < line.Length - i)
            {
                digits[j] = line[i];
                for (int k = j+1; k < 12; k++)
                {
                    digits[k] = '0';
                }
                break;
            }
        }
    }
    string result = new string(digits);
    totalJolts += long.Parse(result);
    Console.WriteLine(result);
}
Console.WriteLine($"Total jolts: {totalJolts}");