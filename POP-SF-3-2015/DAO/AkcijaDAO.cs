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
    class AkcijaDAO
    {
        public static void Read()
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from akcija where active = 1";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "akcija");
                foreach (DataRow row in ds.Tables["akcija"].Rows)
                {
                    Akcija a = new Akcija();
                    a.Id = (long)Int32.Parse(row["Id"].ToString());
                    a.Popust = (int)row["popust"];
                    a.DatumPocetka = (DateTime)row["DatumPocetka"];
                    a.DatumZavrsetka = (DateTime)row["DatumZavrsetka"];

                    Program.Instanca.Akcije.Add(a);
                }
            }
        }

        public static void Create(Akcija a)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Akcija (popust,DatumPocetka,DatumZavrsetka,Active) values (@popust, @datumPocetka, @datumZavrsetka, @active)";


                cmd.Parameters.Add(new SqlParameter("@popust", a.Popust));
                cmd.Parameters.Add(new SqlParameter("@datumPocetka", a.DatumPocetka.Date.ToString("d")));
                cmd.Parameters.Add(new SqlParameter("@datumZavrsetka", a.DatumZavrsetka.Date.ToString("d")));
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

        public static void Update(Akcija a)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update akcija set popust=@popust, datumPocetka=@datumPocetka, datumZavrsetka=@datumZavrsetka where Id=@id";

                cmd.Parameters.Add(new SqlParameter("@id", a.Id));
                cmd.Parameters.Add(new SqlParameter("@popust", a.Popust));
                cmd.Parameters.Add(new SqlParameter("@datumPocetka", a.DatumPocetka.Date.ToString("d")));
                cmd.Parameters.Add(new SqlParameter("@datumZavrsetka", a.DatumZavrsetka.Date.ToString("d")));

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


        public static void Delete(Akcija a)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update akcija set active = 0 where id=@Id";


                cmd.Parameters.Add(new SqlParameter("@id", a.Id));

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
