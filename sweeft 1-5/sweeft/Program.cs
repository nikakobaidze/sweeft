using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sweeft
{
    internal class Program
    {
        public static bool sPalindrome(string text)
        {
            text = new string(text.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToLower();
            return text == new string(text.Reverse().ToArray());

        }
        public static int MinSplit(int amount)
        {
            int min_coin;
            min_coin = amount / 50 + (amount % 50) / 20 + ((amount % 50) % 20) / 10 + (((amount % 50) % 20) % 10) / 5 + (((amount % 50) % 20) % 10) % 5;

            return min_coin;
        }
        public static int NotContains(int[] array)
        {
           

            int minNumber = 1;
            while (array.Contains(minNumber))
            {
                minNumber++;
            }
            return minNumber;
        }
        public static bool IsProperly(string sequence)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in sequence)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0 || stack.Peek() != '(')
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }
        public static int CountVariants(int stairCount)
        {
            int[] dp = new int[stairCount + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= stairCount; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[stairCount];
        }
        static void Main(string[] args)
        {
            //string text = "abCdcba";
            //Console.WriteLine(sPalindrome(text));


            //int amount = 80;
            //Console.WriteLine(MinSplit(amount));

            //int[] array = { 0, 1, 2, -3, 4, -5, 6, };
            //Console.WriteLine(NotContains(array));

            //string sequence = "(()";
            //Console.WriteLine(IsProperly(sequence));

            //int stairCount = 3;
            //Console.WriteLine(CountVariants(stairCount));

            Console.ReadLine();    
        }
    }
}
