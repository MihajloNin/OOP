using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Kontakti
{
    public class Kontakt
    {
        private string ime;
        private string prezime;
        private string glavniBroj;
        public List<string> ostaliBrojevi;

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string GlavniBroj { get => glavniBroj; set => glavniBroj = value; }

        public Kontakt(string ime, string prezime, string glavniBroj)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.glavniBroj = glavniBroj;
        }

        public void DodajBroj(string dodatniBroj)
        {
            if(dodatniBroj != glavniBroj)
            {
                foreach (var item in ostaliBrojevi)
                {
                    if (dodatniBroj == item)
                        break;
                }
                ostaliBrojevi.Add(dodatniBroj);
            }
            else
                Console.WriteLine("Uneti broj vec postoji.");
        }
        
        public void IzbrisiBroj(string dodatniBroj)
        {
            foreach (var item in ostaliBrojevi)
            {
                if (dodatniBroj == item)
                {
                    ostaliBrojevi.Remove(dodatniBroj);
                    return;
                }
            }
            Console.WriteLine("Uneti broj ne postoji");
        }

        public override string ToString()
        {
            StringBuilder ispis = new StringBuilder($"{ime}, {prezime}, {glavniBroj}, [");
            foreach (var item in ostaliBrojevi)
            {
                ispis.Append(item);
                ispis.Append(" ");
            }
            ispis.Append("]");
            return ispis.ToString();
        }
    }
}
