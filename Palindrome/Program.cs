using System;
using System.Linq;

namespace Palindrome
{
    /// <summary>
    /// Console app to check if input string is a palindrome.
    /// </summary>
    class Program
    {
        const string Exit = "exit";

        static void Main(string[] args)
        {
            Console.WriteLine("Lets begin:");
            var input = "";

            while (input != Exit)
            {
                input = Console.ReadLine();
                if (!string.Equals(input.ToLower(), Exit))
                {
                    var isPalindrome = IsPalindrome(input);
                    Console.WriteLine($"Palindrome: {isPalindrome.Item2}, Length: {isPalindrome.Item1}");
                }
            }
        }

        /// <summary>
        /// determines whether an string passed in is a palindrome. 
        /// Accounts for case, punctuation.
        /// </summary>
        /// <param name="input">string to check</param>
        /// <returns>true if a palindrome, and the length of input (0 if not a palindrome)</returns>
        static (int, bool) IsPalindrome(string input)
        {
            var noPuncutationInput = new string(input.ToLower().Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray());
            var reverse = new string(noPuncutationInput.Reverse().ToArray());
            var isPalindrome = noPuncutationInput == reverse;

            return (isPalindrome ? input.Length : 0, isPalindrome);
        }
    }
}
