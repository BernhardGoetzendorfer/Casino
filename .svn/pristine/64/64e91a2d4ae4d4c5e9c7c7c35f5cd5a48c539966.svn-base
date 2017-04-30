using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Threading;
using Datenschicht;
using Tastatur;

namespace Slot_Animation
{
    /// <summary>
    /// Interaktionslogik für SlotMachine_Final.xaml
    /// </summary>
    public partial class SlotMachine_Final : Window
    {
        List<tblHighscore> highList = new List<tblHighscore>();
        dbCasino_IN19Entities db = new dbCasino_IN19Entities();
        
        public int Guthaben { get; set; }
        public int Einsatz { get; set; }
        public int Highscore { get; set; }

        public double Walze1 { get; set; }
        public double Walze2 { get; set; }
        public double Walze3 { get; set; }

        bool mute = true;
        Musi musi = new Musi();

        DispatcherTimer Animationbeenden = new DispatcherTimer();
        DispatcherTimer Automatik = new DispatcherTimer();
        TimeSpan Automatikzeit = new TimeSpan(0, 0, 0, 12, 0);

        Random rnd = new Random();
        RectAnimation slot1_animation, slot2_animation, slot3_animation;
        Storyboard slot1_storyboard, slot2_storyboard, slot3_storyboard;
        const int duration = 750;
        int sessionID;
        public SlotMachine_Final(GlobaleVariablen SessionID) : this()
        {
            sessionID = SessionID.SessionSpielID;
            HighscoreTop3();
        }
        public SlotMachine_Final()
        {
            InitializeComponent();
            InitializeAnimation();

            musi.playBackgroundSound("Resources/bg.wav");

            Guthaben = 500;
            lbGuthaben.Content = Guthaben;

            Animationbeenden.Interval = new TimeSpan(0, 0, 0, 7, 45);
            Animationbeenden.Tick += Animationbeenden_Tick;

            Automatik.Interval = new TimeSpan(0, 0, 0, 8, 0);
            Automatik.Tick += Automatik_Tick;
        }

        private void Automatik_Tick(object sender, EventArgs e)
        {
            lbGuthaben.Content = Guthaben;
            lbHighscore.Content = Highscore;
            if (Walze1 == Walze2 && Walze2 == Walze3)
            {
                musi.playSound("Resources/cs.wav");
            }
            if (Guthaben < Einsatz)
            {
                Automatik.Stop();
                System.Windows.MessageBox.Show("Sie haben nicht genug Guthaben");
                bteinsatzminus.IsEnabled = true;
                bteinsatzplus.IsEnabled = true;
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = true;

            }
            else if (Guthaben > 0 && Einsatz > 0)
            {

                
                Guthaben = (Guthaben <= 0) ? 0 : Guthaben - Einsatz;
                lbGuthaben.Content = Guthaben;

                bteinsatzminus.IsEnabled = false;
                bteinsatzplus.IsEnabled = false;
                btnStart.IsEnabled = false;
                btnAuto.IsEnabled = false;

                BeginAnimation();
                Automatik.Start();

            }
            else if (Einsatz <= 0)
            {
                Automatik.Stop();
                System.Windows.MessageBox.Show("Wählen Sie einen Einsatz");
                bteinsatzminus.IsEnabled = true;
                bteinsatzplus.IsEnabled = true;
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = true;
            }

            else if (Guthaben == 0)
            {
                Automatik.Stop();
                System.Windows.MessageBox.Show("Sie haben kein Guthaben");
                bteinsatzminus.IsEnabled = true;
                bteinsatzplus.IsEnabled = true;
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = true;
            }


        }

        private void Animationbeenden_Tick(object sender, EventArgs e)
        {
            bteinsatzminus.IsEnabled = true;
            bteinsatzplus.IsEnabled = true;
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = true;
            btnAuto.IsEnabled = true;
            if (Walze1 == Walze2 && Walze2 == Walze3) {
                musi.playSound("Resources/cs.wav");
            }

            lbHighscore.Content = Highscore;
            Animationbeenden.Stop();
            Animationbeenden.Interval = new TimeSpan(0, 0, 0, 7,45);

        }

        private void InitializeAnimation()
        {
            ResetAnimation();           
        }

