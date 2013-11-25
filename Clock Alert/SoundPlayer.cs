using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace Clock_Alert
{
    class AudioPlayer
    {
        private SoundPlayer audioPlayer;
        public AudioPlayer()
        {
            audioPlayer = new SoundPlayer(Properties.Resources.sound);
        }
        public AudioPlayer(string path)
        {
            audioPlayer=new SoundPlayer(path);
        }
        public void play()
        {
            audioPlayer.PlaySync(); ;
        }
    }
}
