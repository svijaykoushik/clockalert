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
using System.Speech.Synthesis;

namespace Clock_Alert
{
    class TimeTeller
    {
        /// <summary>
        /// The Speech object to speak time.
        /// </summary>
        private SpeechSynthesizer speaker;

        /// <summary>
        /// Initialize the speech to speak time.
        /// </summary>
        public TimeTeller()
        {
            speaker = new SpeechSynthesizer();
        }

        /// <summary>
        /// Talks the provided content via speech.
        /// </summary>
        /// <param name="content">Content of the speech.</param>
        public void talk(string content)
        {
            speaker.SpeakAsync(content);
        }
    }
}