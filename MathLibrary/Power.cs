using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class Power:BinaryOperation
    {
        protected override double EvaluateInternal(double[] values)
        {
            double result = Math.Pow(values[0], values[1]);
            return result;
        }
    }
}
