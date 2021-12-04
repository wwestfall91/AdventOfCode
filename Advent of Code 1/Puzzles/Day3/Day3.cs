using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Day3 : IPuzzle
{
    #region Singleton
    private static Day3 instance = null;

    private Day3() { }

    public static Day3 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Day3();
            }
            return instance;
        }
    }
    #endregion

    string gammaRate = "";
    string epsiloneRate = "";
    string oxygenRate = "";
    string co2Rate = "";
    public void Run()
    {
        List<string> lines = File.ReadAllLines("Day3Input.txt").ToList();

        int[] trueCount = new int[lines[0].ToCharArray().Count()];
        int currentBit = 0;

        trueCount = GetTrueBinaryCount(lines);

        foreach (var oneCount in trueCount)
        {
            if (oneCount >= lines.Count() / 2)
            {
                gammaRate += "1";
                epsiloneRate += "0";
            }
            else
            {
                gammaRate += "0";
                epsiloneRate += "1";
            }
        }

        List<string> filteredBits = lines;

        trueCount = GetTrueBinaryCount(filteredBits);

        for (int i = 0; i < trueCount.Length; i++)
        {
            float bitsCount = (float)filteredBits.Count() / 2;

            if (filteredBits.Count() == 1)
                break;

            if (trueCount[i] >= bitsCount)
                filteredBits = filteredBits.FindAll(x => x[currentBit].ToString() == "1");
            else
                filteredBits = filteredBits.FindAll(x => x[currentBit].ToString() == "0");
            currentBit++;
            trueCount = GetTrueBinaryCount(filteredBits);
        }

        oxygenRate = filteredBits.First();

        currentBit = 0;
        filteredBits = lines;

        var falseCount = GetFalseBinaryCount(filteredBits);

        for (int i = 0; i < falseCount.Length; i++)
        {
            float bitsCount = (float)filteredBits.Count() / 2;

            if (filteredBits.Count() == 1)
                break;

            if (falseCount[i] <= bitsCount)
                filteredBits = filteredBits.FindAll(x => x[currentBit].ToString() == "0");
            else
                filteredBits = filteredBits.FindAll(x => x[currentBit].ToString() == "1");
            currentBit++;
            falseCount = GetFalseBinaryCount(filteredBits);
        }
        co2Rate = filteredBits.First();

        var epsiloneDecimal = Convert.ToInt32(epsiloneRate, 2);
        var gammaDecimal = Convert.ToInt32(gammaRate, 2);
        var powerConsumption = epsiloneDecimal * gammaDecimal;

        var oxygenDecimal = Convert.ToInt32(oxygenRate, 2);
        var co2Decimal = Convert.ToInt32(co2Rate, 2);
        var lifeSupportRating = oxygenDecimal * co2Decimal;

        Console.WriteLine($"Power Consumption: {powerConsumption}");
        Console.WriteLine($"Life Support Rating: {lifeSupportRating}");
        Console.ReadKey();   
    }

    public int[] GetTrueBinaryCount(List<string> binaryList)
    {
        int currentBit = 0;
        int[] trueCount = new int[binaryList[0].ToCharArray().Count()];

        foreach (var line in binaryList)
        {
            foreach (var bit in line.ToCharArray())
            {
                if (bit == '1')
                    trueCount[currentBit] += 1;

                currentBit++;
            }
            currentBit = 0;
        }

        return trueCount;
    }

    public int[] GetFalseBinaryCount(List<string> binaryList)
    {
        int currentBit = 0;
        int[] falseCount = new int[binaryList[0].ToCharArray().Count()];

        foreach (var line in binaryList)
        {
            foreach (var bit in line.ToCharArray())
            {
                if (bit == '0')
                    falseCount[currentBit] += 1;

                currentBit++;
            }
            currentBit = 0;
        }

        return falseCount;
    }
}
