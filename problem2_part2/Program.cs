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

    var outcome = getOutcome(line[2]);
    score += calculateScore(outcome, getShape(outcome, charToMove(line[0])));
}

Shape getShape(int outcome, Shape shape)
{
    if (outcome == 0 && shape == Shape.Rock) return Shape.Rock;
    if (outcome == 0 && shape == Shape.Paper) return Shape.Paper;
    if (outcome == 0 && shape == Shape.Scissors) return Shape.Scissors;

    if (outcome > 0 && shape == Shape.Rock) return Shape.Paper;
    if (outcome > 0 && shape == Shape.Paper) return Shape.Scissors;
    if (outcome > 0 && shape == Shape.Scissors) return Shape.Rock;

    if (outcome < 0 && shape == Shape.Rock) return Shape.Scissors;
    if (outcome < 0 && shape == Shape.Paper) return Shape.Rock;
    if (outcome < 0 && shape == Shape.Scissors) return Shape.Paper;

    throw new ArgumentOutOfRangeException();
}

int getOutcome(char c)
{
    switch (c)
    {
        case 'X':
            return -1;
        case 'Y':
            return 0;
        case 'Z':
            return 1;
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

enum Shape
{
    Rock, Paper, Scissors
}
