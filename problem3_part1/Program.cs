using var reader = new StreamReader("input.txt");

var sum = 0;

while (true)
{
    var line = reader.ReadLine();
    if (line == null)
    {
        Console.Write(sum);
        return 0;
    }

    var comp1 = line.Take(line.Length / 2).ToHashSet();
    var comp2 = line.TakeLast(line.Length / 2).ToHashSet();
    var intersection = comp1.Intersect(comp2);
    sum += calculatePriorities(intersection);
}

int calculatePriorities(IEnumerable<char> set)
{
    var sum = 0;
    foreach (var c in set)
    {
        if ((int)c >= 97)
        {
            sum += (int)c - 96;
            continue;
        }
        sum += (int)c - 38;
    }
    return sum;
}
