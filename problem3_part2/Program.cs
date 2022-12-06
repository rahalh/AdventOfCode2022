using var reader = new StreamReader("input.txt");

var sum = 0;

while (true)
{
    var line1 = reader.ReadLine();
    if (line1 == null)
    {
        Console.Write(sum);
        return 0;
    }

    var line2 = reader.ReadLine();
    var line3 = reader.ReadLine();

    var intersection = line1.Intersect(line2).Intersect(line3);
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
