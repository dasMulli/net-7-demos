var items = new int[]{ 2, 1, 3 };

var ascending = items.OrderBy(static i => i);
var descending = items.OrderByDescending(static i => i);

Console.WriteLine($"Ascending: {string.Join(", ", ascending)}");
Console.WriteLine($"Descending: {string.Join(", ", descending)}");