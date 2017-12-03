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

namespace POP_SF_3_2015
{
    /// <summary>
    /// Interaction logic for Namestaji.xaml
    /// </summary>
    public partial class Namestaji : Window
    {
        private CollectionViewSource cvs;
        public Namestaji()
        {
            InitializeComponent();
            // OsveziNamestaje();
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;

            //sprega izmedju kolekcije i komponenata
            cvs = new CollectionViewSource();
            cvs.Source = Program.Instanca.Namestaji;
            dgNamestaji.ItemsSource = cvs.View;

            //sortiranje
            cvs.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Ascending));

            //filtriranje




            dgNamestaji.IsReadOnly = true;
            dgNamestaji.SelectionMode = DataGridSelectionMode.Single;
            dgNamestaji.AutoGenerateColumns = false;
            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Naziv";
            c.Binding = new Binding("Naziv");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgNamestaji.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Sifra";
            c.Binding = new Binding("Sifra");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgNamestaji.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Cena";
            c.Binding = new Binding("Cena");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgNamestaji.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "KolicinaUMagacinu";
            c.Binding = new Binding("KolicinaUMagacinu");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgNamestaji.Columns.Add(c);


        }

        private void MyFilter(object sender, FilterEventArgs e)
        {
            Namestaj n = e.Item as Namestaj;
            if (n != null)
            {
                e.Accepted = n.Naziv.ToLower().Contains(tbPretraga.Text.ToLower());  //iz textboxa izvlacimo
            }
        }



        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaj n = new Namestaj();
            NamestajiEdit ne = new NamestajiEdit(n);
            if (ne.ShowDialog() == true)
            {
                //   OsveziKorisnike();
            }
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Namestaj n = dgNamestaji.SelectedItem as Namestaj;

            NamestajiEdit ne = new NamestajiEdit(n, MOD_NAMESTAJ.IZMENA);
            if (ne.ShowDialog() == true)
            {
                //  OsveziKorisnike();
            }
        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Program.Instanca.Namestaji.Remove(dgNamestaji.SelectedItem as Namestaj);
                //  OsveziKorisnike();
            }
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lbNamestaji_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Program.Instanca.Namestaji.Count == 0)
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





    }
}