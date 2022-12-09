Console.WriteLine();
Console.WriteLine("<< START >>");
Console.WriteLine();
Console.WriteLine("Moving crates...");
Console.WriteLine();

var inputLines = File.ReadLines(Path.Combine("input", "input.txt")).ToList();

// Calculate Part 1
Stack<char>[] stacks = new Stack<char>[9];
Stack<char>[] stacks2 = new Stack<char>[9];


for (var s = 0; s < 9; s++) {
    stacks[s] = new Stack<char>();
    stacks2[s] = new Stack<char>();
}

var separatorLineNumber = 0;
while (!String.IsNullOrEmpty(inputLines[separatorLineNumber])) {
    separatorLineNumber++;
}

Console.WriteLine("Stacks:");

for (var stackLineNumber = (separatorLineNumber - 2); stackLineNumber >= 0; stackLineNumber--) {

    var line = inputLines[stackLineNumber];

    for (var i = 0; i < 9; i++) {
        var crateIndex = 1 + (i * 4);
        var crate = line[crateIndex];

        Console.Write(crate);

        if (crate != ' ') {
            stacks[i].Push(crate);
            stacks2[i].Push(crate);
        }
    }
    Console.WriteLine();
}



for (var actionLineNumber = (separatorLineNumber + 1); actionLineNumber < inputLines.Count(); actionLineNumber++) {
    var actionParts = inputLines[actionLineNumber].Split(" ");
    var crateCount = Int32.Parse(actionParts[1]);

    var sourceStack = Int32.Parse(actionParts[3]) - 1;
    var destinationStack = Int32.Parse(actionParts[5]) - 1;

    // Console.WriteLine(inputLines[actionLineNumber]);
    // Console.WriteLine($"Moving {crateCount} crates from {sourceStack} to {destinationStack}");

    for (int j = 0; j < crateCount; j++) {

        stacks[destinationStack].Push(stacks[sourceStack].Pop());
    }
}

var topCrates = string.Empty;
for (var i = 0; i < 9; i++) {
    topCrates += stacks[i].Peek();
}

Console.WriteLine("Part 1");
Console.WriteLine($"Total line count: {inputLines.Count()}");
Console.WriteLine($"Top crates: {topCrates}");
Console.WriteLine();

// Calculate Part 2


for (var actionLineNumber = (separatorLineNumber + 1); actionLineNumber < inputLines.Count(); actionLineNumber++) {
    var actionParts = inputLines[actionLineNumber].Split(" ");
    var crateCount = Int32.Parse(actionParts[1]);

    var sourceStack = Int32.Parse(actionParts[3]) - 1;
    var destinationStack = Int32.Parse(actionParts[5]) - 1;

    // Console.WriteLine(inputLines[actionLineNumber]);
    // Console.WriteLine($"Moving {crateCount} crates from {sourceStack} to {destinationStack}");

    var tempStack = new Stack<char>();
    for (int j = 0; j < crateCount; j++) {

        tempStack.Push(stacks2[sourceStack].Pop());
    }

    while (tempStack.Count > 0) {
        stacks2[destinationStack].Push(tempStack.Pop());
    }
}

var topCrates2 = string.Empty;
for (var i = 0; i < 9; i++) {
    topCrates2 += stacks2[i].Peek();
}


Console.WriteLine("Part 2");
Console.WriteLine($"Top crates 9001: {topCrates2}");
Console.WriteLine();

Console.WriteLine();
Console.WriteLine("<< END >>");
Console.WriteLine();
