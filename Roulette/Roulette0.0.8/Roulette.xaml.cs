﻿using Datenschicht;
using IndividuellesFenster;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Reflection;
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
using System.Windows.Threading;
using Tastatur;

namespace Roulette0._0._8
{
    /// <summary>
    /// Interaktionslogik für Roulette.xaml
    /// </summary>
    public partial class Roulette : Window
    {
        Random rnd = new Random();
        int zufall;

        RouletteSounds rs = new RouletteSounds();
        List<string> soundListe = new List<string>();
        Kessel kessel;

        //MAKA für Mut button
        bool bild1 = true;

        List<int[]> koordinatenListe; // @Martin: Liste für Feldkoordinaten (Feld 0 ausgeschlossen)
        //Queue<Ellipse> ellipsenStack = new Queue<Ellipse>();
        Stack<Ellipse> eliStack = new Stack<Ellipse>();

        DispatcherTimer timer = new DispatcherTimer();
        TimeSpan restzeit = new TimeSpan(0, 0, 10);

        

        #region Highscore Datenbank

       // erzeugung der datenbank
       dbCasino_IN19Entities db = new dbCasino_IN19Entities();

        //Liste für die highscore
        List<tblHighscore> highList = new List<tblHighscore>();

        int sessionID;

        public Roulette(GlobaleVariablen SessionSpielID) : this()
        {
            //ID für das spiel von der datenbank
            sessionID = SessionSpielID.SessionSpielID;

            //anzeige der highscore der top 3 rechts oben
            HighscoreTop3();
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
            lblHighscorePunkte1.Content = Math.Round(liste[0].Punkte, 0);
            lblHighscorePunkte2.Content = Math.Round(liste[1].Punkte, 0);
            lblHighscorePunkte3.Content = Math.Round(liste[2].Punkte, 0);
        }



        private void gewinnNachricht(double ergebnisHighscore)
        {
            PopupFenster pp = new PopupFenster();


            pp.InfoFenster("Gewonnen, Super  du hast " + ergebnisHighscore);
            pp.ShowDialog();

        }

        private void HighscoreEintrag(double ErgebnisHighscore)
        {
            
                    TastaturHighscore t = new TastaturHighscore();
                    t.HighscoreEintragen(ErgebnisHighscore, sessionID);
                    this.Close();
                    return;
           
        }

        #endregion

     

        public Roulette()
        {
            InitializeComponent();


            // Sounds

            if (bild1)
            {
                rs.BackgroundLoop("RSounds/hintergrundNeu2.wav");
            }

            for (int i = 0; i < 37; i++)
            {
                soundListe.Add("RSounds/" + i + ".wav");
            }




            #region Kessel

            eliKugel.Visibility = Visibility.Hidden;
            kessel = new Kessel(eliKesselInnere, eliKugel);
            kessel.TickEventInitialisieren();
            kessel.KesselKoordinatenInitialisieren();

            #endregion

            UeberpruefListenBefuellen();


            #region FeldKoordinaten


            FeldKoordinatenInitialisieren();

            #endregion

            timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timer.Tick += Timer_Tick;
            lblGuthaben.Content = guthaben.ToString();
        }

        public static int gewinnAusgbeBild;

        private void FeldKoordinatenInitialisieren()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                koordinatenListe = new List<int[]>();

