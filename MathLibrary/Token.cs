using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class Token
    {
        internal string _tokenValue { get; }
        internal TokenType _tokenType { get;  }
        internal Token(string value,TokenType type)
        {
            _tokenValue = value;
            _tokenType = type;
        }
    }

    internal enum TokenType
    {
        symbol,
        number
    };
}
