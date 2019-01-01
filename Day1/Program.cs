using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part 1
            Console.WriteLine("1. Part one\nPress enter to open Frequencies .txt file");
            Console.ReadLine();

            string filePath = @"d:\Users\Igor\source\repos\AdventOfCode2018\Day1\Puzzle.txt";
            List<int> txtItems = new List<int>();
            int firstPuzzleResult = 0;
            int countItr = 0;

            using (StreamReader sr = File.OpenText(filePath))
            {
                string txtValue = string.Empty;

                while ((txtValue = sr.ReadLine()) != null)
                {
                    int value = Convert.ToInt32(txtValue);
                    firstPuzzleResult += value;
                    txtItems.Add(value);
                    Console.WriteLine($"[{txtValue}], ");
                    countItr++;
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine($"Total lines: {countItr}");
            Console.WriteLine($"Total frequency is: {firstPuzzleResult.ToString()}");
            Console.WriteLine("--------------------------------------------------------------------|");

            //Part 2
            Console.WriteLine("2. Part two\nFind the first duplicate frequency");
            Console.ReadLine();

            HashSet<int> values = new HashSet<int>();
            bool duplicateFound = false;
            int secoundPuzzleResult = 0;
            int cicles = 0;
            countItr = 0;
            var time = new Stopwatch();

            while (!duplicateFound)
            {
                time.Start();
                foreach (var item in txtItems)
                {
                    secoundPuzzleResult += item;
                    if (values.Contains(secoundPuzzleResult))
                    {
                        duplicateFound = true;
                        break;
                    }
                    values.Add(secoundPuzzleResult);
                    countItr++;
                }
                cicles++;
            }

            time.Stop();
            Console.WriteLine($"Duplicate frequency found : [[{secoundPuzzleResult}]]");
            Console.WriteLine("Number of <Set> iterations: " + countItr);
            Console.WriteLine("Number of Cicles elapsed: " + cicles);
            Console.WriteLine("Total time elapsed: " + time.ElapsedMilliseconds + " millisecounds");
            Console.ReadLine();
        }
    }
}
