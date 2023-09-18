using System;

namespace Palindrom
{
    class PalindromChecker
    {
        // static void Main(string[] args) {
        //     System.Console.Write("Input line: ");
        //     string? input_string = System.Console.ReadLine();
        //     while(string.IsNullOrEmpty(input_string)) {
        //         input_string = System.Console.ReadLine();
        //     }
        //     input_string = input_string.ToLower();
        //     bool isP = userIsPalindrom(input_string, 0, input_string.Length - 1);
        //     System.Console.WriteLine(isP);
        // }

        static bool userIsPalindrom(string input_string, int first_index, int last_index)
        {
            if (first_index == last_index || input_string == "")
            {
                return true;
            }
            else
            {
                if (input_string[first_index] == input_string[last_index])
                {
                    string subString = input_string.Substring(1, last_index - 1);
                    return userIsPalindrom(subString, 0, subString.Length - 1);
                }
                return false;
            }
        }
    }
}