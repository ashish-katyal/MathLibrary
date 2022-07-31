using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class InfixToPostfix
    {
        internal static List<Token> Convert(List<Token> infixExpression, Dictionary<string, OperatorData> operatorsDataJson, Dictionary<string, KeyValuePair<IOperation, int>> operationMap)
        {
            Stack<Token> stack = new Stack<Token>();
            List<Token> postfixExpression = new List<Token>();

            foreach (Token token in infixExpression)
            {
                // If token is number, add it to postfix.
                if (token._tokenType == TokenType.number)
                    postfixExpression.Add(token);

                // If token is opening bracket, add it to stack.
                else if (token._tokenValue == Strings.OpenBracket)
                    stack.Push(token);

                // If token is closing bracket, pop stack until opening bracket is not found
                // and add popped items to postfix.
                else if (token._tokenValue == Strings.CloseBracket)
                {
                    if (stack.Count == 0)
                        throw new InvalidExpressionException(Strings.InvalidExpression);
                    while (stack.Peek()._tokenValue != Strings.OpenBracket)
                    { 
                        postfixExpression.Add(stack.Pop());

                        if (stack.Count == 0)
                            throw new InvalidExpressionException(Strings.InvalidExpression);
                    }
                    stack.Pop();
                }

                // If token is an operator, pop the stack until the precedence of token is not greater than
                // the precedence of top of the stack.
                else
                {
                    while (stack.Count() > 0)
                    {
                        if (stack.Peek()._tokenValue == Strings.OpenBracket)
                            break;
                        if (operatorsDataJson.ContainsKey("power") && 
                            token._tokenValue == operatorsDataJson["power"].Symbol && 
                            stack.Peek()._tokenValue == operatorsDataJson["power"].Symbol)
                            break;
                        if (operationMap[token._tokenValue].Value > operationMap[stack.Peek()._tokenValue].Value)
                            break;
                        else
                        {
                            postfixExpression.Add(stack.Pop());
                        }
                    }
                    stack.Push(token);
                }
            }

            // Empty stack, add all items in postfix.
            while (stack.Count() > 0)
            {
                postfixExpression.Add(stack.Pop());
            }

            return postfixExpression;
        }
    }
}
