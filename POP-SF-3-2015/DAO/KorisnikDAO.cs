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
    public class KorisnikDAO
    {

        public static void Create(Korisnik k)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();
                
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Korisnik(Ime,Prezime,JMBG,DatumRodjenja,KorisnickoIme,Lozinka,TipKorisnikaId,Active) values (@ime, @prez, @jmbg, @datum, @kime, @loz, @tip,@active)";



                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prez", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.JMBG));
                cmd.Parameters.Add(new SqlParameter("@datum", k.DatumRodjenja));
                cmd.Parameters.Add(new SqlParameter("@kime", k.KorisnickoIme));
                cmd.Parameters.Add(new SqlParameter("@loz", k.Lozinka));
                cmd.Parameters.Add(new SqlParameter("@tip", k.Tip.Id));
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
                cmd.CommandText = "select * from Korisnik where active = 1";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "korisnici");
                foreach (DataRow row in ds.Tables["korisnici"].Rows)
                {
                    Korisnik k = new Korisnik();
                    k.Id = (long) Int32.Parse(row["Id"].ToString());
                    k.Ime = (string)row["Ime"];
                    k.Prezime = (string)row["Prezime"];
                    k.JMBG = (string)row["JMBG"];
                    k.DatumRodjenja = (DateTime)row["DatumRodjenja"];
                    k.KorisnickoIme = (string)row["KorisnickoIme"];
                    k.Lozinka = (string)row["Lozinka"];
                    k.Tip = Program.Instanca.GetTipKorisnikaById((long) Int32.Parse(row["TipKorisnikaId"].ToString()));

                    Program.Instanca.Korisnici.Add(k);
                    //return k;
                }
            }
        }

        public static void Update(Korisnik k)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update korisnik set Ime=@ime, Prezime=@prez, JMBG=@jmbg, DatumRodjenja=@datum, KorisnickoIme=@kime, Lozinka=@loz,TipKorisnikaId=@tip where Id=@id";

                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prez", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.JMBG));
                cmd.Parameters.Add(new SqlParameter("@datum", k.DatumRodjenja));
                cmd.Parameters.Add(new SqlParameter("@kime", k.KorisnickoIme));
                cmd.Parameters.Add(new SqlParameter("@loz", k.Lozinka));
                cmd.Parameters.Add(new SqlParameter("@tip", k.Tip.Id));

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
        public static void Delete(Korisnik k)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update korisnik set active = 0 where id=@Id";


                cmd.Parameters.Add(new SqlParameter("@id", k.Id));

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
