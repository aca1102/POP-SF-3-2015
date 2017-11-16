using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace POP_SF_3_2015.Model
{
    public class Salon : INotifyPropertyChanged
    {
        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        private string telefon;

        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string web;

        public string Web
        {
            get { return web; }
            set
            {
                web = value;
                OnPropertyChanged("Web");
            }
        }

        private string pib;

        public string Pib
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("Pib");
            }
        }

        private string maticniBroj;

        public string MaticniBroj
        {
            get { return maticniBroj; }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }

        private string ziroRacun;

        public string ZiroRacun
        {
            get { return ziroRacun; }
            set
            {
                ziroRacun = value;
                OnPropertyChanged("ZiroRacun");
            }
        }

        public Salon()
        {

        }

        public Salon(string naziv, string adresa, string telefon, string email, string webAdresa, string pib, string maticniBr, string ziroRacun)
        {
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.Telefon = telefon;
            this.Email = email;
            this.Web = webAdresa;
            this.Pib = pib;
            this.MaticniBroj = maticniBr;
            this.ZiroRacun = ziroRacun;
        }

        public override string ToString()
        {
            return "Naziv: " + this.Naziv + "\nAdresa: " + this.Adresa + "\nTelefon: " + this.Telefon + "\nEmail: " + this.Email + "\nWeb adresa: " + this.Web + "\nPIB: " + this.Pib + "\nMaticni broj: " + this.MaticniBroj + "\nZiro racun: " + this.ZiroRacun;
        }

        public Salon DeepCopy()
        {
            Salon copy = new Salon(this.Naziv, this.Adresa, this.Telefon, this.Email, this.Web, this.Pib, this.MaticniBroj, this.ZiroRacun);
            return copy;
        }

        public void SetProp(Salon s)
        {
            this.Naziv = s.Naziv;
            this.Adresa = s.Adresa;
            this.Telefon = s.Telefon;
            this.Email = s.Email;
            this.Web = s.Web;
            this.Pib = s.Pib;
            this.MaticniBroj = s.MaticniBroj;
            this.ZiroRacun = s.ZiroRacun;
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
