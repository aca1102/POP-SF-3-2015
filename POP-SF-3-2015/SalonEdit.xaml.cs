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
using POP_SF_3_2015.Model;


namespace POP_SF_3_2015
{
    /// <summary>
    /// Interaction logic for SalonEdit.xaml
    /// </summary>
    /// 
    public enum MOD_SALON { DODAVANJE, IZMENA };

    public partial class SalonEdit : Window
    {
        protected Salon orginal, editO;
        protected MOD_SALON mod;
        public SalonEdit()
        {
            InitializeComponent();
        }

        public SalonEdit(Salon s, MOD_SALON m = MOD_SALON.DODAVANJE) : this()
        {
            this.orginal = s;
            this.mod = m;

            this.DataContext = orginal;

            if (mod == MOD_SALON.IZMENA)
            {
                tbAdresa.IsEnabled = false;
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
            if (mod == MOD_SALON.DODAVANJE)
            {
                Program.Instanca.Saloni.Add(orginal);
            }
            else
            {
                orginal.SetProp(editO);
            }
            this.DialogResult = true;
            this.Close();
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}