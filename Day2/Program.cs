Console.WriteLine("Calculating scores...");

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

var choices = inputLines.Select(line =>
{
    var tokens = line.Split(" ");
    var theirs = mapping[tokens[0]];
    var mine = mapping[tokens[1]];

    return (theirs, mine);
});

var scores = choices
    .Select((choice) => Score(choice.theirs, choice.mine))
    .Aggregate((sum, choice) => (sum.Item1 += choice.Item1, sum.Item2 += choice.Item2));

Console.WriteLine($"Their score: {scores.Item1}");
Console.WriteLine($"My score: {scores.Item2}");

Console.WriteLine("");
Console.WriteLine("<< END >>");
Console.WriteLine("");

const int loseScore = 0;
const int drawScore = 3;
const int winScore = 6;

(int, int) Score(Choice theirs, Choice mine)
{
    int theirScore = 0;
    int myScore = 0;
    
    if (theirs == mine)
    {
        theirScore = myScore = drawScore;
    }
    else if (beats[theirs] == mine)
    {
        theirScore = winScore;
        myScore = loseScore;
    }
    else if (beats[mine] == theirs)
    {
        theirScore = loseScore;
        myScore = winScore;
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

enum Choice
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
};