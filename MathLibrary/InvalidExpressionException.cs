using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException()
        { }
        public InvalidExpressionException(string message):base(message)
        { }
        public InvalidExpressionException(string message, Exception inner):base(message, inner)
        { }
    }
}
