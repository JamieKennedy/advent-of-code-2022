using Day2;

const string fileName = "input.txt";

var totalScore = 0;
foreach (var line in File.ReadLines(fileName))
{
    if (line != string.Empty)
    {
        var chars = line.Split(" ");

        totalScore += Puzzle1SimulateRound(chars[0], chars[1]);
    }
}

Console.WriteLine($"Puzzle 1 answer: {totalScore}");

totalScore = 0;
foreach (var line in File.ReadLines(fileName))
{
    if (line != string.Empty)
    {
        var chars = line.Split(" ");

        totalScore += Puzzle2SimulateRound(chars[0], chars[1]);
    }
}

Console.WriteLine($"Puzzle 2 answer: {totalScore}");

int Puzzle2SimulateRound(string p1Char, string roundOutcome)
{
    var p1 = MapCharToOption(p1Char);

    if (p1 != null)
    {
        var p2 = MapCharToOutcome(p1, roundOutcome);

        if (p2 != null)
        {
            return CalcResult(p1, p2) + p2.GetValueForChoice();
        }
    }

    return 0;
}





int Puzzle1SimulateRound(string p1Char, string p2Char)
{
    var p1 = MapCharToOption(p1Char);
    var p2 = MapCharToOption(p2Char);

    if (p1 == null || p2 == null) return 0;

    var result = CalcResult(p1, p2) + p2.GetValueForChoice();

    return result;

}

Option? MapCharToOutcome(Option p1, string input)
{
    switch (input)
    {
       case "X":
           // Lose
           return p1.Value switch
           {
               Option.Values.Rock => new Option(Option.Values.Scissors),
               Option.Values.Paper => new Option(Option.Values.Rock),
               Option.Values.Scissors => new Option(Option.Values.Paper),
               _ => null
           };
       case "Y":
           // Draw
           return p1;
       case "Z":
            // Win
            return p1.Value switch
            {
                Option.Values.Rock => new Option(Option.Values.Paper),
                Option.Values.Paper => new Option(Option.Values.Scissors),
                Option.Values.Scissors => new Option(Option.Values.Rock),
                _ => null
            };
       default:
           return null;
    }
}

Option? MapCharToOption(string input)
{
    switch (input)
    {
        case "A":
        case "X":
            return new(Option.Values.Rock);
        case "B":
        case "Y":
            return new(Option.Values.Paper);
        case "C":
        case "Z":
            return new(Option.Values.Scissors);
        default:
            return null;
    }
}

int CalcResult(Option p1, Option p2)
{
    if (p1.Value == p2.Value)
    {
        // Draw
        return 3;
    }

    if (p2.OptionBeats() == p1.Value)
    {
        // Win
        return 6;
    }

    // Loss
    return 0;
}