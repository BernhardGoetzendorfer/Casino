using System.Windows;
using System.Windows.Controls;
using Datenschicht;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity.Core.Objects;

namespace Tastatur
{
    /// <summary>
    /// Interaction logic for TastaturHighscore.xaml
    /// </summary>
    public partial class TastaturHighscore : Window
    {
        //Spielid
        int spielid;
        //MAKA Username zum Speichern in der Datenbank
        private string Username { get; set; } = "";
        //MAKA Datenbank Model
        dbCasino_IN19Entities Datenbank = new dbCasino_IN19Entities();
        //MAKA Erzeug die Klasse um auf die Globalen Variablen zuzugreifen

        //MAKA zum Überprüfen der eingegeben Zeichen
        int zeichenanzahl = 0;



        public TastaturHighscore()
        {
            InitializeComponent();

            //MAKA Maixmale Namen Länge
            tbxName.MaxLength = 9;

        }

        /// <summary>
        /// Zum Eintragen der Highscore die Punkte mitgeben als double und den Namen des Spiel als string ("Roulette", "Gluecksrad", "Slotmaschine", "Escalero")
        /// </summary>
        /// <param name="ErgebnisHighscore"></param>
        /// <param name="spiel"></param>
        public void HighscoreEintragen(double ErgebnisHighscore, int SessionID)
        {
            spielid = SessionID;
            bool darfEintragen = false;
            List<tblSpiel> spielliste = Datenbank.tblSpiel.ToList();

            var fkspiele = from s in Datenbank.tblSpiel where spielid == s.IDSpiel select s;
            foreach (var item in fkspiele)
            {
                this.spielid = item.IDSpiel;
            }

            //MAKA Tastatur für Highscore Erzeugen und Einblenden
            //MAKA Highscore Eintarg mit Standart Wert
            tblHighscore highnew = new tblHighscore() { Spieler = "Player", Punkte = ErgebnisHighscore, FKSpiel = spielid, Datum = DateTime.Now, };
            darfEintragen = this.HighscoreErgebnis(highnew);

            if (darfEintragen)
            {
                //MAKA zeigt das Highscore Fenster an
                this.ShowDialog();


               
                //MAKA Wenn Standart Wert geänderti wird wird es im if geaendert
                if (this.Username != "")
                {
                    //MAKA Neuen Highscore eintrage erzeugen und an die Datenbank Weitergeben
                    highnew = new tblHighscore() { Spieler = this.Username, Punkte = ErgebnisHighscore, FKSpiel = SessionID, Datum = DateTime.Now, };
                }
                //MAKA fügt den eintrag in die Datenbank ein       
                Datenbank.tblHighscore.Add(highnew);
                Datenbank.SaveChanges();
            }
            //MAKA Wenn eintrag möglich wird es auch in der Datenbank gespeichert

            Username = "";
            darfEintragen = false;
            this.Close();

        }

        /// <summary>
        /// MAKA Hier wird Überprüft ob die Highscore für die Top 100 reicht und gibt einen Bool für True oder false zurück
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        private bool HighscoreErgebnis(tblHighscore score)
        {
            tblSpiel spiel = Datenbank.tblSpiel.Find(score.FKSpiel);


            //MAKA holt den letzten möglich Highscore EIntrag und speichert ihn
            var Punkte = new ObjectParameter("Score", typeof(double));
            Punkte.Value = 0.0;
            Datenbank.pTop100WertNeu(spiel.IDSpiel,Punkte);

            if ((double)Punkte.Value < score.Punkte)
            {
                return true;
            }



            //MAKA Hollt die letzten 100 Eintraege aus der Highscore und speichert sie ab.
            //MAKA Über Linq        
            //var listeTop100 = (from high in Datenbank.tblHighscore
            //            where high.FKSpiel == score.FKSpiel
            //            orderby high.Punkte ascending
            //            select high)
            //            .Take(100);

            //var listletzter = (from high in listeTop100
            //            select high)
            //            .Take(1);

            //foreach (var item in listletzter)
            //{
            //    if (item.Punkte < score.Punkte)
            //    {
            //        return true;
            //    }
            //}

            return false;
        }

        private void btnFertig(object sender, RoutedEventArgs e)
        {
            Username = tbxName.Text;
            tbxName.Text = "";
            zeichenanzahl = 0;

            this.Close();
        }

        private void btnName(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (zeichenanzahl < tbxName.MaxLength)
            {
                if ((string)btn.Content == "Leerzeichen" )
                {
                    tbxName.Text += " ";
                    zeichenanzahl++;
                }
                else if ((string)btn.Content == "Löschen")
                {
                    if (tbxName.Text != "")
                    {
                        tbxName.Text = tbxName.Text.Substring(0, tbxName.Text.Length - 1);
                        zeichenanzahl--;
                    }
                }
                else 
                {
                    tbxName.Text += btn.Content;
                    zeichenanzahl++;
                }
            }
            else if (zeichenanzahl < 10 && (string)btn.Content == "Löschen")
            {
                if (tbxName.Text != "")
                {
                    tbxName.Text = tbxName.Text.Substring(0, tbxName.Text.Length - 1);
                    zeichenanzahl--;
                }
            }

            
            

        }
    }

}