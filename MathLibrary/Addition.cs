using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class Addition: BinaryOperation
    {
        protected override double EvaluateInternal(double[] values)
        {
            double result=values[0]+values[1];
            return result;
        }
    }
}
