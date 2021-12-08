using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

public class Line
{
    public Point startingPoint;
    public Point endingPoint;

    public Line(Point startingPoint, Point endingPoint)
    {
        this.startingPoint = startingPoint;
        this.endingPoint = endingPoint;
    }
}

public class Day5 : IPuzzle
{
    #region Singleton
    private static Day5 instance = null;

    private Day5() { }

    public static Day5 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Day5();
            }
            return instance;
        }
    }
    #endregion

    int[,] grid;

    public void Run()
    {
        List<string> input = File.ReadAllLines("Day5TestInput.txt").ToList();

        List<Line> lines = new List<Line>();

        Point startingPoint;
        Point endingPoint;

        int highestX = 0;
        int highestY = 0;

        int dangerousAreas = 0;

        foreach (var line in input)
        {
            startingPoint = ConvertStringToPoint(line.Split(" -> ")[0]);
            endingPoint = ConvertStringToPoint(line.Split(" -> ")[1]);

            if (startingPoint.Y == endingPoint.Y || startingPoint.X == endingPoint.X || 
               (startingPoint.X == startingPoint.Y && endingPoint.X == endingPoint.Y) ||
               (startingPoint.X == endingPoint.Y && startingPoint.Y == endingPoint.X))
            {
                if (startingPoint.X > highestX)
                    highestX = startingPoint.X;

                if (endingPoint.Y > highestY)
                    highestY = endingPoint.Y;

                lines.Add(new Line(startingPoint, endingPoint));
            }
        }

        grid = new int[highestX + 1, highestY + 1];

        foreach (var line in lines)
        {
            var distanceX = line.endingPoint.X - line.startingPoint.X;
            var distanceY = line.endingPoint.Y - line.startingPoint.Y;

            if(distanceX == distanceY)
                if (distanceX > 0 || distanceY > 0)
                    MoveDiagonalSame(line.startingPoint, line.endingPoint);
                else if (distanceX < 0 || distanceY < 0)
                    MoveDiagonalSame(line.endingPoint, line.startingPoint);
            else if(distanceX != 0 && distanceY != 0)
            {
                if (distanceX > 0 || distanceY > 0)
                    MoveDiagonalInverse(line.startingPoint, line.endingPoint);
                else if (distanceX < 0 || distanceY < 0)
                    MoveDiagonalInverse(line.endingPoint, line.startingPoint);
            }
            else if (distanceX > 0 || distanceY > 0)
                MoveInLine(line.startingPoint, line.endingPoint);
            else if (distanceX < 0 || distanceY < 0)
                MoveInLine(line.endingPoint, line.startingPoint);
        }

        for (int x = 0; x <= highestX; x++)
        {
            for (int y = 0; y <= highestY; y++)
            {
                if (grid[x, y] >= 2)
                    dangerousAreas++;
            }
        }

        Console.WriteLine($"Number of Dangerous Areas: {dangerousAreas}");

    }

    private Point ConvertStringToPoint(string point)
    {
        var x = int.Parse(point.Split(",")[0]);
        var y = int.Parse(point.Split(",")[1]);

        return new Point(x, y);
    }

    private void MoveInLine(Point startingPoint, Point endingPoint)
    {
        for (int x = startingPoint.X; x <= endingPoint.X; x++)
        {
            for (int y = startingPoint.Y; y <= endingPoint.Y; y++)
            {
                grid[x, y]++;
            }
        }
    }

    private void MoveDiagonalSame(Point startingPoint, Point endingPoint)
    {
        var numberOfMoves = (endingPoint.X - startingPoint.X) + 1;

        var x = startingPoint.X;
        var y = startingPoint.Y;

        for (int i = 0; i < numberOfMoves; i++)
        {
            grid[x, y]++;

            x++;
            y++;
        }
    }

    private void MoveDiagonalInverse(Point startingPoint, Point endingPoint)
    {
        var numberOfMoves = (endingPoint.X - startingPoint.X) + 1;

        var x = startingPoint.X;
        var y = startingPoint.Y;

        for (int i = 0; i < numberOfMoves; i++)
        {
            grid[x, y]++;

            x++;
            y--;
        }
    }
}
