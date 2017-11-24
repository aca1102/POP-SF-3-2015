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

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

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

        private int brTelefon;

        public int BrTelefon
        {
            get { return brTelefon; }
            set
            {
                brTelefon = value;
                OnPropertyChanged("BrTelefona");
            }
        }


        private bool tip;

        public bool Tip
        {
            get { return tip; }
            set
            {
                tip = value;
                OnPropertyChanged("Tip");
            }
        }

        private string nazivtip;

        public string NazivTip
        {
            get { return nazivtip; }
            set
            {
                nazivtip = value;
                OnPropertyChanged("NazivTip");
            }
        }


        public Korisnik() : base()
        {
            this.DatumRodjenja = DateTime.Today;
        }


        public Korisnik(string ime, string prezime, string jmbg, DateTime datum, string kime, string loz, bool tip, string nazivtip, bool status) : base(ime, prezime, jmbg, datum, status)
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
            return base.ToString() + "\nKorisnicko ime: " + this.KorisnickoIme + "\nLozinka: " + this.Lozinka + "\nTip:" + this.Tip + "\n";
        }

        public Korisnik DeepCopy()
        {
            Korisnik copy = new Korisnik(this.Ime, this.Prezime, this.JMBG, this.DatumRodjenja, this.KorisnickoIme, this.Lozinka, this.tip, "", this.Status);
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
            this.Tip = k.tip;
            this.Status = k.Status;
        }
    }
}
