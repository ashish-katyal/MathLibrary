using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class Division:BinaryOperation
    {
        protected override double EvaluateInternal(double[] values)
        {
            if (values[1] == 0)
                throw new DivideByZeroException(Strings.DivideByZero);
            double result = values[0] / values[1];
            return result;
        }
    }
}
