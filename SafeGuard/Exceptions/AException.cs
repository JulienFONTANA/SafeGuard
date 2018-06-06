using SafeGuard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeGuard.Exceptions
{
    public abstract class AException : Exception
    {
        public ErrorLevelEnum ErrorLevel { get; set; }

        public AException(string message, ErrorLevelEnum errorLevel) : base(message)
        {
            ErrorLevel = errorLevel;
        }
    }
}
