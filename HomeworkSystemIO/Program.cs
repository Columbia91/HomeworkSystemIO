using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeworkSystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr;
            StreamWriter sw;

            string path = "input.txt";
            string path2 = "output.txt";

            bool check = false;
            Random rnd = new Random();

            while (!check)
            {
                try
                {
                    sr = new StreamReader(path);
                    string[] numbers = sr.ReadToEnd().Split(new char[] { ' ' });
                    sr.Close();
                    check = true;
                    sw = new StreamWriter(path2);
                    for (int i = 0; i < numbers.Length / 2; i++)
                    {
                        sw.WriteLine("{0}", int.Parse(numbers[i]) + int.Parse(numbers[i + 1]));
                    }
                    sw.Close();
                }
                catch (Exception)
                {
                    var myFile = File.Create(path);
                    myFile.Close();
                    sw = new StreamWriter(path);
                    sw.WriteLine($"{rnd.Next(100)} {rnd.Next(100)}");
                    sw.Close();
                }
            }

            path = "FibonacciNumbers.txt";
            check = false;
            int rangeA = 5;
            int rangeB = 10;
            
            while (!check)
            {
                try
                {
                    sr = new StreamReader(path);
                    string str = sr.ReadToEnd().Trim();
                    string[] numbers = str.Split(new char[] { ' ' });
                    Console.WriteLine(int.Parse(numbers[numbers.Length - 2]));
                    sr.Close();
                    check = true;
                    sw = new StreamWriter(path, true);
                    int[] fibonacciNumbers = { int.Parse(numbers[numbers.Length - 2]), int.Parse(numbers[numbers.Length - 1]) };
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        Array.Resize(ref fibonacciNumbers, fibonacciNumbers.Length + 1);
                        int index = fibonacciNumbers.Length;
                        fibonacciNumbers[index - 1] = fibonacciNumbers[index - 2] + fibonacciNumbers[index - 3];
                        sw.Write($"{fibonacciNumbers[i]} ");
                    }
                    sw.Close();
                }
                catch (Exception)
                {
                    var myFile = File.Create(path);
                    myFile.Close();
                    sw = new StreamWriter(path);
                    int[] fibonacciNumbers = { 0, 1 };
                    for (int i = fibonacciNumbers.Length; i < rnd.Next(rangeA, rangeB); i++)
                    {
                        Array.Resize(ref fibonacciNumbers, fibonacciNumbers.Length + 1);
                        fibonacciNumbers[i] = fibonacciNumbers[i - 2] + fibonacciNumbers[i - 1];
                        sw.Write($"{fibonacciNumbers[i]} ");
                    }
                    sw.Close();
                }
            }
        }
        // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34
    }
}
