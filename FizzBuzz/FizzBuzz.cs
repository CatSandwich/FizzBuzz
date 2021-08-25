using System;
using System.Collections.Generic;
using System.Linq;

public class FizzBuzz
{
    /// <summary> Stores all the numbers to replace with strings </summary>
    private readonly List<(int num, string val)> _values = new List<(int num, string val)>();

    public static void Main()
    {
        var fb = new FizzBuzz();
        fb.AddValue(3, "Fizz");
        fb.AddValue(5, "Buzz");
        fb.Run(100);
    }
        
    /// <summary>Adds a number to replace with a string</summary>
    /// <param name="num">The number to replace</param>
    /// <param name="val">The string to replace the number with</param>
    public void AddValue(int num, string val) => AddValue((num, val));
    /// <summary>Adds a number to replace with a string</summary>
    /// <param name="tuple">The number to be replaced and the string to replace it with</param>
    public void AddValue((int num, string val) tuple) => _values.Add(tuple);
        
    /// <summary>
    /// Runs the FizzBuzz - prints numbers 0 through <paramref name="max"/>
    /// replacing numbers with strings where configured
    /// </summary>
    /// <param name="max">The number it runs to</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="max"/> is negative</exception>
    public void Run(int max)
    {
        if (max < 0) throw new ArgumentException($"{nameof(max)} must be positive. Was {max}.");
            
        // Like one liners?
        // Console.WriteLine(string.Join('\n', Enumerable.Range(0, max + 1).Select(i => string.Join("", _values.Where(tuple => i % tuple.num == 0).Select(tuple => tuple.val).DefaultIfEmpty(i.ToString())))));

        for (var i = 0; i <= max; i++)
        {
            var output = "";
            var hasValue = false;
                
            foreach (var (num, val) in _values)
            {
                if (i % num == 0)
                {
                    output += val;
                    hasValue = true;
                }
            }
                
            if (!hasValue) output = i.ToString();
            Console.WriteLine(output);
        }
    }
}