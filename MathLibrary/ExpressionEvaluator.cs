using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

namespace MathLibrary
{
    public class ExpressionEvaluator
    {
        Dictionary<string, KeyValuePair<IOperation, int>> _operationMap;
        Dictionary<string, OperatorData> _operatorsDataJson;
        public ExpressionEvaluator()
        {
            const string jsonPath = "SymbolPrecedence.json";    
            _operatorsDataJson = JsonConvert.DeserializeObject<Dictionary<string, OperatorData>>(File.ReadAllText(jsonPath));

            _operationMap = new Dictionary<string, KeyValuePair<IOperation, int>>();

            _operationMap.Add(_operatorsDataJson["power"].Symbol,
                new KeyValuePair<IOperation, int>(new Power(),
                _operatorsDataJson["power"].Precedence));

            _operationMap.Add(_operatorsDataJson["multiply"].Symbol,
                new KeyValuePair<IOperation, int>(new Multiplication(),
                _operatorsDataJson["multiply"].Precedence));

            _operationMap.Add(_operatorsDataJson["divide"].Symbol,
                new KeyValuePair<IOperation, int>(new Division(),
                _operatorsDataJson["divide"].Precedence));

            _operationMap.Add(_operatorsDataJson["add"].Symbol,
                new KeyValuePair<IOperation, int>(new Addition(),
                _operatorsDataJson["add"].Precedence));

            _operationMap.Add(_operatorsDataJson["subtract"].Symbol,
                new KeyValuePair<IOperation, int>(new Subtraction(),
                _operatorsDataJson["subtract"].Precedence));

            _operationMap.Add(_operatorsDataJson["negate"].Symbol,
                new KeyValuePair<IOperation, int>(new Negate(),
                _operatorsDataJson["negate"].Precedence));

            _operationMap.Add(_operatorsDataJson["squareRoot"].Symbol,
                new KeyValuePair<IOperation, int>(new SquareRoot(),
                _operatorsDataJson["squareRoot"].Precedence));

            _operationMap.Add(_operatorsDataJson["reciprocal"].Symbol,
                new KeyValuePair<IOperation, int>(new Reciprocal(),
                _operatorsDataJson["reciprocal"].Precedence));

            _operationMap.Add(_operatorsDataJson["naturalLog"].Symbol,
                new KeyValuePair<IOperation, int>(new NaturalLog(),
                _operatorsDataJson["naturalLog"].Precedence));

            _operationMap.Add(_operatorsDataJson["logBase10"].Symbol,
                new KeyValuePair<IOperation, int>(new LogBase10(),
                _operatorsDataJson["logBase10"].Precedence));

            _operationMap.Add(_operatorsDataJson["absolute"].Symbol,
                new KeyValuePair<IOperation, int>(new Absolute(),
                _operatorsDataJson["absolute"].Precedence));

            _operationMap.Add(_operatorsDataJson["percent"].Symbol,
                new KeyValuePair<IOperation, int>(new Percent(),
                _operatorsDataJson["percent"].Precedence));
        }


        public double Evaluate(string expression)
        {
            List<Token> infixExpression=Tokenizer.GetTokens(expression,_operationMap);
            List<Token> postfixExpression=InfixToPostfix.Convert(infixExpression,_operatorsDataJson,_operationMap);

            Stack<double> evaluator=new Stack<double>();

            foreach(Token token in postfixExpression)
            {
                // If token is a number, push in stack.
                if(token._tokenType==TokenType.number)
                {
                    evaluator.Push(Double.Parse(token._tokenValue));
                }

                // If token is an operator, check its operand count, pop that many numbers
                // from stack, evaluate them and push the result in stack again.
                else
                {
                    int operandCount = _operationMap[token._tokenValue].Key.OperandCount;

                    double[] values=new double[operandCount];
                    for(int i=0; i<operandCount; i++)
                    {
                        if (evaluator.Count() == 0)
                            throw new InvalidExpressionException(Strings.InvalidOperands);
                        values[operandCount - i - 1] = evaluator.Pop();
                    }
                    double result = _operationMap[token._tokenValue].Key.Evaluate(values);
                    evaluator.Push(result);
                }
            }
            if (evaluator.Count() !=1 )
                throw new InvalidExpressionException(Strings.InvalidExpression);
            return evaluator.Peek();
        }

        public void RegisterCustomOperation(string key,IOperation Operation)
        {
            if (Operation.OperandCount < 1)
                throw new Exception(Strings.OperandCountInvalid);
            _operationMap[_operatorsDataJson[key].Symbol] = new KeyValuePair<IOperation, int>(Operation, _operatorsDataJson[key].Precedence);
        }
    }
}
