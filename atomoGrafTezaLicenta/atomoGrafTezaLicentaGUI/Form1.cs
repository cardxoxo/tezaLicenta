using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atomoGrafTezaLicentaGUI
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            atomi.handleForma = this;
        }

        private void Carbon_Click(object sender, EventArgs e)
        {
            this.listaAtomi.AppendText("C, "); atomi.incrNrAtomi();
        }

        private void Azot_Click(object sender, EventArgs e)
        {
            this.listaAtomi.AppendText("N, "); atomi.incrNrAtomi();
        }

        private void Oxigen_Click(object sender, EventArgs e)
        {
            this.listaAtomi.AppendText("O, "); atomi.incrNrAtomi();
        }

        public void completeazaCuHidrogen(int nrDeHidrogeni)
        {
           this.listaAtomi.AppendText(" + " + nrDeHidrogeni + " H adaugati automat. ");
        }

        private void Genereaza_Click(object sender, EventArgs e)
        {
            this.C.Enabled            = !this.C.Enabled;
            this.N.Enabled            = !this.N.Enabled;
            this.O.Enabled            = !this.O.Enabled;
            this.stergeUltima.Enabled = !this.stergeUltima.Enabled;
            this.curataTot.Enabled    = !this.curataTot.Enabled;

            if (this.genereazaButton.Text == "genereaza altul")
            {
                this.listaAtomi.Text = atomi.getAtomiCurenti();
                this.genereazaButton.Text = "genereaza izomeri";
            }
            else
            {
                this.genereazaButton.Text = "genereaza altul";
                atomi.creareVectorAtomi(this.listaAtomi.Text);
                 if (izomeri.generareIzomeri())
                 {
                     this.Location = new Point(0, this.Location.Y);
                     new unityHandler(false);
                     this.listaAtomi.AppendText(" Izomerii vor aparea in fereastra noua.");
                 }
                 else
                     this.listaAtomi.AppendText(" Nu ati introdus atomi.");
                
            }
        }

       
        private void curataTot_Click(object sender, EventArgs e)
        {
            this.listaAtomi.Text = null; atomi.zeroNrAtomi();
        }

        private void stergeUltima_Click(object sender, EventArgs e)
        {
            this.listaAtomi.Text = this.listaAtomi.Text.Substring(0, this.listaAtomi.Text.Length - 3);
            atomi.decrNrAtomi();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            new unityHandler(true);//ca sa unicitojim ultima fereastra de unity - inchidem aplicatia
                                   //principala -> inchidem tot
        }

        


    }
}
