using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPuzzle puzzle = Day7.Instance;

            Console.WriteLine($"Running puzzle: {puzzle}");
            puzzle.Run();
        }
    }
}
