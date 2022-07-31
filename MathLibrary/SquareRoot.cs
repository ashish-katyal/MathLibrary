using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class SquareRoot:UnaryOperation
    {
        protected override double EvaluateInternal(double[] values)
        {
            if (values[0] < 0)
                throw new ArithmeticException(Strings.SqrtOfNegative);
            double result = Math.Sqrt(values[0]);
            return result;
        }
    }
}
