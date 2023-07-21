using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a piece of text:");
            string userInput = Console.ReadLine();

            int wordCount = CountWords(userInput);
            Console.WriteLine($"Word Count: {wordCount}");

            var emails = FindEmailAddresses(userInput);
            if (emails.Length > 0)
            {
                Console.WriteLine("Email Addresses:");
                foreach (var email in emails)
                {
                    Console.WriteLine(email);
                }
            }
            else
            {
                Console.WriteLine("No email addresses found.");
            }

            var mobileNumbers = ExtractMobileNumbers(userInput);
            if (mobileNumbers.Length > 0)
            {
                Console.WriteLine("Mobile Numbers:");
                foreach (var number in mobileNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("No mobile numbers found.");
            }

            Console.WriteLine("Enter a custom regular expression:");
            string customRegexPattern = Console.ReadLine();
            var customRegexMatches = FindCustomRegexMatches(userInput, customRegexPattern);
            if (customRegexMatches.Length > 0)
            {
                Console.WriteLine("Custom Regex Matches:");
                foreach (var match in customRegexMatches)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine("No matches found for the custom regular expression.");
            }
        }

        static int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        static string[] FindEmailAddresses(string text)
        {
            string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            var matches = Regex.Matches(text, pattern);
            string[] emails = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                emails[i] = matches[i].Value;
            }
            return emails;
        }

        static string[] ExtractMobileNumbers(string text)
        {
            string pattern = @"\b\d{10}\b";
            var matches = Regex.Matches(text, pattern);
            string[] mobileNumbers = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                mobileNumbers[i] = matches[i].Value;
            }
            return mobileNumbers;
        }

        static string[] FindCustomRegexMatches(string text, string customRegexPattern)
        {
            var matches = Regex.Matches(text, customRegexPattern);
            string[] results = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                results[i] = matches[i].Value;
            }
            return results;
        }
    }
}