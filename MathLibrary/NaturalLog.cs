using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class NaturalLog : UnaryOperation
    {
        protected override double EvaluateInternal(double[] values)
        {
            if (values[0] <= 0)
                throw new ArithmeticException(Strings.InvalidInput);
            return Math.Log(values[0]);
        }
    }
}
