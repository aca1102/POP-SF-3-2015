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
            bIzmeni.IsEnabled = false;

            cvs = new CollectionViewSource();
            cvs.Source = Program.Instanca.Saloni;
            dgSalon.ItemsSource = cvs.View;

            cvs.SortDescriptions.Add(new SortDescription("Ime", ListSortDirection.Ascending));

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
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Salon s = dgSalon.SelectedItem as Salon;

            SalonEdit sew = new SalonEdit(s, MOD_SALON.IZMENA);
            if (sew.ShowDialog() == true)
            {

            }

        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgSalon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Program.Instanca.Korisnici.Count == 0)
            {
                bIzmeni.IsEnabled = false;
            }
            else
            {
                bIzmeni.IsEnabled = true;
            }
        }
    }
}
