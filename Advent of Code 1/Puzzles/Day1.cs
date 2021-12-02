using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


class Day1 : IPuzzle
{
    #region Singleton
    private static Day1 instance = null;

    private Day1() { }

    public static Day1 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Day1();
            }
            return instance;
        }
    }
    #endregion

    public void Run()
    {
        List<string> levels = File.ReadAllLines("input.txt").ToList();
        List<int> measurements = new List<int>();

        int count = 0;

        while (levels.Count >= 3)
        {
            measurements.Add(int.Parse(levels[0]) + int.Parse(levels[1]) + int.Parse(levels[2]));
            levels.RemoveAt(0);
        }

        for (int i = 1; i < measurements.Count; i++)
        {
            var previousMeasurement = measurements[i - 1];

            if (previousMeasurement < measurements[i])
                count++;
        }

        Console.WriteLine($"Level increased {count} times");
    }
}

