using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Day2 : IPuzzle
{
    #region Singleton
    private static Day2 instance = null;

    private Day2() { }

    public static Day2 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Day2();
            }
            return instance;
        }
    }
    #endregion

    List<string> lines = File.ReadAllLines("day2.txt").ToList();
    int horizontal = 0;
    int depth = 0;
    int aim = 0;

    public void Run()
    {
        foreach (var line in lines)
        {
            var movement = line.Split(' ')[0];
            var units = int.Parse(line.Split(' ')[1]);

            if (movement == "forward")
            {
                horizontal += units;
                depth += aim * units;
            }
            else if (movement == "up")
                aim -= units;
            else
                aim += units;
        }

        Console.WriteLine($"Moved forward {horizontal} units.");
        Console.WriteLine($"Depth = {depth} units.");
        Console.WriteLine($"Final Value = {depth * horizontal}");
    }
}