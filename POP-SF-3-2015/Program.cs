using POP_SF_3_2015.Model;
using POP_SF_3_2015.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace POP_SF_3_2015
{
    public class Program
    {

        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }
        public ObservableCollection<Salon> Saloni { get; set; }
        public ObservableCollection<DodatnaUsluga> Usluga { get; set; }
        public ObservableCollection<Namestaj> Namestaji { get; set; }
        public ObservableCollection<Prodaja> Prodaje { get; set; }
        public ObservableCollection<TipNamestaja> Tipovi { get; set; }

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


        }
    }
}
