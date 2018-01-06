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
    /// Interaction logic for SalonEdit.xaml
    /// </summary>
    /// 
    public enum MOD_AKCIJA { DODAVANJE, IZMENA };

    public partial class AkcijeEdit : Window
    {
        protected Akcija orginal, editO;
        protected MOD_AKCIJA mod;
        public AkcijeEdit()
        {
            InitializeComponent();
        }

        public AkcijeEdit(Akcija a, MOD_AKCIJA m = MOD_AKCIJA.DODAVANJE) : this()
        {
            this.orginal = a;
            this.mod = m;

            this.DataContext = orginal;

            if (mod == MOD_AKCIJA.IZMENA)
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
            if (mod == MOD_AKCIJA.DODAVANJE)
            {
                Program.Instanca.Akcije.Add(orginal);
                AkcijaDAO.Create(orginal);
            }
            else
            {
                orginal.SetProp(editO);
                AkcijaDAO.Update(orginal);
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