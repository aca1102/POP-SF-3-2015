using POP_SF_3_2015.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POP_SF_3_2015.DAO
{
    class TipKorisnikaDAO
    {
        public static void Read()
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from TipKorisnika";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "tipovi");
                foreach (DataRow row in ds.Tables["tipovi"].Rows)
                {
                    TipKorisnika t = new TipKorisnika();
                    t.Id = (long)Int32.Parse(row["Id"].ToString());
                    t.Naziv = (string)row["Naziv"];
                    t.Opis = (string)row["Opis"];

                    Program.Instanca.TipoviKorisnika.Add(t);
                }
            }
        }

        public static void Create(TipKorisnika t)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into tip_korisnika values (@n,@o)";


                cmd.Parameters.Add(new SqlParameter("@naziv", t.Naziv));
                cmd.Parameters.Add(new SqlParameter("@opis", t.Opis));


                try
                {
                    cmd.ExecuteNonQuery();
                    t.Id = GetTableId("tip_korisnika");
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                }

            }

        }

        public static void Update(TipKorisnika t)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " update tip_korisnika set naziv=@naziv, opis=@opis where naziv=@naziv";


                cmd.Parameters.Add(new SqlParameter("@naziv", t.Naziv));
                cmd.Parameters.Add(new SqlParameter("@opis", t.Opis));


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

        private static long GetTableId(string table)
        {
            long retVal = -1;
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select IDENT_CURRENT ('" + table + "')";

                retVal = Convert.ToInt64(cmd.ExecuteScalar());

            }
            return retVal;
        }


        public static void Delete(TipKorisnika t)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update tip_korisnika set active = 0 where naziv=@naziv";


                cmd.Parameters.Add(new SqlParameter("@naziv", t.Naziv));

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
