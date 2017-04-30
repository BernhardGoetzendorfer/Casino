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
using System.Windows.Threading;

namespace Roulette0._0._8
{
    /// <summary>
    /// Interaktionslogik für GewinnAusgabe.xaml
    /// </summary>
    public partial class GewinnAusgabe : Window
    {
        public int aktuellerGewinn;

        DispatcherTimer timer = new DispatcherTimer();
        TimeSpan restzeit = new TimeSpan(0, 0, 3);

        public GewinnAusgabe()
        {
            InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            restzeit -= timer.Interval;

            lblGewinnAusgabe.Content = "Sie haben " + aktuellerGewinn + " Punkte gewonnen.";

            if (restzeit == new TimeSpan(0, 0, 0, 0))
            {
                timer.Stop();
                Close();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


    }
}
