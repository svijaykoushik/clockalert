using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockAlert.Modules
{
    internal interface ICrashReporter
    {
        void getException(Exception exception);
        void createReport();
        void sendReport();
    }
}
