using POP_SF_3_2015.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POP_SF_3_2015.DAO
{
    public class NamestajDAO
    {

        public static void Create(Namestaj n)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Namestaj(Naziv,Sifra,Cena,KolicinaUMagacinu,TipNamestajaId,AkcijaId,Active) values (@naziv, @sifra, @cena, @kolicinaUMagacinu, @tipNamestaja, @akcija, @active)";



                cmd.Parameters.Add(new SqlParameter("@naziv", n.Naziv));
                cmd.Parameters.Add(new SqlParameter("@sifra", n.Sifra));
                cmd.Parameters.Add(new SqlParameter("@cena", n.Cena));
                cmd.Parameters.Add(new SqlParameter("@kolicinaUMagacinu", n.KolicinaUMagacinu));
                cmd.Parameters.Add(new SqlParameter("@tipNamestaja", n.TipNamestaja.Id));
                cmd.Parameters.Add(new SqlParameter("@akcija", n.Akcija.Id));   
                cmd.Parameters.Add(new SqlParameter("@active", 1));


                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                }

            }

        }

        public static void Read()
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from namestaj where active = 1";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "namestaj");
                foreach (DataRow row in ds.Tables["namestaj"].Rows)
                {
                    Namestaj n = new Namestaj();
                    n.Id = (long)Int32.Parse(row["Id"].ToString());
                    n.Naziv = (string)row["Naziv"];
                    n.Sifra = (string)row["Sifra"];
                    n.Cena = (int)row["Cena"];
                    n.KolicinaUMagacinu = (int)row["KolicinaUMagacinu"];
                    n.TipNamestaja = Program.Instanca.GetTipNamestajById((int)row["TipNamestajaId"]);
                    n.Akcija = Program.Instanca.GetTipAkcijaById((int)row["AkcijaId"]);
                    


                    Program.Instanca.Namestaji.Add(n);
                    
                }
            }
        }

        public static void Update(Namestaj n)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update namestaj set Naziv=@naziv, Sifra=@sifra, Cena=@cena, KolicinaUMagacinu=@kolicinaUMagacinu, TipNamestajaId=@tipNamestaja, AkcijaId=@akcija where Id=@id";

                cmd.Parameters.Add(new SqlParameter("@id", n.Id));
                cmd.Parameters.Add(new SqlParameter("@naziv", n.Naziv));
                cmd.Parameters.Add(new SqlParameter("@sifra", n.Sifra));
                cmd.Parameters.Add(new SqlParameter("@cena", n.Cena));
                cmd.Parameters.Add(new SqlParameter("@kolicinaUMagacinu", n.KolicinaUMagacinu));
                cmd.Parameters.Add(new SqlParameter("@tipNamestaja", n.TipNamestaja.Id));
                cmd.Parameters.Add(new SqlParameter("@akcija", n.Akcija.Id));

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                }
            }
        }
        public static void Delete(Namestaj n)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update namestaj set active = 0 where id=@Id";


                cmd.Parameters.Add(new SqlParameter("@id", n.Id));

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                }

            }
        }

    }
}
