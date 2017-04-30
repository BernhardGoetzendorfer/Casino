using qrcodeDeEncoder;
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
using MessagingToolkit.QRCode.Codec;
using Datenbank;

namespace QrcodeErstellerKassa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        dbCasino_IN19Entities db = new dbCasino_IN19Entities();
        Qrcode qr = new Qrcode();
        BitmapImage bild;
        int wert;
        string qrcodeInhalt;

        public MainWindow()
        {
            InitializeComponent();
            
        }
       
        private void Erstellen()
        {   
            //Qrcode Erzeugen
            bild = qr.Encoden(qrcodeInhalt);
            iBild.Source = bild;
        }

        private void Generieren(object sender, RoutedEventArgs e)
        {

            string inhalt = ((Button)sender).Content.ToString();
            if ( inhalt == "5")
            {
                wert = 5;
                zahlerzeugen();
                Erstellen();
            }
            else if(inhalt == "10")
            {
                wert = 10;
                zahlerzeugen();
                Erstellen();
            }
            else if (inhalt == "25")
            {
                wert = 25;
                zahlerzeugen();
                Erstellen();
            }
            else if (inhalt == "50")
            {
                wert = 50;
                zahlerzeugen();
                Erstellen();
            }
        }

        private void zahlerzeugen()
        {
            Random rd = new Random();
            Q4R c = new Q4R();
            qrcodeInhalt = "" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + "-" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + "-" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
            bool neu = true;
            do
            {
                foreach (var code in db.tblQ4R)
                {
                    if (code.QRBAN == qrcodeInhalt || code == null)
                        qrcodeInhalt = "" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + "-" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + "-" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
                    else
                    {
                        neu = false;
                        c = new Q4R() { QRBAN = qrcodeInhalt, value = wert };
                    }
                   
                }
            } while (neu);

            db.tblQ4R.Add(c);
            db.SaveChanges();



        }
    }

}
