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
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private List<Namestaj> namestajZaProdaju;

        public List<Namestaj> NamestajZaProdaju
        {
            get { return namestajZaProdaju; }
            set
            {
                namestajZaProdaju = value;
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

        private List<DodatnaUsluga> dodatnaUsluga;

        public List<DodatnaUsluga> DodatnaUsluga
        {
            get { return dodatnaUsluga; }
            set
            {
                dodatnaUsluga = value;
                OnPropertyChanged("DodatnaUsluga");
            }
        }
        public const double PDV = 0.02;


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

        public Prodaja(int id, List<Namestaj> namestajZaProdaju, DateTime datumProdaje, string brojRacuna, string Kupac, List<DodatnaUsluga> dodatnaUsluga, double ukupnaCena)
        {

            this.Id = id;
            this.NamestajZaProdaju = namestajZaProdaju;
            this.DatumProdaje = datumProdaje;
            this.BrojRacuna = brojRacuna;
            this.Kupac = kupac;
            this.DodatnaUsluga = dodatnaUsluga;
            this.UkupnaCena = ukupnaCena;

        }

        public override string ToString()
        {
            return "Namestaj za prodaju: " + this.namestajZaProdaju + "\nDatum prodaje: " + this.datumProdaje + "\nBroj racuna: " + this.brojRacuna + "\nKupac: " + this.kupac + "\nDodatnaUsluga: " + this.dodatnaUsluga + "\nUkupnaCena: " + this.ukupnaCena;
        }

        public Prodaja DeepCopy()
        {
            Prodaja copy = new Prodaja(this.Id, this.NamestajZaProdaju, this.DatumProdaje, this.BrojRacuna, this.Kupac, this.DodatnaUsluga, this.UkupnaCena);
            return copy;
        }

        public void SetProp(Prodaja p)
        {
            this.Id = p.Id;
            this.NamestajZaProdaju = p.NamestajZaProdaju;
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
