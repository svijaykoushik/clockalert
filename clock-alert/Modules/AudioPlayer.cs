using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace ClockAlert.Modules
{
    internal class AudioPlayer
    {
        private readonly SoundPlayer audioPlayer;
        /// <summary>
        /// Instantiates the audio player to play the default sound.
        /// </summary>
        public AudioPlayer()
        {
            audioPlayer = new SoundPlayer(Properties.Resources.sound);
        }

        /// <summary>
        /// Instantiates the audio player to play the specified sound.
        /// </summary>
        /// <param name="soundResource">Name of the sound fiile resource.</param>
        public AudioPlayer(System.IO.UnmanagedMemoryStream soundResource)
        {
            audioPlayer = new SoundPlayer(soundResource);
        }
        /// <summary>
        /// Plays the specified sound file
        /// </summary>
        public void Play()
        {
            audioPlayer.PlaySync(); ;
        }

        /// <summary>
        /// Plays the specified sound file asynchronusly.
        /// </summary>
        public void PlayAsync()
        {
            audioPlayer.Play();
        }

        /// <summary>
        /// Stops the current playing music
        /// </summary>
        public void Stop()
        {
            audioPlayer.Stop();
        }
    }
}
