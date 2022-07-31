using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class Negate:UnaryOperation
    {
        protected override double EvaluateInternal(double[] values)
        {
            double result = -1*values[0];
            return result;
        }
    }
}
