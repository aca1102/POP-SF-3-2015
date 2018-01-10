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
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {
        private CollectionViewSource cvs;


        public ProdajaWindow()
        {
            InitializeComponent();
            

            cvs = new CollectionViewSource();
            cvs.Source = Program.Instanca.Prodaje;
            dgProdaja.ItemsSource = cvs.View;

            //cvs.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Ascending));

            dgProdaja.IsReadOnly = true;
            dgProdaja.SelectionMode = DataGridSelectionMode.Single;
            dgProdaja.AutoGenerateColumns = false;

            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Kupac";
            c.Binding = new Binding("Kupac");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgProdaja.Columns.Add(c);


            c = new DataGridTextColumn();
            c.Header = "Broj Racuna";
            c.Binding = new Binding("BrojRacuna");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgProdaja.Columns.Add(c);



            c = new DataGridTextColumn();
            c.Header = "Datum Prodaje";
            c.Binding = new Binding("DatumProdaje");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgProdaja.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Namestaj";
            c.Binding = new Binding("Namestaj.Naziv");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgProdaja.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Dodatna Usluga";
            c.Binding = new Binding("DodatnaUsluga.Naziv");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgProdaja.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Ukupna Cena";
            c.Binding = new Binding("UkupnaCena");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgProdaja.Columns.Add(c);

            dgProdaja.SelectedIndex = -1;
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;

        }

        private void MyFilter(object sender, FilterEventArgs e)
        {
            Prodaja p = e.Item as Prodaja;
            if (p != null)
            {
                e.Accepted = p.Kupac.ToLower().Contains(tbPretraga.Text.ToLower());


            }

        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(MyFilter);
        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Prodaja p = new Prodaja();
            ProdajaEdit pew = new ProdajaEdit(p);
            if (pew.ShowDialog() == true)
            {

            }
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Prodaja p = dgProdaja.SelectedItem as Prodaja;

            ProdajaEdit pew = new ProdajaEdit(p, MOD_PRODAJA.IZMENA);
            if (pew.ShowDialog() == true)
            {

            }

        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Prodaja p = dgProdaja.SelectedItem as Prodaja;

                ProdajaDAO.Delete(dgProdaja.SelectedItem as Prodaja);
                Program.Instanca.Prodaje.Remove(dgProdaja.SelectedItem as Prodaja);

                ProdajaDAO.Delete(p);

            }
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgProdaja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Program.Instanca.Prodaje.Count == 0)
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
    }
}
