using System;
using System.Collections.Generic;
using System.IO;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            // get input from file
            var numbers = GetNumbers();

            // sort numbers
            numbers.Sort();

            // find 3 numbers that add to 2020
            foreach (var num1 in numbers)
            {
                foreach (var num2 in numbers)
                {
                    foreach (var num3 in numbers)
                    {
                        var sum = num1 + num2 + num3;
                        if (sum == 2020)
                        {
                            Console.WriteLine($"Found it: {num1} + {num2} + {num3} = 2020, product = {num1 * num2 * num3}");
                            return;
                        }
                        if (sum > 2020)
                        {
                            // short circuit search
                            break;
                        }
                    }
                }
            }
        }

        static List<int> GetNumbers()
        {
            var numList = new List<int>();
            using (var file = new StreamReader("./numbers.txt"))
            {
                var line = string.Empty;
                var num = 0;

                while ((line = file.ReadLine()) != null)
                {
                    if (int.TryParse(line, out num))
                    {
                        numList.Add(num);
                    }
                }
            }
            return numList;
        }
    }
}
