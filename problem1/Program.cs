var maxCalories = 0;

using var reader = new StreamReader("input.txt");

var runningSum = 0;

while (true)
{
    var line = reader.ReadLine();
    if (line == null)
    {
        Console.WriteLine(maxCalories);
        return 0;
    }

    if (int.TryParse(line, out var cals))
    {
        runningSum += cals;
    }
    else
    {
        if (runningSum > maxCalories)
        {
            maxCalories = runningSum;
        }
        runningSum = 0;
    }
}
