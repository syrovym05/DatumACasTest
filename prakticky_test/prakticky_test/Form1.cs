using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prakticky_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DateTime nejmaldsi;
        DateTime nejstarsi;

        List<string> kolekceM = new List<string>();
        List<string> kolekceZ = new List<string>();
        int pocet = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime datum = dateTimePicker1.Value;
            pocet++;
                       
            int roky, mesice, dny, koncovka;
            long cislo;
            string rok, mesic, den;            
            bool zena = radioButton1.Checked;

            roky = datum.Year % 100;            //roky       
            if (roky < 10)  
            {
                rok = "0" + roky;
            }
            else rok = roky.ToString();
            
            mesice = datum.Month;               //mesice
            if(zena) mesice += 50;           
            if (mesice < 10) mesic = "0" + mesice;
            else mesic = mesice.ToString();            

            dny = datum.Day;                    //dny            
            if (dny < 10) den = "0" + dny;
            else den = dny.ToString();
           

            string rodnycislo = rok + mesic + den;
            
            Random rng = new Random();             //koncovka                       
           
            string rdcislo = rodnycislo;

            bool konec = false;

            while(konec == false)
            {
                if (konec == false)
                {
                    rodnycislo = rdcislo;
                    koncovka = rng.Next(100, 1000);
                    rodnycislo += koncovka.ToString();
                }
                for (int i = 0; i < 10; i++)
                {
                    cislo = Convert.ToInt64(rodnycislo + i.ToString());

                    if (cislo % 11 == 0)
                    {
                        rodnycislo += i.ToString();
                        konec = true;

                        break;
                    }
                }
            }

            
            
            if (pocet == 2)  button2.Visible = true;         
           

            if (zena) kolekceZ.Add(rodnycislo);
            else kolekceM.Add(rodnycislo);


            maskedTextBox1.Text = rodnycislo;
            maskedTextBox2.Text = rodnycislo;

        }



        private void button2_Click(object sender, EventArgs e)
        {
            Vypis();
        }

        private void Vypis()
        {
            label5.Text = "Celkovy pocet muzu: " + kolekceM.Count;
            label6.Text = "Celkovy pocet zen: " + kolekceZ.Count;
        }

    }
}
