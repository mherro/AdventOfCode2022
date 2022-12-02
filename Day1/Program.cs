// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var inputLines = File.ReadLines(Path.Combine("input", "problem1.txt"));

var elves = new List<int>();
var currentCalorieCount = 0;
foreach (var inputLine in inputLines)
{
    if (inputLine == String.Empty)
    {
       elves.Add(currentCalorieCount);
       currentCalorieCount = 0;
    }
    else
    {
        currentCalorieCount += Int32.Parse(inputLine);
    }
}

if (currentCalorieCount > 0)
{
    elves.Add(currentCalorieCount);
    currentCalorieCount = 0;
}

var sortedElves = elves.OrderByDescending(c => c);

var mostCalories = sortedElves.First();

Console.WriteLine("The elf with them most calories has:");
Console.WriteLine($"{mostCalories}");
Console.WriteLine("");

var top3Calories = sortedElves.Take(3).Sum();

Console.WriteLine("The top 3 elves have:");
Console.WriteLine($"{top3Calories} calories");
Console.WriteLine("");

Console.WriteLine("<< END >>");
Console.WriteLine("");