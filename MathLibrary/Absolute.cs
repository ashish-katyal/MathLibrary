using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class Absolute : UnaryOperation
    {
        protected override double EvaluateInternal(double[] values)
        {
            return Math.Abs(values[0]);
        }
    }
}
