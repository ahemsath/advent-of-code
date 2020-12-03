using System;
using System.IO;
using System.Text.RegularExpressions;

namespace day2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var validPasswordCount = 0;
            var invalidCount = 0;

            using (var file = new StreamReader("./input.txt"))
            {
                var line = string.Empty;

                while ((line = file.ReadLine()) != null)
                {
                    var pwp = new PasswordWithPolicy(line);
                    if (pwp.IsValid())
                    {
                        validPasswordCount++;
                    }
                    else
                    {
                        invalidCount++;
                    }
                }

            }

            Console.WriteLine("Valid count = " + validPasswordCount + ", invalid count = " + invalidCount);
        }

    }

    class PasswordWithPolicy
    {
        int pos1;
        int pos2;
        char letter;
        string password;

        public PasswordWithPolicy(string input)
        {
            //7-8 n: gspnbfnp

            var regex = new Regex(@"(\d+)\-(\d+)\ (\w)\:\ (\w+)");
            var match = regex.Match(input);

            if (match.Success)
            {
                pos1 = int.Parse(match.Groups[1].Value);
                pos2 = int.Parse(match.Groups[2].Value);
                letter = char.Parse(match.Groups[3].Value);
                password = match.Groups[4].Value;

                //Console.WriteLine($"min = {pos1}, max={pos2}, letter={letter}, password={password}");
            }

        }

        public bool IsValid()
        {
            var chars = password.ToCharArray();

            return chars[pos1-1] == letter ^ chars[pos2-1] == letter;
        }
    }
}
