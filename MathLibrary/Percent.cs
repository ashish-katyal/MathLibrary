using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class Percent:UnaryOperation
    {
        protected override double EvaluateInternal(double[] values)
        {
            double result= values[0] / 100;
            return result;
        }
    }
}
