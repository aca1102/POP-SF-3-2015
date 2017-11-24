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


        private bool status;

        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("status");
            }
        }


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

        }

        public Osoba(string ime, string prezime, string jmbg, DateTime datum, bool status)
        {

            this.Ime = ime;
            this.prezime = prezime;
            this.JMBG = jmbg;
            this.DatumRodjenja = datum;
            this.Status = status;
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