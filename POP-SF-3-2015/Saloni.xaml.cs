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
using System.ComponentModel;
using POP_SF_3_2015.DAO;

namespace POP_SF_3_2015
{
    /// <summary>
    /// Interaction logic for Salon.xaml
    /// </summary>
    public partial class Saloni : Window
    {
        private CollectionViewSource cvs;


        public Saloni()
        {
            InitializeComponent();
            

            cvs = new CollectionViewSource();
            cvs.Source = Program.Instanca.Saloni;
            dgSalon.ItemsSource = cvs.View;

            cvs.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Ascending));

            dgSalon.IsReadOnly = true;
            dgSalon.SelectionMode = DataGridSelectionMode.Single;
            dgSalon.AutoGenerateColumns = false;

            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Naziv";
            c.Binding = new Binding("Naziv");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgSalon.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Adresa";
            c.Binding = new Binding("Adresa");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgSalon.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Telefon";
            c.Binding = new Binding("Telefon");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgSalon.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Email";
            c.Binding = new Binding("Email");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgSalon.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Web";
            c.Binding = new Binding("Web");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgSalon.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Pib";
            c.Binding = new Binding("Pib");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgSalon.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "MaticniBroj";
            c.Binding = new Binding("MaticniBroj");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgSalon.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "ZiroRacun";
            c.Binding = new Binding("ZiroRacun");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgSalon.Columns.Add(c);

            dgSalon.SelectedIndex = -1;
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;

        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Salon s = new Salon();
            SalonEdit sew = new SalonEdit(s);
            if (sew.ShowDialog() == true)
            {

            }
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Salon s = dgSalon.SelectedItem as Salon;

            SalonEdit sew = new SalonEdit(s, MOD_SALON.IZMENA);
            if (sew.ShowDialog() == true)
            {

            }

        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Salon s = dgSalon.SelectedItem as Salon;

                SalonDAO.Delete(dgSalon.SelectedItem as Salon);
                Program.Instanca.Saloni.Remove(dgSalon.SelectedItem as Salon);

                SalonDAO.Delete(s);

            }
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgSalon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Program.Instanca.Saloni.Count == 0)
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
