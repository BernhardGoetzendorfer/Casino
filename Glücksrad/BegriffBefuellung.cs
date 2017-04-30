using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datenschicht;

namespace Glücksrad
{
    public class BegriffBefuellung
    {

        public string Name { get; set; }

        public string Kategorie { get; set; }

        public BegriffBefuellung()
        {

        }

        public BegriffBefuellung(string name, string kategorie)
        {
            Name = name;
            Kategorie = kategorie;
        }

        public List<string> ZufallBegriffAlleKategorien()
        {
            dbCasino_IN19Entities dbContext = new dbCasino_IN19Entities();

            Random rnd = new Random();


            var Kategorien = dbContext.tblkategorie.ToList();

            int rndKat = rnd.Next(0, Kategorien.Count());

            int zw = Kategorien[rndKat].IDKategorie;

            var BegriffSuche = dbContext.tblBegriff.Where(x => x.FKKategorie == zw).ToList();

            int RandomBegriff = rnd.Next(0, BegriffSuche.Count());

            string Kategorie = Kategorien[rndKat].Kategorie;
            string Begriff = BegriffSuche[RandomBegriff].Begriff;

            List<string> KateGriff = new List<string>();
            KateGriff.Add(Kategorie);
            KateGriff.Add(Begriff);

            return KateGriff;





        }
    }
}
