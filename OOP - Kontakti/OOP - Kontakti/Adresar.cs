using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP___Kontakti
{
    public partial class Adresar
    {
        Dictionary<string, Kontakt> kontakti = new Dictionary<string, Kontakt>();

        public void Dodaj(Kontakt k)
        {
            kontakti.Add(k.GlavniBroj, k);
        }

        public void Dodaj(string ime, string prezime, string glavniBroj)
        {
            Kontakt k = new Kontakt(ime, prezime, glavniBroj);
            kontakti.Add(glavniBroj, k);
        }

        public void Blokiraj(string broj)
        {
            kontakti.Remove(broj);
        }

        public void Share(string file, string glavniBroj)
        {
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(kontakti.ContainsKey(glavniBroj));
        }

        public void Receive(string file)
        {
            FileStream fs = File.Open(file, FileMode.Open);
            BinaryReader rider = new BinaryReader(fs);

            string ime = rider.ReadString();
            string prezime = rider.ReadString();
            string glavniBroj = rider.ReadString();
            Kontakt k = new Kontakt(ime, prezime, glavniBroj);
            kontakti.Add(glavniBroj, k);
            fs.Close();
        }

        public void Backup(string file)
        {
            StreamWriter bekap = new StreamWriter(file);
            foreach (var item in kontakti)
            {
                bekap.WriteLine(item);
            }
        }
    }
}
