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
using System.Windows.Threading;

namespace Roulette0._0._8
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // @Stekal: Kessel- und Kugeltimer
        DispatcherTimer kesselTimer = new DispatcherTimer();
        DispatcherTimer kugelTimer = new DispatcherTimer();
        TimeSpan restZeitKessel = new TimeSpan(0, 0, 0, 0, 50);
        TimeSpan restZeitKugel = new TimeSpan(0, 0, 0, 3, 50);

        // @Stekal: Kugelsgeschwindigkeit
        double geschwindigkeitKugel;

        // @Stekal: Diese Membervariable wird benötigt damit die Rotation funktioniert
        RotateTransform rotierungKessel = new RotateTransform(0);
        RotateTransform rotierungKugel = new RotateTransform(0);

        Random rnd = new Random();
        int zufall;

        

        public MainWindow()
        {
            InitializeComponent();

            kugelTimer.Tick += KugelTimer_Tick;
            kesselTimer.Tick += Timer_Tick;
            UeberpruefListenBefuellen();
            AllesAufAnfang();

            // Befüllt die 3 Listen, die zur Überprüfung benötigt werden
            
        }

        //__________________________________________________________________________________________________________________________

        //                  B E W E G U N G   D E R   K U G E L

        bool rundenErreicht = false;


        /// <summary>
        /// @Stekal:
        /// Hier wird definiert was alle 20 Millisekunden mit der Kugel passiert.+
        /// Überprüfung wie weit die Kugel gefahren ist (in Grad).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KugelTimer_Tick(object sender, EventArgs e)
        {
            eliKugel.Visibility = Visibility.Visible;

            KugelEndspurt();
            KugelVerlangsamen();




            // @Stekal:
            // Wenn die Kugel x Runden erreicht hat wird die Richtung der
            // Kugel velangsamt und in die andere Richtung gedreht
            // der Boolsche Wert wird auf true gesetzt, damit die Verzweigung
            // wo die Kugel in die andere Richtung fährt aufgerufen wird.
            if (rotierungKugel.Angle <= -360 && !rundenErreicht)
            {
                restZeitKugel -= kugelTimer.Interval;
                eliKugel.RenderTransform = rotierungKugel;
                rotierungKugel.Angle -= geschwindigkeitKugel;

                if (geschwindigkeitKugel <= 1)
                    rundenErreicht = true;
            }
            else if (!rundenErreicht)
            {
                restZeitKugel -= kugelTimer.Interval;
                eliKugel.RenderTransform = rotierungKugel;
                rotierungKugel.Angle -= geschwindigkeitKugel; // -3
            }
            else if (rundenErreicht)
            {

                geschwindigkeitKugel = 1;
                lblZahl.Content = zufall.ToString();

                

                //@Christof Label Gewinnzahl Farbe änderung
                if (zufall.ToString() == "0")
                {
                    lblZahl.Background = Brushes.Green;
                    lblGewinn.Content = gesamtGewinn;
                    
                    








                }
                else if (zufall.ToString() == "2" || zufall.ToString() == "4" || zufall.ToString() == "6" ||
                                                    zufall.ToString() == "8" || zufall.ToString() == "10" ||
                                                    zufall.ToString() == "11" || zufall.ToString() == "13" ||
                                                    zufall.ToString() == "15" || zufall.ToString() == "17" ||
                                                    zufall.ToString() == "20" || zufall.ToString() == "22" ||
                                                    zufall.ToString() == "24" || zufall.ToString() == "26" ||
                                                    zufall.ToString() == "28" || zufall.ToString() == "29" ||
                                                    zufall.ToString() == "31" || zufall.ToString() == "33" ||
                                                    zufall.ToString() == "35")
                {
                    lblZahl.Background = Brushes.Black;
                    lblGewinn.Content = gesamtGewinn;
                }
                else
                {
                    lblZahl.Background = Brushes.Red;
                    lblGewinn.Content = gesamtGewinn;
                }


                rotierungKugel.Angle += geschwindigkeitKugel; // +1
                restZeitKugel -= kugelTimer.Interval;
                if (rotierungKugel.Angle == 180)
                {
                    kugelTimer.Stop();
                    rundenErreicht = false;
                    eliKugel.Visibility = Visibility.Hidden;
                }


            }

            lblGewinn.Content = gesamtGewinn;
        }


        //@ Christof Überprüfung ob Jeton gesetzt wurde

          
            


            


        //__________________________________________________________________________________________________________________________

        //                  K U G E L   I N   D E N   K E S S E L   Z I E H E N

        /// <summary>
        /// @Stekal
        /// Diese Variablen werden alleine nur für die Animation, dass sich die
        /// Kugel in den Kessel hinein bewegt benötigt.
        /// </summary>
        double gradVonOben = -360;
        double gradVonUnten = -180;
        double yAchse;
        double xAchse;

        // @Stekal:
        // hier wird immer die Position "Canvas.GetTop()" oder "Canvas.GetLeft"
        // hineingespeichert
        int position;

        /// <summary>
        /// @Stekal:
        /// Mittels dieser Methode wird die Kugel von Runde zu Runde weiter in die Mitte gezogen,
        /// um eine realistischere Animation zu generieren.
        /// </summary>
        private void KugelEndspurt()
        {
            /*              O R I G I N A L - P O S I T I O N 

            von Oben:

                Canvas.Top="25"
                Canvas.Left="150"
                Stroke="Black" RenderTransformOrigin="-2.6,9.8">    
              
            */


            if (rotierungKugel.Angle <= (gradVonOben + 7) && rotierungKugel.Angle >= (gradVonOben - 7))
            {
                yAchse -= 0.5;
                // Wenn man von Oben um 1 runter geht, setzt man den neuen Punkt (y-Achse) um -0.1
                // eliKugel.RenderTransformOrigin = new Point(-2.6, 9.8);
                eliKugel.RenderTransformOrigin = new Point(xAchse, yAchse);
                //Canvas.SetTop(eliKugel, positionVonOben);
                position = int.Parse(Canvas.GetTop(eliKugel).ToString()) + 5;
                Canvas.SetTop(eliKugel, position);
                gradVonOben -= 360;
            }
            else if (rotierungKugel.Angle <= (gradVonUnten + 7) && rotierungKugel.Angle >= (gradVonUnten - 7))
            {
                yAchse -= 0.5;

                eliKugel.RenderTransformOrigin = new Point(xAchse, yAchse);
                position = int.Parse(Canvas.GetTop(eliKugel).ToString()) + 5;
                Canvas.SetTop(eliKugel, position);
                gradVonUnten -= 360;
            }


        }

        //__________________________________________________________________________________________________________________________

        //              K U G E L   V E R L A N G S A M E N

        // @Stekal:
        // wenn die Kugel einen bestimmten Umdrehungspunkt erreicht,
        // dann wird diese Variable zum vergleichen benötigt.
        double kreisUmdrehung = 0;

        private void KugelVerlangsamen()
        {
            // @Stekal:
            // Ich habe zuerst versucht alle 180° von der Kugel aus gesehn die Kugel um 0,1 zu veringern,
            // doch da ab der 1. Veringerung die Grade, in der die Kugel steht bis zu dieser Überprüfung,
            // die Bewegung in Kommazahlen ändert, muss ich Werte mit größer als und kleiner als verwenden. // 2* (bis -720)
            if (rotierungKugel.Angle > -720 && rotierungKugel.Angle <= (kreisUmdrehung + 5) && rotierungKugel.Angle >= (kreisUmdrehung - 5))
            {
                geschwindigkeitKugel -= 0.7;
                kreisUmdrehung -= 360;
            } // 6 * (bis -1440)
            else if (rotierungKugel.Angle > -1440 && rotierungKugel.Angle <= (kreisUmdrehung + 4) && rotierungKugel.Angle >= (kreisUmdrehung - 4))
            {
                geschwindigkeitKugel -= 1;
                kreisUmdrehung -= 180;
            } // 2 * (bis -2160)
            else if (rotierungKugel.Angle > -2160 && rotierungKugel.Angle <= (kreisUmdrehung + 4) && rotierungKugel.Angle >= (kreisUmdrehung - 4))
            {
                geschwindigkeitKugel -= 1;
                kreisUmdrehung -= 90;
                string stopPosition = rotierungKugel.Angle.ToString();
            }
        }

        //________________________________________________________________________________________________________________________

        //                  K E S S E L   R O T I E R U N G

        private void Timer_Tick(object sender, EventArgs e)
        {
            GenauBeiNull();

            restZeitKessel = kesselTimer.Interval;

            // hier weise ich der Ellipse (Kreis) die Rotation zu
            eliKesselInnere.RenderTransform = rotierungKessel;
            // Hier sag ich, dass das Bild immer um 1 (Grad) 
            // nach rechts rotieren soll.
            rotierungKessel.Angle += 1;
        }

        /// <summary>
        /// @Stekal:
        /// Hier wird auf genau 360 Grad abgestoppt 
        /// </summary>
        private void GenauBeiNull()
        {
            if (rotierungKessel.Angle == 360)
                rotierungKessel.Angle = 0;

        }

        //________________________________________________________________________________________________________________________

        private void btnDrehen_Click(object sender, RoutedEventArgs e)
        {
            // @Stekal:
            // Damit die Animation steuerbar ist wird das Rad auf eine 
            // Standard-Startposition gesetzt (sofern gerade keine Animation
            // vorhanden ist
            if (eliKugel.Visibility == Visibility.Hidden)
            {
                zufall = rnd.Next(5, 6);
                AllesAufAnfang();
                rotierungKessel.Angle = StartPosition()[4];
                kugelTimer.Start();
                
            }
            else if (rundenErreicht)
            {
                eliKugel.Visibility = Visibility.Hidden;
                kugelTimer.Stop();
                AllesAufAnfang();
               
                lblGewinn.Content = gesamtGewinn;
            }
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // @Stekal:
            // Damit die Animation steuerbar ist wird das Rad auf eine 
            // Standard-Startposition gesetzt (sofern gerade keine Animation
            // vorhanden ist
            if (eliKugel.Visibility == Visibility.Hidden)
            {
                zufall = rnd.Next(5, 6);
                AllesAufAnfang();
                rotierungKessel.Angle = StartPosition()[4];
                kugelTimer.Start();
               
            }
            else if (rundenErreicht)
            {
                eliKugel.Visibility = Visibility.Hidden;
                kugelTimer.Stop();
                AllesAufAnfang();
                
                lblZahl.Content = "";
            }
        }


        /// <summary>
        /// @Stekal:
        /// Mittels dieser Methode werden die Werte vom Kessel und von der Kugel wieder auf Anfang gesetzt.
        /// </summary>
        private void AllesAufAnfang()
        {
            

            kesselTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            kesselTimer.Start();

            kugelTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);


            eliKugel.Visibility = Visibility.Hidden;
            geschwindigkeitKugel = 10;
            rundenErreicht = false;

            rotierungKugel.Angle = 0;

            kreisUmdrehung = 0;

            // Kugel Standardwerte:120
            Canvas.SetTop(eliKugel, StartPosition()[0]);
            Canvas.SetLeft(eliKugel, StartPosition()[1]);
            //-0.6,10.1
            gradVonOben = -360;
            gradVonUnten = -540;
            xAchse = StartPosition()[2];
            yAchse = StartPosition()[3];
            eliKugel.RenderTransformOrigin = new Point(xAchse, yAchse);


            //{
            //    startPositionen.Add(17);
            //    startPositionen.Add(115);
            //    startPositionen.Add(0.9);
            //    startPositionen.Add(10.6);
            //    startPositionen.Add(-138);
            //}
        }


        /// <summary>
        /// @Stekal:
        /// Hier wird die zufällige Zahl verglichen und die
        /// Koordinaten so geändert, dass das mit der gezogenen
        /// Zahl übereinstimmt.
        /// </summary>
        /// <returns></returns>
        private List<double> StartPosition()
        {
            List<double> startPositionen = new List<double>();

            if (zufall == 0)
            {
                startPositionen.Add(30);  // TOP-Kugel
                startPositionen.Add(81);  // LEFT-Kugel
                startPositionen.Add(4.3);  // eliKugel.RenderTransformOrigin X
                startPositionen.Add(9.3);  // eliKugel.RenderTransformOrigin Y
                startPositionen.Add(18);  // rotierungKessel.Angle


                if (zahlenListe[0] > 0)     // wenn der Wert grösser als 0 ist
                    gesamtGewinn = zahlenListe[0] * 36;     // multipliziere den Einsatz mit 36
                                                            // und füge ihm in die Variable "gesamtGewinn" ein

                EinsatzAufNull();
            }
            else if (zufall == 1)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(193);

                Gewinnpruefung(1, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 2)
            {
                startPositionen.Add(20);
                startPositionen.Add(128);
                startPositionen.Add(-0.4);
                startPositionen.Add(10.3);
                startPositionen.Add(10);

                Gewinnpruefung(2, Schwarz(), Gerade());
                EinsatzAufNull();

            }
            else if (zufall == 3)
            {
                startPositionen.Add(30);
                startPositionen.Add(81);
                startPositionen.Add(4.3);
                startPositionen.Add(9.3);
                startPositionen.Add(38);

                Gewinnpruefung(3, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 4)
            {
                startPositionen.Add(20);
                startPositionen.Add(117);
                startPositionen.Add(0.7);
                startPositionen.Add(10.3);
                startPositionen.Add(20);

                Gewinnpruefung(4, Schwarz(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 5)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(-129);

                Gewinnpruefung(5, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 6)
            {
                startPositionen.Add(20);
                startPositionen.Add(137);
                startPositionen.Add(-1.3);
                startPositionen.Add(10.3);
                startPositionen.Add(342);

                Gewinnpruefung(6, Schwarz(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 7)
            {
                startPositionen.Add(30);
                startPositionen.Add(81);
                startPositionen.Add(4.3);
                startPositionen.Add(9.3);
                startPositionen.Add(77);

                Gewinnpruefung(7, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 8)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(-100);

                Gewinnpruefung(8, Schwarz(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 9)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(153);

                Gewinnpruefung(9, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 10)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(-119);

                Gewinnpruefung(10, Schwarz(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 11)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(-80);

                Gewinnpruefung(11, Schwarz(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 12)
            {
                startPositionen.Add(30);
                startPositionen.Add(81);
                startPositionen.Add(4.3);
                startPositionen.Add(9.3);
                startPositionen.Add(58);

                Gewinnpruefung(12, Rot(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 13)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(-60);

                Gewinnpruefung(13, Schwarz(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 14)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(173);

                Gewinnpruefung(14, Rot(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 15)
            {
                startPositionen.Add(25);
                startPositionen.Add(150);
                startPositionen.Add(-2.6);
                startPositionen.Add(9.8);
                startPositionen.Add(73);

                Gewinnpruefung(15, Schwarz(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 16)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(-148);

                Gewinnpruefung(16, Rot(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 17)
            {
                startPositionen.Add(25);
                startPositionen.Add(145);
                startPositionen.Add(-2.1);
                startPositionen.Add(9.8);
                startPositionen.Add(10);

                Gewinnpruefung(17, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 18)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(134);

                Gewinnpruefung(18, Rot(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 19)
            {
                startPositionen.Add(19);
                startPositionen.Add(117);
                startPositionen.Add(0.7);
                startPositionen.Add(10.5);
                startPositionen.Add(30);

                Gewinnpruefung(19, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 20)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(183);

                Gewinnpruefung(20, Schwarz(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 21)
            {
                startPositionen.Add(20);
                startPositionen.Add(117);
                startPositionen.Add(0.7);
                startPositionen.Add(10.3);
                startPositionen.Add(10);

                Gewinnpruefung(21, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 22)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(144);

                Gewinnpruefung(22, Schwarz(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 23)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(-109);

                Gewinnpruefung(23, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 24)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(-138);

                Gewinnpruefung(24, Schwarz(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 25)
            {
                startPositionen.Add(20);
                startPositionen.Add(137);
                startPositionen.Add(-1.3);
                startPositionen.Add(10.3);
                startPositionen.Add(10);

                Gewinnpruefung(25, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 26)
            {
                startPositionen.Add(30);
                startPositionen.Add(81);
                startPositionen.Add(4.3);
                startPositionen.Add(9.3);
                startPositionen.Add(28);

                Gewinnpruefung(26, Schwarz(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 27)
            {
                startPositionen.Add(25);
                startPositionen.Add(145);
                startPositionen.Add(-2.1);
                startPositionen.Add(9.8);
                startPositionen.Add(342);

                Gewinnpruefung(27, Rot(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 28)
            {
                startPositionen.Add(30);
                startPositionen.Add(81);
                startPositionen.Add(4.3);
                startPositionen.Add(9.3);
                startPositionen.Add(67);

                Gewinnpruefung(28, Schwarz(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 29)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(123);

                Gewinnpruefung(29, Schwarz(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 30)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(-90);

                Gewinnpruefung(30, Rot(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 31)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(163);

                Gewinnpruefung(31, Schwarz(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 32)
            {
                startPositionen.Add(30);
                startPositionen.Add(81);
                startPositionen.Add(4.3);
                startPositionen.Add(9.3);
                startPositionen.Add(9);

                Gewinnpruefung(32, Rot(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 33)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(202);

                Gewinnpruefung(33, Schwarz(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 34)
            {
                startPositionen.Add(25);
                startPositionen.Add(145);
                startPositionen.Add(-2.1);
                startPositionen.Add(9.8);
                startPositionen.Add(360);

                Gewinnpruefung(34, Rot(), Gerade());
                EinsatzAufNull();
            }
            else if (zufall == 35)
            {
                startPositionen.Add(30);
                startPositionen.Add(81);
                startPositionen.Add(4.3);
                startPositionen.Add(9.3);
                startPositionen.Add(48);

                Gewinnpruefung(35, Schwarz(), Ungerade());
                EinsatzAufNull();
            }
            else if (zufall == 36)
            {
                startPositionen.Add(17);
                startPositionen.Add(115);
                startPositionen.Add(0.9);
                startPositionen.Add(10.6);
                startPositionen.Add(-70);

                Gewinnpruefung(36, Rot(), Gerade());
                EinsatzAufNull();

                
            }

            return startPositionen;
        }




        private void btnSchliessen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } // @Stekal: Kessel 




        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        //                      M A R T I N

        // @Stekal:
        // kleine Hilfsmethoden zum setzen und überprüfen

        private int Rot()
        {
            return 0;
        }

        private int Schwarz()
        {
            return 1;
        }

        private int Gerade()
        {
            return 0;
        }

        private int Ungerade()
        {
            return 1;
        }

        /// <summary>
        /// @Stekal:
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
            if (zahl > 0)
            {
                gesamtGewinn = (zahlenListe[zahl] * 36);
                lblGewinn.Content = gesamtGewinn;
            }

            if (farbenListe[farbe] > 0)
               gesamtGewinn = farbenListe[farbe] * 2;

            if (unGeradenListe[unGerade] > 0)
                gesamtGewinn = unGeradenListe[unGerade] * 2;
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

        /// <summary>
        /// @Stekal:
        /// Befüllt die zum überprüfen benötigte Listen mit den Startwerten.
        /// Damit in der Zahlenliste 36 Werte vorhanden sind.
        /// Damit in der farbenListe 2 Werte für "rot" und "schwarz" vorhanden sind.
        /// Damit in der unGeradenListe 2 werte vorhanden sind.
        /// </summary>
        private void UeberpruefListenBefuellen()
        {
            // Zahlen
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0); // 5
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0); // 10
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0); // 15
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0); // 20
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0); // 25
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0); // 30
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0);
            zahlenListe.Add(0); 
            zahlenListe.Add(0);// 35
            zahlenListe.Add(0); // 36

            // Farben
            farbenListe.Add(0); // Rot
            farbenListe.Add(0); // Schwarz

            // Gerade ungerade
            unGeradenListe.Add(0);  // gerade
            unGeradenListe.Add(0);  // ungerade

        }

        #region GesetzteFeldWerte

        // @Stekal:
        // Zahlen wie Index von 0 bis 36
        List<int> zahlenListe = new List<int>();
        // @Stekal: [0] = rot, [1] = schwarz
        List<int> farbenListe = new List<int>();
        // @Stekal: [0] = gerade, [1] = ungerade
        List<int> unGeradenListe = new List<int>();

        int gesamtGewinn = 0;



        #endregion


        #region JetonHintergrund

        // @Martin/Christoph auf Stick
        //ImageBrush blau = new ImageBrush(new BitmapImage(new Uri(@"F:\VS_Projekte\Setz_Buttons\Roulette_Geruest\jeton_blau.png")));
        //ImageBrush gelb = new ImageBrush(new BitmapImage(new Uri(@"F:\VS_Projekte\Setz_Buttons\Roulette_Geruest\jeton_gelb.png")));

        ImageBrush tuerkis = new ImageBrush(new BitmapImage(new Uri("./05.png", UriKind.Relative)));
        ImageBrush grau = new ImageBrush(new BitmapImage(new Uri("./10.png", UriKind.Relative)));
        ImageBrush blau = new ImageBrush(new BitmapImage(new Uri("./25.png", UriKind.Relative)));
        ImageBrush lila = new ImageBrush(new BitmapImage(new Uri("./50.png", UriKind.Relative)));



        #endregion

        int einsatz = 0;
       

        #region JetonsAuswahl




        private void jeton5Auswahl(object sender, MouseButtonEventArgs e)
        {
            eliJetonZehnGewaehlt.Visibility = Visibility.Hidden;
            eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Hidden;
            eliJetonFuenfzigGewaehlt.Visibility = Visibility.Hidden;


            // Vergrößert bzw. verkleinert den Jeton 5 selektiert/deselektiert
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Hidden)
            {
                eliJetonFuenfGewaehlt.Visibility = Visibility.Visible;
                
            }
            else if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                eliJetonFuenfGewaehlt.Visibility = Visibility.Hidden;
                
            }
        }

        private void jeton10Auswahl(object sender, MouseButtonEventArgs e)
        {
            eliJetonFuenfGewaehlt.Visibility = Visibility.Hidden;
            eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Hidden;
            eliJetonFuenfzigGewaehlt.Visibility = Visibility.Hidden;

            // Vergrößert bzw. verkleinert den Jeton 10 selektiert/deselektiert
            if (eliJetonZehnGewaehlt.Visibility == Visibility.Hidden)
            {
                eliJetonZehnGewaehlt.Visibility = Visibility.Visible;
              
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                eliJetonZehnGewaehlt.Visibility = Visibility.Hidden;
              
            }

        }

        private void jeton25Auswahl(object sender, MouseButtonEventArgs e)
        {
            eliJetonZehnGewaehlt.Visibility = Visibility.Hidden;
            eliJetonFuenfGewaehlt.Visibility = Visibility.Hidden;
            eliJetonFuenfzigGewaehlt.Visibility = Visibility.Hidden;

            if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Hidden)
            {
                eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Visible;

            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Hidden;

            }

        }

        private void jeton50Auswahl(object sender, MouseButtonEventArgs e)
        {
            eliJetonZehnGewaehlt.Visibility = Visibility.Hidden;
            eliFuenfUndZwanzigGewaehlt.Visibility = Visibility.Hidden;
            eliJetonFuenfGewaehlt.Visibility = Visibility.Hidden;

            if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Hidden)
            {
                eliJetonFuenfzigGewaehlt.Visibility = Visibility.Visible;

            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
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


            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonFeldNull(0, 511, 470, polFeld0, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonFeldNull(0, 511, 470, polFeld0, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonFeldNull(0, 511, 470, polFeld0, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonFeldNull(0, 511, 470, polFeld0, lila);
            }

           
        }

        

        private void cvsEins_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Feld 1!!
            // Prüft im Feld 1 ob Jeton 5 gewählt ist, wenn ja erhöht es den Wert jeweils um 5


            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(1, 575, 526, cvsEins, tuerkis);
            }

            // Prüft im Feld 1 ob Jeton 10 gewählt ist, wenn ja erhöht es den Wert jeweils um 10
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(1, 575, 526, cvsEins, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(1, 575, 526, cvsEins, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(1, 575, 526, cvsEins, lila);
            }
        }

        private void cvsZwei_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            // Feld 2!!
            // Prüft im Feld 2 ob Jeton 5 gewählt ist, wenn ja erhöht es den Wert jeweils um 5


            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(2, 512, 526, cvsZwei, tuerkis);
            }

            // Prüft im Feld 2 ob Jeton 10 gewählt ist, wenn ja erhöht es den Wert jeweils um 10
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(2, 512, 526, cvsZwei, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(2, 512, 526, cvsZwei, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(2, 512, 526, cvsZwei, lila);
            }
        }

        private void cvsDrei_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(3, 450, 526, cvsDrei, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(3, 450, 526, cvsDrei, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(3, 450, 526, cvsDrei, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(3, 450, 526, cvsDrei, lila);
            }
        }

        private void cvsVier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(4, 575, 576, cvsVier, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(4, 575, 576, cvsVier, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(4, 575, 576, cvsVier, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(4, 575, 576, cvsVier, lila);
            }
        }

        private void cvsFuenf_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(5, 512, 576, cvsFuenf, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(5, 512, 576, cvsFuenf, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(5, 512, 576, cvsFuenf, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(5, 512, 576, cvsFuenf, lila);
            }
        }

        private void cvsSechs_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(6, 450, 576, cvsSechs, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(6, 450, 576, cvsSechs, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(6, 450, 576, cvsSechs, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(6, 450, 576, cvsSechs, lila);
            }
        }

        private void cvsSieben_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(7, 575, 625, cvsSieben, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(7, 575, 625, cvsSieben, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(7, 575, 625, cvsSieben, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(7, 575, 625, cvsSieben, lila);
            }
        }

        private void cvsAcht_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(8, 512, 625, cvsAcht, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(8, 512, 625, cvsAcht, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(8, 512, 625, cvsAcht, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(8, 512, 625, cvsAcht, lila);
            }
        }

        private void cvsNeun_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(9, 450, 625, cvsNeun, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(9, 450, 625, cvsNeun, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(9, 450, 625, cvsNeun, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(9, 450, 625, cvsNeun, lila);
            }
        }

        private void cvsZehn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(10, 575, 675, cvsZehn, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(10, 575, 675, cvsZehn, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(10, 575, 675, cvsZehn, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(10, 575, 675, cvsZehn, lila);
            }
        }

        private void cvsElf_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(11, 512, 675, cvsElf, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(11, 512, 675, cvsElf, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(11, 512, 675, cvsElf, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(11, 512, 675, cvsElf, lila);
            }
        }

        private void cvsZwoelf_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(12, 450, 675, cvsZwoelf, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(12, 450, 675, cvsZwoelf, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(12, 450, 675, cvsZwoelf, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(12, 450, 675, cvsZwoelf, lila);
            }
        }

        private void cvsDreiZehn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(13, 575, 731, cvsDreiZehn, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(13, 575, 731, cvsDreiZehn, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(13, 575, 731, cvsDreiZehn, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(13, 575, 731, cvsDreiZehn, lila);
            }
        }

        private void cvsVierZehn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(14, 512, 731, cvsVierZehn, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(14, 512, 731, cvsVierZehn, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(14, 512, 731, cvsVierZehn, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(14, 512, 731, cvsVierZehn, lila);
            }
        }

        private void cvsFuenfZehn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(15, 450, 731, cvsFuenfZehn, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(15, 450, 731, cvsFuenfZehn, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(15, 450, 731, cvsFuenfZehn, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(15, 450, 731, cvsFuenfZehn, lila);
            }
        }

        private void cvsSechsZehn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(16, 575, 781, cvsSechsZehn, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(16, 575, 781, cvsSechsZehn, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(16, 575, 781, cvsSechsZehn, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(16, 575, 781, cvsSechsZehn, lila);
            }
        }

        private void cvsSiebZehn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(17, 512, 781, cvsSiebZehn, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(17, 512, 781, cvsSiebZehn, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(17, 512, 781, cvsSiebZehn, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(17, 512, 781, cvsSiebZehn, lila);
            }

            
        }

        private void cvsAchtZehn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(18, 450, 781, cvsAchtZehn, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(18, 450, 781, cvsAchtZehn, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(18, 450, 781, cvsAchtZehn, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(18, 450, 781, cvsAchtZehn, lila);
            }
        }

        private void cvsNeunZehn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(19, 575, 831, cvsNeunZehn, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(19, 575, 831, cvsNeunZehn, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(19, 575, 831, cvsNeunZehn, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(19, 575, 831, cvsNeunZehn, lila);
            }
        }

        private void cvsZwanzig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(20, 512, 831, cvsZwanzig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(20, 512, 831, cvsZwanzig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(20, 512, 831, cvsZwanzig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(20, 512, 831, cvsZwanzig, lila);
            }
        }

        private void cvsEinUndZwanzig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(21, 450, 831, cvsEinUndZwanzig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(21, 450, 831, cvsEinUndZwanzig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(21, 450, 831, cvsEinUndZwanzig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(21, 450, 831, cvsEinUndZwanzig, lila);
            }
        }

        private void cvsZweiUndZwanzig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(22, 575, 881, cvsZweiUndZwanzig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(22, 575, 881, cvsZweiUndZwanzig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(22, 575, 881, cvsZweiUndZwanzig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(22, 575, 881, cvsZweiUndZwanzig, lila);
            }
        }

        private void cvsDreiUndZwanzig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(23, 512, 881, cvsDreiUndZwanzig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(23, 512, 881, cvsDreiUndZwanzig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(23, 512, 881, cvsDreiUndZwanzig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(23, 512, 881, cvsDreiUndZwanzig, lila);
            }
        }

        private void cvsVierUndZwanzig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(24, 450, 881, cvsVierUndZwanzig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(24, 450, 881, cvsVierUndZwanzig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(24, 450, 881, cvsVierUndZwanzig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(24, 450, 881, cvsVierUndZwanzig, lila);
            }
        }

        private void csvFuenfUndZwanzig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(25, 575, 937, csvFuenfUndZwanzig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(25, 575, 937, csvFuenfUndZwanzig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(25, 575, 937, csvFuenfUndZwanzig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(25, 575, 937, csvFuenfUndZwanzig, lila);
            }
        }

        private void cvsSechsUndZwanzig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(26, 512, 937, cvsSechsUndZwanzig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(26, 512, 937, cvsSechsUndZwanzig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(26, 512, 937, cvsSechsUndZwanzig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(26, 512, 937, cvsSechsUndZwanzig, lila);
            }
        }

        private void csvSiebenUndZwanzig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(27, 450, 937, csvSiebenUndZwanzig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(27, 450, 937, csvSiebenUndZwanzig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(27, 450, 937, csvSiebenUndZwanzig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(27, 450, 937, csvSiebenUndZwanzig, lila);
            }
        }

        private void csvAchtUndZwanzig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(28, 575, 987, csvAchtUndZwanzig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(28, 575, 987, csvAchtUndZwanzig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(28, 575, 987, csvAchtUndZwanzig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(28, 575, 987, csvAchtUndZwanzig, lila);
            }
        }

        private void cvsNeunUndZwanzig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(29, 512, 987, cvsNeunUndZwanzig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(29, 512, 987, cvsNeunUndZwanzig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(29, 512, 987, cvsNeunUndZwanzig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(29, 512, 987, cvsNeunUndZwanzig, lila);
            }
        }

        private void csvDreissig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(30, 450, 987, csvDreissig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(30, 450, 987, csvDreissig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(30, 450, 987, csvDreissig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(30, 450, 987, csvDreissig, lila);
            }
        }

        private void cvsEinUndDreissig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(31, 575, 1036, cvsEinUndDreissig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(31, 575, 1036, cvsEinUndDreissig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(31, 575, 1036, cvsEinUndDreissig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(31, 575, 1036, cvsEinUndDreissig, lila);
            }
        }

        private void cvsZweiUndDreissig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(32, 512, 1036, cvsZweiUndDreissig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(32, 512, 1036, cvsZweiUndDreissig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(32, 512, 1036, cvsZweiUndDreissig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(32, 512, 1036, cvsZweiUndDreissig, lila);
            }
        }

        private void cvsDreiUndDreissig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(33, 450, 1036, cvsDreiUndDreissig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(33, 450, 1036, cvsDreiUndDreissig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(33, 450, 1036, cvsDreiUndDreissig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(33, 450, 1036, cvsDreiUndDreissig, lila);
            }
        }

        private void cvsVierUndDreissig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(34, 575, 1087, cvsVierUndDreissig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(34, 575, 1087, cvsVierUndDreissig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(34, 575, 1087, cvsVierUndDreissig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(34, 575, 1087, cvsVierUndDreissig, lila);
            }
        }

        private void cvsFuenfUndDreissig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(35, 512, 1087, cvsFuenfUndDreissig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(35, 512, 1087, cvsFuenfUndDreissig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(35, 512, 1087, cvsFuenfUndDreissig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(35, 512, 1087, cvsFuenfUndDreissig, lila);
            }
        }

        private void cvsSechsUndDreissig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(36, 450, 1087, cvsSechsUndDreissig, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(36, 450, 1087, cvsSechsUndDreissig, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(36, 450, 1087, cvsSechsUndDreissig, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFeld(36, 450, 1087, cvsSechsUndDreissig, lila);
            }
        }

        private Ellipse JetonFeldNull(int zahl, int top, int left, Polygon feld, ImageBrush farbe)
        {
            Ellipse jeton = new Ellipse();
            jeton.Fill = farbe;
            jeton.Width = 35;
            jeton.Height = 35;
            cvsHintergrund.Children.Add(jeton);

            Canvas.SetTop(jeton, top);
            Canvas.SetLeft(jeton, left);
            Panel.SetZIndex(feld, 10);

            if (farbe == tuerkis)
            {
                einsatz += 5; // Erhöht den Gesamteinsatz um 5.
                zahlenListe[zahl] += 5; // Erhöht die Summe des Einsatzes des Feldes 0, um 5.
            }
            else if (farbe == grau)
            {
                einsatz += 10; // Erhöht den Gesamteinsatz um 10.
                zahlenListe[zahl] += 10; // Erhöht die Summe des Einsatzes des Feldes 0, um 10.
            }
            else if (farbe == blau)
            {
                einsatz += 25; // Erhöht den Gesamteinsatz um 5.
                zahlenListe[zahl] += 25; // Erhöht die Summe des Einsatzes des Feldes 0, um 25.
            }
            else
            {
                einsatz += 50; // Erhöht den Gesamteinsatz um 5.
                zahlenListe[zahl] += 50; // Erhöht die Summe des Einsatzes des Feldes 0, um 50.
            }


            lblEinsatz.Content = einsatz; // Anzeige des Gesamteinsatzes. 


            return jeton;
        }

        private Ellipse JetonAufFeld(int zahl, int top, int left, Canvas feld, ImageBrush farbe)
        {
            Ellipse jeton = new Ellipse();
            jeton.Fill = farbe;
            jeton.Width = 35;
            jeton.Height = 35;
            cvsHintergrund.Children.Add(jeton);

            Canvas.SetTop(jeton, top);
            Canvas.SetLeft(jeton, left);
            Panel.SetZIndex(feld, 10);

            if (farbe == tuerkis)
            {
                einsatz += 5; // Erhöht den Gesamteinsatz um 5.
                zahlenListe[zahl] += 5; // Erhöht die Summe des Einsatzes des Feldes 0, um 5.
            }
            else if (farbe == grau)
            {
                einsatz += 10; // Erhöht den Gesamteinsatz um 10.
                zahlenListe[zahl] += 10; // Erhöht die Summe des Einsatzes des Feldes 0, um 10.
            }
            else if (farbe == blau)
            {
                einsatz += 25; // Erhöht den Gesamteinsatz um 5.
                zahlenListe[zahl] += 25; // Erhöht die Summe des Einsatzes des Feldes 0, um 25.
            }
            else
            {
                einsatz += 50; // Erhöht den Gesamteinsatz um 5.
                zahlenListe[zahl] += 50; // Erhöht die Summe des Einsatzes des Feldes 0, um 50.
            }

            lblEinsatz.Content = einsatz; // Anzeige des Gesamteinsatzes. 
            lblGewinn.Content = gesamtGewinn;
            


            return jeton;
        }


        //// @Stekal:
        //// Zahlen wie Index von 0 bis 36
        //List<int> zahlenListe = new List<int>();
        //// @Stekal: [0] = rot, [1] = schwarz
        //List<int> farbenListe = new List<int>();
        //// @Stekal: [0] = gerade, [1] = ungerade
        //List<int> unGeradenListe = new List<int>();

        private Ellipse JetonAufFarbe(int zahl, int top, int left, Canvas feld, ImageBrush farbe)
        {
            Ellipse jeton = new Ellipse();
            jeton.Fill = farbe;
            jeton.Width = 35;
            jeton.Height = 35;
            cvsHintergrund.Children.Add(jeton);

            Canvas.SetTop(jeton, top);
            Canvas.SetLeft(jeton, left);
            Panel.SetZIndex(feld, 10);

            if (farbe == tuerkis)
            {
                einsatz += 5; // Erhöht den Gesamteinsatz um 5.
                farbenListe[zahl] += 5; // Erhöht die Summe des Einsatzes des Feldes 0, um 5.
            }
            else if (farbe == grau)
            {
                einsatz += 10; // Erhöht den Gesamteinsatz um 10.
                farbenListe[zahl] += 10; // Erhöht die Summe des Einsatzes des Feldes 0, um 10.
            }
            else if (farbe == blau)
            {
                einsatz += 25; // Erhöht den Gesamteinsatz um 5.
                farbenListe[zahl] += 25; // Erhöht die Summe des Einsatzes des Feldes 0, um 25.
            }
            else
            {
                einsatz += 50; // Erhöht den Gesamteinsatz um 5.
                farbenListe[zahl] += 50; // Erhöht die Summe des Einsatzes des Feldes 0, um 50.
            }

            lblEinsatz.Content = einsatz; // Anzeige des Gesamteinsatzes. 
            lblGewinn.Content = gesamtGewinn;



            return jeton;
        }

        private Ellipse JetonAufGerade(int zahl, int top, int left, Canvas feld, ImageBrush farbe)
        {
            Ellipse jeton = new Ellipse();
            jeton.Fill = farbe;
            jeton.Width = 35;
            jeton.Height = 35;
            cvsHintergrund.Children.Add(jeton);

            Canvas.SetTop(jeton, top);
            Canvas.SetLeft(jeton, left);
            Panel.SetZIndex(feld, 10);

            if (farbe == tuerkis)
            {
                einsatz += 5; // Erhöht den Gesamteinsatz um 5.
                unGeradenListe[zahl] += 5; // Erhöht die Summe des Einsatzes des Feldes 0, um 5.
            }
            else if (farbe == grau)
            {
                einsatz += 10; // Erhöht den Gesamteinsatz um 10.
                unGeradenListe[zahl] += 10; // Erhöht die Summe des Einsatzes des Feldes 0, um 10.
            }
            else if (farbe == blau)
            {
                einsatz += 25; // Erhöht den Gesamteinsatz um 5.
                unGeradenListe[zahl] += 25; // Erhöht die Summe des Einsatzes des Feldes 0, um 25.
            }
            else
            {
                einsatz += 50; // Erhöht den Gesamteinsatz um 5.
                unGeradenListe[zahl] += 50; // Erhöht die Summe des Einsatzes des Feldes 0, um 50.
            }

            lblEinsatz.Content = einsatz; // Anzeige des Gesamteinsatzes. 
            lblGewinn.Content = gesamtGewinn;



            return jeton;
        }

        // **********************************
        // * Feld gerade und ungerade       *
        // **********************************

        private void cvsGerade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufGerade(0, 626, 650, cvsGerade, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufGerade(0, 626, 650, cvsGerade, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufGerade(0, 626, 650, cvsGerade, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufGerade(0, 626, 650, cvsGerade, lila);
            }
        }

        private void cvsUngerade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufGerade(1, 626, 962, cvsUngerade, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufGerade(1, 626, 962, cvsUngerade, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufGerade(1, 626, 962, cvsUngerade, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufGerade(1, 626, 962, cvsUngerade, lila);
            }
        }


        // **********************************
        // * Feld rot und schwarz           *
        // **********************************

        private void cvsRot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFarbe(0, 626, 756, cvsRot, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFarbe(0, 626, 756, cvsRot, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFarbe(0, 626, 756, cvsRot, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFarbe(0, 626, 756, cvsRot, lila);
            }
        }

        private void cvsSchwarz_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliJetonFuenfGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFarbe(1, 626, 856, cvsSchwarz, tuerkis);
            }
            else if (eliJetonZehnGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFarbe(1, 626, 856, cvsSchwarz, grau);
            }
            else if (eliFuenfUndZwanzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFarbe(1, 626, 856, cvsSchwarz, blau);
            }
            else if (eliJetonFuenfzigGewaehlt.Visibility == Visibility.Visible)
            {
                JetonAufFarbe(1, 626, 856, cvsSchwarz, lila);
            }
        }

        #endregion

        //private Ellipse JetonZehnErstellen()
        //{
        //    Ellipse jetonZehn = new Ellipse();
        //    jetonZehn.Fill = grau;
        //    jetonZehn.Width = 40;
        //    jetonZehn.Height = 40;
        //    cvsHintergrund.Children.Add(jetonZehn);
        //    return jetonZehn;
        //}

       


        private void Drehen(object sender, RoutedEventArgs e)
        {
            //if (zufall == 0 && summeFeld0 > 0)
            //{
            //    summeFeld0 *= 36;
            //    lblGewinn.Content = summeFeld0;
            //}
        }

        /// <summary>
        /// Animation von Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_png_MouseEnter(object sender, MouseEventArgs e)
        {
            int top = int.Parse(Canvas.GetTop(StartButton_png).ToString());
            top += -15;
            Canvas.SetTop(StartButton_png, top);

        }

        private void StartButton_png_MouseLeave(object sender, MouseEventArgs e)
        {
            int top = int.Parse(Canvas.GetTop(StartButton_png).ToString());
            top += 15;
            Canvas.SetTop(StartButton_png, top);

        }

        private void ZurueckButton_png_MouseEnter(object sender, MouseEventArgs e)
        {
            int top = int.Parse(Canvas.GetTop(ZurueckButton_png).ToString());
            top += -15;
            Canvas.SetTop(ZurueckButton_png, top);
        }

        private void ZurueckButton_png_MouseLeave(object sender, MouseEventArgs e)
        {
            int top = int.Parse(Canvas.GetTop(ZurueckButton_png).ToString());
            top += 15;
            Canvas.SetTop(ZurueckButton_png, top);
        }

        private void löschenbutton_png_MouseEnter(object sender, MouseEventArgs e)
        {
            int top = int.Parse(Canvas.GetTop(löschenbutton_png).ToString());
            top += -15;
            Canvas.SetTop(löschenbutton_png, top);
        }

        private void löschenbutton_png_MouseLeave(object sender, MouseEventArgs e)
        {
            int top = int.Parse(Canvas.GetTop(löschenbutton_png).ToString());
            top += 15;
            Canvas.SetTop(löschenbutton_png, top);
        }

        private void StartButton_png_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eliKugel.Visibility == Visibility.Hidden)
            {
                zufall = rnd.Next(0, 37);
                AllesAufAnfang();
                rotierungKessel.Angle = StartPosition()[4];
                kugelTimer.Start();


            }
            else if (rundenErreicht)
            {
                eliKugel.Visibility = Visibility.Hidden;
                kugelTimer.Stop();
                AllesAufAnfang();


                lblGewinn.Content = gesamtGewinn;
            }
        }

        private void löschenbutton_png_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}



