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

        public Korisnik UlogovaniKorisnik { get; set; }


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
    
            
            

        }



        private void UcitajKorisnike()
        {
            KorisnikDAO.Read();
            }

    private void UcitajSalon()
        {

            SalonDAO.Read();
        }

        private void UcitajAkciju()
        {

            AkcijaDAO.Read();
        }

        private void UcitajNamestaj()
        {

            NamestajDAO.Read();

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

        public TipNamestaja GetTipNamestajById(long id)
        {
            TipNamestaja retVal = null;
            foreach (TipNamestaja o in this.Tipovi)
            {
                if (o.Id == id)
                {
                    retVal = o;
                    break;
                }
            }
            return retVal;
        }

        public Akcija GetTipAkcijaById(long id)
        {
            Akcija retVal = null;
            foreach (Akcija p in this.Akcije)
            {
                if (p.Id == id)
                {
                    retVal = p;
                    break;
                }
            }
            return retVal;
        }

    }
}


