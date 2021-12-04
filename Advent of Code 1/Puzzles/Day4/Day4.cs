using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Day4 : IPuzzle
{
    #region Singleton
    private static Day4 instance = null;

    private Day4() { }

    public static Day4 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Day4();
            }
            return instance;
        }
    }
    #endregion

    Dictionary<BingoBoard, string> winningBoards = new Dictionary<BingoBoard, string>();

    public void Run()
    {
        List<BingoBoard> bingoBoards = new List<BingoBoard>();
        
        List<string> lines = File.ReadAllLines("Day4Input.txt").ToList();
        string[] bingoNumbers = lines[0].Split(",");
        List<string> bingoBoardNumbers = new List<string>();

        for (int i = 2; i < lines.Count(); i++)
        {
            foreach (var number in lines[i].Split(" "))
            {
                if (number != "")
                    bingoBoardNumbers.Add(number);
            }

            if (bingoBoardNumbers.Count() == 25)
            {
                bingoBoards.Add(new BingoBoard(new Queue(bingoBoardNumbers)));
                bingoBoardNumbers.Clear();
                i++;
            }
        }

        Play(bingoBoards, bingoNumbers);
    }

    public void Play(List<BingoBoard> bingoBoards, string[] bingoNumbers)
    {
        

        foreach (var number in bingoNumbers)
        {
            var winningBoardsThisRound = new List<BingoBoard>();
            foreach (var board in bingoBoards)
            {
                board.CheckNumber(number);
                if (board.HasWon())
                {
                    winningBoards.Add(board, number);
                    winningBoardsThisRound.Add(board);
                }
            }

            foreach (var board in winningBoardsThisRound)
            {
                bingoBoards.Remove(board);
            }

        }

        GameEnd(winningBoards);
    }

    public void GameEnd(Dictionary<BingoBoard, string> winningBoards)
    {
        int sum = 0;

        foreach (var number in winningBoards.Keys.First().board)
        {
            if (number != "X")
                sum += int.Parse(number);
        }

        Console.WriteLine($"We have a winner: {winningBoards.First()}");
        Console.WriteLine($"Final Score: {sum * int.Parse(winningBoards.Values.First())}");

        sum = 0;

        foreach (var number in winningBoards.Keys.Last().board)
        {
            if (number != "X")
                sum += int.Parse(number);
        }

        Console.WriteLine($"Last Board to win: {winningBoards.Last()}");
        Console.WriteLine($"Final Score: {sum * int.Parse(winningBoards.Values.Last())}");

        Console.ReadLine();
    }
}
