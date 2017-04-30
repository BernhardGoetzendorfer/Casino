using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;

namespace Slot_Animation
{
    class Musi
    {
        public MediaPlayer player { get; set; }
        public SoundPlayer backgroundLoop { get; set; }

        public void playBackgroundSound(string path)
        {
            backgroundLoop = new SoundPlayer(path);
            backgroundLoop.PlayLooping();
        }
        public void playSound(string path) {
            player = new MediaPlayer();
            player.Open(new Uri(path, UriKind.Relative));
            player.Volume = 100;
            player.Play();
        }
        public void playbackMusic(string path) {
            if (path != null) {
                player = new MediaPlayer();
                player.Open(new Uri(path, UriKind.Relative));
                player.MediaEnded += new EventHandler(Media_Ended);
                player.Play();
                return;
            }
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            player.Position = TimeSpan.Zero;
            player.Play();
        }
    }
}
