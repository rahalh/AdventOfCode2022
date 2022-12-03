var sums = new List<int>();
using var reader = new StreamReader("input.txt");

var runningSum = 0;

while (true)
{
    var line = reader.ReadLine();
    if (line == null)
    {
        Console.WriteLine(sums
            .OrderByDescending(x => x)
            .Take(3)
            .Sum());
        return 0;
    }

    if (int.TryParse(line, out var cals))
    {
        runningSum += cals;
    }
    else
    {
        sums.Add(runningSum);
        runningSum = 0;
    }
}
