using POP_SF_3_2015.DAO;
using POP_SF_3_2015.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        private CollectionViewSource cvs;


        public AkcijaWindow()
        {
            InitializeComponent();
           

            cvs = new CollectionViewSource();
            cvs.Source = Program.Instanca.Akcije;
            dgAkcije.ItemsSource = cvs.View;

            //cvs.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Ascending));

            dgAkcije.IsReadOnly = true;
            dgAkcije.SelectionMode = DataGridSelectionMode.Single;
            dgAkcije.AutoGenerateColumns = false;

            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Popust";
            c.Binding = new Binding("Popust");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgAkcije.Columns.Add(c);


            c = new DataGridTextColumn();
            c.Header = "DatumPocetka";
            c.Binding = new Binding("DatumPocetka");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgAkcije.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "DatumZavrsetka";
            c.Binding = new Binding("DatumZavrsetka");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgAkcije.Columns.Add(c);

            dgAkcije.SelectedIndex = -1;
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;

        }



        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Akcija a = new Akcija();
            AkcijeEdit aew = new AkcijeEdit(a);
            if (aew.ShowDialog() == true)
            {

            }
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Akcija a = dgAkcije.SelectedItem as Akcija;

            AkcijeEdit aew = new AkcijeEdit(a, MOD_AKCIJA.IZMENA);
            if (aew.ShowDialog() == true)
            {

            }

        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Akcija s = dgAkcije.SelectedItem as Akcija;

                AkcijaDAO.Delete(dgAkcije.SelectedItem as Akcija);
                Program.Instanca.Akcije.Remove(dgAkcije.SelectedItem as Akcija);

                AkcijaDAO.Delete(s);

            }
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgAkcije_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Program.Instanca.Akcije.Count == 0)
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


