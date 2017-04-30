﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Roulette0._0._8
{
    public class RouletteSounds
    {
        public MediaPlayer mp { get; set; }
        public SoundPlayer sp { get; set; }

        public void BackgroundLoop(string path)
        {
            sp = new SoundPlayer(path);
            
            sp.PlayLooping();
            
        }

        public void PlaySound(string path)
        {
            mp = new MediaPlayer();
            mp.Open(new Uri(path, UriKind.Relative));
            mp.Play();
        }

        public void BackgroundSoundStop()
        {
            sp.Stop();
          
        }

    }
}