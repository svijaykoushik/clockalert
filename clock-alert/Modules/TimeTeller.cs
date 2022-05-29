using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace ClockAlert.Modules
{
    internal class TimeTeller
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
        public void Talk(string content)
        {
            speaker.SpeakAsync(content);
        }
    }
}
