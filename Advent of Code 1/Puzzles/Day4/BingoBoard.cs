using System.Collections;


public class BingoBoard
{
    public string[,] board = new string[5,5];
    public int boardNumber = 0;
    public BingoBoard(Queue boardNumbers)
    {
        GenerateBoard(boardNumbers);
    }

    public void GenerateBoard(Queue boardNumbers)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                board[i, j] = boardNumbers.Dequeue().ToString();
            }
        }        
    }

    public void CheckNumber(string number)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (board[i, j] == number)
                {
                    board[i, j] = "X";
                }
            }
        }
    }

    public bool HasWon()
    {
        var count = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (board[i, j] == "X")
                {
                    count++;
                    if (count == 5)
                        return true;
                }
            }
            count = 0;
        }

        count = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (board[j, i] == "X")
                {
                    count++;
                    if (count == 5)
                        return true;
                }
            }
            count = 0;
        }

        return false;
    }
}

