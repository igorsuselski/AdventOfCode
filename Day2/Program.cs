using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        private static int count;
        private static int countTwoPairs;
        private static int countTreePairs;
        private static bool hasTwo = false;
        private static bool hasThree = false;
        private static List<string> Items;

        static void Main(string[] args)
        {
            string filePath = @"d:\Users\Igor\source\repos\AdventOfCode2018\Day2\PuzzleTwo.txt";

            //Part1
            Console.WriteLine("1. Part one:\nPress enter...");

            using (StreamReader sr = File.OpenText(filePath))
            {
                string txtLine = string.Empty;
                Items = new List<string>();

                while ((txtLine = sr.ReadLine()) != null)
                {
                    CountPairsCharInLine(txtLine);
                    Console.WriteLine($"{txtLine} [ {countTwoPairs} | {countTreePairs} ] ");
                    Items.Add(txtLine);
                }
            }

            int CheckSum = countTwoPairs * countTreePairs;
            Console.WriteLine($"\nCheckSum: [ {CheckSum.ToString()} ] ");
            Console.ReadLine();
            Console.WriteLine("----------------------------------------------------------|");

            //Part2
            Console.WriteLine("2. Part two");
            Console.ReadLine();

            int closestMatch = 25;
            bool exit = false;

            foreach (var element in Items)
            {
                foreach (var index in Items)
                {
                    if (closestMatch == TotalCommonLetters(element, index))
                    {
                        Console.WriteLine($"Clossest match IDs found: {element} : {index}");
                        string match = CommonCharacters(element, index);
                        Console.WriteLine($"Common letters between the two correct box IDs are: [ {match} ]");
                        exit = true;
                        break;
                    }
                    if (exit) break;
                    count++;
                }
            }

            Console.ReadLine();
        }

        private static void CountPairsCharInLine(string line)
        {
            count = 0;
            HashSet<char> counted = new HashSet<char>();

            foreach (var character in line)
            {
                if (!counted.Contains(character))
                {
                    count = line.Count(l => l == character);
                    switch (count)
                    {
                        case 2:
                            hasTwo = true;
                            break;
                        case 3:
                            hasThree = true;
                            break;
                    }
                    counted.Add(character);
                    count = 0;
                }
                count = 0;
            }

            if (hasTwo)
            {
                countTwoPairs++;
            }
            if (hasThree)
            {
                countTreePairs++;
            }
            hasTwo = false;
            hasThree = false;
        }

        private static int TotalCommonLetters(string present, string target)
        {
            return Enumerable.Range(0, Math.Min(present.Length, target.Length))
                             .Count(i => present[i] == target[i]);
        }

        private static string CommonCharacters(string a, string b)
        {
            string result = "";
            foreach (char letter in a)
            {
                if (b.Contains(letter))
                    result += letter;
            }
            return result;
        }
    }
}
