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
            initializareaDatelor();
        }

        string listaAtomilor;
        int indexCurentMatr;
        int indexPrinMatr;
        int distantaRelativa;
        int iterator;
        int nrMaxDeLegaturi;
        List<Label>  linie;
        List<Label> coloana;
        List<Button> matr;

        void initializareaDatelor()
        {

            indexCurentMatr = 0;
            indexPrinMatr = 0;
            distantaRelativa = 15;
            linie = new List<Label>();
            coloana = new List<Label>();
            matr = new List<Button>();
            nrMaxDeLegaturi=0;

            System.IO.StreamReader reader = new System.IO.StreamReader("caracteristiciAtomi.txt", true);
            string buffer;
            int temp;
            do
            {
                buffer = reader.ReadLine();
                if (buffer.Contains("grOxidare"))
                {
                    int.TryParse(buffer.Substring(10, buffer.Length - 10), out temp);
                    if (temp > nrMaxDeLegaturi) nrMaxDeLegaturi = temp;
                }
            } 
            while (!reader.EndOfStream);

            reader.Close();
        }


        private void Carbon_Click(object sender, EventArgs e)
        {
            this.listaAtomi.AppendText("C, ");
            marireMatriceGUI("C");
        }

        private void Azot_Click(object sender, EventArgs e)
        {
            this.listaAtomi.AppendText("N, ");
            marireMatriceGUI("N");
        }

        private void Oxigen_Click(object sender, EventArgs e)
        {
            this.listaAtomi.AppendText("O, ");
            marireMatriceGUI("O");
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

            if (this.genereazaButton.Text == "redacteaza datele de intrare")
            {
                this.listaAtomi.Text=listaAtomilor;
                this.genereazaButton.Text = "genereaza informatie despre molecula";
            }
            else
            {
                this.genereazaButton.Text = "redacteaza datele de intrare";
                
                 if (this.listaAtomi.Text.Length!=0)
                 {
                     listaAtomilor=this.listaAtomi.Text;
                     creareInfoPtGraf();
                     this.Location = new Point(0, this.Location.Y);
                     new unityHandler(false);
                     this.listaAtomi.AppendText("\n");
                     this.listaAtomi.AppendText(" Date despre molecula:");
                 }
                 else
                     this.listaAtomi.AppendText(" Nu ati introdus atomi.");
                
            }
        }

       
        private void curataTot_Click(object sender, EventArgs e)
        {
            this.listaAtomi.Text = null;
            listaAtomilor = null;
            distrugereMatriceGUI();
        }

        private void stergeUltima_Click(object sender, EventArgs e)
        {
            if (this.listaAtomi.Text.Length > 2)
            {
                listaAtomilor = this.listaAtomi.Text.Substring(0, this.listaAtomi.Text.Length - 3);
                this.listaAtomi.Text = listaAtomilor;
                micsorareMatriceGUI();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            new unityHandler(true);//ca sa unicitojim ultima fereastra de unity - inchidem aplicatia
                                   //principala -> inchidem tot
        }

        void marireMatriceGUI(string tip)
        {
            int locatie = (int)((indexCurentMatr+1) * (distantaRelativa * 2));
            int a, b;

            linie.Add(new Label());
            linie[indexCurentMatr].Location = new Point(locatie + (int)(distantaRelativa * 0.27), (int)(distantaRelativa / 1.9));
            linie[indexCurentMatr].Size = new Size((int)(distantaRelativa * 1.5), (int)(distantaRelativa * 1.5));
            linie[indexCurentMatr].BackColor = Color.DarkOrange;
            linie[indexCurentMatr].Font = new Font(FontFamily.GenericSerif, distantaRelativa);
            linie[indexCurentMatr].Text = tip;
            this.matrPanel.Controls.Add(linie[indexCurentMatr]);

            coloana.Add(new Label());
            coloana[indexCurentMatr].Location = new Point((int)(distantaRelativa / 1.9), locatie + (int)(distantaRelativa * 0.27));
            coloana[indexCurentMatr].Size = new Size((int)(distantaRelativa * 1.5), (int)(distantaRelativa * 1.5));
            coloana[indexCurentMatr].BackColor = Color.DarkOrange;
            coloana[indexCurentMatr].Font = new Font(FontFamily.GenericSerif, distantaRelativa);
            coloana[indexCurentMatr].Text = tip;
            this.matrPanel.Controls.Add(coloana[indexCurentMatr]);

            for (iterator = 0; iterator < indexCurentMatr; iterator++)
            {
                matr.Add(new Button());
                a = (indexCurentMatr + 1) * distantaRelativa * 2;
                b = (iterator + 1) * distantaRelativa * 2;
                matr[indexPrinMatr].Click += new System.EventHandler(this.matrPressed);
                matr[indexPrinMatr].Location = new Point(a, b);
                matr[indexPrinMatr].Size = new Size(distantaRelativa * 2, distantaRelativa * 2);
                matr[indexPrinMatr].BackColor = Color.Gold;
                matr[indexPrinMatr].Font = new Font(FontFamily.GenericSerif, distantaRelativa / 2);
                matr[indexPrinMatr].Text = "0";

                this.matrPanel.Controls.Add(matr[indexPrinMatr]);
                
                indexPrinMatr++;

                matr.Add(new Button());
                matr[indexPrinMatr].Click += new System.EventHandler(this.matrPressed);
                matr[indexPrinMatr].Location = new Point(b, a);
                matr[indexPrinMatr].Size = new Size(distantaRelativa * 2, distantaRelativa * 2);
                matr[indexPrinMatr].BackColor = Color.Gold;
                matr[indexPrinMatr].Font = new Font(FontFamily.GenericSerif, distantaRelativa / 2);
                matr[indexPrinMatr].Text = "0";

                this.matrPanel.Controls.Add(matr[indexPrinMatr]);
               
                indexPrinMatr++;
            }

            matr.Add(new Button());
            a = (indexCurentMatr + 1) * distantaRelativa * 2;
            b = (iterator + 1) * distantaRelativa * 2;
            matr[indexPrinMatr].Click += new System.EventHandler(this.matrPressed);
            matr[indexPrinMatr].Location = new Point(a, b);
            matr[indexPrinMatr].Size = new Size(distantaRelativa * 2, distantaRelativa * 2);
            matr[indexPrinMatr].BackColor = Color.Gold;
            matr[indexPrinMatr].Font = new Font(FontFamily.GenericSerif, distantaRelativa / 2);
            matr[indexPrinMatr].Text = "0";

            this.matrPanel.Controls.Add(matr[indexPrinMatr]);
            indexPrinMatr++;

                indexCurentMatr++;
            
        }

        void matrPressed(object sender, EventArgs e)
        {   
            Button btsn = (Button)sender;

            if (btsn.Location.X == btsn.Location.Y) return;
                
            if (btsn.Text==nrMaxDeLegaturi.ToString()) btsn.Text="0"; else 
            {   
                int temp;
                int.TryParse(btsn.Text, out temp);
                temp++;
                btsn.Text=temp.ToString();
            }

            matr.Find(x => (x.Location.X == btsn.Location.Y && x.Location.Y == btsn.Location.X)).Text = btsn.Text; 

            }

        void micsorareMatriceGUI()
        {

            if (indexCurentMatr != 0)
            {
                linie[indexCurentMatr - 1].Dispose();
                coloana[indexCurentMatr - 1].Dispose();
                linie.Remove(linie[indexCurentMatr - 1]);
                coloana.Remove(coloana[indexCurentMatr - 1]);


                int stopper = indexPrinMatr - indexCurentMatr * 2;
                for (iterator = indexPrinMatr - 1; iterator > stopper; iterator--)
                {
                    matr[iterator].Dispose();
                    matr.Remove(matr[iterator]);

                }
                indexPrinMatr -= indexCurentMatr * 2 - 1;
                --indexCurentMatr;
            }
             

        }

        void distrugereMatriceGUI()
        {
            if (indexCurentMatr != 0)
            {

                for (iterator = 0; iterator < indexCurentMatr; iterator++)
                {
                    linie[iterator].Dispose();
                    coloana[iterator].Dispose();
                    matr[iterator].Dispose();
                }

                for (; iterator < indexPrinMatr; iterator++) matr[iterator].Dispose();

                linie.Clear();
                coloana.Clear();
                matr.Clear();

                indexPrinMatr = 0;
                indexCurentMatr = 0;

            }
        }

        void creareInfoPtGraf()
        {
            int a, b;
                     dateGraf infoAdunata;
                     infoAdunata.atomi = listaAtomilor;
                     infoAdunata.matr = new int[indexCurentMatr][];
                     for (iterator = 0; iterator < indexCurentMatr; iterator++)
                     {
                         infoAdunata.matr[iterator] = new int[indexCurentMatr];
                     }
                         for (iterator = 0; iterator < matr.Count; iterator++)
                         {

                             a = (iterator % indexCurentMatr + 1) * distantaRelativa * 2;
                             b = (iterator / indexCurentMatr + 1) * distantaRelativa * 2;
                                 

int.TryParse(matr.Find(x => (x.Location.X == a && x.Location.Y == b)).Text, out infoAdunata.matr[iterator / indexCurentMatr][iterator % indexCurentMatr]);
                         }
                     
            
                     new graphWorker(infoAdunata);

        }
    }
}
