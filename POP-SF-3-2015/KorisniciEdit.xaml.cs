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
    /// Interaction logic for KorisniciEditWindow.xaml
    /// </summary>
    /// 

    public enum MOD { DODAVANJE, IZMENA };

    public partial class KorisniciEdit : Window
    {
        protected Korisnik orginal, editO;
        protected MOD mod;

        public KorisniciEdit()
        {
            InitializeComponent();
        }
        
        public KorisniciEdit(Korisnik k, MOD m = MOD.DODAVANJE) : this()
        {
            this.orginal = k;
            this.mod = m;
            cbTip.ItemsSource = Program.Instanca.TipoviKorisnika;
            
            if (mod == MOD.IZMENA)
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
            if (tbIme.Text != null && tbIme.Text != "" && tbPrezime.Text != null && tbPrezime.Text != "" && tbJmbg.Text != null && tbJmbg.Text != "" && tbKorisnickoIme.Text != null && tbKorisnickoIme.Text != "" && tbLozinka.Text != null && tbLozinka.Text != "" && cbTip.Text != null)
            {
                if (mod == MOD.DODAVANJE)
                {
                    if (cbTip.Text == "admin")
                    {
                        orginal.Tip.Id = 1;
                    }
                    else
                    {
                        orginal.Tip.Id = 2;
                    }
                    Program.Instanca.Korisnici.Add(orginal);
                    KorisnikDAO.Create(orginal);
                }
                else
                {
                    if (cbTip.Text == "admin")
                    {
                        editO.Tip.Id = 1;
                        editO.Tip.Naziv = "admin";
                    }
                    else
                    {
                        editO.Tip.Id = 2;
                        editO.Tip.Naziv = "Zaposleni";
                    }
                    orginal.SetProp(editO);
                    KorisnikDAO.Update(orginal);
                }

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(tbIme.Text);
                MessageBox.Show(tbPrezime.Text);
                MessageBox.Show(tbJmbg.Text);
                MessageBox.Show(tbKorisnickoIme.Text);
                MessageBox.Show(tbLozinka.Text);
                MessageBox.Show(cbTip.Text);
                MessageBox.Show("Niste uneli sve podatke!");
            }
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
