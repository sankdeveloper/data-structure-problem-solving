namespace ConsoleApp1.Stack;

/*
 QUESTION:
 https://leetcode.com/problems/valid-parentheses/
 */
public class StackValidParenthesis
{
    public static void Main1(string[] args)
    {
        var str = IsValidParenthesis("()[]{}"); // true
        var str2 = IsValidParenthesis("()[]{}}"); // false
        Console.WriteLine(str);
        Console.WriteLine(str2);
        Console.ReadKey();
    }

    public static bool IsValidParenthesis(string @string)
    {
        Stack<char> stack = new();
        string leftParanthesis = "{[(";
        Dictionary<char, char> leftRightMap = new()
        {
            { ']', '[' },
            { '}', '{' },
            { ')', '(' },
        };

        foreach (var str in @string)
        {
            if (leftParanthesis.Contains(str)) // add all the left parenthesis.
            {
                stack.Push(str);
                continue;
            }

            if (stack.Count > 0)
            {
                var lastParanth = stack.Pop();
                if (leftRightMap.ContainsKey(str) && leftRightMap[str] != lastParanth)
                {
                    return false;
                }
            }
            else // all parenthasis done with matching, but there is one extra at the end.
            {
                return false;
            }
        }

        return stack.Count == 0;
    }
}

/*
Example 1:
    Input: s = "()"
    Output: true
    Example 2:

Input: s = "()[]{}"
    Output: true
    Example 3:

Input: s = "(]"
    Output: false
 */