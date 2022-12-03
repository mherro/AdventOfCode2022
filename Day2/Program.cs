Console.WriteLine();
Console.WriteLine("<< START >>");
Console.WriteLine();
Console.WriteLine("Calculating scores...");
Console.WriteLine();

var inputLines = File.ReadLines(Path.Combine("input", "strategy_guide.txt"));

var mapping = new Dictionary<string, Choice>()
{
    {"A", Choice.Rock},
    {"B", Choice.Paper},
    {"C", Choice.Scissors},
    {"X", Choice.Rock},
    {"Y", Choice.Paper},
    {"Z", Choice.Scissors}
};

var beats = new Dictionary<Choice, Choice>()
{
    {Choice.Rock, Choice.Scissors},
    {Choice.Scissors, Choice.Paper},
    {Choice.Paper, Choice.Rock}
};

var loses = new Dictionary<Choice, Choice>()
{
    {Choice.Scissors, Choice.Rock},
    {Choice.Paper, Choice.Scissors},
    {Choice.Rock, Choice.Paper}
};

// Read input
var choices = inputLines.Select(line =>
{
    var tokens = line.Split(" ");
    var theirs = mapping[tokens[0]];
    var mine = mapping[tokens[1]];

    return (theirs, mine);
});

var outcomeMapping = new Dictionary<string, Outcome>()
{
    {"X", Outcome.Lose},
    {"Y", Outcome.Draw},
    {"Z", Outcome.Win}
};


// Calculate Part 1
var scores = choices
    .Select((choice) => Score(choice.theirs, choice.mine))
    .Aggregate((sum, choice) => (sum.Item1 += choice.Item1, sum.Item2 += choice.Item2));

Console.WriteLine("Part 1");
Console.WriteLine($"Their score: {scores.Item1}");
Console.WriteLine($"My score: {scores.Item2}");
Console.WriteLine();

// Calculate Part 2

var strategies = inputLines.Select(line =>
{
    var tokens = line.Split(" ");
    var theirs = mapping[tokens[0]];
    var outcome = tokens[1];

    return (theirs, outcome);
});


var scoresPart2 = strategies
    .Select((strategy) => {
        var outcome = outcomeMapping[strategy.outcome];
        var mine = MakeChoice(strategy.theirs, outcome);

        var scores = Score(strategy.theirs, mine);
        return scores;
    })
    .Aggregate((sum, choice) => (sum.Item1 += choice.Item1, sum.Item2 += choice.Item2));

Console.WriteLine("Part 2");
Console.WriteLine($"Their score: {scoresPart2.Item1}");
Console.WriteLine($"My score: {scoresPart2.Item2}");

Console.WriteLine();
Console.WriteLine("<< END >>");
Console.WriteLine();

(int, int) Score(Choice theirs, Choice mine)
{
    int theirScore = 0;
    int myScore = 0;
    
    if (theirs == mine)
    {
        theirScore = myScore = (int) Outcome.Draw;
    }
    else if (beats[theirs] == mine)
    {
        theirScore = (int) Outcome.Win;
        myScore = (int) Outcome.Lose;
    }
    else if (beats[mine] == theirs)
    {
        theirScore = (int) Outcome.Lose;
        myScore = (int) Outcome.Win;
    }
    else
    {
        throw new Exception("I have made a mistake");
    }

    var theirWeightedScore = WeighScore(theirs, theirScore);
    var myWeightedScore = WeighScore(mine, myScore);
    
    return (theirWeightedScore, myWeightedScore);
}

int WeighScore(Choice choice, int score)
{
    return ((int) choice) + score;
}

Choice MakeChoice(Choice theirChoice, Outcome outcome) {

    var myChoice = outcome switch
    {
        Outcome.Win => loses[theirChoice],
        Outcome.Lose => beats[theirChoice],
        _ => theirChoice // Draw
    };

    return myChoice;
}

enum Choice
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
};

enum Outcome
{
    Win = 6,
    Lose = 0,
    Draw = 3
};