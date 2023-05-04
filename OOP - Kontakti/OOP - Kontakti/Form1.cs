using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOP___Kontakti
{
    public partial class Adresar : Form
    {
        public Adresar()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region Dodaj kontakt

        int brojacdodaj = 0;
        private void tbImeDodaj_Click(object sender, EventArgs e)
        {
            if(tbImeDodaj.Text == "Unesite ime")
                tbImeDodaj.Clear();
        }

        private void tbPrezimeDodaj_Click(object sender, EventArgs e)
        {
            if (tbPrezimeDodaj.Text == "Unesite prezime")
                tbPrezimeDodaj.Clear();
        }

        private void tbGlavniBrojDodaj_Click(object sender, EventArgs e)
        {
            if (tbGlavniBrojDodaj.Text == "Unesite broj telefona")
                tbGlavniBrojDodaj.Clear();
        }

        private void btnSubmitDodaj_Click(object sender, EventArgs e)
        {
            if (tbImeDodaj.Text == null || tbPrezimeDodaj.Text == null || tbGlavniBrojDodaj.Text == null)
                lblInfoDodaj.Text = "Morate popuniti sva polja";
            else if (kontakti.TryGetValue(tbGlavniBrojDodaj.Text, out Kontakt k))
                lblInfoDodaj.Text = "Uneti broj telefona vec postoji";
            else
            {
                Dodaj(tbImeDodaj.Text, tbPrezimeDodaj.Text, tbGlavniBrojDodaj.Text);
                tbImeDodaj.Clear();
                tbPrezimeDodaj.Clear();
                tbGlavniBrojDodaj.Clear();
                lblInfoDodaj.Text = "Uspesno ste dodali kontakt.";
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if(brojacdodaj%2 == 0)
                pDodajKontakt.Visible = true;
            else
                pDodajKontakt.Visible = false;
            brojacdodaj++;
        }
        #endregion

        #region Blokiraj kontakt

        int brojacblokiraj = 0;
        private void tbBrTelBlokiraj_Click(object sender, EventArgs e)
        {
            if (tbBrTelBlokiraj.Text == "Unesite broj telefona")
                tbBrTelBlokiraj.Clear();
        }

        private void btnBlokiraj_Click(object sender, EventArgs e)
        {
            if (brojacblokiraj % 2 == 0)
                pBlokiraj.Visible = true;
            else
                pBlokiraj.Visible = false;
            brojacblokiraj++;
        }

        private void btnSubmitBlokiraj_Click(object sender, EventArgs e)
        {
            if (kontakti.ContainsKey(tbBrTelBlokiraj.Text))
            {
                Blokiraj(tbBrTelBlokiraj.Text);
                lblInfoBlokiraj.Text = "Uspesno ste blokirali kontakt";
                tbBrTelBlokiraj.Clear();
            }
            else if (tbBrTelBlokiraj.Text == null)
                lblInfoBlokiraj.Text = "Morate uneti broj telefona";
            else
                lblInfoBlokiraj.Text = "Uneti broj ne postoji u adresaru";
        }
        #endregion

        #region Podeli kontakt

        int brojacpodeli = 0;
        private void tbFajlPodeli_Click(object sender, EventArgs e)
        {
            if (tbFajlPodeli.Text == "Unesite naziv fajla sa ekstenzijom")
                tbFajlPodeli.Clear();
        }

        private void tbBrojPodeli_Click(object sender, EventArgs e)
        {
            if (tbBrojPodeli.Text == "Unesite broj telefona")
                tbBrojPodeli.Clear();
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (brojacpodeli% 2 == 0)
                pPodeli.Visible = true;
            else
                pPodeli.Visible = false;
            brojacpodeli++;
        }

        private void btnSubmitPodeli_Click(object sender, EventArgs e)
        {
            if (tbFajlPodeli.Text == null || tbBrojPodeli.Text == null)
                lblInfoPodeli.Text = "Morate uneti sve podatke";
            else if (!kontakti.ContainsKey(tbBrojPodeli.Text))
                lblInfoPodeli.Text = "Uneti broj ne postoji";
            else if (File.Exists(tbFajlPodeli.Text))
                lblInfoPodeli.Text = "Uneti fajl vec postoji";
            else
            {
                Share(tbFajlPodeli.Text, tbBrojPodeli.Text);
                lblInfoPodeli.Text = "Uspesno ste podelili kontakt u fajl " + tbFajlPodeli.Text;
                tbFajlPodeli.Clear();
                tbBrojPodeli.Clear();
            }
        }


        #endregion

        #region Uvezi kontakt

        int brojacuvezi = 0;
        private void btnUvezi_Click(object sender, EventArgs e)
        {
            if (brojacuvezi % 2 == 0)
                pUvezi.Visible = true;
            else
                pUvezi.Visible = false;
            brojacuvezi++;
        }

        private void tbFajlUvezi_Click(object sender, EventArgs e)
        {
            if (tbFajlUvezi.Text == "Unesite naziv fajla sa ekstenzijom")
                tbFajlUvezi.Clear();
        }

        private void btnSubmitUvezi_Click(object sender, EventArgs e)
        {
            if (tbFajlUvezi.Text == null)
                lblInfoUvezi.Text = "Morate uneti podatke";
            else if (!File.Exists(tbFajlUvezi.Text))
                lblInfoUvezi.Text = "Uneti fajl ne postoji";
            else
            {
                Receive(tbFajlUvezi.Text);
                lblInfoUvezi.Text = "Uspesno uvezen fajl";
                tbFajlUvezi.Clear();
            }
        }

        #endregion

        #region Bekap kontakta

        int brojacbekap = 0;
        private void tbFajlBekap_Click(object sender, EventArgs e)
        {
            if (tbFajlBekap.Text == "Unesite naziv fajla sa ekstenzijom")
                tbFajlBekap.Clear();
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            if (brojacbekap % 2 == 0)
                pBekap.Visible = true;
            else
                pBekap.Visible = false;
            brojacbekap++;
        }

        private void btnSubmitBekap_Click(object sender, EventArgs e)
        {
            if (tbFajlBekap.Text == null)
                lblInfoBekap.Text = "Morate uneti podatke";
            else
            {
                Backup(tbFajlBekap.Text);
                lblInfoBekap.Text = "Uspesno bekapovani kontakti";
                tbFajlBekap.Clear();
            }
        }
        #endregion
    }
}
