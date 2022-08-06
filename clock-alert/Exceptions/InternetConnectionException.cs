using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockAlert.Exceptions
{
    public class InternetConnectionException : Exception
    {
        public InternetConnectionException() : base("No Internet")
        {
        }
    }
}
