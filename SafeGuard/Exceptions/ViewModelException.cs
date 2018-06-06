using SafeGuard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeGuard.Exceptions
{
    public class ViewModelException : AException
    {
        public ViewModelException(string msg, ErrorLevelEnum errorLevel) : base(msg, errorLevel)
        {
        }
    }
}
