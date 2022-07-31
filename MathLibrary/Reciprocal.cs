using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class Reciprocal:UnaryOperation
    {
        protected override double EvaluateInternal(double[] values)
        {
            if(values[0] == 0)
                throw new DivideByZeroException(Strings.DivideByZero);
            double result = 1/values[0];
            return result;
        }
    }
}
