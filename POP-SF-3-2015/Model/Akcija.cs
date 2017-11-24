using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_3_2015.Model
{
    public class Akcija : INotifyPropertyChanged
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

        private DateTime datumPocetka;

        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }

        private decimal popust;

        public decimal Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }

        private DateTime datumZavrsetka;

        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }
        }
        public Akcija()
        {

        }

        public Akcija(int id, DateTime datumPocetka, decimal popust, DateTime datumZavrsetka)
        {

            this.Id = id;
            this.DatumPocetka = datumPocetka;
            this.Popust = popust;
            this.DatumZavrsetka = datumZavrsetka;

        }

        public override string ToString()
        {
            return "Datum Pocetka: " + this.datumPocetka + "\nPopust: " + this.popust + "\nDatum Zavrsetka: " + this.datumZavrsetka;
        }

        public Akcija DeepCopy()
        {
            Akcija copy = new Akcija(this.Id, this.DatumPocetka, this.Popust, this.DatumZavrsetka);
            return copy;
        }

        public void SetProp(Akcija a)
        {
            this.Id = a.Id;
            this.DatumPocetka = a.DatumPocetka;
            this.Popust = a.Popust;
            this.DatumZavrsetka = a.DatumZavrsetka;


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
