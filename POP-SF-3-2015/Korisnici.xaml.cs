using System;
using System.Collections.Generic;
using System.Linq;
using POP_SF_3_2015.Model;
using System.ComponentModel;
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
using POP_SF_3_2015.DAO;

namespace POP_SF_3_2015
{
    /// <summary>
    /// Interaction logic for KorisniciWindow.xaml
    /// </summary>
    public partial class Korisnici : Window
    {
        private CollectionViewSource cvs;
        public Korisnici()
        {
            InitializeComponent();

            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;


            cvs = new CollectionViewSource();
            cvs.Source = Program.Instanca.Korisnici;
            dgKorisnici.ItemsSource = cvs.View;


            cvs.SortDescriptions.Add(new SortDescription("Ime", ListSortDirection.Ascending));


            dgKorisnici.IsReadOnly = true;
            dgKorisnici.SelectionMode = DataGridSelectionMode.Single;
            dgKorisnici.AutoGenerateColumns = false;


            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Ime";
            c.Binding = new Binding("Ime");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKorisnici.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Prezime";
            c.Binding = new Binding("Prezime");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKorisnici.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "JMBG";
            c.Binding = new Binding("JMBG");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKorisnici.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Datum rodjenja";
            c.Binding = new Binding("DatumRodjenja");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKorisnici.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Tip korisnika";
            c.Binding = new Binding("Tip.Naziv");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKorisnici.Columns.Add(c);


        }

        private void MyFilter(object sender, FilterEventArgs e)
        {
            Korisnik k = e.Item as Korisnik;
            if (k != null)
            {
                e.Accepted = (k.Ime.ToLower() + " " + k.Prezime.ToLower() + " " + k.KorisnickoIme.ToLower()).Contains(tbPretraga.Text.ToLower());


            }

        }



        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = new Korisnik();
            KorisniciEdit kew = new KorisniciEdit(k);
            if (kew.ShowDialog() == true)
            {

            }
        }

        private void bDodajTip_Click(object sender, RoutedEventArgs e)
        {
            TipKorisnika t = new TipKorisnika("direktor", "opis...");
            Program.Instanca.TipoviKorisnika.Add(t);
            TipKorisnikaDAO.Create(t);
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = dgKorisnici.SelectedItem as Korisnik;

            KorisniciEdit kew = new KorisniciEdit(k, MOD.IZMENA);
            if (kew.ShowDialog() == true)
            {

            }
        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Korisnik k = dgKorisnici.SelectedItem as Korisnik;

                KorisnikDAO.Delete(dgKorisnici.SelectedItem as Korisnik);
                Program.Instanca.Korisnici.Remove(dgKorisnici.SelectedItem as Korisnik);

                KorisnikDAO.Delete(k);

            }
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lbKorisnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Program.Instanca.Korisnici.Count == 0)
            {
                bIzmeni.IsEnabled = false;
                bObrisi.IsEnabled = false;
            }
            else
            {
                bIzmeni.IsEnabled = true;
                bObrisi.IsEnabled = true;
            }
            

        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(MyFilter);
        }



        private void miHelp_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Skola jezika v0.1. Developer: Bojana Kusljic");
        }
    }
}
