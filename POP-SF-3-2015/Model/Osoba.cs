using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_3_2015.Model
{
    public class Osoba : INotifyPropertyChanged
    {

        private string ime;

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }


        private string prezime;

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        //public string JMBG { get; set; }

        private string jmbg;

        public string JMBG
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged("JMBG");
            }
        }

        private DateTime datumRodjenja;

        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set
            {
                datumRodjenja = value;
                OnPropertyChanged("Datum rodjenja");
            }
        }




        public Osoba()
        {
            this.DatumRodjenja = DateTime.Now;
        }

        public Osoba(string ime, string prezime, string jmbg, DateTime datum)
        {

            this.Ime = ime;
            this.prezime = prezime;
            this.JMBG = jmbg;
            this.DatumRodjenja = datum;
        }

        public virtual void func1()
        {

        }

        public override string ToString()
        {
            return "Ime: " + this.Ime + "\nPrezime: " + this.prezime + "\nJMBG: " + this.JMBG;
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