        private void ResetAnimation()
        {
          

            double symbol1 = rnd.Next(0, 4) * 0.25;
            double symbol2 = rnd.Next(0, 4) * 0.25;
            double symbol3 = rnd.Next(0, 4) * 0.25;
            if (symbol1 == symbol2)
            {
                symbol3 = symbol2;
            }
            else if (symbol1 != symbol2)
            {
                symbol3 = rnd.Next(0, 4) * 0.25;
            }
            Walze1 = symbol1;
            Walze2 = symbol2;
            Walze3 = symbol3;
           

            slot1_animation = new RectAnimation()
            {
                To = new Rect(0, 2, 1, 1),
                RepeatBehavior = new RepeatBehavior(4 + symbol1),
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, duration))
            };

            slot2_animation = new RectAnimation()
            {
                To = new Rect(0, 2, 1, 1),
                RepeatBehavior = new RepeatBehavior(6 + symbol2),
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, duration))
            };

            slot3_animation = new RectAnimation()
            {
                To = new Rect(0, 2, 1, 1),
                RepeatBehavior = new RepeatBehavior(8 + symbol3),
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, duration))
            };
            

            if (symbol1 == symbol2 && symbol2 == symbol3)
            {
                if (symbol3 == 0)
                {
                    Guthaben = Guthaben + Einsatz;
                    Highscore = Highscore + (Einsatz * 15);
                }
                else if (symbol3 == 0.25)
                {
                    Guthaben = Guthaben + Einsatz;
                    Highscore = Highscore + (Einsatz * 20);
                }
                else if (symbol3 == 0.5)
                {
                    Guthaben = Guthaben + Einsatz;
                    Highscore = Highscore + (Einsatz * 10);
                }
                else if (symbol3 == 0.75)
                {
                    Guthaben = Guthaben + Einsatz;
                    Highscore = Highscore + (Einsatz * 5);
                }
                //if (symbol3 == 0)
                //    Debug.WriteLine("BAR gewonnen");
                    
                //else if (symbol3 == 0.25)
                //    Debug.WriteLine("KIRSCHE gewonnen");
                //else if (symbol3 == 0.5)
                //    Debug.WriteLine("MELONE gewonnen");
                //else if (symbol3 == 0.75)
                //    Debug.WriteLine("7 gewonnen");

                //Debugger.Break();
            }
        }

        private void BeginAnimation()
        {
            grid1.Children.Remove(this.slot1);
            grid1.Children.Remove(this.slot2);
            grid1.Children.Remove(this.slot3);

            ResetAnimation();

            Border slot1 = CreateSlot();
            Border slot2 = CreateSlot2();
            Border slot3 = CreateSlot2();

            grid1.Children.Add(slot1);
            Grid.SetColumn(slot1, 1); Grid.SetRow(slot1, 4);
            grid1.Children.Add(slot2);
            Grid.SetColumn(slot2, 4); Grid.SetRow(slot2, 4);
            grid1.Children.Add(slot3);
            Grid.SetColumn(slot3, 7); Grid.SetRow(slot3, 4);

            slot1_storyboard = new Storyboard()
            {
                Children = { slot1_animation },
            };
            slot2_storyboard = new Storyboard()
            {
                Children = { slot2_animation }
            };
            slot3_storyboard = new Storyboard()
            {
                Children = { slot3_animation }
            };

            Storyboard.SetTargetProperty(slot1_animation, new PropertyPath("Background.(ImageBrush.Viewport)"));
            Storyboard.SetTargetProperty(slot2_animation, new PropertyPath("Background.(ImageBrush.Viewport)"));
            Storyboard.SetTargetProperty(slot3_animation, new PropertyPath("Background.(ImageBrush.Viewport)"));

            slot1.BeginStoryboard(slot1_storyboard);
            slot2.BeginStoryboard(slot2_storyboard);
            slot3.BeginStoryboard(slot3_storyboard);
        }

        private void einsatzerhöhen(object sender, RoutedEventArgs e)
        {
            if (Einsatz >= 20)
            {
                bteinsatzplus.IsEnabled = false;
                lbEinsatz.Content = Einsatz;
            }
            else
            {
                bteinsatzminus.IsEnabled = true;
                Einsatz = Einsatz + 1;
                lbEinsatz.Content = Einsatz;
            }
        }

        private void einsatzsenken(object sender, RoutedEventArgs e)
        {
            if (Einsatz <= 0)
            {
                bteinsatzminus.IsEnabled = false;
                lbEinsatz.Content = Einsatz;
            }
            else
            {
                bteinsatzplus.IsEnabled = true;
                Einsatz = Einsatz - 1;
                lbEinsatz.Content = Einsatz;
            }
        }

        private Border CreateSlot()
        {
            return new Border()
            {
                Height = 840,
                Width = 230,
                Background = new ImageBrush()
                {
                    ImageSource = LoadBitmapFromResource("Resources/walze.png"),
                    Viewport = new Rect(0, 1, 1, 1),
                    TileMode = TileMode.Tile
                }
            };
        }

        private void Autostart(object sender, RoutedEventArgs e)
        {
            if (Guthaben < Einsatz)
            {

                System.Windows.MessageBox.Show("Sie haben nicht genug Guthaben");

            }
            else if (Guthaben > 0 && Einsatz > 0)
            {


                Guthaben = (Guthaben <= 0) ? 0 : Guthaben - Einsatz;
                lbGuthaben.Content = Guthaben;

                bteinsatzminus.IsEnabled = false;
                bteinsatzplus.IsEnabled = false;
                btnStart.IsEnabled = false;
                btnAuto.IsEnabled = false;
                

                BeginAnimation();
                Automatik.Start();

            }
            else if (Einsatz <= 0)
            {
                System.Windows.MessageBox.Show("Wählen Sie einen Einsatz");
            }

            else if (Guthaben == 0)
            {
                System.Windows.MessageBox.Show("Sie haben kein Guthaben");
            }
        }

        private void automatikstop(object sender, RoutedEventArgs e)
        {
            Automatik.Stop();
            bteinsatzminus.IsEnabled = true;
            bteinsatzplus.IsEnabled = true;
            btnStart.IsEnabled = true;
            btnAuto.IsEnabled = true;
        }

        private Border CreateSlot2()
        {
            return new Border()
            {
                Height = 840,
                Width = 230,
                Background = new ImageBrush()
                {
                    ImageSource = LoadBitmapFromResource("Resources/walze.png"),
                    Viewport = new Rect(0, 1, 1, 1),
                    TileMode = TileMode.Tile
                }
            };
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (Guthaben < Einsatz)
            {

                System.Windows.MessageBox.Show("Sie haben nicht genug Guthaben");

            }
            else if (Guthaben > 0 && Einsatz > 0)
            {
                

                Guthaben = (Guthaben <= 0) ? 0 : Guthaben - Einsatz;
                lbGuthaben.Content = Guthaben;

                bteinsatzminus.IsEnabled = false;
                bteinsatzplus.IsEnabled = false;
                btnStart.IsEnabled = false;
                btnAuto.IsEnabled = false;
                btnStop.IsEnabled = false;

                BeginAnimation();
                Animationbeenden.Start();
                
            }
            else if (Einsatz <= 0)
            {
                System.Windows.MessageBox.Show("Wählen Sie einen Einsatz");
            }

            else if (Guthaben == 0)
            {
                System.Windows.MessageBox.Show("Sie haben kein Guthaben");
            }
           
        }

        private void btnzurueck_Click(object sender, MouseButtonEventArgs e) {
            musi.backgroundLoop.Stop();
            HighscoreEintrag(Highscore);
            this.Close();
        }

        private void btnSound(object sender, MouseButtonEventArgs e)
        {
            if (mute)
            {
                musi.backgroundLoop.Stop();
                btnMute.Source = new BitmapImage(new Uri("Resources/Volume_Off.png", UriKind.Relative));
                mute = false;
            }
            else {
                musi.playBackgroundSound("Resources/bg.wav");
                btnMute.Source = new BitmapImage(new Uri("Resources/Volume_On.png", UriKind.Relative));
                mute = true;
            }
            
        }

        public BitmapImage LoadBitmapFromResource(string pathInApplication, Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            if (pathInApplication[0] == '/')
            {
                pathInApplication = pathInApplication.Substring(1);
            }
            return new BitmapImage(new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication, UriKind.Absolute));
        }

        private void HighscoreTop3() {
            List<tblHighscore> liste = new List<tblHighscore>();
            var top3 = (from high in db.tblHighscore where high.FKSpiel == sessionID orderby high.Punkte descending select high).Take(3);
            foreach (var item in top3) {
                liste.Add(item);
            }
            lblHighscore1.Content = "1     " + liste[0].Spieler;
            lblHighscorePunkte1.Content = Math.Round(liste[0].Punkte, 0);
            lblHighscore2.Content = "2     " + liste[1].Spieler;
            lblHighscorePunkte2.Content = Math.Round(liste[1].Punkte, 0);
            lblHighscore3.Content = "3     " + liste[2].Spieler;
            lblHighscorePunkte3.Content = Math.Round(liste[2].Punkte, 0);
        }
        private void HighscoreEintrag(double ErgebnisHighscore) {
            TastaturHighscore t = new TastaturHighscore();
            t.HighscoreEintragen(ErgebnisHighscore, sessionID);
            return;
        }
    }
}
