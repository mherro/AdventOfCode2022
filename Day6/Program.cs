

Console.WriteLine();
Console.WriteLine("<< TEST >>");
Console.WriteLine();

RunTest("bvwbjplbgvbhsrlpgdmjqwftvncz", 4, 5);

RunTest("nppdvjthqldpwncqszvftbrmjlhg", 4, 6);

RunTest("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4, 10);

RunTest("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4, 11);

RunTest("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14, 19);

RunTest("bvwbjplbgvbhsrlpgdmjqwftvncz", 14, 23);

RunTest("nppdvjthqldpwncqszvftbrmjlhg", 14, 23);

RunTest("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14, 29);

RunTest("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14, 26);


Console.WriteLine();

Console.WriteLine();
Console.WriteLine("<< START >>");
Console.WriteLine();
Console.WriteLine("Detecting packet...");
Console.WriteLine();

var inputLines = File.ReadLines(Path.Combine("input", "input.txt")).ToList();

// Calculate Part 1

var inputLine = inputLines.First();

var firstPacketIndex = FindUniqueIndex(inputLine, 4);


Console.WriteLine("Part 1");
Console.WriteLine($"Datastream size: {inputLine.Length}");
Console.WriteLine($"First packet detected: {firstPacketIndex}");
Console.WriteLine();

// Calculate Part 2

var firstMessageIndex = FindUniqueIndex(inputLine, 14);

Console.WriteLine("Part 2");
Console.WriteLine($"First message detected: {firstMessageIndex}");
Console.WriteLine();

Console.WriteLine();
Console.WriteLine("<< END >>");
Console.WriteLine();


int FindUniqueIndex(string datastream, int uniqueLength) {

    var markerCheck = string.Empty;

    int j = 0;
    for (var i = 0; i < datastream.Length; i++) {
        var c = datastream[i];

        var cIndex = markerCheck.IndexOf(c);

        if (cIndex == -1) {
            if (markerCheck.Length >= (uniqueLength - 1)) {
                // Console.WriteLine($"{c} not detected");

                j = i;
                i = datastream.Length;
            }
        } else {
            markerCheck = markerCheck[(cIndex + 1)..];
        }

        markerCheck += c;
    }

    return j + 1;
}

void RunTest(string datastream, int uniqueLength, int expectedResult) {
    var testResult = FindUniqueIndex(datastream, uniqueLength) == expectedResult ?  "PASS" : "FAIL";
    Console.WriteLine($"Test {datastream}, {uniqueLength} : {testResult}");
}