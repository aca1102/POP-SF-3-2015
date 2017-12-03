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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF_3_2015
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        

        private void bKorisnici_Click(object sender, RoutedEventArgs e)
        {
            Korisnici kw = new Korisnici();
            kw.Show();
        }

        private void bSalon_Click(object sender, RoutedEventArgs e)
        {
            Saloni kw = new Saloni();
            kw.Show();
        }

        private void bNamestaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaji kw = new Namestaji();
            kw.Show();

        }

    }
}