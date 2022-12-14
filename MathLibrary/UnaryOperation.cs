using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public abstract class UnaryOperation: IOperation
    {
        public int OperandCount { get; }
        public UnaryOperation()
        {
            OperandCount = 1;
        }
        public double Evaluate(double[] values)
        {
            if (OperandCount != values.Length)
                throw new InvalidExpressionException(Strings.OperandCountNotValid);

            return EvaluateInternal(values);
        }

        protected abstract double EvaluateInternal(double[] values);   
    }
}
