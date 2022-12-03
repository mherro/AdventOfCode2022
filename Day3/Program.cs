Console.WriteLine();
Console.WriteLine("<< START >>");
Console.WriteLine();
Console.WriteLine("Calculating priorities...");
Console.WriteLine();

var inputLines = File.ReadLines(Path.Combine("input", "rucksack_contents.txt")).ToList();

var alphabetPriority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

var contents = inputLines.Select(inputLine => {
    var contentSize = inputLine.Length / 2;
    var firstCompartment = inputLine[..contentSize];
    var secondCompartment = inputLine[contentSize..];

    return (firstCompartment, secondCompartment);
});

var commonItems = contents.Select(content => {

    var commonItems = 
        content.firstCompartment.ToCharArray()
            .Intersect(content.secondCompartment.ToCharArray());

    var commonItem = commonItems.First();

    return commonItem;
});

var priorityTotal = commonItems
    .Select(commonItem =>
        alphabetPriority.IndexOf(commonItem) + 1
    )
    .Sum();

Console.WriteLine("Part 1");
Console.WriteLine($"Rucksack count: {inputLines.Count()}");
Console.WriteLine($"Priority total {priorityTotal}");
Console.WriteLine();

// Calculate Part 2

const int batchSize = 3;
var groupCount = inputLines.Count() / batchSize;

var groupBadges = new List<char>();

for (var i = 0; i < groupCount; i++) {

    var commonItem = inputLines.Skip(batchSize * i).Take(batchSize)
        .Select(inputLine => inputLine.ToCharArray())
        .Aggregate(alphabetPriority.ToCharArray().Cast<char>(), (commonItems, inputItems) => 
            commonItems.Intersect(inputItems)
        );

    groupBadges.Add(commonItem.First());
}

var badgePriorityTotal = groupBadges
    .Select(groupBadge =>
        alphabetPriority.IndexOf(groupBadge) + 1
    )
    .Sum();

Console.WriteLine("Part 2");
Console.WriteLine($"Group count: {groupCount}");
Console.WriteLine($"Badge priority total: {badgePriorityTotal}");
Console.WriteLine();

Console.WriteLine();
Console.WriteLine("<< END >>");
Console.WriteLine();
