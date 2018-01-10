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
    class ProdajaDAO
    {
        public static void Read()
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from prodaja where active = 1";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "prodaja");
                foreach (DataRow row in ds.Tables["prodaja"].Rows)
                {
                    Prodaja p = new Prodaja();
                    p.Id = (long)Int32.Parse(row["Id"].ToString());
                    p.Kupac = (string)row["Kupac"];
                    p.BrojRacuna = (string)row["BrojRacuna"];
                    p.DatumProdaje = (DateTime)row["DatumProdaje"];
                    p.Namestaj = Program.Instanca.GetNamestajById((int)row["NamestajId"]);
                    p.DodatnaUsluga = Program.Instanca.GetDodatnaUslugaById((int)row["DodatnaUslugaId"]);
                    p.UkupnaCena = Convert.ToDouble(row["UkupnaCena"]);


                    Program.Instanca.Prodaje.Add(p);
                }
            }
        }

        public static void Create(Prodaja p)
        {

            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Prodaja (Kupac,BrojRacuna,DatumProdaje,NamestajId,DodatnaUslugaId,UkupnaCena,Active) values (@kupac, @brojRacuna, @datumProdaje, @namestajId, @dodatnaUslugaId, @ukupnaCena, @active)";


                cmd.Parameters.Add(new SqlParameter("@kupac", p.Kupac));
                cmd.Parameters.Add(new SqlParameter("@brojRacuna", p.BrojRacuna));
                cmd.Parameters.Add(new SqlParameter("@datumProdaje", p.DatumProdaje));
                cmd.Parameters.Add(new SqlParameter("@namestajId", p.Namestaj.Id));
                cmd.Parameters.Add(new SqlParameter("@dodatnaUslugaId", p.DodatnaUsluga.Id));
                cmd.Parameters.Add(new SqlParameter("@ukupnaCena", p.UkupnaCena));
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

        public static void Update(Prodaja p)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update prodaja set kupac=@kupac, brojRacuna=@brojRacuna, datumProdaje=@datumProdaje, namestajId=@namestajId, dodatnaUslugaId=@dodatnaUslugaId, ukupnaCena=@ukupnaCena where Id=@id";

                cmd.Parameters.Add(new SqlParameter("@id", p.Id));
                cmd.Parameters.Add(new SqlParameter("@kupac", p.Kupac));
                cmd.Parameters.Add(new SqlParameter("@brojRacuna", p.BrojRacuna));
                cmd.Parameters.Add(new SqlParameter("@datumProdaje", p.DatumProdaje));
                cmd.Parameters.Add(new SqlParameter("@namestajId", p.Namestaj.Id));
                cmd.Parameters.Add(new SqlParameter("@dodatnaUslugaId", p.DodatnaUsluga.Id));
                cmd.Parameters.Add(new SqlParameter("@ukupnaCena", p.UkupnaCena));

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


        public static void Delete(Prodaja p)
        {
            using (SqlConnection conn = new SqlConnection(Program.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update prodaja set active = 0 where id=@Id";


                cmd.Parameters.Add(new SqlParameter("@id", p.Id));

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

