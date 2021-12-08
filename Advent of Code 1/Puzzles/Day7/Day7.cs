using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class Day7 : IPuzzle
{
    #region Singleton
    private static Day7 instance = null;

    private Day7() { }

    public static Day7 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Day7();
            }
            return instance;
        }
    }
    #endregion

    public void Run()
    {
        string input = File.ReadAllText("Day7Input.txt");
        List<int> horizontalPositions = new List<int>();
        int halfIndex = 0;
        float bestPosition = 0;

        for (int i = 0; i < input.Split(",").Length; i++)
        {
            horizontalPositions.Add(int.Parse(input.Split(",")[i]));
        }

        halfIndex = horizontalPositions.Count() / 2;

        horizontalPositions.Sort();

        if (horizontalPositions.Count() % 2 == 0)
        {
            bestPosition = (horizontalPositions[(horizontalPositions.Count()/2) - 1] + horizontalPositions[(horizontalPositions.Count()/2)])/2.0F;
        }
        else
        {
            bestPosition = horizontalPositions[(horizontalPositions.Count()/2)];
        }

        double FuelRequired = 0;

        foreach (var position in horizontalPositions)
        {
            FuelRequired += Math.Abs(position - bestPosition);
        }

        Console.WriteLine($"Best Location = {bestPosition}. Fuel Used = {FuelRequired}");
    }
}

