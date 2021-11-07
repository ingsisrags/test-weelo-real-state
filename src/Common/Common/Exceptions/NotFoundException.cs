using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utilities.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message) : base(message)
        { 
        
        }
    }
}
