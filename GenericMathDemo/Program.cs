// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;


Console.WriteLine($"Average using int,int: {Average(2, 5)}");
Console.WriteLine($"Average using int,float: {Average(2.0,5.0)}");

static T Average<T>(T first, T second)
    where T : INumber<T>
{
    return T.CreateChecked((first + second) / T.CreateChecked(2));
}










partial class Point : IParsable<Point>
{
    public int X { get; set; }
    public int Y { get; set; }

    public static Point Parse(string s, IFormatProvider? provider)
    {
        if (!TryParse(s, provider, out var point))
        {
            throw new ArgumentException("Invalid point string");
        }
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out Point result)
    {
        result = new Point();

        if (s is null)
        {
            return false;
        }

        var match = ParsingRegex().Match(s);

        if (!match.Success)
        {
            return false;
        }

        if (!int.TryParse(match.Groups[0].ValueSpan, provider, out var x)
            || !int.TryParse(match.Groups[1].ValueSpan, provider, out var y))
        {
            return false;
        }

        result.X = x;
        result.Y = y;

        return true;
    }

    [GeneratedRegex(@"\(?(d+)[,|](d+)\)?")]
    private static partial Regex ParsingRegex();
}