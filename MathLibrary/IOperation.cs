using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public interface IOperation
    {
        int OperandCount { get; }
        double Evaluate(double[] Values);
    }
}
