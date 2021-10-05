using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexSchoolWork
{
    class Program
    {
        // 1. checks that a string contains only a certain set of characters (in this case a-z, A-Z and 0-9). 
        private static bool q1(string text)
        {
            return Regex.IsMatch(text, @"^[\da-zA-Z]*$");
        }

        // 2. matches a string that has an  followed by zero or more b's. 
        private static bool q2(string text)
        {
            return Regex.IsMatch(text, @"^ab*$");
        }

        // 3. matches a string that has an followed by one or more b's. 
        private static bool q3(string text)
        {
            return Regex.IsMatch(text, @"^ab+$");
        }

        // 4. matches a string that has an a followed by zero or one 'b'.
        private static bool q4(string text)
        {
            return Regex.IsMatch(text, @"^ab?$");
        }

        // 5. matches a string that has an a followed by three 'b'. 
        private static bool q5(string text)
        {
            return Regex.IsMatch(text, @"^abbb$");
        }

        // 6. matches a string that has an a followed by two to three 'b'. 
        private static bool q6(string text)
        {
            return Regex.IsMatch(text, @"^ab?bb$");
        }

        // 7. finds sequences of lowercase letters joined with a underscore.
        private static void q7(string text)
        {
            MatchCollection mc = Regex.Matches(text, @"[a-z]+_[a-z]+");

            foreach (Match m in mc)
            {
                Console.WriteLine(m);
            }
        }

        // 8. finds the sequences of one upper case letter followed by lower case letters. 
        private static void q8(string text)
        {
            MatchCollection mc = Regex.Matches(text, @"[A-Z][a-z]+"); 

            foreach (Match m in mc)
            {
                Console.WriteLine(m);
            }
        }

        // 9.  matches a string that has an 'a' followed by anything, ending in 'b'. 
        private static bool q9(string text)
        {
            return Regex.IsMatch(text, @"a.*b$");
        }

        // 10.  Given a string, write a method that checks if consists of letters only and ends with period.
        // If string has more than one word, words are separated by space.
        // Expected input and output:
        // AlmostOnlyLetters("She is nice.") → true
        // AlmostOnlyLetters("true 222.") → false
        private static bool q10(string text)
        {
            return Regex.IsMatch(text, @"[a-zA-Z\s]+\.$");
        }

        // 11. Given a phone number as a string, write a method that checks if it is in the format +XX YYY-YYY-YYY.
        // Expected input and output
        // CheckPhoneNumber("+35 392-022-194") → true
        // CheckPhoneNumber("+958 28492-503") → false
        private static bool q11(string text)
        {
            return Regex.IsMatch(text, @"\+\d{2}\s\d{3}\-\d{3}\-\d{3}");
        }

        // 12. Given a string, write a method that checks if contains
        // decimal digit and if yes returns its value and position.
        // Expected input and output
        // DecimalDigitInformation("This is 9") → "Digit 9 at position 8"
        // DecimalDigitInformation("ABCdef") → "No digit found!"
        private static void q12(string text)
        {
            MatchCollection mc = Regex.Matches(text, @"\d");
            if(mc.Count == 0)
            {
                Console.WriteLine("No digit found!");
            }
            foreach(Match m in mc)
            {
                Console.WriteLine($"Digit {m.Value} at position {m.Index}.");
            }
        }

        // 13. Given a string, write a method that checks if every word begins with capital letter.
        // Expected input and output
        // EveryWordInTheString("Use Of Technology") → true
        // EveryWordInTheString("Rocket science") → false
        private static bool q13(string text)
        {
            string[] split = text.Split(' ');
            int count = 0;

            for(int i = 0; i < split.Length; i++)
            {
                if (Regex.IsMatch(split[i], @"^[A-Z]"))
                {
                    count++;
                }
            }
            return count == split.Length;
        }

        // 14. Given a string, write a method that replaces every word 'good' with 'bad'.
        // Assume that words to be replaced may consist of mixed cases (gOod, baD, etc.).
        // Expected input and output
        // ReplaceGoodWithBad("gOOd") → "good"
        // ReplaceGoodWithBad("so b@d") → "so b@d"
        private static void q14(string text)
        {
            Console.WriteLine(Regex.Replace(text, @"[gG][oO]{2}d", "bad"));
        }
        static void Main(string[] args)
        {
            // q1 tests
            Console.WriteLine(q1("/")); // false
            Console.WriteLine(q1("ao27GQ3b4b8H")); // true
            Console.WriteLine(q1("ao27GQ3b4b^H")); // false
            Console.WriteLine(q1("a 2")); // false

            Console.WriteLine();

            // q2 tests
            Console.WriteLine(q2("abbbb")); // true
            Console.WriteLine(q2("a")); // true 
            Console.WriteLine(q2("")); // false
            Console.WriteLine(q2("anbr")); // false

            Console.WriteLine();

            // q3 tests
            Console.WriteLine(q3("abbbb")); // true
            Console.WriteLine(q3("abb")); // true
            Console.WriteLine(q3("a")); // false
            Console.WriteLine(q3("abr")); // false

            Console.WriteLine();

            // q4 tests
            Console.WriteLine(q4("ab")); // true
            Console.WriteLine(q4("a")); // true
            Console.WriteLine(q4("abb")); // false
            Console.WriteLine(q4("anb")); // false

            Console.WriteLine();

            // q5 tests
            Console.WriteLine(q5("abbb")); // true
            Console.WriteLine(q5("abb")); // false 

            Console.WriteLine();

            // q6 tests
            Console.WriteLine(q6("abb")); // true 
            Console.WriteLine(q6("abbb")); // true
            Console.WriteLine(q6("ab")); // false
            Console.WriteLine(q6("anbb")); // false

            Console.WriteLine();

            // q7 tests 
            q7("aab_cdd12_-gA_a_lb_7"); // aab_ccd a_lb
            Console.WriteLine();
            q7("D_f,*&4e_op3"); // e_op

            Console.WriteLine();

            // q8 tests
            q8("Abbb237-GHDnn4n"); // Abbbb Dnn
            Console.WriteLine();
            q8("HUPjjUW"); // Pjj

            Console.WriteLine();

            // q9 tests 
            Console.WriteLine(q9("ah97crnp23tr v7pt8gf ab ab")); // true 
            Console.WriteLine(q9("ah97crnp23tr v7pt8gf ab a")); // false

            Console.WriteLine();

            // q10 tests
            Console.WriteLine(q10("She is nice.")); // true 
            Console.WriteLine(q10("true 222.")); // false

            Console.WriteLine();

            // q11 tests
            Console.WriteLine(q11("+35 392-022-194")); // true 
            Console.WriteLine(q11("+958 28492-503")); // false

            Console.WriteLine();

            // q12 tests 
            q12("This is 9"); // Digit 9 at position 8
            Console.WriteLine();
            q12("ABCdef"); // No digit found!
            Console.WriteLine();
            q12("123456789"); // Digit 1 found at position 0... 

            Console.WriteLine();

            // q13 tests 
            Console.WriteLine(q13("Use Of Technology")); // true
            Console.WriteLine(q13("Rocket science")); // false

            Console.WriteLine();

            // q14 tests 
            q14("good"); // bad
            q14("g0od"); // bad
            q14("b@d"); // so bad
            q14("get good"); // get bad
        }
    }
}
