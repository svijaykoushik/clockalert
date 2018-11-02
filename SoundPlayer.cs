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
using System.Media;

namespace Clock_Alert
{
    /// <summary>
    /// Audio player used for playing sounds
    /// </summary>
    class AudioPlayer
    {
        private SoundPlayer audioPlayer;
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
            audioPlayer=new SoundPlayer(soundResource);
        }
        /// <summary>
        /// Plays the specified sound file
        /// </summary>
        public void play()
        {
            audioPlayer.PlaySync(); ;
        }

        /// <summary>
        /// Plays the specified sound file asynchronusly.
        /// </summary>
        public void playAsynch()
        {
            audioPlayer.Play();
        }
    }
}
