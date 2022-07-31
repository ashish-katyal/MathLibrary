using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class Tokenizer
    {
        internal static List<Token> GetTokens(string expression, Dictionary<string, KeyValuePair<IOperation, int>> operationMap)
        {
            List<Token> infixExpression = new List<Token>();
            int index = 0;
            while (index < expression.Length)
            {
                // If '(' is present at index, add it to infix.
                if (char.ToString(expression[index]) == Strings.OpenBracket)
                    infixExpression.Add(new Token(char.ToString(expression[index++]), TokenType.symbol));

                // If ')' is present at index, add it to infix. 
                else if (char.ToString(expression[index]) == Strings.CloseBracket)
                    infixExpression.Add(new Token(char.ToString(expression[index++]), TokenType.symbol));

                // If a digit or decimal is present.
                else if ((expression[index] >= '0' && expression[index] <= '9') || expression[index] == '.')
                {
                    string token = string.Empty;
                    // While digits are available, take them as single token.
                    while (index < expression.Length && ((expression[index] >= '0' && expression[index] <= '9') || expression[index] == '.'))
                    {
                        token += expression[index++];
                    }

                    infixExpression.Add(new Token(token, TokenType.number));
                }

                // If an operator is present, check the list of operators to identify 
                // which operator is it.
                else
                {
                    string longestSymbol=string.Empty;
                    int jumpToIndex=index;

                    // Checking each operator from all the operators. 
                    foreach (string symbol in operationMap.Keys)
                    {
                        int i, j;
                        for (i = 0, j = index; i < symbol.Length; i++, j++)
                        {
                            if (j >= expression.Length || symbol[i] != expression[j])
                            {
                                break;
                            }
                        }
                        if (i == symbol.Length && symbol.Length>longestSymbol.Length)
                        {
                            longestSymbol = symbol;
                            jumpToIndex = j;
                        }
                    }
                    if (jumpToIndex == index)
                        throw new InvalidExpressionException(Strings.InvalidOperator);
                    index = jumpToIndex;
                    infixExpression.Add(new Token(longestSymbol, TokenType.symbol));
                }

            }

            return infixExpression;
        }
    }
}
