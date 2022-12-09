Console.WriteLine();
Console.WriteLine("<< START >>");
Console.WriteLine();
Console.WriteLine("Calculating overlaps...");
Console.WriteLine();

var inputLines = File.ReadLines(Path.Combine("input", "input.txt")).ToList();

// Calculate Part 1
var completeOverlapCount = inputLines.Select(inputLine => {
    var sectionsRanges = inputLine.Split(",");

    var sectionRange1 = sectionsRanges[0].Split("-");

    var sectionRange1Start = Int32.Parse(sectionRange1[0]);
    var sectionRange1End = Int32.Parse(sectionRange1[1]);

    var sectionRange2 = sectionsRanges[1].Split("-");

    var sectionRange2Start = Int32.Parse(sectionRange2[0]);
    var sectionRange2End = Int32.Parse(sectionRange2[1]);

    if ((sectionRange1Start >= sectionRange2Start && sectionRange1End <= sectionRange2End) ||
        (sectionRange2Start >= sectionRange1Start && sectionRange2End <= sectionRange1End)) {
            return true;
        }
    return false;
    })
    .Where(isOverlap => isOverlap)
    .Count();


Console.WriteLine("Part 1");
Console.WriteLine($"Total line count: {inputLines.Count()}");
Console.WriteLine($"Complete overlap count: {completeOverlapCount}");
Console.WriteLine();

// Calculate Part 2
var partialOverlapCount = inputLines.Select(inputLine => {
    var sectionsRanges = inputLine.Split(",");

    var sectionRange1 = sectionsRanges[0].Split("-");

    var sectionRange1Start = Int32.Parse(sectionRange1[0]);
    var sectionRange1End = Int32.Parse(sectionRange1[1]);

    var sectionRange2 = sectionsRanges[1].Split("-");

    var sectionRange2Start = Int32.Parse(sectionRange2[0]);
    var sectionRange2End = Int32.Parse(sectionRange2[1]);

    if ((sectionRange1Start <= sectionRange2End && sectionRange1End >= sectionRange2Start)) {
            return true;
        }
    return false;
    })
    .Where(isOverlap => isOverlap)
    .Count();

Console.WriteLine("Part 2");
Console.WriteLine($"Partial overlap count: {partialOverlapCount}");
Console.WriteLine();

Console.WriteLine();
Console.WriteLine("<< END >>");
Console.WriteLine();
