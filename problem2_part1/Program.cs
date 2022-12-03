Shape charToMove(char c)
{
    switch (c)
    {
        case 'X':
        case 'A':
            return Shape.Rock;
        case 'Y':
        case 'B':
            return Shape.Paper;
        case 'Z':
        case 'C':
            return Shape.Scissors;
        default:
            throw new ArgumentOutOfRangeException();
    }
}

int calculateScore(int outcome, Shape shape)
{
    var score = 0;
    if (outcome > 0) score = 6;
    else if (outcome == 0) score = 3;

    if (shape == Shape.Rock) score += 1;
    else if (shape == Shape.Paper) score += 2;
    else if (shape == Shape.Scissors) score += 3;

    return score;
}

int getOutcome(Shape a, Shape b)
{
    if (a == Shape.Rock && b == Shape.Rock) return 0;
    if (a == Shape.Rock && b == Shape.Paper) return 1;
    if (a == Shape.Rock && b == Shape.Scissors) return -1;

    if (a == Shape.Paper && b == Shape.Rock) return -1;
    if (a == Shape.Paper && b == Shape.Paper) return 0;
    if (a == Shape.Paper && b == Shape.Scissors) return 1;

    if (a == Shape.Scissors && b == Shape.Rock) return 1;
    if (a == Shape.Scissors && b == Shape.Paper) return -1;
    if (a == Shape.Scissors && b == Shape.Scissors) return 0;

    throw new ArgumentOutOfRangeException();
}

using var reader = new StreamReader("input.txt");

var score = 0;

while (true)
{
    var line = reader.ReadLine();
    if (line == null)
    {
        Console.WriteLine(score);
        return 0;
    }

    score += calculateScore(
        getOutcome(
            charToMove(line[0]),
            charToMove(line[2])),
        charToMove(line[2]));
}

enum Shape
{
    Rock, Paper, Scissors
}
