using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.Exceptions
{
    public class AlreadyExistException : Exception
    {
        // Constructors
        public AlreadyExistException() : base()
        {
        }

        public AlreadyExistException(string message) : base(message)
        {
        }

        public AlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
