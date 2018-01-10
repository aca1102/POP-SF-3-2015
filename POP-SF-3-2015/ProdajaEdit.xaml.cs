using POP_SF_3_2015.DAO;
using POP_SF_3_2015.Model;
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
using System.Windows.Shapes;

namespace POP_SF_3_2015
{
    /// <summary>
    /// Interaction logic for ProdajaEdit.xaml
    /// </summary>
    public enum MOD_PRODAJA { DODAVANJE, IZMENA };

    public partial class ProdajaEdit : Window
    {
        protected Prodaja orginal, editO;
        protected MOD_PRODAJA mod;

        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
        }

            public ProdajaEdit()
        {
            InitializeComponent();
        }

        public ProdajaEdit(Prodaja p, MOD_PRODAJA m = MOD_PRODAJA.DODAVANJE) : this()
        {
            this.orginal = p;
            this.mod = m;
            

            cbNamestaj.ItemsSource = Program.Instanca.Namestaji;
            cbDodatnaUsluga.ItemsSource = Program.Instanca.Usluga;

            this.DataContext = orginal;

            if (mod == MOD_PRODAJA.IZMENA)
            {
                this.editO = orginal.DeepCopy();
                this.DataContext = editO;
            }
            else
            {
                this.DataContext = orginal;
            }
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaj izabraniNamestaj = (Namestaj) cbNamestaj.SelectedValue;
            DodatnaUsluga izabranaUsluga = (DodatnaUsluga) cbDodatnaUsluga.SelectedValue;
            izabraniNamestaj.KolicinaUMagacinu = izabraniNamestaj.KolicinaUMagacinu - (cbKolicinaUMagacinu.SelectedIndex + 1);
            NamestajDAO.Update(izabraniNamestaj);

            double ukupnaCena = izabraniNamestaj.Cena * (cbKolicinaUMagacinu.SelectedIndex + 1);
            ukupnaCena -= ukupnaCena * izabraniNamestaj.Akcija.Popust / 100;
            ukupnaCena += izabranaUsluga.Cena;
            ukupnaCena += ukupnaCena * Prodaja.PDV;

            MessageBox.Show(ukupnaCena.ToString());

            orginal.UkupnaCena = ukupnaCena;

            if (mod == MOD_PRODAJA.DODAVANJE)
            {
                Program.Instanca.Prodaje.Add(orginal);
                ProdajaDAO.Create(orginal);
            }
            else
            {
                orginal.SetProp(editO);
                ProdajaDAO.Update(orginal);
            }

            this.DialogResult = true;   //zatvaramo u slucaju uspesnog rezultata
            this.Close();
        }

        private void cbNamestaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Namestaj nam in Program.Instanca.Namestaji)
            {
                if (nam.ToString() == cbNamestaj.SelectedValue.ToString())
                {
                    cbKolicinaUMagacinu.Items.Clear();
                    for (int i = 1; i <= nam.KolicinaUMagacinu; i++)
                    {
                        cbKolicinaUMagacinu.Items.Add(i);
                    }
                    if (cbKolicinaUMagacinu.Items.Count > 0)
                    {
                        cbKolicinaUMagacinu.SelectedIndex = 0;
                    }
                }
            }

        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
