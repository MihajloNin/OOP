using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP___Moving_Label
{
    public partial class FormIgrica : Form
    {
        public FormIgrica()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            int x = pnlKretanje.Width;
            int y = pnlKretanje.Height;
            lblKretac.Location = new Point(x / 2, y / 2);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int pomeranjegore, pomeranjedole, pomeranjelevo, pomeranjedesno, brgreski;

        private void btnGore_Click(object sender, EventArgs e)
        {
            if (lblKretac.Location.Y - 10 < pnlKretanje.Location.Y)
            {
                MessageBox.Show("Izlazi van okvira panela");
                brgreski++;
                lblBrGreski.Text = Convert.ToString(brgreski);
            }
            else
            {
                lblKretac.Location = new Point(lblKretac.Location.X, lblKretac.Location.Y - 10);
                listAkcije.Items.Add("Gore");
                pomeranjegore++;
                lblBrGore.Text = Convert.ToString(pomeranjegore);
            }
        }

        private void btnLevo_Click(object sender, EventArgs e)
        {
            if (lblKretac.Location.X - 10 < pnlKretanje.Location.X)
            {
                MessageBox.Show("Izlazi van okvira panela");
                brgreski++;
                lblBrGreski.Text = Convert.ToString(brgreski);
            }
            else
            {
                lblKretac.Location = new Point(lblKretac.Location.X - 10, lblKretac.Location.Y);
                listAkcije.Items.Add("Levo");
                pomeranjelevo++;
                lblBrLevo.Text = Convert.ToString(pomeranjelevo);
            }
        }

        private void BtnDole_Click(object sender, EventArgs e)
        {
            if(lblKretac.Location.Y + 10 > pnlKomande.Location.Y - 45)
            {
                MessageBox.Show("Izlazi van okvira panela");
                brgreski++;
                lblBrGreski.Text = Convert.ToString(brgreski);
            }
            else
            {
                lblKretac.Location = new Point(lblKretac.Location.X, lblKretac.Location.Y + 10);
                listAkcije.Items.Add("Dole");
                pomeranjedole++;
                lblBrDole.Text = Convert.ToString(pomeranjedole);
            }
            
        }

        private void btnDesno_Click(object sender, EventArgs e)
        {
            if(lblKretac.Location.X + 10 > pnlIspisAkcija.Location.X - 45)
            {
                MessageBox.Show("Izlazi van okvira panela");
                brgreski++;
                lblBrGreski.Text = Convert.ToString(brgreski);
            }
            else
            {
                lblKretac.Location = new Point(lblKretac.Location.X+10, lblKretac.Location.Y);
                listAkcije.Items.Add("Desno");
                pomeranjedesno++;
                lblBrDesno.Text = Convert.ToString(pomeranjedesno);
            }
            
        }
    }
}
