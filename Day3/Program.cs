const string fileName = "input.txt";
List<char> intersect;

// Puzzle 1
var sum = 0;

foreach (var line in File.ReadLines(fileName))
{
    if (line != string.Empty)
    {
        int midPoint = line.Length / 2;

        var half1 = line.Substring(0, midPoint);
        var half2 = line.Substring(midPoint, line.Length - midPoint);

        intersect = GetIntersectOf2(half1, half2);

        foreach (var c in intersect)
        {
            sum += GetPriority(c);
        }
    }
}


Console.WriteLine($"Puzzle 1 answer: {sum}");

// Puzzle 2
sum = 0;
List<List<char>> group = new();
foreach (var line in File.ReadLines(fileName))
{
    if (line != string.Empty)
    {
        group.Add(new List<char>(line));

        if (group.Count == 3)
        {
            intersect = GetIntersectOfN(group);

            foreach (var c in intersect)
            {
                sum += GetPriority(c);
            }

            group = new();
        }

    }
}

Console.WriteLine($"Puzzle 2 answer: {sum}");

List<char> GetIntersectOf2(string x, string y)
{
    return x.Intersect(y).ToList();
}

List<T> GetIntersectOfN<T>(List<List<T>> lists)
{
    return lists.Aggregate((prev, next) => prev.Intersect(next).ToList());
}

int GetPriority(char c)
{
    var pos = c % 32;

    if (c.ToString().ToUpper() == c.ToString())
    {
        // Uppercase
        pos += 26;
    }

    return pos;
}