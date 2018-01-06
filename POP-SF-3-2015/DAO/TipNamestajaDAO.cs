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
    class TipNamestajaDAO
    {
        public static void Read()
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from tipNamestaja";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "tipoviNamestaja");
                foreach (DataRow row in ds.Tables["tipoviNamestaja"].Rows)
                {
                    TipNamestaja tn = new TipNamestaja();
                    tn.Id = (long)Int32.Parse(row["Id"].ToString());
                    tn.Naziv = (string)row["Naziv"];
                    tn.Opis = (string)row["Opis"];
                    Program.Instanca.Tipovi.Add(tn);
                }
            }
        }

        public static void Create(TipNamestaja tn)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into tipNamestaja values (@n,@o)";


                cmd.Parameters.Add(new SqlParameter("@naziv", tn.Naziv));
                cmd.Parameters.Add(new SqlParameter("@opis", tn.Opis));


                try
                {
                    cmd.ExecuteNonQuery();
                    tn.Id = GetTableId("tipNamestaja");
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                }

            }

        }

        public static void Update(TipNamestaja tn)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " update tipNamestaja set naziv=@naziv, opis=@opis where naziv=@naziv";


                cmd.Parameters.Add(new SqlParameter("@naziv", tn.Naziv));
                cmd.Parameters.Add(new SqlParameter("@opis", tn.Opis));


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


        public static void Delete(TipNamestaja tn)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update tipNamestaja set active = 0 where naziv=@naziv";


                cmd.Parameters.Add(new SqlParameter("@naziv", tn.Naziv));

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

