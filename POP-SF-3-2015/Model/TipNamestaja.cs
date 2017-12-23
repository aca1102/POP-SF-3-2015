using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace POP_SF_3_2015.Model
{
    public class TipNamestaja : INotifyPropertyChanged
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

        private string opis;

        public string Opis
        {
            get { return opis; }
            set
            {
                opis = value;
                OnPropertyChanged("Opis");
            }
        }

        public TipNamestaja()
        {

        }


        public TipNamestaja(string naziv, string opis)
        {
            this.Naziv = naziv;
            this.Opis = opis;
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
        //#region Datebase
        //public static ObservableCollection<TipNamestaja> GetAll()
        //{
        //    var tipoviNamestaja = new ObservableCollection<TipNamestaja>();
        //    using (var con = new SqlConnection(ConfigurationManager.ConnectionString["POP"].ConnectionString))
        //    {
        //        SqlCommand cmd = con.CreateCommand();
        //        cmd.CommandText = "select * from TipNamestaja where Obrisan=0";

                
        //        DataSet ds= new DataSet();
        //        SqlDataAdapter da new SqlDataAdapter();

        //        da.SelectCommand = cmd;
        //        da.Fill(ds, "TipNamsestaja");

        //        foreach (DataRow row in ds.Tables["TipNamestaja"].Row) ;
        //        {
                    
        //        }
                
        //    }
        //}
        
        //#endregion
    }
}
