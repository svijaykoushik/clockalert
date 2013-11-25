using System;
using System.Collections.Generic;
using System.Text;

namespace Clock_Alert
{
    class TimeKeeper
    {
        public bool isItTime()
        {
            if (DateTime.Now.Minute.ToString() == "0" && DateTime.Now.Second.ToString() == "0")
                return true;
            else 
                return false;
        }
    }
}
