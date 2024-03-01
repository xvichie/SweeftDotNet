namespace Algos
{
    class Program
    {
        static void Main()
        {
            string palindromeString = "aba";
            int minSplitInt = 225;
            int[] notContainsArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string properlySequnce = "(()())";
            int countVariantsStairs = 20;

            Console.WriteLine("#1 sPalindrome: " + sPalindrome(palindromeString));
            Console.WriteLine("#2 minSplit: " + MinSplit(minSplitInt));
            Console.WriteLine("#3 NotContains: " + NotContains(notContainsArray));
            Console.WriteLine("#4 isProperly: " + IsProperly(properlySequnce));
            Console.WriteLine("#5 CountVariants: " + CountVariants(countVariantsStairs));
        }

        #region (1) sPalindrome

        public static bool sPalindrome(string text)
        {
            bool result = true;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != text[text.Length - i - 1])
                {
                    result = false; break;
                }
            }
            return result;
        }
        #endregion

        #region (2) MinSplit
        public static int MinSplit(int amount)
        {
            List<int> coins = new List<int> { 1, 5, 10, 20, 50 };
            int[] dp = new int[amount + 1];

            for (int i = 1; i <= amount; i++)
            {
                dp[i] = amount + 1;
            }

            dp[0] = 0;

            for (int i = 1; i <= amount; i++)
            {
                foreach (int coin in coins)
                {
                    if (i - coin >= 0)
                    {
                        dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                    }
                }
            }

            return dp[amount] == amount + 1 ? -1 : dp[amount];
        }
        #endregion

        #region (3) NotContains
        public static int NotContains(int[] numbers)
        {
            int arrayLen = numbers.Length;
            bool[] present = new bool[arrayLen + 2];

            foreach (int num in numbers)
            {
                if (num > 0 && num <= arrayLen)
                {
                    present[num] = true;
                }
            }

            for (int i = 1; i <= arrayLen + 1; i++)
            {
                if (!present[i])
                {
                    return i;
                }
            }

            return -1;
        }
        #endregion

        #region (4) IsProperly
        public static bool IsProperly(string sequence)
        {
            bool result = true;

            Stack<char> stack = new Stack<char>();

            foreach (char ch in sequence)
            {
                if (ch == '(')
                {
                    stack.Push(ch);
                }
                else if (ch == ')')
                {
                    if (stack.Count == 0 || stack.Pop() != '(')
                    {
                        return false;
                    }
                }
            }

            if (stack.Count != 0) result = false;

            return result;
        }
        #endregion

        #region (5) CountVariants
        public static int CountVariants(int stairCount)
        {
            int[] dp = new int[stairCount + 2];

            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= stairCount; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[stairCount];
        }
        #endregion
    }
}