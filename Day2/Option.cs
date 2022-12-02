namespace Day2;

public class Option
{
    public enum Values
    {
        Rock,
        Paper,
        Scissors
    }

    public Values Value { get; init; }

    public Option(Values values)
    {
        this.Value = values;
    }

    public Values OptionBeats()
    {
        switch (Value)
        {
            case Values.Rock:
                return Values.Scissors;
            case Values.Paper:
                return Values.Rock;
            case Values.Scissors:
                return Values.Paper;
            default:
                throw new ArgumentException("No valid Value");
        }
    }

    public int GetValueForChoice()
    {
        switch (Value)
        {
            case Values.Rock:
                return 1;
            case Values.Paper:
                return 2;
            case Values.Scissors:
                return 3;
            default:
                return 0;
        }
    }
}