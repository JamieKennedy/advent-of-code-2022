const string fileName = "input.txt";

Dictionary<int, int> elves = new();
var index = 0;
var currentSum = 0;

foreach (var line in File.ReadLines(fileName))
{
    if (line == string.Empty)
    {
        elves.Add(index, currentSum);

        // Increment the index and reset the sum
        index += 1;
        currentSum = 0;
        continue;
    }

    if (int.TryParse(line, out var num))
    {
        currentSum += num;
    }
}

// sort highest to lowest
var dictAsList = elves.ToList();
dictAsList.Sort((x, y) => y.Value.CompareTo(x.Value));

var puzzle1Ans = dictAsList[0].Value;

Console.WriteLine($"Puzzle 1 answer: {puzzle1Ans}");

var top3Sum = dictAsList.Take(3).Select(elf => elf.Value).Sum();

Console.WriteLine($"Puzzle 2 answer: {top3Sum}");