                koordinatenListe.Add(new int[] { 575, 526 }); // Feld 1 (Canvas.Top, Canvas.Left)
                koordinatenListe.Add(new int[] { 512, 526 }); // Feld 2
                koordinatenListe.Add(new int[] { 450, 526 }); // Feld 3
                koordinatenListe.Add(new int[] { 575, 576 }); // Feld 4
                koordinatenListe.Add(new int[] { 512, 576 }); // Feld 5
                koordinatenListe.Add(new int[] { 450, 576 }); // Feld 
                koordinatenListe.Add(new int[] { 575, 625 }); // Feld 
                koordinatenListe.Add(new int[] { 512, 625 }); // Feld 
                koordinatenListe.Add(new int[] { 450, 625 }); // Feld 
                koordinatenListe.Add(new int[] { 575, 675 }); // Feld 10
                koordinatenListe.Add(new int[] { 512, 675 }); // Feld 
                koordinatenListe.Add(new int[] { 450, 675 }); // Feld 
                koordinatenListe.Add(new int[] { 575, 731 }); // Feld 
                koordinatenListe.Add(new int[] { 512, 731 }); // Feld 
                koordinatenListe.Add(new int[] { 450, 731 }); // Feld 
                koordinatenListe.Add(new int[] { 575, 781 }); // Feld 
                koordinatenListe.Add(new int[] { 512, 781 }); // Feld 
                koordinatenListe.Add(new int[] { 450, 781 }); // Feld 
                koordinatenListe.Add(new int[] { 575, 831 }); // Feld 
                koordinatenListe.Add(new int[] { 512, 831 }); // Feld 20
                koordinatenListe.Add(new int[] { 450, 831 }); // Feld 
                koordinatenListe.Add(new int[] { 575, 881 }); // Feld 
                koordinatenListe.Add(new int[] { 512, 881 }); // Feld 
                koordinatenListe.Add(new int[] { 450, 881 }); // Feld 
                koordinatenListe.Add(new int[] { 575, 937 }); // Feld 
                koordinatenListe.Add(new int[] { 512, 937 }); // Feld 
                koordinatenListe.Add(new int[] { 450, 937 }); // Feld 
                koordinatenListe.Add(new int[] { 575, 987 }); // Feld 
                koordinatenListe.Add(new int[] { 512, 987 }); // Feld 
                koordinatenListe.Add(new int[] { 450, 987 }); // Feld 30
                koordinatenListe.Add(new int[] { 575, 1036 }); // Feld 
                koordinatenListe.Add(new int[] { 512, 1036 }); // Feld 
                koordinatenListe.Add(new int[] { 450, 1036 }); // Feld 
                koordinatenListe.Add(new int[] { 575, 1087 }); // Feld 
                koordinatenListe.Add(new int[] { 512, 1087 }); // Feld 
                koordinatenListe.Add(new int[] { 450, 1087 }); // Feld 36
            }
            else
            {
                // Koordinaten für Laptopbetrieb

                koordinatenListe = new List<int[]>();

                koordinatenListe.Add(new int[] { 419, 411 });   // 1
                koordinatenListe.Add(new int[] { 374, 411 });   // 2
                koordinatenListe.Add(new int[] { 329, 411 });   // 3
                koordinatenListe.Add(new int[] { 419, 450 });   // 4
                koordinatenListe.Add(new int[] { 374, 450 });   // 5
                koordinatenListe.Add(new int[] { 329, 450 });   // 6    
                koordinatenListe.Add(new int[] { 419, 490 });   // 7 
                koordinatenListe.Add(new int[] { 374, 490 });   // 8
                koordinatenListe.Add(new int[] { 329, 490 });   // 9 
                koordinatenListe.Add(new int[] { 419, 529 });   // 10
                koordinatenListe.Add(new int[] { 374, 529 });   // 11
                koordinatenListe.Add(new int[] { 329, 529 });   // 12
                koordinatenListe.Add(new int[] { 419, 573 });   // 13 
                koordinatenListe.Add(new int[] { 374, 573 });   // 14 
                koordinatenListe.Add(new int[] { 329, 573 });   // 15 
                koordinatenListe.Add(new int[] { 419, 613 });   // 16 
                koordinatenListe.Add(new int[] { 374, 613 });   // 17 
                koordinatenListe.Add(new int[] { 329, 613 });   // 18
                koordinatenListe.Add(new int[] { 419, 652 });   // 19 
                koordinatenListe.Add(new int[] { 374, 652 });   // 20 
                koordinatenListe.Add(new int[] { 329, 652 });   // 21
                koordinatenListe.Add(new int[] { 419, 691 });   // 22
                koordinatenListe.Add(new int[] { 374, 691 });   // 23
                koordinatenListe.Add(new int[] { 329, 691 });   // 24
                koordinatenListe.Add(new int[] { 419, 736 });   // 25
                koordinatenListe.Add(new int[] { 374, 736 });   // 26
                koordinatenListe.Add(new int[] { 329, 736 });   // 27
                koordinatenListe.Add(new int[] { 419, 775 });   // 28
                koordinatenListe.Add(new int[] { 374, 775 });   // 29
                koordinatenListe.Add(new int[] { 329, 775 });   // 30   
                koordinatenListe.Add(new int[] { 419, 814 });   // 31
                koordinatenListe.Add(new int[] { 374, 814 });   // 32                   
                koordinatenListe.Add(new int[] { 329, 814 });   // 33

                koordinatenListe.Add(new int[] { 419, 853 });   // 34
                koordinatenListe.Add(new int[] { 374, 853 });   // 35
                koordinatenListe.Add(new int[] { 329, 853 });   // 36 
            }
        }
        //________________________________________________________________________________________________________________________



        #region Buttons

        private void Abraeumen()
        {
            lblSchnellStart.Content = "Abräumen";
            Canvas.SetLeft(lblSchnellStart, 720);
            
            lblStart.Content = "Abräumen";
            Canvas.SetLeft(lblStart, 824);
        }
        
        private void StandardButtons()
        {
            lblStart.Content = "Start";
            Canvas.SetLeft(lblStart, 840);
            
            lblSchnellStart.Content = "Schnell Start";
            Canvas.SetLeft(lblSchnellStart, 715);
        }

        bool animationStart = true;

        private void btnDrehen_Click(object sender, RoutedEventArgs e)
        {
            if (kessel.rundenErreicht)
            {
                gewinn = 0;
                lblGuthaben.Content = guthaben.ToString();
                lblGewinn.Content = gewinn.ToString();
                AlleJettonsLoeschen();
                timer.Stop();
                jetonVerfuegbar = false;


                if (guthaben == 0)
                {
                    // ********************************************************************************
                    // D A T E N B A N K   ( H I G H S C O R E )
                    HighscoreEintrag(punkte);
                    
                }
                StandardButtons();

                animationStart = false;
            }
            else if (!kessel.rundenErreicht)
            {
                schnellSpiel = false;

                if (bild1)
                {
                    rs.PlaySound("RSounds/roulettekesselSound.wav");
                }

                timer.Start();
                jetonVerfuegbar = true;
                AlleJetonsNichtVerfuegbar();

                Abraeumen();

                animationStart = true;
            }

            zufall = rnd.Next(0,37);
            
            kessel.AnimationStart(zufall, animationStart); 
            
            
        }

        private void btnSchnellStart_click(object sender, MouseButtonEventArgs e)
        {
            if (schnellSpiel)
            {
                zufall = rnd.Next(0, 37);

                if (kessel.rundenErreicht)
                {
                    gewinn = 0;
                    lblGuthaben.Content = guthaben.ToString();
                    lblGewinn.Content = gewinn.ToString();
                    AlleJettonsLoeschen();
                    timer.Stop();
                    jetonVerfuegbar = false;
                    kessel.KugelFertigGedreht();
                    kessel.rundenErreicht = false;

                    if (guthaben == 0)
                    {
                        // ********************************************************************************
                        // D A T E N B A N K   ( H I G H S C O R E )
                        HighscoreEintrag(punkte);
                    }
                    StandardButtons();

                    animationStart = true;
                }
                else if (!kessel.rundenErreicht)
                {
                    timer.Start();
                    jetonVerfuegbar = true;
                    AlleJetonsNichtVerfuegbar();
                    Gewinnrueckgabe();
                    kessel.rundenErreicht = true;

                    Abraeumen();

                    animationStart = false;
                }

            }

        }

        private void btnZurueck_Click(object sender, MouseButtonEventArgs e)
        {
            PopupFenster pp = new PopupFenster();
            pp.Logout("Wollen Sie das Spiel wirklich verlassen?\nAchtung Ihr Guthaben geht verloren!");
            pp.ShowDialog();
            rs.BackgroundSoundStop();
            //if (punkte > 0)
            //{
            //    HighscoreEintrag(punkte);
            //}
            //else
            //{
            //    this.Close();
            //}

            if (pp.ja && guthaben > 0)
            {
                HighscoreEintrag(punkte);
                this.Close();
            }
            else
            {
                if (bild1)
                {
                    rs.BackgroundLoop("RSounds/hintergrundNeu2.wav");
                }


               
            }

           

           
        }

        private void btnMute_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MAKA bilder Wechsel des Mute Buttons
            if (bild1)
            {
                btnOn.Source = new BitmapImage(new Uri("Bilder/Volume_Off.png", UriKind.Relative));
                bild1 = false;
                rs.BackgroundSoundStop();
             
                
            }
            else
            {
                btnOn.Source = new BitmapImage(new Uri("Bilder/Volume_ON.png", UriKind.Relative));
                bild1 = true;
                rs.BackgroundLoop("RSounds/RouletteHintergrund.wav");
            }
        }



        private void btnInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            InfoFensterRoulette infoF = new InfoFensterRoulette();
            infoF.Show();

            //MessageBox.Show("Info wird noch Implementiert!!");
        }

        /// <summary>
        /// Animation von Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimation_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Image)
            {


                if (sender == btnStart && Canvas.GetTop(btnStart) == 786)
                {
                    int top = int.Parse(Canvas.GetTop(btnStart).ToString());
                    top += -15;
                    Canvas.SetTop(btnStart, top);
                    Canvas.SetTop(btnEinsatzLoeschen, 786);
                    Canvas.SetTop(btnEinsatzWiederholen, 786);
                }
                else if (sender == btnEinsatzWiederholen && Canvas.GetTop(btnEinsatzWiederholen) == 786)
                {
                    int top = int.Parse(Canvas.GetTop(btnEinsatzWiederholen).ToString());
                    top += -15;
                    Canvas.SetTop(btnEinsatzWiederholen, top);
                    Canvas.SetTop(btnStart, 786);
                    Canvas.SetTop(btnEinsatzLoeschen, 786);

                }
                else if (sender == btnEinsatzLoeschen && Canvas.GetTop(btnEinsatzLoeschen) == 786)
                {
                    int top = int.Parse(Canvas.GetTop(btnEinsatzLoeschen).ToString());
                    top += -15;
                    Canvas.SetTop(btnEinsatzLoeschen, top);
                    Canvas.SetTop(btnStart, 786);
                    Canvas.SetTop(btnEinsatzWiederholen, 786);
                }
            }


        }

        private void loescheAlleEllipsenAufFeld(object sender, MouseButtonEventArgs e)
        {
            if (schnellSpiel && lblStart.Content.ToString()!="Abräumen")
            {
                guthaben += einsatz;

                AlleJettonsLoeschen();
                lblGuthaben.Content = guthaben.ToString(); 
            }
        }

        #endregion

        private void AlleJettonsLoeschen()
        {
            ////////////////////////////////////////////////////////////////
            // Version 2 um nur den letzten gesetzten Jeton zu löschen   ///
            // if (eliStack.Count > 0)                                   ///
            //  cvsHintergrund.Children.Remove(eliStack.Pop());          ///
            ////////////////////////////////////////////////////////////////


            List<Ellipse> zuLoeschen = new List<Ellipse>();

            foreach (var item in cvsHintergrund.Children)
            {
                if (item is Ellipse)
                    zuLoeschen.Add(item as Ellipse);
            }

            foreach (var item in zuLoeschen)
            {
                cvsHintergrund.Children.Remove(item);
            }

            EinsatzAufNull();
            einsatz = 0;
            lblEinsatz.Content = einsatz;
        }

        // für den Schnellspielbutton, damit man während der Animation, diese nicht 
        // unterbrechen kann.
        bool schnellSpiel = true;

        private void Timer_Tick(object sender, EventArgs e)
        {
            restzeit -= timer.Interval;

            if (kessel.labelBefueller)
            {
                Gewinnrueckgabe();
                schnellSpiel = true;
            }
        }

  

        bool jetonVerfuegbar = false;

        /// <summary>
        /// Mittels dieser Methode wird überprüft, ob auf die erdrehte
        /// Zahl gesetzt wurde,
        /// Farbe gesetzt wurde bzw.
        /// auf "Gerade" oder "Ungerade" 
        /// gesetzt wurde.
        /// </summary>
        /// <param name="zahl">Die Zahl die erdreht wurde</param>
        /// <param name="farbe">[0] = Rot; [1] = Schwarz</param>
        /// <param name="unGerade">[0] = Gerade; [1] = Ungerade</param>
        private void Gewinnpruefung(int zahl, int farbe, int unGerade)
        {
            int zwischen;

            if (zahlenListe[zahl] > 0)
            {
                guthaben += zahlenListe[zahl];
                zwischen = (zahlenListe[zahl] * 36);
                gewinn += zwischen;
            }

            if (farbenListe[farbe] > 0)
            {
                guthaben += farbenListe[farbe];
                zwischen = farbenListe[farbe] * 2;
                gewinn += zwischen;
            }
            if (unGeradenListe[unGerade] > 0)
            {
                guthaben += unGeradenListe[unGerade];
                zwischen = unGeradenListe[unGerade] * 2;
                gewinn += zwischen;
            }


            punkte += gewinn;

            GlueckszahlAnzeige();

            if (gewinn > 0)
            {
                GewinnAusgabe ga = new GewinnAusgabe();
                ga.aktuellerGewinn = gewinn;
                gewinnAusgbeBild = gewinn;
                ga.ShowDialog();
            }

            lblGewinn.Content = gewinn.ToString();
            lblPunkte.Content = punkte.ToString();
            
            timer.Stop();

        }

        /// <summary>
        /// Hier wird bei der Erdrehten Zahl überprüft, ob auf eine einzelne Zahl, auf
        /// Gerade/Ungerade und/oder auf Rot/Schwarz gesetzt wurde.
        /// </summary>
        /// <returns></returns>
        private void Gewinnrueckgabe()
        {
            if (zufall == 0)
            {
                Gewinnpruefung(zufall, 2, 2);
            }
            else if (zufall == 1 || zufall == 3 || zufall == 5 || zufall == 7 || zufall == 9 || zufall == 19 ||
                zufall == 21 || zufall == 23 || zufall == 25 || zufall == 27)
            {
                Gewinnpruefung(zufall, 0, 1);
            }
            else if (zufall == 11 || zufall == 13 || zufall == 15 || zufall == 17 || zufall == 29 || zufall == 31 || zufall == 33 || zufall == 35)
            {
                Gewinnpruefung(zufall, 1, 1);
            }
            else if (zufall == 2 || zufall == 4 || zufall == 6 || zufall == 8 || zufall == 10 || zufall == 20 ||
                zufall == 22 || zufall == 24 || zufall == 26 || zufall == 28)
            {
                Gewinnpruefung(zufall, 1, 0);
            }
            else
            {
                Gewinnpruefung(zufall, 0, 0);
            }
        }

        private void GlueckszahlAnzeige()
        {
            //@Christof Label Gewinnzahl Farbe änderung
            if (zufall == 0)
            {
                lblZahl.Content = zufall.ToString();
                lblZahl.Background = Brushes.Green;
            }
            else if (zufall == 2 || zufall == 4 || zufall == 6 || zufall == 8 || zufall == 10 || zufall == 11 || zufall == 13 ||
                     zufall == 15 || zufall == 17 || zufall == 20 || zufall == 22 || zufall == 24 || zufall == 26 || zufall == 28 ||
                     zufall == 29 || zufall == 31 || zufall == 33 || zufall == 35)
            {
                lblZahl.Content = zufall.ToString();
                lblZahl.Background = Brushes.Black;

               

                //if (zufall == 13)
                //{
                //    rs.PlaySound(soundListe[13]);
                //}
                //if (zufall == 15)
                //{
                //    rs.PlaySound(soundListe[15]);
                //}
            }
            else
            {
                lblZahl.Content = zufall.ToString();
                lblZahl.Background = Brushes.Red;
            }

            // Gewinnzahl Ansage:

            if (bild1)
            {
                rs.PlaySound(soundListe[zufall]);
            }


           

        }

        /// <summary>
        /// @Stekal:
        /// Mittels dieser Methode werden die gesamten Einsätze 
        /// wieder auf "0" gesetzt!
        /// </summary>
        private void EinsatzAufNull()
        {
            // Einsatz von den Zahlenfeldern lösen
            for (int i = 0; i < zahlenListe.Count; i++)
                zahlenListe[i] = 0;

            // Einsatz von Farbenfeldern lösen
            for (int i = 0; i < farbenListe.Count; i++)
                farbenListe[i] = 0;

            // Einsatz von Geraden/Ungeraden-Feldern lösen
            for (int i = 0; i < unGeradenListe.Count; i++)
                unGeradenListe[i] = 0;
        }

        
        #region GesetzteFeldWerte

        // @Stekal:
        // Zahlen wie Index von 0 bis 36
        List<int> zahlenListe = new List<int>();
        // @Stekal: [0] = rot, [1] = schwarz
        List<int> farbenListe = new List<int>();
        // @Stekal: [0] = gerade, [1] = ungerade
        List<int> unGeradenListe = new List<int>();

        int gewinn = 0;
        int punkte = 0;

        /// <summary>
        /// Befüllt die zum überprüfen benötigte Listen mit den Startwerten.
        /// Damit in der Zahlenliste 36 Werte vorhanden sind.
        /// Damit in der farbenListe 2 Werte für "rot" und "schwarz" vorhanden sind.
        /// Damit in der unGeradenListe 2 werte vorhanden sind.
        /// </summary>
        private void UeberpruefListenBefuellen()
        {
            // Zahlen
            for (int i = 0; i < 37; i++)
                zahlenListe.Add(0);



            // Farben (Rot/Schwarz/Grün)
            for (int i = 0; i < 3; i++)
                farbenListe.Add(0);

            // Gerade ungerade (gerade/ungerade/null)
            for (int i = 0; i < 3; i++)
                unGeradenListe.Add(0);
        }

        #endregion


        #region JetonHintergrund

        ImageBrush jetonFuenf = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Roulette0.0.8;component/Bilder/05.png", UriKind.RelativeOrAbsolute)));
        ImageBrush jetonZehn = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Roulette0.0.8;component/Bilder/10.png", UriKind.RelativeOrAbsolute)));
        ImageBrush jetonFuenfundzwanzig = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Roulette0.0.8;component/Bilder/25.png", UriKind.RelativeOrAbsolute)));
        ImageBrush jetonFuenfzig = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Roulette0.0.8;component/Bilder/50.png", UriKind.RelativeOrAbsolute)));

        #endregion

        int guthaben = 1000;
        int einsatz = 0;

        // Während der Animation
        #region JetonNichtVerfügbar
            
        private void AlleJetonsNichtVerfuegbar()
        {
            eliJetonFuenfGewaehlt.Visibility = Visibility.Hidden;
            eliJetonZehnGewaehlt.Visibility = Visibility.Hidden;
            eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Hidden;
            eliJetonFuenfzigGewaehlt.Visibility = Visibility.Hidden;
        }

        #endregion

        #region JetonsAuswahl

        private void jeton5Auswahl(object sender, MouseButtonEventArgs e)
        {
            if (bild1)
            {
                rs.PlaySound("RSounds/JetonSetzten.wav");
            }
            

            if (!jetonVerfuegbar)
            {
                eliJetonZehnGewaehlt.Visibility = Visibility.Hidden;
                eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Hidden;
                eliJetonFuenfzigGewaehlt.Visibility = Visibility.Hidden;

                // Vergrößert bzw. verkleinert den Jeton 5 selektiert/deselektiert
                if (eliJetonFuenfGewaehlt.Visibility == Visibility.Hidden)
                    eliJetonFuenfGewaehlt.Visibility = Visibility.Visible;
                else if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
                    eliJetonFuenfGewaehlt.Visibility = Visibility.Hidden;
            }
        }

        private void jeton10Auswahl(object sender, MouseButtonEventArgs e)
        {
            if (bild1)
            {
                rs.PlaySound("RSounds/JetonSetzten.wav");
            }

            if (!jetonVerfuegbar)
            {
                eliJetonFuenfGewaehlt.Visibility = Visibility.Hidden;
                eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Hidden;
                eliJetonFuenfzigGewaehlt.Visibility = Visibility.Hidden;

                // Vergrößert bzw. verkleinert den Jeton 10 selektiert/deselektiert
                if (eliJetonZehnGewaehlt.Visibility == Visibility.Hidden)
                    eliJetonZehnGewaehlt.Visibility = Visibility.Visible;
                else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
                    eliJetonZehnGewaehlt.Visibility = Visibility.Hidden;
            }
        }

        private void jeton25Auswahl(object sender, MouseButtonEventArgs e)
        {
            if (bild1)
            {
                rs.PlaySound("RSounds/JetonSetzten.wav");
            }

            if (!jetonVerfuegbar)
            {
                eliJetonZehnGewaehlt.Visibility = Visibility.Hidden;
                eliJetonFuenfGewaehlt.Visibility = Visibility.Hidden;
                eliJetonFuenfzigGewaehlt.Visibility = Visibility.Hidden;

                if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Hidden)
                    eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Visible;
                else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
                    eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Hidden;
            }
        }

        private void jeton50Auswahl(object sender, MouseButtonEventArgs e)
        {
            if (bild1)
            {
                rs.PlaySound("RSounds/JetonSetzten.wav");
            }

            if (!jetonVerfuegbar)
            {
                eliJetonZehnGewaehlt.Visibility = Visibility.Hidden;
                eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Hidden;
                eliJetonFuenfGewaehlt.Visibility = Visibility.Hidden;

                if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Hidden)
                    eliJetonFuenfzigGewaehlt.Visibility = Visibility.Visible;
                else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
                    eliJetonFuenfzigGewaehlt.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        #region FelderAuswahl

        // **********************************
        // * Feld Null bis SechsUndDreissig *
        // **********************************

        private void polFeld0_click(object sender, MouseButtonEventArgs e)
        {
            //// Feld 0!!
            //// Prüft im Feld 0 ob Jeton 5 gewählt ist, wenn ja erhöht es den Wert jeweils um 5
            // 374, 366

            
            if (WindowState == WindowState.Maximized)
            {
                if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95 && guthaben >= 5)
                    JetonFeldNull(0, 511, 470, polFeld0, jetonFuenf);
                else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90 && guthaben >= 10)
                    JetonFeldNull(0, 511, 470, polFeld0, jetonZehn);
                else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75 && guthaben >= 25)
                    JetonFeldNull(0, 511, 470, polFeld0, jetonFuenfundzwanzig);
                else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50 && guthaben >= 50)
                    JetonFeldNull(0, 511, 470, polFeld0, jetonFuenfzig);
            }
            else
            {
                if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95 && guthaben >= 5)
                    JetonFeldNull(0, 374, 366, polFeld0, jetonFuenf);
                else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90 && guthaben >= 10)
                    JetonFeldNull(0, 374, 366, polFeld0, jetonZehn);
                else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75 && guthaben >= 25)
                    JetonFeldNull(0, 374, 366, polFeld0, jetonFuenfundzwanzig);
                else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50 && guthaben >= 50)
                    JetonFeldNull(0, 374, 366, polFeld0, jetonFuenfzig);
            } 
            
            
        }

        private void felderauswahl(object sender, MouseButtonEventArgs e)
        {
            if (guthaben > 0)
            {
                // Prüft im Feld ob Jeton 5 gewählt ist, wenn ja erhöht es den Wert jeweils um 5

                Canvas feld = sender as Canvas;

                int feldnr = Convert.ToInt32(feld.Tag);

                if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95 && guthaben >= 5)
                    JetonAufFeld(feldnr, koordinatenListe[feldnr - 1][0], koordinatenListe[feldnr - 1][1], feld, jetonFuenf);
                // Prüft im Feld ob Jeton 10 gewählt ist, wenn ja erhöht es den Wert jeweils um 10
                else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90 && guthaben >= 10)
                    JetonAufFeld(feldnr, koordinatenListe[feldnr - 1][0], koordinatenListe[feldnr - 1][1], feld, jetonZehn);
                else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75 && guthaben >= 25)
                    JetonAufFeld(feldnr, koordinatenListe[feldnr - 1][0], koordinatenListe[feldnr - 1][1], feld, jetonFuenfundzwanzig);
                else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50 && guthaben >= 50)
                    JetonAufFeld(feldnr, koordinatenListe[feldnr - 1][0], koordinatenListe[feldnr - 1][1], feld, jetonFuenfzig); 
            }
        }

        private Ellipse JetonFeldNull(int zahl, int top, int left, Polygon feld, ImageBrush farbe)
        {
            if (bild1)
            {
                rs.PlaySound("RSounds/JetonSetzten.wav");
            }


            Ellipse jeton = new Ellipse();
                jeton.Fill = farbe;
                jeton.Width = 35;
                jeton.Height = 35;
                cvsHintergrund.Children.Add(jeton);

                Canvas.SetTop(jeton, top);
                Canvas.SetLeft(jeton, left);
                Panel.SetZIndex(feld, 10);

                if (farbe == jetonFuenf)
                {
                    einsatz += 5; // Erhöht den Gesamteinsatz um 5.
                    zahlenListe[zahl] += 5; // Erhöht die Summe des Einsatzes des Feldes 0, um 5.
                    guthaben -= 5;
                    lblGuthaben.Content = guthaben.ToString();
                }
                else if (farbe == jetonZehn)
                {
                    einsatz += 10; // Erhöht den Gesamteinsatz um 10.
                    zahlenListe[zahl] += 10; // Erhöht die Summe des Einsatzes des Feldes 0, um 10.
                    guthaben -= 10;
                    lblGuthaben.Content = guthaben.ToString();
                }
                else if (farbe == jetonFuenfundzwanzig)
                {
                    einsatz += 25; // Erhöht den Gesamteinsatz um 5.
                    zahlenListe[zahl] += 25; // Erhöht die Summe des Einsatzes des Feldes 0, um 25.
                    guthaben -= 25;
                    lblGuthaben.Content = guthaben.ToString();
                }
                else
                {
                    einsatz += 50; // Erhöht den Gesamteinsatz um 5.
                    zahlenListe[zahl] += 50; // Erhöht die Summe des Einsatzes des Feldes 0, um 50.
                    guthaben -= 50;
                    lblGuthaben.Content = guthaben.ToString();
                } 
            
                lblEinsatz.Content = einsatz; // Anzeige des Gesamteinsatzes. 

                return jeton;
            
        }

        private Ellipse JetonAufFeld(int zahl, int top, int left, Canvas feld, ImageBrush farbe)
        {

            if (bild1)
            {
                rs.PlaySound("RSounds/JetonSetzten.wav");
            }

            Ellipse jeton = new Ellipse();
            jeton.Fill = farbe;
            jeton.Width = 35;
            jeton.Height = 35;
            cvsHintergrund.Children.Add(jeton);


            ///////////////////////////////////////////////////////////
            // Vielleicht Version 2 ///////////////////////////////////
            // Funktion um nur den letzten gesetzten Jeton zu löschen /
            // eliStack.Push(jeton); //////////////////////////////////
            // cvsHintergrund.Children.Add(jeton); ////////////////////
            ///////////////////////////////////////////////////////////



            Canvas.SetTop(jeton, top);
            Canvas.SetLeft(jeton, left);
            Panel.SetZIndex(feld, 10);

            if (farbe == jetonFuenf)
            {
                einsatz += 5; // Erhöht den Gesamteinsatz um 5.
                zahlenListe[zahl] += 5; // Erhöht die Summe des Einsatzes des Feldes 0, um 5.
                guthaben -= 5;
                lblGuthaben.Content = guthaben.ToString();
            }
            else if (farbe == jetonZehn)
            {
                einsatz += 10; // Erhöht den Gesamteinsatz um 10.
                zahlenListe[zahl] += 10; // Erhöht die Summe des Einsatzes des Feldes 0, um 10.
                guthaben -= 10;
                lblGuthaben.Content = guthaben.ToString();
            }
            else if (farbe == jetonFuenfundzwanzig)
            {
                einsatz += 25; // Erhöht den Gesamteinsatz um 5.
                zahlenListe[zahl] += 25; // Erhöht die Summe des Einsatzes des Feldes 0, um 25.
                guthaben -= 25;
                lblGuthaben.Content = guthaben.ToString();
            }
            else
            {
                einsatz += 50; // Erhöht den Gesamteinsatz um 5.
                zahlenListe[zahl] += 50; // Erhöht die Summe des Einsatzes des Feldes 0, um 50.
                guthaben -= 50;
                lblGuthaben.Content = guthaben.ToString();
            }

            lblEinsatz.Content = einsatz; // Anzeige des Gesamteinsatzes. 
            //lblGewinn.Content = gesamtGewinn;

            return jeton;
        }


   
        //// Zahlen wie Index von 0 bis 36
        //List<int> zahlenListe = new List<int>();
        //// @Stekal: [0] = rot, [1] = schwarz
        //List<int> farbenListe = new List<int>();
        //// @Stekal: [0] = gerade, [1] = ungerade
        //List<int> unGeradenListe = new List<int>();

        private Ellipse JetonAufFarbe(int zahl, int top, int left, Canvas feld, ImageBrush farbe)
        {
            if (bild1)
            {
                rs.PlaySound("RSounds/JetonSetzten.wav");
            }

            Ellipse jeton = new Ellipse();
            jeton.Fill = farbe;
            jeton.Width = 35;
            jeton.Height = 35;
            cvsHintergrund.Children.Add(jeton);

            Canvas.SetTop(jeton, top);
            Canvas.SetLeft(jeton, left);
            Panel.SetZIndex(feld, 10);

            if (farbe == jetonFuenf)
            {
                einsatz += 5; // Erhöht den Gesamteinsatz um 5.
                farbenListe[zahl] += 5; // Erhöht die Summe des Einsatzes des Feldes 0, um 5.
                guthaben -= 5;
                lblGuthaben.Content = guthaben.ToString();
            }
            else if (farbe == jetonZehn)
            {
                einsatz += 10; // Erhöht den Gesamteinsatz um 10.
                farbenListe[zahl] += 10; // Erhöht die Summe des Einsatzes des Feldes 0, um 10.
                guthaben -= 10;
                lblGuthaben.Content = guthaben.ToString();
            }
            else if (farbe == jetonFuenfundzwanzig)
            {
                einsatz += 25; // Erhöht den Gesamteinsatz um 5.
                farbenListe[zahl] += 25; // Erhöht die Summe des Einsatzes des Feldes 0, um 25.
                guthaben -= 25;
                lblGuthaben.Content = guthaben.ToString();
            }
            else
            {
                einsatz += 50; // Erhöht den Gesamteinsatz um 5.
                farbenListe[zahl] += 50; // Erhöht die Summe des Einsatzes des Feldes 0, um 50.
                guthaben -= 50;
                lblGuthaben.Content = guthaben.ToString();
            }

            lblEinsatz.Content = einsatz; // Anzeige des Gesamteinsatzes. 
            //lblGewinn.Content = gesamtGewinn;

            return jeton;
        }

        private Ellipse JetonAufGerade(int zahl, int top, int left, Canvas feld, ImageBrush farbe)
        {
            if (bild1)
            {
                rs.PlaySound("RSounds/JetonSetzten.wav");
            }

            Ellipse jeton = new Ellipse();
            jeton.Fill = farbe;
            jeton.Width = 35;
            jeton.Height = 35;
            cvsHintergrund.Children.Add(jeton);

            Canvas.SetTop(jeton, top);
            Canvas.SetLeft(jeton, left);
            Panel.SetZIndex(feld, 10);

            if (farbe == jetonFuenf)
            {
                einsatz += 5; // Erhöht den Gesamteinsatz um 5.
                unGeradenListe[zahl] += 5; // Erhöht die Summe des Einsatzes des Feldes 0, um 5.
                guthaben -= 5;
                lblGuthaben.Content = guthaben.ToString();
            }
            else if (farbe == jetonZehn)
            {
                einsatz += 10; // Erhöht den Gesamteinsatz um 10.
                unGeradenListe[zahl] += 10; // Erhöht die Summe des Einsatzes des Feldes 0, um 10.
                guthaben -= 10;
                lblGuthaben.Content = guthaben.ToString();
            }
            else if (farbe == jetonFuenfundzwanzig)
            {
                einsatz += 25; // Erhöht den Gesamteinsatz um 5.
                unGeradenListe[zahl] += 25; // Erhöht die Summe des Einsatzes des Feldes 0, um 25.
                guthaben -= 25;
                lblGuthaben.Content = guthaben.ToString();
            }
            else
            {
                einsatz += 50; // Erhöht den Gesamteinsatz um 5.
                unGeradenListe[zahl] += 50; // Erhöht die Summe des Einsatzes des Feldes 0, um 50.
                guthaben -= 50;
                lblGuthaben.Content = guthaben.ToString();
            }

            lblEinsatz.Content = einsatz; // Anzeige des Gesamteinsatzes. 
            //lblGewinn.Content = gesamtGewinn;

            return jeton;
        }

        // **********************************
        // * Feld gerade und ungerade       *
        // **********************************

        private void cvsGerade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (guthaben > 0)
            {
                if (WindowState == WindowState.Maximized)
                {
                    if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95 && guthaben >= 5)
                        JetonAufGerade(0, 626, 650, cvsGerade, jetonFuenf);
                    else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90 && guthaben >= 10)
                        JetonAufGerade(0, 626, 650, cvsGerade, jetonZehn);
                    else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75 && guthaben >= 25)
                        JetonAufGerade(0, 626, 650, cvsGerade, jetonFuenfundzwanzig);
                    else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50 && guthaben >= 50)
                        JetonAufGerade(0, 626, 650, cvsGerade, jetonFuenfzig);
                }
                else
                {
                    if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95)
                        JetonAufGerade(0, 456, 509, cvsGerade, jetonFuenf);
                    else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90)
                        JetonAufGerade(0, 456, 509, cvsGerade, jetonZehn);
                    else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75)
                        JetonAufGerade(0, 456, 509, cvsGerade, jetonFuenfundzwanzig);
                    else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50)
                        JetonAufGerade(0, 456, 509, cvsGerade, jetonFuenfzig);
                } 
            }

        }

        private void cvsUngerade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (guthaben > 0)
            {
                if (WindowState == WindowState.Maximized)
                {
                    if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95 && guthaben >= 5)
                        JetonAufGerade(1, 626, 962, cvsUngerade, jetonFuenf);
                    else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90 && guthaben >= 10)
                        JetonAufGerade(1, 626, 962, cvsUngerade, jetonZehn);
                    else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75 && guthaben >= 25)
                        JetonAufGerade(1, 626, 962, cvsUngerade, jetonFuenfundzwanzig);
                    else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50 && guthaben >= 50)
                        JetonAufGerade(1, 626, 962, cvsUngerade, jetonFuenfzig);
                }
                else
                {
                    if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95 && guthaben >= 5)
                        JetonAufGerade(1, 456, 755, cvsUngerade, jetonFuenf);
                    else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90 && guthaben >= 10)
                        JetonAufGerade(1, 456, 755, cvsUngerade, jetonZehn);
                    else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75 && guthaben >= 25)
                        JetonAufGerade(1, 456, 755, cvsUngerade, jetonFuenfundzwanzig);
                    else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50 && guthaben >= 50)
                        JetonAufGerade(1, 456, 755, cvsUngerade, jetonFuenfzig);
                } 
            }
        }


        // **********************************
        // * Feld rot und schwarz           *
        // **********************************

        private void cvsRot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!jetonVerfuegbar && guthaben > 0)
            {
                if (WindowState == WindowState.Maximized)
                {
                    if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95 && guthaben >= 5)
                        JetonAufFarbe(0, 626, 756, cvsRot, jetonFuenf);
                    else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90 && guthaben >= 10)
                        JetonAufFarbe(0, 626, 756, cvsRot, jetonZehn);
                    else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75 && guthaben >= 25)
                        JetonAufFarbe(0, 626, 756, cvsRot, jetonFuenfundzwanzig);
                    else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50 && guthaben >= 50)
                        JetonAufFarbe(0, 626, 756, cvsRot, jetonFuenfzig); 
                }
                else
                {
                    if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95 && guthaben >= 5)
                        JetonAufFarbe(0, 456, 593, cvsRot, jetonFuenf);
                    else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90 && guthaben >= 10)
                        JetonAufFarbe(0, 456, 593, cvsRot, jetonZehn);
                    else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75 && guthaben >= 25)
                        JetonAufFarbe(0, 456, 593, cvsRot, jetonFuenfundzwanzig);
                    else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50 && guthaben >= 50)
                        JetonAufFarbe(0, 456, 593, cvsRot, jetonFuenfzig);
                }
            }
        }

        private void cvsSchwarz_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!jetonVerfuegbar && guthaben > 0)
            {
                if (WindowState == WindowState.Maximized)
                {
                    if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95 && guthaben >= 5)
                        JetonAufFarbe(1, 626, 856, cvsSchwarz, jetonFuenf);
                    else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90 && guthaben >= 10)
                        JetonAufFarbe(1, 626, 856, cvsSchwarz, jetonZehn);
                    else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75 && guthaben >= 25)
                        JetonAufFarbe(1, 626, 856, cvsSchwarz, jetonFuenfundzwanzig);
                    else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50 && guthaben >= 50)
                        JetonAufFarbe(1, 626, 856, cvsSchwarz, jetonFuenfzig); 
                }
                else
                {
                if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible && einsatz <= 95 && guthaben >= 5)
                    JetonAufFarbe(1, 456, 672, cvsSchwarz, jetonFuenf);
                else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible && einsatz <= 90 && guthaben >= 10)
                    JetonAufFarbe(1, 456, 672, cvsSchwarz, jetonZehn);
                else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 75 && guthaben >= 25)
                    JetonAufFarbe(1, 456, 672, cvsSchwarz, jetonFuenfundzwanzig);
                else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible && einsatz <= 50 && guthaben >= 50)
                    JetonAufFarbe(1, 456, 672, cvsSchwarz, jetonFuenfzig);

            }
        }
    }

        #endregion


    }
    
}