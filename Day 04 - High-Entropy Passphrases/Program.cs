// See https://aka.ms/new-console-template for more information
Console.WriteLine("Advent Of Code 2017 - Day 4");

var passwords = File.ReadAllLines(@"Resources\input.txt").ToList();

Console.WriteLine(passwords.Count(p => p.IsValid()));
Console.WriteLine(passwords.Select(p => p.RemoveAnagrams()).Count(p => p.IsValid()));

static class PasswordExtensions
{
    public static bool IsValid( this string password)
    {
        var words = password.Split(' ');

        if (words.Length == words.Distinct().Count())
            return true;
        return false;
    }

    public static string RemoveAnagrams(this string password)
    {
        var words = password.Split(' ');

        return string.Join(' ', words.Select(w => string.Concat(w.OrderBy(c => c))));
    }
}