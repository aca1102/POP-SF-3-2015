using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_3_2015.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged
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

        private int cena;

        public int Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public DodatnaUsluga()
        {

        }

        public DodatnaUsluga(long id, string naziv, int cena)
        {

            this.Id = id;
            this.Naziv = naziv;
            this.Cena = cena;

        }

        public override string ToString()
        {
            return "Naziv: " + this.naziv + "\nCena: " + this.cena;
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