using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U.Universal
{
    public class OparationAlreadySetException : Exception
    {

        const string error = " An altern operation can only be set once";

        public OparationAlreadySetException() : base(error) { }

        public OparationAlreadySetException(string message) : base(message + error) { }

        public OparationAlreadySetException(string message, Exception inner) : base(message + error, inner) { }

    }
}
