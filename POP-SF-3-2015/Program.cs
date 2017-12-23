using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POP_SF_3_2015.Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using POP_SF_3_2015.DAO;

namespace POP_SF_3_2015
{
    public class Program
    {
        public const string CONN_STR = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=POP;Integrated Security=True;";

        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }
        public ObservableCollection<Salon> Saloni { get; set; }
        public ObservableCollection<DodatnaUsluga> Usluga { get; set; }
        public ObservableCollection<Namestaj> Namestaji { get; set; }
        public ObservableCollection<Prodaja> Prodaje { get; set; }
        public ObservableCollection<TipNamestaja> Tipovi { get; set; }
        public ObservableCollection<TipKorisnika> TipoviKorisnika { get; set; }

        private static Program instanca = new Program();

        public static Program Instanca
        {
            get { return instanca; }
        }

        private Program()
        {
            Korisnici = new ObservableCollection<Korisnik>();
            Akcije = new ObservableCollection<Akcija>();
            Saloni = new ObservableCollection<Salon>();
            Usluga = new ObservableCollection<DodatnaUsluga>();
            Namestaji = new ObservableCollection<Namestaj>();
            Prodaje = new ObservableCollection<Prodaja>();
            Tipovi = new ObservableCollection<TipNamestaja>();
            TipoviKorisnika = new ObservableCollection<TipKorisnika>();

            UcitajSalon();
            UcitajNamestaj();

        }



        private void UcitajKorisnike()
        {
            KorisnikDAO.Read();
            //    TipoviKorisnika.Add(new TipKorisnika("admin", "administrira celu aplikaciju"));
            //    TipoviKorisnika.Add(new TipKorisnika("radnik", "ima pristup kursevima i ucenicima"));
            //    TipoviKorisnika.Add(new TipKorisnika("menadzer", "ima pristup kursevima i uplatama"));

            //    Korisnik k = new Korisnik("Aleksandar", "Miladinovic", "123", new DateTime(1996, 5, 12), "b", "k", true, "cao", false);
            //    Korisnici.Add(k);
            //    Korisnici.Add(new Korisnik("Zoran", "Peric", "312", new DateTime(1996, 2, 19), "n", "f", true, "cao", false));
            //    Korisnici.Add(new Korisnik("Goran", "Zoranic", "456", new DateTime(1996, 5, 23), "s", "c", true, "cao", false));

        }

    private void UcitajSalon()
        {

            Salon s = new Salon("Forma", "Bulevar Oslobodjenja 101", "063/123456", "acam@gmail.com", "faca.com", "789456123", "456789", "8974651");
            Saloni.Add(s);
        }

        private void UcitajNamestaj()
        {

            Tipovi.Add(new TipNamestaja("bracni", "bracni krevet"));
            Tipovi.Add(new TipNamestaja("ugaona", "za sedenje"));
            Tipovi.Add(new TipNamestaja("drveni", "trpezarijski"));

            Namestaj n = new Namestaj(1, "krevet", "123", 500, 10);
            Namestaji.Add(n);
            Namestaji.Add(new Namestaj(2, "fotelja", "456", 400, 15));
            Namestaji.Add(new Namestaj(3, "sto", "789", 600, 18));

        }

        public TipKorisnika GetTipKorisnikaById(long id)
        {
            TipKorisnika retVal = null;
            foreach (TipKorisnika t in this.TipoviKorisnika)
            {
                if (t.Id == id)
                {
                    retVal = t;
                    break;
                }
            }
            return retVal;
        }

    }
}


