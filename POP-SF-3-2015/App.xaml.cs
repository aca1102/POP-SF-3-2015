using POP_SF_3_2015.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace POP_SF_3_2015
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            TipKorisnikaDAO.Read();
            KorisnikDAO.Read();
            SalonDAO.Read();
            AkcijaDAO.Read();
            TipNamestajaDAO.Read();
            NamestajDAO.Read();
        }

    }
}
