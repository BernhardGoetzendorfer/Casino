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
using System.Windows.Shapes;

namespace IndividuellesFenster
{
    /// <summary>
    /// Interaction logic for PopupFenster.xaml
    /// </summary>
    public partial class PopupFenster : Window
    {
        public bool ja { get; set; } = false;

        public bool FW_JA { get; set; } = false;

        public PopupFenster()
        {
            InitializeComponent();
            cLogout.Visibility = Visibility.Hidden;
            cInfo.Visibility = Visibility.Hidden;
            cHighscore.Visibility = Visibility.Hidden;
        }


        /// <summary>
        /// MAKA Hier wird der String angezeigt den Ihr mitgibt
        /// </summary>
        /// <param name="text"></param>
        public void Logout(string text)
        {
            cLogout.Visibility = Visibility.Visible;
            lblnachricht.Content = text;
        }

        private void btnJa(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.ToString() == "Ja")
            {
                ja = true;
                this.Close();
            }
            else
                ja = false;
            this.Close();
        }

        public void btnOk(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

        public void InfoFenster(string inhalt)
        {
            cHighscore.Visibility = Visibility.Visible;
            lblHighscore.Content = inhalt;
        }

        private void FW_true(object sender, MouseButtonEventArgs e)
        {
            
          
                FW_JA = true;
          
            this.Close();


        }

        private void FW_False(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        public void FW_Aufruf()
        {
            FW_Aufloesen.Visibility = Visibility.Visible;

        }

    }
}
