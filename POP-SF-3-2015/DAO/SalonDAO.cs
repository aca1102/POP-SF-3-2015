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
    class SalonDAO
    {
        public static void Read()
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from salon where active = 1";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "salon");
                foreach (DataRow row in ds.Tables["salon"].Rows)
                {
                    Salon s = new Salon();
                    s.Id = (long)Int32.Parse(row["Id"].ToString());
                    s.Naziv = (string)row["naziv"];
                    s.Adresa = (string)row["adresa"];
                    s.Telefon = (string)row["telefon"];
                    s.Email = (string)row["email"];
                    s.Web = (string)row["web"];
                    s.Pib = (string)row["pib"];
                    s.MaticniBroj = (string)row["maticniBroj"];
                    s.ZiroRacun = (string)row["ziroRacun"];


                    Program.Instanca.Saloni.Add(s);
                }
            }
        }

        public static void Create(Salon s)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Salon (Naziv,Adresa,Telefon,Email,Web,Pib,MaticniBroj,ZiroRacun,Active) values (@naziv, @adresa, @telefon, @email, @web, @pib, @maticniBroj, @ziroRacun, @active)";

                
                cmd.Parameters.Add(new SqlParameter("@naziv", s.Naziv));
                cmd.Parameters.Add(new SqlParameter("@adresa", s.Adresa));
                cmd.Parameters.Add(new SqlParameter("@telefon", s.Telefon));
                cmd.Parameters.Add(new SqlParameter("@email", s.Email));
                cmd.Parameters.Add(new SqlParameter("@web", s.Web));
                cmd.Parameters.Add(new SqlParameter("@pib", s.Pib));
                cmd.Parameters.Add(new SqlParameter("@maticniBroj", s.MaticniBroj));
                cmd.Parameters.Add(new SqlParameter("@ziroRacun", s.ZiroRacun));
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

        public static void Update(Salon s)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update salon set naziv=@naziv, adresa=@adresa, telefon=@telefon, email=@email, web=@web, pib=@pib, maticniBroj=@maticniBroj, ziroRacun=@ziroRacun where Id=@id";

                cmd.Parameters.Add(new SqlParameter("@id", s.Id));
                cmd.Parameters.Add(new SqlParameter("@naziv", s.Naziv));
                cmd.Parameters.Add(new SqlParameter("@adresa", s.Adresa));
                cmd.Parameters.Add(new SqlParameter("@telefon", s.Telefon));
                cmd.Parameters.Add(new SqlParameter("@email", s.Email));
                cmd.Parameters.Add(new SqlParameter("@web", s.Web));
                cmd.Parameters.Add(new SqlParameter("@pib", s.Pib));
                cmd.Parameters.Add(new SqlParameter("@maticniBroj", s.MaticniBroj));
                cmd.Parameters.Add(new SqlParameter("@ziroRacun", s.ZiroRacun));

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


        public static void Delete(Salon s)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update salon set active = 0 where id=@Id";


                cmd.Parameters.Add(new SqlParameter("@id", s.Id));

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

