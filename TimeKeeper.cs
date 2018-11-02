/***********************************************************************************
This file is part of Clock Alert.

    Clock Alert is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License version 3 as published by
    the Free Software Foundation.

    Clock Alert is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Clock Alert.  If not, see <http://www.gnu.org/licenses/>.
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Clock_Alert
{
    /// <summary>
    /// Performs time related operations
    /// </summary>
    class TimeKeeper
    {
        /// <summary>
        /// Checks wether it is time to ring the sound
        /// </summary>
        /// <returns>True if an hour is complete</returns>
        public bool isItTime()
        {
            if (DateTime.Now.Minute.ToString() == "0" && DateTime.Now.Second.ToString() == "0")
                return true;
            else 
                return false;
        }
    }
}
