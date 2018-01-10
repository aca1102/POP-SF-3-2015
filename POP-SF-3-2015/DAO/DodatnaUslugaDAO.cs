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
    class DodatnaUslugaDAO
    {
        public static void Read()
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from dodatnaUsluga";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "dodatnaUsluga");
                foreach (DataRow row in ds.Tables["dodatnaUsluga"].Rows)
                {
                    DodatnaUsluga du = new DodatnaUsluga();
                    du.Id = (long)Int32.Parse(row["Id"].ToString());
                    du.Naziv = (string)row["Naziv"];
                    du.Cena = (int)row["Cena"];
                    Program.Instanca.Usluga.Add(du);
                }
            }
        }

        public static void Create(DodatnaUsluga du)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into dodatnaUsluga values (@n,@c)";


                cmd.Parameters.Add(new SqlParameter("@naziv", du.Naziv));
                cmd.Parameters.Add(new SqlParameter("@cena", du.Cena));


                try
                {
                    cmd.ExecuteNonQuery();
                    du.Id = GetTableId("dodatnaUsluga");
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                }

            }

        }

        public static void Update(DodatnaUsluga du)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " update dodatnaUsluga set naziv=@naziv, cena=@cena where naziv=@naziv";


                cmd.Parameters.Add(new SqlParameter("@naziv", du.Naziv));
                cmd.Parameters.Add(new SqlParameter("@cena", du.Cena));


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


        public static void Delete(DodatnaUsluga du)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update dodatnaUsluga set active = 0 where naziv=@naziv";


                cmd.Parameters.Add(new SqlParameter("@naziv", du.Naziv));

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
