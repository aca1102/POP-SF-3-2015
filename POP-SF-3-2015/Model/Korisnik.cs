using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_3_2015.Model
{
    public class Korisnik : Osoba, INotifyPropertyChanged
    {

        public long Id { get; set; }

        private string korisnickoIme;

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }



        private string lozinka;

        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }

        }

        //private int brTelefon;

        //public int BrTelefon
        //{
        //    get { return brTelefon; }
        //    set
        //    {
        //        brTelefon = value;
        //        OnPropertyChanged("BrTelefona");
        //    }
        //}

        private TipKorisnika tip;

        public TipKorisnika Tip
        {
            get { return tip; }
            set { tip = value; }
        }





        public Korisnik() : base()
        {

        }


        public Korisnik(string ime, string prezime, string jmbg, DateTime datum, string kime, string loz, TipKorisnika tip) : base(ime, prezime, jmbg, datum)
        {
            this.KorisnickoIme = kime;
            this.Lozinka = loz;
            this.Tip = tip;
        }

        public bool LogIn(string kime, string loz)
        {
            if (kime == this.KorisnickoIme && loz == this.Lozinka)
            {
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return base.ToString() + "\nKorisnicko ime: " + this.KorisnickoIme + "\nLozinka: " + this.Lozinka + "\n";
        }

        public Korisnik DeepCopy()
        {
            Korisnik copy = new Korisnik(this.Ime, this.Prezime, this.JMBG, this.DatumRodjenja, this.KorisnickoIme, this.Lozinka, this.Tip);
            return copy;
        }

        public void SetProp(Korisnik k)
        {
            this.Ime = k.Ime;
            this.Prezime = k.Prezime;
            this.JMBG = k.JMBG;
            this.DatumRodjenja = k.DatumRodjenja;
            this.KorisnickoIme = k.KorisnickoIme;
            this.Lozinka = k.Lozinka;
            this.Tip = k.Tip;
        }




    }
}
