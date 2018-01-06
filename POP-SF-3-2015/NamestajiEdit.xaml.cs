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
    /// Interaction logic for NamestajiEdit.xaml
    /// </summary>
    public enum MOD_NAMESTAJ { DODAVANJE, IZMENA };

    public partial class NamestajiEdit : Window
    {
        protected Namestaj orginal, editO;
        protected MOD_NAMESTAJ mod;



        public NamestajiEdit()
        {
            InitializeComponent();
        }

        public NamestajiEdit(Namestaj n, MOD_NAMESTAJ m = MOD_NAMESTAJ.DODAVANJE) : this()
        {
            this.orginal = n;
            this.mod = m;



            cbTipNamestaja.ItemsSource = Program.Instanca.Tipovi;
            cbAkcija.ItemsSource = Program.Instanca.Akcije;

            this.DataContext = orginal;

            if (mod == MOD_NAMESTAJ.IZMENA)
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
            if (mod == MOD_NAMESTAJ.DODAVANJE)
            {
                Program.Instanca.Namestaji.Add(orginal);
                NamestajDAO.Create(orginal);
            }
            else
            {
                orginal.SetProp(editO);
                NamestajDAO.Update(orginal);
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