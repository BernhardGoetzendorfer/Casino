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

namespace Highscore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ScoreList : Window
    {

        dbCasino_IN19Entities db = new dbCasino_IN19Entities();
        public ScoreList(dbCasino_IN19Entities db) : this()
        {
            this.db = db;
        }

        public ScoreList()
        {
            InitializeComponent();

            //MAKA Foreignkey aus datenbank 1 = Glücksrad 2 = Roulette 3= Escalero 4 = Slotmaschine
            lvGluecksrad.ItemsSource = Scorefuellen(1);
            lvRoulette.ItemsSource = Scorefuellen(4);
            lvEscalero.ItemsSource = Scorefuellen(2);
            lvSlots.ItemsSource = Scorefuellen(3);

        }

        /// <summary>
        /// Befuellt die HighscoreListe mit Daten aus der Datenbank und benuetigt nur ein INT für das Spiel
        /// </summary>
        /// <param name="fkspiel">INT</param>
        /// <returns></returns>
        private List<HighscoreListe> Scorefuellen(int fkspiel)
        {
            //MAKA Befüllen über eine Datenbank
            //MAKA Am besten über eine View für jedes Spiel
            int rang = 1;
            List<HighscoreListe> liste = new List<HighscoreListe>();

            //MAKA Holt die ersten 10 Highscore von den Spielen aus der Datenbank
            var item = (from high in db.tblHighscore where high.FKSpiel == fkspiel orderby high.Punkte descending select high).Take(10);

            //MAKA fügt die Highscore in die Liste.
            foreach (var daten in item)
            {
                if (rang <= 10)
                {
                    //MAKA Und Highscore Runden auf 0 Komma stellen
                    liste.Add(new HighscoreListe(rang, daten.Spieler, Math.Round(daten.Punkte, 0)));
                    rang++;
                }
            }
            return liste;
        }

        private void btnBeenden(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Mausaendern(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Mausnormal(object sender, MouseEventArgs e)
        {

        }
    }

}