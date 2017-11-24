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
            //cbTip.ItemsSource = Program.Instanca.TipoviKorisnika;

            this.DataContext = orginal;

            if (mod == MOD.IZMENA)
            {

                tbJmbg.IsEnabled = false;
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
            if (mod == MOD.DODAVANJE)
            {
                Program.Instanca.Korisnici.Add(orginal);

            }
            else
            {
                orginal.SetProp(editO);
            }

            this.DialogResult = true;   //zatvaramo u slucaju uspesnog rezultata
            this.Close();
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
