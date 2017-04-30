using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Datenschicht;
using System.Media;
using System.Threading;
using IndividuellesFenster;
using Tastatur;

namespace Würfelpoker
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Escalero : Window
    {
       
        public double Gesamtpunkte { get; set; }

        public MediaPlayer soundplayerOne { get; set; }
        public MediaPlayer soundplayerTwo { get; set; }
        public MediaPlayer soundplayerThree { get; set; }
        
        SoundPlayer backgroundmusic = new SoundPlayer();

        // für Sound: Mute Taste
        bool bild1 = true;

        // Fixes Array für die zufallsgenerierten "Würfel", damit leere Indizes nicht verloren gehen! 
        public int[] RandomArray = new int[5];


        // Liste für die Opacities der zufallsgenerierten "Würfel".
        public List<double> opacityList = new List<double>();

        // Zufallszahlen 1-6
        public Random num = new Random();

        //Für die 33 Würfelrunden.
        int RundenZähler = 0;

        // Zählervariablen
        int neun = 0;
        int zehn = 0;
        int bube = 0;
        int dame = 0;
        int könig = 0;
        int ass = 0;

        //Datenbank
        dbCasino_IN19Entities db = new dbCasino_IN19Entities();

        //Liste der Highscores
        List<tblHighscore> highList = new List<tblHighscore>();

        

        public List<int> WürfelErgebnis = new List<int>();

        List<TextBox> AllTextBoxes = new List<TextBox>();

        BitmapImage kreuz = new BitmapImage(new Uri("Bilder/kreuz.png", UriKind.Relative));


        List<TextBox> AlreadyClickedTextBoxes = new List<TextBox>();

        //GlobaleSpielID
        int sessionID;

        public Escalero(GlobaleVariablen SessionSpielID) : this()
        {
            //ID für das spiel von der datenbank
            sessionID = SessionSpielID.SessionSpielID;

            //anzeige der highscore der top 3 rechts oben
            HighscoreTop3();
        }


        public int grandePunkte { get; set; }
        public int fullHousePunkte { get; set; }
        public int pokerPunkte { get; set; }
        public int straßePunkte { get; set; }
        public int summeEinsPunkte { get; set; }
        public int summeZweiPunkte { get; set; }
        public int summeDreiPunkte { get; set; }

        public bool ersterWurf = false;
        public bool zweiterWurf = false;
        public bool dritterWurf = false;

        public bool streichAktiv = false;

        //------MAIN: -----------11111111111111111111111111111111111111111111111111111111111111111111111
        public Escalero()
        {
            InitializeComponent();

            backgroundmusic = new SoundPlayer("ESounds/background.wav");
            //backgroundmusic2.Open(new Uri("ESounds/background.wav", UriKind.Relative));
            //backgroundmusic2.Play();
            backgroundmusic.PlayLooping();

            rectW1.Opacity = 0;
            rectW2.Opacity = 0;
            rectW3.Opacity = 0;
            rectW4.Opacity = 0;
            rectW5.Opacity = 0;
      
            Streichtabelle.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Streichtabelle_Click), true);

            foreach (TextBox TSBox in this.StreichGrid.Children)
            {
                if (TSBox != null)
                {
                    AllTextBoxes.Add(TSBox);
                }
                if (Content.ToString() !=  "")
                {
                    TSBox.Foreground = new SolidColorBrush(Colors.ForestGreen);

                }
            }

        }

       


        //------METHODEN: -----------22222222222222222222222222222222222222222222222222222222222
        public void btnErsterWurf_Click(object sender, RoutedEventArgs e)
        {

            var source = e.OriginalSource as FrameworkElement;  //Der Source, sprich Ursprung des Eventauslösers (button_name) wird gespeichert.

            int Number1;
            int Number2;
            int Number3;
            int Number4;
            int Number5;


            if (source == btnErsterWurf || source == btnZweiterWurf || source == btnDritterWurf) //If-Abfrage um zu ermitteln welcher Wurf-button betätigt wurde.
            {
                source.Visibility = Visibility.Collapsed; //Der Source, sprich Ursprung des Eventauslösers (button_name) wird auf Collapse gesetzt

                //Ausführung der HALTEN-METHODE: ---------------------------------------------------
                // Zuweisung von der Zahl zu Bild und String "BitmapImage Img1 = new BitmapImage(..."
                if (rectW1.Opacity == 0)
                {
                    Number1 = num.Next(1, 7);
                    RandomArray[0] = Number1;
                    BitmapImage Img1 = new BitmapImage(new Uri("Bilder/" + RandomArray[0].ToString() + ".png", UriKind.Relative));
                    image1.Source = Img1;
                    //Wuerfeln_W1();
                }
                if (rectW2.Opacity == 0)
                {
                    Number2 = num.Next(1, 7);
                    RandomArray[1] = Number2;
                    BitmapImage Img2 = new BitmapImage(new Uri("Bilder/" + RandomArray[1].ToString() + ".png", UriKind.Relative));
                    image2.Source = Img2;
                    //Wuerfeln_W2();
                }
                if (rectW3.Opacity == 0)
                {
                    Number3 = num.Next(1, 7);
                    RandomArray[2] = Number3;
                    BitmapImage Img3 = new BitmapImage(new Uri("Bilder/" + RandomArray[2].ToString() + ".png", UriKind.Relative));
                    image3.Source = Img3;
                    //Wuerfeln_W3();
                }
                if (rectW4.Opacity == 0)
                {
                    Number4 = num.Next(1, 7);
                    RandomArray[3] = Number4;
                    BitmapImage Img4 = new BitmapImage(new Uri("Bilder/" + RandomArray[3].ToString() + ".png", UriKind.Relative));
                    image4.Source = Img4;
                    //Wuerfeln_W4();
                }
                if (rectW5.Opacity == 0)
                {
                    Number5 = num.Next(1, 7);
                    RandomArray[4] = Number5;
                    BitmapImage Img5 = new BitmapImage(new Uri("Bilder/" + RandomArray[4].ToString() + ".png", UriKind.Relative));
                    image5.Source = Img5;
                    //Wuerfeln_W5();
                }
                //------------------------------------------------------------------------------------




                // Überprüfung welche Zahl in welchem Index gespeichert ist
                //GewürfelteZählen(RandomArray, ref neun, ref zehn, ref bube, ref dame, ref könig, ref ass);
                // Anzeige der Bilder auf den Imagefeldern im Windows


                if (source == btnErsterWurf)   //Abfrage für Erster, Zweiter, Dritter Wurf Button (If true, then next Wurf visibility.visible)
                {
                    //playSound("ESounds/two_hard.wav");
                    //playSound("ESounds/three_hard.wav");

                    M_ButtonSounds(source);

                    dritterWurf = false;
                    ersterWurf = true;

                    GewürfelteZählen(RandomArray, ref neun, ref zehn, ref bube, ref dame, ref könig, ref ass);
                    btnZweiterWurf.Visibility = Visibility.Visible;
                    RundenZähler++;
                    
                    M_Streichtabelle_Checker();

                        }

                if (source == btnZweiterWurf)
                {
                    ersterWurf = false;
                    zweiterWurf = true;

                    M_ButtonSounds(source);

                    GewürfelteZählen(RandomArray, ref neun, ref zehn, ref bube, ref dame, ref könig, ref ass);
                    btnDritterWurf.Visibility = Visibility.Visible;
                    RundenZähler++;

                    M_Streichtabelle_Checker();


                        }

                if (source == btnDritterWurf)
                {
                    zweiterWurf = false;
                    dritterWurf = true;

                    M_ButtonSounds(source);

                    GewürfelteZählen(RandomArray, ref neun, ref zehn, ref bube, ref dame, ref könig, ref ass);

                    //btnErsterWurf.Visibility = Visibility.Visible;
                    btnStreichen.Visibility = Visibility.Visible;
                    RundenZähler++;

                    M_Streichtabelle_Checker();

                            }
                        }

                            }


        // Zählt die Würfergebnisse
        public static void GewürfelteZählen(int[] RandomArray, ref int neun, ref int zehn, ref int bube, ref int dame, ref int könig, ref int ass)
        {
            List<int> GewürfeltesErgebnis = new List<int>();

            int i = 0;
            int j = 1;
            int z = 0;
            int y = 0;

            while (y < 6)
            {
                while (z < 5)
                {
                    if (RandomArray[i] == j)
                    {
                        neun++;
                    }
                    j++;

                    if (RandomArray[i] == j)
                    {
                        zehn++;
                    }
                    j++;

                    if (RandomArray[i] == j)
                    {
                        bube++;
                    }
                    j++;

                    if (RandomArray[i] == j)
                    {
                        dame++;
                    }
                    j++;

                    if (RandomArray[i] == j)
                    {
                        könig++;
                    }
                    j++;

                    if (RandomArray[i] == j)
                    {
                        ass++;
                    }
                    j = 1;
                    i++;
                    z++;
                }

                y++;
            }
        }



        //WÜRFELKOMBINATIONEN ANFANG
        // Grande
        public void Grande(int neun, int zehn, int bube, int dame, int könig, int ass)
        {
            //grandeServiert = RandomArray.All(item => item == 1 || item == 2 || item == 3 || item == 4 || item == 5);
            //grandePunkte = 0;
            if (neun == 5 || zehn == 5 || bube == 5 || dame == 5 || könig == 5 || ass == 5)
            {
                if (opacityList.All(Opacity => Opacity == 0))
                {
                    grandePunkte = 50; playSound(soundplayerThree, "ESounds/served.wav");
                }
                //if ((rectW1.Opacity == 0) && (rectW2.Opacity == 0) && (rectW3.Opacity == 0) && (rectW4.Opacity == 0) && (rectW5.Opacity == 0))
                //{
                //}
                grandePunkte += 50;
                
            }
        }

        // Poker
        public void Poker(int neun, int zehn, int bube, int dame, int könig, int ass)
        {
            //pokerPunkte = 0;
            if (neun == 4 || zehn == 4 || bube == 4 || dame == 4 || könig == 4 || ass == 4)
            {
                if ((rectW1.Opacity == 0) && (rectW2.Opacity == 0) && (rectW3.Opacity == 0) && (rectW4.Opacity == 0) && (rectW5.Opacity == 0))
                {
                    pokerPunkte = 5; playSound(soundplayerThree, "ESounds/served.wav");
                }
                //if ((rectW1.Opacity == 0) && (rectW2.Opacity == 0) && (rectW3.Opacity == 0) && (rectW4.Opacity == 0) && (rectW5.Opacity == 0))
                //{
                //}
                pokerPunkte += 40;
            }
        }

        // FullHouse
        public void FullHouse(int neun, int zehn, int bube, int dame, int könig, int ass)
        {
            //fullHousePunkte = 0;
            if ((neun == 3 && (zehn == 2 || bube == 2 || dame == 2 || könig == 2 || ass == 2)) ||
                (zehn == 3 && (neun == 2 || bube == 2 || dame == 2 || könig == 2 || ass == 2)) ||
                (bube == 3 && (neun == 2 || zehn == 2 || dame == 2 || könig == 2 || ass == 2)) ||
                (dame == 3 && (neun == 2 || zehn == 2 || bube == 2 || könig == 2 || ass == 2)) ||
                (könig == 3 && (neun == 2 || zehn == 2 || bube == 2 || dame == 2 || ass == 2)) ||
                (ass == 3 && (neun == 2 || zehn == 2 || bube == 2 || dame == 2 || könig == 2)))
            {
                if ((rectW1.Opacity == 0) && (rectW2.Opacity == 0) && (rectW3.Opacity == 0) && (rectW4.Opacity == 0) && (rectW5.Opacity == 0))
                {
                    fullHousePunkte = 5; playSound(soundplayerThree, "ESounds/served.wav");
                }
                fullHousePunkte += 30;
            }
        }

        // Straße
        public void Straße(int neun, int zehn, int bube, int dame, int könig, int ass)
        {
            //straßePunkte = 0;
            if ((neun == 1 && zehn == 1 && bube == 1 && dame == 1 && könig == 1) ||
            (zehn == 1 && bube == 1 && dame == 1 && könig == 1 && ass == 1))
            {
                if ((rectW1.Opacity == 0) && (rectW2.Opacity == 0) && (rectW3.Opacity == 0) && (rectW4.Opacity == 0) && (rectW5.Opacity == 0))

                {
                    straßePunkte = 5; playSound(soundplayerThree, "ESounds/served.wav");
                }
                straßePunkte += 20;
            }
        }
        //WÜRFELKOMBINATIONEN ENDE



        // Spielefenster schließen
        public void btnzurueck_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Das Spiel wird nun beendet!");
            backgroundmusic.Stop();
            this.Close();
        }


        //--------------------------------------------------------------------
        // Klick Funktion des Würfels 1 (Halten, aber auch Freigeben!)
        private void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rectW1.Opacity == 0)
            {
                playSound(soundplayerOne, "ESounds/hold.wav");
                rectW1.Opacity = 100;
                opacityList.Add(rectW1.Opacity);


                if ((rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100))
                {
                    if (ersterWurf == true)
                    {
                        btnZweiterWurf.Visibility = Visibility.Collapsed;
                        //btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                    else if (zweiterWurf == true)
                    {
                        //btnErsterWurf.Visibility = Visibility.Collapsed;
                        btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                }


            }
            else if (rectW1.Opacity == 100)
            {
                rectW1.Opacity = 0;
                opacityList.Remove(rectW1.Opacity);
                opacityList.Add(rectW1.Opacity);


                    if (ersterWurf == true)
                    {
                        btnZweiterWurf.Visibility = Visibility.Visible;
                        //btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                    else if (zweiterWurf == true)
                    {
                        //btnErsterWurf.Visibility = Visibility.Collapsed;
                        btnDritterWurf.Visibility = Visibility.Visible;
                    }

            }
        }
        // Klick Funktion des Würfels 2 (Halten, aber auch Freigeben!)
        private void image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rectW2.Opacity == 0)
            {
                playSound(soundplayerOne, "ESounds/hold.wav");
                rectW2.Opacity = 100;
                opacityList.Add(rectW2.Opacity);

                if ((rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100))
                {
                    if (ersterWurf == true)
                    {
                        btnZweiterWurf.Visibility = Visibility.Collapsed;
                        //btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                    else if (zweiterWurf == true)
                    {
                        //btnErsterWurf.Visibility = Visibility.Collapsed;
                        btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                }


            }
            else if (rectW2.Opacity == 100)
            {
                rectW2.Opacity = 0;
                opacityList.Remove(rectW2.Opacity);
                opacityList.Add(rectW2.Opacity);

                if (ersterWurf == true)
                {
                    btnZweiterWurf.Visibility = Visibility.Visible;
                    //btnDritterWurf.Visibility = Visibility.Collapsed;
                }
                else if (zweiterWurf == true)
                {
                    //btnErsterWurf.Visibility = Visibility.Collapsed;
                    btnDritterWurf.Visibility = Visibility.Visible;
                }


            }
        }
        // Klick Funktion des Würfels 3 (Halten, aber auch Freigeben!)
        private void image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rectW3.Opacity == 0)
            {
                playSound(soundplayerOne, "ESounds/hold.wav");
                rectW3.Opacity = 100;
                opacityList.Add(rectW3.Opacity);

                if ((rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100))
                {
                    if (ersterWurf == true)
                    {
                        btnZweiterWurf.Visibility = Visibility.Collapsed;
                        //btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                    else if (zweiterWurf == true)
                    {
                        //btnErsterWurf.Visibility = Visibility.Collapsed;
                        btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                }


            }
            else if (rectW3.Opacity == 100)
            {
                rectW3.Opacity = 0;
                opacityList.Remove(rectW3.Opacity);
                opacityList.Add(rectW3.Opacity);

                if (ersterWurf == true)
                {
                    btnZweiterWurf.Visibility = Visibility.Visible;
                    //btnDritterWurf.Visibility = Visibility.Collapsed;
                }
                else if (zweiterWurf == true)
                {
                    //btnErsterWurf.Visibility = Visibility.Collapsed;
                    btnDritterWurf.Visibility = Visibility.Visible;
                }


            }
        }
        // Klick Funktion des Würfels 4 (Halten, aber auch Freigeben!)
        private void image4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rectW4.Opacity == 0)
            {
                playSound( soundplayerOne, "ESounds/hold.wav");
                rectW4.Opacity = 100;
                opacityList.Add(rectW4.Opacity);

                if (rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100)
                {
                    if (ersterWurf == true)
                    {
                        btnZweiterWurf.Visibility = Visibility.Collapsed;
                        //btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                    else if (zweiterWurf == true)
                    {
                        //btnErsterWurf.Visibility = Visibility.Collapsed;
                        btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                }

            }
            else if (rectW4.Opacity == 100)
            {
                rectW4.Opacity = 0;
                opacityList.Remove(rectW4.Opacity);
                opacityList.Add(rectW4.Opacity);

                if (ersterWurf == true)
                {
                    btnZweiterWurf.Visibility = Visibility.Visible;
                    //btnDritterWurf.Visibility = Visibility.Collapsed;
                }
                else if (zweiterWurf == true)
                {
                    //btnErsterWurf.Visibility = Visibility.Collapsed;
                    btnDritterWurf.Visibility = Visibility.Visible;
                }

            }
        }
        // Klick Funktion des Würfels 5 (Halten, aber auch Freigeben!)
        private void image5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rectW5.Opacity == 0)
            {
                playSound(soundplayerOne, "ESounds/hold.wav");
                rectW5.Opacity = 100;
                opacityList.Add(rectW5.Opacity);

                if ((rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100))
                {
                    if (ersterWurf == true)
                    {
                        btnZweiterWurf.Visibility = Visibility.Collapsed;
                        //btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                    else if (zweiterWurf == true)
                    {
                        //btnErsterWurf.Visibility = Visibility.Collapsed;
                        btnDritterWurf.Visibility = Visibility.Collapsed;
                    }
                }

            }
            else if (rectW5.Opacity == 100)
            {
                rectW5.Opacity = 0;
                opacityList.Remove(rectW5.Opacity);
                opacityList.Add(rectW5.Opacity);

                if (ersterWurf == true)
                {
                    btnZweiterWurf.Visibility = Visibility.Visible;
                    //btnDritterWurf.Visibility = Visibility.Collapsed;
                }
                else if (zweiterWurf == true)
                {
                    //btnErsterWurf.Visibility = Visibility.Collapsed;
                    btnDritterWurf.Visibility = Visibility.Visible;
                }


            }
        }
        //--------------------------------------------------------------------


        private void btnSound(object sender, MouseButtonEventArgs e)
        {
            //MAKA Bild wechsel des Mute Button
            if (bild1)
            {
                btnMute.Source = new BitmapImage(new Uri("Hintergrund/Volume_Off.png", UriKind.Relative));
                bild1 = false;
            }
            else
            {
                btnMute.Source = new BitmapImage(new Uri("Hintergrund/Volume_On.png", UriKind.Relative));
                bild1 = true;
            }
        }


        private void Streichtabelle_Click(object sender, MouseButtonEventArgs e)
        {


            TextBox x = e.Source as TextBox;

            if (x == null)
            {
                return;
            }

            if (/*!string.IsNullOrEmpty(x.Text) && */!AlreadyClickedTextBoxes.Contains(x))
            {
                int i = 0;

                if (!string.IsNullOrEmpty(x.Text))
                {
                    i = int.Parse(x.Text);

                }

                if (i > 0 && streichAktiv == false && !string.IsNullOrEmpty(x.Text))
                {
                    playSound(soundplayerOne, "ESounds/insert.wav");


                    x.IsEnabled = false;
                    x.Text = x.Text;
                    x.FontWeight =  FontWeights.Bold;
                    x.Foreground = new SolidColorBrush(Colors.MidnightBlue);
                    x.Foreground.Opacity = 100;


                    if (x == TxTNeunEins || x == TxTZehnEins || x == TxTBubeEins || x == TxTDameEins || x == TxTKönigEins || x == TxTAssEins || x == TxTStraßeEins || x == TxTFullHouseEins || x == TxTPokerEins || x == TxTGrandeEins || x == TxTGrandeVier )
                    {
                        summeEinsPunkte += i;
                        TxTSummeEins.Text = summeEinsPunkte.ToString();

                    }
                    else if (x == TxTNeunZwei || x == TxTZehnZwei || x == TxTBubeZwei || x == TxTDameZwei || x == TxTKönigZwei || x == TxTAssZwei || x == TxTStraßeZwei || x == TxTFullHouseZwei || x == TxTPokerZwei || x == TxTGrandeZwei || x == TxTGrandeFuenf)
                    {
                        summeZweiPunkte += i;
                        TxTSummeZwei.Text = summeZweiPunkte.ToString();

                    }
                    else if (x == TxTNeunDrei || x == TxTZehnDrei || x == TxTBubeDrei || x == TxTDameDrei || x == TxTKönigDrei || x == TxTAssDrei || x == TxTStraßeDrei || x == TxTFullHouseDrei || x == TxTPokerDrei || x == TxTGrandeDrei || x == TxTGrandeSechs)
                    {
                        summeDreiPunkte += i;
                        TxTSummeDrei.Text = summeDreiPunkte.ToString();

                    }


                    AlreadyClickedTextBoxes.Add(x);


                    

                    M_Rundenzähler();

                }





                if (ersterWurf == true && !string.IsNullOrEmpty(x.Text) || ersterWurf == true && streichAktiv == true)
                {
                    ersterWurf = false;
                    
                    btnZweiterWurf.Visibility = Visibility.Collapsed;
                    btnErsterWurf.Visibility = Visibility.Visible;
                    RundenZähler += 2;

                    image1.Source = null;
                    image2.Source = null;
                    image3.Source = null;
                    image4.Source = null;
                    image5.Source = null;
                    rectW1.Opacity = 0;
                    rectW2.Opacity = 0;
                    rectW3.Opacity = 0;
                    rectW4.Opacity = 0;
                    rectW5.Opacity = 0;



                }
                else if (zweiterWurf == true && !string.IsNullOrEmpty(x.Text) || zweiterWurf == true && streichAktiv == true)
                {
                    zweiterWurf = false;
                    btnDritterWurf.Visibility = Visibility.Collapsed;
                    btnErsterWurf.Visibility = Visibility.Visible;
                    RundenZähler += 1;

                    image1.Source = null;
                    image2.Source = null;
                    image3.Source = null;
                    image4.Source = null;
                    image5.Source = null;
                    rectW1.Opacity = 0;
                    rectW2.Opacity = 0;
                    rectW3.Opacity = 0;
                    rectW4.Opacity = 0;
                    rectW5.Opacity = 0;


                }
                else if (dritterWurf == true && !string.IsNullOrEmpty(x.Text) || dritterWurf == true && streichAktiv == true)
                {
                    ersterWurf = true;
                    dritterWurf = false;
                    btnErsterWurf.Visibility = Visibility.Visible;
                    btnStreichen.Visibility = Visibility.Collapsed;

               

                    image1.Source = null;
                    image2.Source = null;
                    image3.Source = null;
                    image4.Source = null;
                    image5.Source = null;
                    rectW1.Opacity = 0;
                    rectW2.Opacity = 0;
                    rectW3.Opacity = 0;
                    rectW4.Opacity = 0;
                    rectW5.Opacity = 0;


                }

                

                if (streichAktiv == true)
                {

                    //x.Background = new ImageBrush(kreuz);

                    x.IsEnabled = false;
                    x.Visibility = Visibility.Collapsed;
                    AlreadyClickedTextBoxes.Add(x);
                    btnStreichen.Visibility = Visibility.Collapsed;


                    if (x == TxTNeunEins)
                    {
                        PicNeunEins.Visibility = Visibility.Visible;
                        PicNeunEins.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));

                    }

                    if (x == TxTNeunZwei)
                    {
                        PicNeunZwei.Visibility = Visibility.Visible;
                        PicNeunZwei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));

                    }

                    if (x == TxTNeunDrei)
                    {
                        PicNeunDrei.Visibility = Visibility.Visible;
                        PicNeunDrei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                        ;
                    }




                    if (x == TxTZehnEins)
                    {
                        PicZehnEins.Visibility = Visibility.Visible;
                        PicZehnEins.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTZehnZwei)
                    {
                        PicZehnZwei.Visibility = Visibility.Visible;
                        PicZehnZwei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTZehnDrei)
                    {
                        PicZehnDrei.Visibility = Visibility.Visible;
                        PicZehnDrei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }





                    if (x == TxTBubeEins)
                    {
                        PicBubeEins.Visibility = Visibility.Visible;
                        PicBubeEins.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTBubeZwei)
                    {
                        PicBubeZwei.Visibility = Visibility.Visible;
                        PicBubeZwei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTBubeDrei)
                    {
                        PicBubeDrei.Visibility = Visibility.Visible;
                        PicBubeDrei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }



                    if (x == TxTDameEins)
                    {
                        PicDameEins.Visibility = Visibility.Visible;
                        PicDameEins.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTDameZwei)
                    {
                        PicDameZwei.Visibility = Visibility.Visible;
                        PicDameZwei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTDameDrei)
                    {
                        PicDameDrei.Visibility = Visibility.Visible;
                        PicDameDrei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }


                    if (x == TxTKönigEins)
                    {
                        PicKönigEins.Visibility = Visibility.Visible;
                        PicKönigEins.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTKönigZwei)
                    {
                        PicKönigZwei.Visibility = Visibility.Visible;
                        PicKönigZwei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTKönigDrei)
                    {
                        PicKönigDrei.Visibility = Visibility.Visible;
                        PicKönigDrei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }


                    if (x == TxTAssEins)
                    {
                        PicAssEins.Visibility = Visibility.Visible;
                        PicAssEins.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTAssZwei)
                    {
                        PicAssZwei.Visibility = Visibility.Visible;
                        PicAssZwei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTAssDrei)
                    {
                        PicAssDrei.Visibility = Visibility.Visible;
                        PicAssDrei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }


                    if (x == TxTGrandeEins)
                    {
                        PicGrandeEins.Visibility = Visibility.Visible;
                        PicGrandeEins.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTGrandeZwei)
                    {
                        PicGrandeZwei.Visibility = Visibility.Visible;
                        PicGrandeZwei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTGrandeDrei)
                    {
                        PicGrandeDrei.Visibility = Visibility.Visible;
                        PicGrandeDrei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTGrandeVier)
                    {
                        PicGrandeVier.Visibility = Visibility.Visible;
                        PicGrandeVier.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTGrandeFuenf)
                    {
                        PicGrandeFuenf.Visibility = Visibility.Visible;
                        PicGrandeFuenf.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTGrandeSechs)
                    {
                        PicGrandeSechs.Visibility = Visibility.Visible;
                        PicGrandeSechs.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }




                    if (x == TxTFullHouseEins)
                    {
                        PicFullHouseEins.Visibility = Visibility.Visible;
                        PicFullHouseEins.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTFullHouseZwei)
                    {
                        PicFullHouseZwei.Visibility = Visibility.Visible;
                        PicFullHouseZwei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTFullHouseDrei)
                    {
                        PicFullHouseDrei.Visibility = Visibility.Visible;
                        PicFullHouseDrei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }





                    if (x == TxTStraßeEins)
                    {
                        PicStraßeEins.Visibility = Visibility.Visible;
                        PicStraßeEins.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTStraßeZwei)
                    {
                        PicStraßeZwei.Visibility = Visibility.Visible;
                        PicStraßeZwei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTStraßeDrei)
                    {
                        PicStraßeDrei.Visibility = Visibility.Visible;
                        PicStraßeDrei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }



                    if (x == TxTPokerEins)
                    {
                        PicPokerEins.Visibility = Visibility.Visible;
                        PicPokerEins.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTPokerZwei)
                    {
                        PicPokerZwei.Visibility = Visibility.Visible;
                        PicPokerZwei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    if (x == TxTPokerDrei)
                    {
                        PicPokerDrei.Visibility = Visibility.Visible;
                        PicPokerDrei.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));
                    }

                    //x.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Bilder/kreuz.png")));




                    
                    

                    M_Rundenzähler();

                }


                if (!string.IsNullOrEmpty(x.Text))
                {

                foreach (TextBox t in AllTextBoxes.Except(AlreadyClickedTextBoxes))
                {

                    t.Clear();
                }

                }

                streichAktiv = false;

                btnStreichAbbrechen.Visibility = Visibility.Collapsed;
            }
        }
        

        private void btnStreichen_Click(object sender, RoutedEventArgs e)
        {

            btnStreichen.Visibility = Visibility.Collapsed;
            streichAktiv = true;
            btnStreichAbbrechen.Visibility = Visibility.Visible;



        }

        private void btnStreichAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            btnStreichAbbrechen.Visibility = Visibility.Collapsed;
            streichAktiv = false;
            btnStreichen.Visibility = Visibility.Visible;
        }

       

        public void playSound(MediaPlayer soundplayer, string path)
        {
            soundplayer = new MediaPlayer();

            soundplayer.Open(new Uri(path, UriKind.Relative));

            soundplayer.Volume = 1000;

            soundplayer.Play();

        }

        private void btnzurueck_Click(object sender, MouseButtonEventArgs e)
        {
        
            PopupFenster pp = new PopupFenster();
            pp.Logout("Wollen Sie das Spiel wirklich verlassen?\nAchtung Ihr Guthaben geht verloren!");
            pp.ShowDialog();
            backgroundmusic.Stop();


            //if (punkte > 0)
            //{
            //    HighscoreEintrag(punkte);
            //}
            //else
            //{
            //    this.Close();
            //}

            if (pp.ja)
            {
                this.Close();
            }
            else
            {
                if (bild1)
                {
                    HighscoreEintrag(Gesamtpunkte);

                    backgroundmusic.PlayLooping();
                }
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HighscoreTop3()
        {
            List<tblHighscore> liste = new List<tblHighscore>();

            var top3 = (from high in db.tblHighscore where high.FKSpiel == sessionID orderby high.Punkte descending select high).Take(3);

            foreach (var item in top3)
            {
                liste.Add(item);
            }

            lblHighscore1.Content = "1    " + liste[0].Spieler;
            lblHighscore2.Content = "2    " + liste[1].Spieler;
            lblHighscore3.Content = "3    " + liste[2].Spieler;
            lblHighscorePunkte1.Content = liste[0].Punkte;
            lblHighscorePunkte2.Content = liste[1].Punkte;
            lblHighscorePunkte3.Content = liste[2].Punkte;
        }

        private void HighscoreEintrag(double ErgebnisHighscore)
        {

            TastaturHighscore t = new TastaturHighscore();
            t.Topmost = true;
            t.HighscoreEintragen(ErgebnisHighscore, sessionID);
            

            return;

        }

        public void M_ButtonSounds (FrameworkElement source)
        {

            if (source == btnErsterWurf || source == btnZweiterWurf || source == btnDritterWurf)
            {

                if (
                    rectW1.Opacity == 100 && rectW2.Opacity == 0 && rectW3.Opacity == 0 && rectW4.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW2.Opacity == 100 && rectW1.Opacity == 0 && rectW3.Opacity == 0 && rectW4.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW3.Opacity == 100 && rectW1.Opacity == 0 && rectW2.Opacity == 0 && rectW4.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW4.Opacity == 100 && rectW1.Opacity == 0 && rectW2.Opacity == 0 && rectW3.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW5.Opacity == 100 && rectW1.Opacity == 0 && rectW2.Opacity == 0 && rectW3.Opacity == 0 && rectW4.Opacity == 0)
                {
                    playSound(soundplayerOne, "ESounds/three_hard.wav");
                }
                else if (
                    rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW3.Opacity == 0 && rectW4.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW3.Opacity == 100 && rectW2.Opacity == 0 && rectW4.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW4.Opacity == 100 && rectW2.Opacity == 0 && rectW3.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW5.Opacity == 100 && rectW2.Opacity == 0 && rectW3.Opacity == 0 && rectW4.Opacity == 0 ||
                    rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW1.Opacity == 0 && rectW4.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW2.Opacity == 100 && rectW4.Opacity == 100 && rectW1.Opacity == 0 && rectW3.Opacity == 0 && rectW4.Opacity == 0 ||
                    rectW2.Opacity == 100 && rectW5.Opacity == 100 && rectW1.Opacity == 0 && rectW3.Opacity == 0 && rectW4.Opacity == 0 ||
                    rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW1.Opacity == 0 && rectW2.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW3.Opacity == 100 && rectW5.Opacity == 100 && rectW1.Opacity == 0 && rectW2.Opacity == 0 && rectW4.Opacity == 0 ||
                    rectW4.Opacity == 100 && rectW5.Opacity == 100 && rectW1.Opacity == 0 && rectW2.Opacity == 0 && rectW3.Opacity == 0)
                {
                    playSound(soundplayerOne, "ESounds/three_hard.wav");
                }
                else if (
                    rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW4.Opacity == 100 && rectW3.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW5.Opacity == 100 && rectW3.Opacity == 0 && rectW4.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW2.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW3.Opacity == 100 && rectW5.Opacity == 100 && rectW2.Opacity == 0 && rectW4.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100 && rectW2.Opacity == 0 && rectW3.Opacity == 0 ||
                    rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW2.Opacity == 0 && rectW5.Opacity == 0 ||
                    rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW5.Opacity == 100 && rectW1.Opacity == 0 && rectW4.Opacity == 0 ||
                    rectW2.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100 && rectW1.Opacity == 0 && rectW3.Opacity == 0 ||
                    rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100 && rectW1.Opacity == 0 && rectW2.Opacity == 0)
                {
                    playSound(soundplayerOne, "ESounds/two_hard.wav");
                }
                else if (
                    rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW5.Opacity == 100 && rectW4.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW2.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100 && rectW3.Opacity == 0 ||
                    rectW1.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100 && rectW2.Opacity == 0 ||
                    rectW2.Opacity == 100 && rectW3.Opacity == 100 && rectW4.Opacity == 100 && rectW5.Opacity == 100 && rectW1.Opacity == 0)
                {
                    playSound(soundplayerOne, "ESounds/One_hard.wav");
                }
                else if (rectW1.Opacity == 0 && rectW2.Opacity == 0 && rectW3.Opacity == 0 && rectW4.Opacity == 0 && rectW5.Opacity == 0)
                {
                    //playSound(soundplayerOne, "ESounds/two_hard.wav");
                    playSound(soundplayerTwo, "ESounds/three_hard.wav");
                }

            }


        }

        public void M_Streichtabelle_Checker ()
        {


            WürfelErgebnis.Add(neun);
            WürfelErgebnis.Add(zehn);
            WürfelErgebnis.Add(bube);
            WürfelErgebnis.Add(dame);
            WürfelErgebnis.Add(könig);
            WürfelErgebnis.Add(ass);

            Grande(neun, zehn, bube, dame, könig, ass);
            FullHouse(neun, zehn, bube, dame, könig, ass);
            Poker(neun, zehn, bube, dame, könig, ass);
            Straße(neun, zehn, bube, dame, könig, ass);


            int x = 0;


            if (WürfelErgebnis.Any())
            {


                if (neun > 0)
                {



                    if (TxTNeunEins.IsEnabled == true)
                    {

                        TxTNeunEins.Text = neun.ToString();
                    }

                    if (TxTNeunZwei.IsEnabled == true)
                    {
                        x = neun * 2;
                        TxTNeunZwei.Text = (x).ToString();
                    }

                    if (TxTNeunDrei.IsEnabled == true)
                    {
                        x = neun * 3;
                        TxTNeunDrei.Text = (x).ToString();
                    }
                }
                else if (neun == 0)
                {
                    if (TxTNeunEins.IsEnabled == true)
                    {
                        TxTNeunEins.Clear();
                    }

                    if (TxTNeunZwei.IsEnabled == true)
                    {
                        TxTNeunZwei.Clear();
                    }

                    if (TxTNeunDrei.IsEnabled == true)
                    {
                        TxTNeunDrei.Clear();
                    }

                }


                if (zehn > 0)
                {

                    if (TxTZehnEins.IsEnabled == true)
                    {
                        x = zehn * 2;
                        TxTZehnEins.Text = x.ToString();
        }

                    if (TxTZehnZwei.IsEnabled == true)
                    {
                        x = zehn * 4;
                        TxTZehnZwei.Text = x.ToString();
                    }

                    if (TxTZehnDrei.IsEnabled == true)
                    {
                        x = zehn * 6;
                        TxTZehnDrei.Text = x.ToString();
                    }
                }
                else if (zehn == 0)
                {
                    if (TxTZehnEins.IsEnabled == true)
                    {
                        TxTZehnEins.Clear();
                    }

                    if (TxTZehnZwei.IsEnabled == true)
                    {
                        TxTZehnZwei.Clear();
                    }

                    if (TxTZehnDrei.IsEnabled == true)
                    {
                        TxTZehnDrei.Clear();
                    }

                }

                if (bube > 0)
                {

                    if (TxTBubeEins.IsEnabled == true)
                    {
                        x = bube * 3;
                        TxTBubeEins.Text = x.ToString();
                    }

                    if (TxTBubeZwei.IsEnabled == true)
                    {
                        x = bube * 6;
                        TxTBubeZwei.Text = x.ToString();
                    }

                    if (TxTBubeDrei.IsEnabled == true)
                    {
                        x = bube * 9;
                        TxTBubeDrei.Text = x.ToString();
                    }
                }
                else if (bube == 0)
                {
                    if (TxTBubeEins.IsEnabled == true)
                    {
                        TxTBubeEins.Clear();
                    }

                    if (TxTBubeZwei.IsEnabled == true)
                    {
                        TxTBubeZwei.Clear();
                    }

                    if (TxTBubeDrei.IsEnabled == true)
                    {
                        TxTBubeDrei.Clear();
                    }

                }

                if (dame > 0)
                {

                    if (TxTDameEins.IsEnabled == true)
                    {
                        x = dame * 4;
                        TxTDameEins.Text = x.ToString();
                    }

                    if (TxTDameZwei.IsEnabled == true)
                    {
                        x = dame * 8;
                        TxTDameZwei.Text = x.ToString();
                    }

                    if (TxTDameDrei.IsEnabled == true)
                    {
                        x = dame * 12;
                        TxTDameDrei.Text = x.ToString();
                    }
                }
                else if (dame == 0)
                {
                    if (TxTDameEins.IsEnabled == true)
                    {
                        TxTDameEins.Clear();
                    }

                    if (TxTDameZwei.IsEnabled == true)
                    {
                        TxTDameZwei.Clear();
                    }

                    if (TxTDameDrei.IsEnabled == true)
                    {
                        TxTDameDrei.Clear();
                    }

                }


                if (könig > 0)
                {

                    if (TxTKönigEins.IsEnabled == true)
                    {
                        x = könig * 5;
                        TxTKönigEins.Text = x.ToString();
                    }

                    if (TxTKönigZwei.IsEnabled == true)
                    {
                        x = könig * 10;
                        TxTKönigZwei.Text = x.ToString();
                    }

                    if (TxTKönigDrei.IsEnabled == true)
                    {
                        x = könig * 15;
                        TxTKönigDrei.Text = x.ToString();
                    }
                }
                else if (könig == 0)
                {
                    if (TxTKönigEins.IsEnabled == true)
                    {
                        TxTKönigEins.Clear();
                    }

                    if (TxTKönigZwei.IsEnabled == true)
                    {
                        TxTKönigZwei.Clear();
                    }

                    if (TxTKönigDrei.IsEnabled == true)
                    {
                        TxTKönigDrei.Clear();
                    }

                }


                if (ass > 0)
                {

                    if (TxTAssEins.IsEnabled == true)
                    {
                        x = ass * 6;
                        TxTAssEins.Text = x.ToString();
                    }

                    if (TxTAssZwei.IsEnabled == true)
                    {
                        x = ass * 12;
                        TxTAssZwei.Text = x.ToString();
                    }

                    if (TxTAssDrei.IsEnabled == true)
                    {
                        x = ass * 18;
                        TxTAssDrei.Text = x.ToString();
                    }
                }
                else if (ass == 0)
                {
                    if (TxTAssEins.IsEnabled == true)
                    {
                        TxTAssEins.Clear();
                    }

                    if (TxTAssZwei.IsEnabled == true)
                    {
                        TxTAssZwei.Clear();
                    }

                    if (TxTAssDrei.IsEnabled == true)
                    {
                        TxTAssDrei.Clear();
                    }

                }

                if (grandePunkte > 0)
                {
                    if (TxTGrandeEins.IsEnabled == true)
                    {
                        TxTGrandeEins.Text = grandePunkte.ToString();
                    }

                    if (TxTGrandeZwei.IsEnabled == true)
                    {
                        x = grandePunkte * 2;
                        TxTGrandeZwei.Text = x.ToString();

                    }

                    if (TxTGrandeDrei.IsEnabled == true)
                    {
                        x = grandePunkte * 3;
                        TxTGrandeDrei.Text = x.ToString();

                    }

                    if (TxTGrandeVier.IsEnabled == true)
                    {
                        TxTGrandeVier.Text = grandePunkte.ToString();

                    }

                    if (TxTGrandeFuenf.IsEnabled == true)
                    {
                        x = grandePunkte * 2;
                        TxTGrandeFuenf.Text = x.ToString();

                    }

                    if (TxTGrandeSechs.IsEnabled == true)
                    {
                        x = grandePunkte * 3;
                        TxTGrandeSechs.Text = x.ToString();

                    }
                }
                else if (grandePunkte == 0)
                {
                    if (TxTGrandeEins.IsEnabled == true)
                    {
                        TxTGrandeEins.Clear();
                    }

                    if (TxTGrandeZwei.IsEnabled == true)
                    {
                        TxTGrandeZwei.Clear();

                    }

                    if (TxTGrandeDrei.IsEnabled == true)
                    {
                        TxTGrandeDrei.Clear();

                    }

                    if (TxTGrandeVier.IsEnabled == true)
                    {
                        TxTGrandeVier.Clear();

                    }

                    if (TxTGrandeFuenf.IsEnabled == true)
                    {
                        TxTGrandeFuenf.Clear();

                    }

                    if (TxTGrandeSechs.IsEnabled == true)
                    {
                        TxTGrandeSechs.Clear();

                    }

                }


                if (fullHousePunkte > 0)
                {
                    if (TxTFullHouseEins.IsEnabled == true)
                    {
                        TxTFullHouseEins.Text = fullHousePunkte.ToString();
                    }

                    if (TxTFullHouseZwei.IsEnabled == true)
                    {
                        x = fullHousePunkte * 2;
                        TxTFullHouseZwei.Text = x.ToString();

                    }

                    if (TxTFullHouseDrei.IsEnabled == true)
                    {
                        x = fullHousePunkte * 3;
                        TxTFullHouseDrei.Text = x.ToString();

                    }
                }
                else if (fullHousePunkte == 0)
                {
                    if (TxTFullHouseEins.IsEnabled == true)
                    {
                        TxTFullHouseEins.Clear();
                    }

                    if (TxTFullHouseZwei.IsEnabled == true)
                    {
                        TxTFullHouseZwei.Clear();
                    }

                    if (TxTFullHouseDrei.IsEnabled == true)
                    {
                        TxTFullHouseDrei.Clear();
                    }

                }



                if (straßePunkte > 0)
                {
                    if (TxTStraßeEins.IsEnabled == true)
                    {
                        TxTStraßeEins.Text = straßePunkte.ToString();
                    }

                    if (TxTStraßeZwei.IsEnabled == true)
                    {
                        x = straßePunkte * 2;
                        TxTStraßeZwei.Text = x.ToString();

                    }

                    if (TxTStraßeDrei.IsEnabled == true)
                    {
                        x = straßePunkte * 3;
                        TxTStraßeDrei.Text = x.ToString();

                    }
                }
                else if (straßePunkte == 0)
                {
                    if (TxTStraßeEins.IsEnabled == true)
                    {
                        TxTStraßeEins.Clear();
                    }

                    if (TxTStraßeZwei.IsEnabled == true)
                    {
                        TxTStraßeZwei.Clear();
                    }

                    if (TxTStraßeDrei.IsEnabled == true)
                    {
                        TxTStraßeDrei.Clear();
                    }

                }


                if (pokerPunkte > 0)
                {
                    if (TxTPokerEins.IsEnabled == true)
                    {
                        TxTPokerEins.Text = pokerPunkte.ToString();
                    }

                    if (TxTPokerZwei.IsEnabled == true)
                    {
                        x = pokerPunkte * 2;
                        TxTPokerZwei.Text = x.ToString();

                    }

                    if (TxTPokerDrei.IsEnabled == true)
                    {
                        x = pokerPunkte * 3;
                        TxTPokerDrei.Text = x.ToString();

                    }
                }
                else if (pokerPunkte == 0)
                {
                    if (TxTPokerEins.IsEnabled == true)
                    {
                        TxTPokerEins.Clear();
                    }

                    if (TxTPokerZwei.IsEnabled == true)
                    {
                        TxTPokerZwei.Clear();
                    }

                    if (TxTPokerDrei.IsEnabled == true)
                    {
                        TxTPokerDrei.Clear();
                    }

                }


                neun = 0;
                zehn = 0;
                bube = 0;
                dame = 0;
                könig = 0;
                ass = 0;
                pokerPunkte = 0;
                grandePunkte = 0;
                fullHousePunkte = 0;
                straßePunkte = 0;

            }

        }

        public void M_Rundenzähler()
        {
            if (RundenZähler == 99)
            {
                int gesamtpunkte = summeDreiPunkte + summeEinsPunkte + summeZweiPunkte;

                grdSpielende.Visibility = Visibility.Visible;

                HighscoreEintrag(gesamtpunkte);

                for (int z = 0; z < gesamtpunkte; z++)
                {

                    lblPunktestand.Content = z;
                }

                

            }

        }

    }
}

