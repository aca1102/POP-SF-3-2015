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

    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)

        {
            
            
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            foreach (Korisnik korisnik in Program.Instanca.Korisnici)
            {
                if (korisnik.KorisnickoIme == username && korisnik.Lozinka == password)
                {
                    Program.Instanca.UlogovaniKorisnik = korisnik;
                    MainWindow m = new MainWindow();
                    m.Show();
                    this.Close();
                    return;
                }

            }
            


            MessageBox.Show("Pokusajte ponovo", "Korisnicko ime i lozinka nisu ispravni!", MessageBoxButton.OK);



            Program.Instanca.UlogovaniKorisnik = null;

        }
    }
}