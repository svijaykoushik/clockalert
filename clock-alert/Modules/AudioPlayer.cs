using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace ClockAlert.Modules
{
    internal class AudioPlayer
    {
        private readonly SoundPlayer audioPlayer;
        private readonly byte[] soundBytes;
        /// <summary>
        /// Instantiates the audio player to play the default sound.
        /// </summary>
        public AudioPlayer()
        {
            audioPlayer = new SoundPlayer(Properties.Resources.sound);
            MemoryStream soundStream = new MemoryStream();
            Properties.Resources.sound.CopyTo(soundStream);
            soundBytes = soundStream.ToArray();
        }

        /// <summary>
        /// Instantiates the audio player to play the specified sound.
        /// </summary>
        /// <param name="soundResource">Name of the sound fiile resource.</param>
        public AudioPlayer(UnmanagedMemoryStream soundResource)
        {
            audioPlayer = new SoundPlayer(soundResource);
            MemoryStream soundStream = new MemoryStream();
            soundResource.CopyTo(soundStream);
            soundResource.Position = 0;
            soundBytes = soundStream.ToArray();
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

        /// <summary>
        /// Get the duration of sound in Seconds
        /// </summary>
        /// <returns>Duration in seconds</returns>
        public int GetDuration()
        {
            // Based on the solution from 
            // https://stackoverflow.com/a/30711338/3207831
            int byterate = BitConverter.ToInt32(new[] { soundBytes[28], soundBytes[29], soundBytes[30], soundBytes[31] }, 0);
            int duration = (soundBytes.Length - 8) / byterate;
            return duration;
        }
    }
}
