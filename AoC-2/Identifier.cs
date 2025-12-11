namespace AoC_2;
public class Identifier
{
    public long Id { get; }

    public Identifier(long id)
    {
        Id = id;
    }
    public bool IsValid()
    {
        string litteral = this.Id.ToString();
        if (litteral.Substring(0, 1) == "0")
        {
            return false;
        }
        else
        {
            int divisor = 1;
            while (divisor <= litteral.Length / 2)
            {
                if (litteral.Length % divisor == 0)
                {
                    string firstPartOfNumberForComparison = litteral.Substring(0, divisor);
                    for (int i = divisor; i + divisor <= litteral.Length ; i += divisor)
                    {
                        if (firstPartOfNumberForComparison != litteral.Substring(i, divisor))
                        {
                            break;
                        }
                        if (i + divisor == litteral.Length)
                        {
                            Console.WriteLine($"Identifier {this.Id} is invalid because of repeating part {firstPartOfNumberForComparison}");
                            return false;  
                        } 
                    }
                }
                divisor++;
            }
        }
        return true;
    }
}