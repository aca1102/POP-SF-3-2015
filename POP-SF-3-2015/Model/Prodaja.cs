using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_3_2015.Model
{
    public class Prodaja : INotifyPropertyChanged
    {
        private long id;

        public long Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private Namestaj namestaj;

        public Namestaj Namestaj
        {
            get { return namestaj; }
            set
            {
                namestaj = value;
                OnPropertyChanged("NamestajZaProdaju");
            }
        }


        private DateTime datumProdaje;

        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }

        private string brojRacuna;

        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }

        private string kupac;

        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        private DodatnaUsluga dodatnaUsluga;

        public DodatnaUsluga DodatnaUsluga
        {
            get { return dodatnaUsluga; }
            set
            {
                dodatnaUsluga = value;
                OnPropertyChanged("DodatnaUsluga");
            }
        }
        public const double PDV = 0.2;


        private double ukupnaCena;

        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set
            {
                ukupnaCena = value;
                OnPropertyChanged("UkupnaCena");
            }
        }

        public Prodaja()
        {

        }

        public Prodaja(long id, Namestaj namestaj, DateTime datumProdaje, string brojRacuna, string kupac, DodatnaUsluga dodatnaUsluga, double ukupnaCena)
        {

            this.Id = id;
            this.Namestaj = namestaj;
            this.DatumProdaje = datumProdaje;
            this.BrojRacuna = brojRacuna;
            this.Kupac = kupac;
            this.DodatnaUsluga = dodatnaUsluga;
            this.UkupnaCena = ukupnaCena;

        }

        public override string ToString()
        {
            return "Namestaj za prodaju: " + this.namestaj + "\nDatum prodaje: " + this.datumProdaje + "\nBroj racuna: " + this.brojRacuna + "\nKupac: " + this.kupac + "\nDodatnaUsluga: " + this.dodatnaUsluga + "\nUkupnaCena: " + this.ukupnaCena;
        }

        public Prodaja DeepCopy()
        {
            Prodaja copy = new Prodaja(this.Id, this.Namestaj, this.DatumProdaje, this.BrojRacuna, this.Kupac, this.DodatnaUsluga, this.UkupnaCena);
            return copy;
        }

        public void SetProp(Prodaja p)
        {
            this.Id = p.Id;
            this.Namestaj = p.Namestaj;
            this.DatumProdaje = p.DatumProdaje;
            this.BrojRacuna = p.BrojRacuna;
            this.Kupac = p.Kupac;
            this.DodatnaUsluga = p.DodatnaUsluga;
            this.UkupnaCena = p.UkupnaCena;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
