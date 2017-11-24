using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_3_2015.Model
{
    public class Namestaj : INotifyPropertyChanged
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


        private string sifra;

        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }


        private double cena;

        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }


        private int kolicinaUMagacinu;

        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
            }
        }


        private TipNamestaja tipNamestaja;

        public TipNamestaja TipNamestaja
        {
            get { return tipNamestaja; }
            set
            {
                tipNamestaja = value;
                OnPropertyChanged("TipNamestaja");
            }
        }


        private Akcija akcija;

        public Akcija Akcija
        {
            get { return akcija; }
            set
            {
                akcija = value;
                OnPropertyChanged("Akcija");
            }
        }

        public Namestaj()
        {

        }

        public Namestaj(int id, string naziv, string sifra, double cena, int kolicinaUMagacinu, TipNamestaja tipNamestaja, Akcija akcija)
        {

            this.Id = id;
            this.Naziv = naziv;
            this.Sifra = sifra;
            this.Cena = cena;
            this.KolicinaUMagacinu = kolicinaUMagacinu;
            this.TipNamestaja = tipNamestaja;
            this.Akcija = akcija;

        }

        public override string ToString()
        {
            return "Naziv: " + this.naziv + "\nSifra: " + this.sifra + "\nCena: " + this.cena + "\nKolicina u magacinu: " + this.kolicinaUMagacinu + "\nTip namestaja: " + this.tipNamestaja + "\nAkcija: " + this.akcija;
        }

        public Namestaj DeepCopy()
        {
            Namestaj copy = new Namestaj(this.Id, this.Naziv, this.Sifra, this.Cena, this.KolicinaUMagacinu, this.TipNamestaja, this.Akcija);
            return copy;
        }

        public void SetProp(Namestaj n)
        {
            this.Id = n.Id;
            this.Naziv = n.Naziv;
            this.Sifra = n.Sifra;
            this.Cena = n.Cena;
            this.KolicinaUMagacinu = n.KolicinaUMagacinu;
            this.TipNamestaja = n.TipNamestaja;
            this.Akcija = n.Akcija;

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
