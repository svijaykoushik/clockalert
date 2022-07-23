using System;

namespace ClockAlert.Modules
{
    internal interface ICrashReporter
    {
        void getException(Exception exception);
        void createReport();
        void sendReport();
    }
}
