using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class Day6 : IPuzzle
{
    #region Singleton
    private static Day6 instance = null;

    private Day6() { }

    public static Day6 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Day6();
            }
            return instance;
        }
    }
    #endregion

    public void Run()
    {
        string input = File.ReadAllText("Day6Input.txt");

        long[] fishCount = new long[9];
        

        for (long i = 0; i < input.Split(",").Length; i++)
        {
            long fish = int.Parse(input.Split(",")[i]);

            fishCount[fish]++;
        }
        for (long i = 0; i < 256; i++)
        {
            long totalCount = 0;
            long newFish = 0;
            for (int j = 0; j < 9; j++)
            {
                int nextIndex = j - 1;

                if (nextIndex < 0)
                    newFish = fishCount[j];
                else
                {
                    fishCount[nextIndex] = fishCount[j];
                    fishCount[j] = 0;
                }
            }

            fishCount[6] += newFish;
            fishCount[8] = newFish;

            foreach (var count in fishCount)
            {
                totalCount += count;
            }

            Console.WriteLine($"Day {i + 1} - Fish: {totalCount}");
        }

        
    }
}

