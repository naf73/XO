using System;

namespace XO
{
    class XOException : Exception
    {
        public XOException(string message) : base(message) { }
    }
}
