using System.IO;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System;

namespace EasyPlants
{
    class ParametrageBase
    {
        public static string connectionString, serverName, nomUtilisateur, motDePasse, connectionMode, cheminDataBase;
        public static void ParametrerBase()
        {
            string cheminFichier = System.IO.Directory.GetCurrentDirectory() + (@"\Easy.Par");
            string line;
            int counter = 1;
            // Read the file and display it line by line.  
            var fs = new FileStream(cheminFichier, FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs, Encoding.UTF8);
            while ((line = sr.ReadLine()) != null)
            {
                if (counter == 1)
                {
                    serverName = line.ToString().Trim();
                }
                if (counter == 2)
                {
                    cheminDataBase = line.ToString().Trim() + (@"\Base\");
                }
                if (counter == 3)
                {
                    connectionMode = line.ToString().Trim();
                }
                counter++;
            }
            nomUtilisateur = "";
            motDePasse = "";
            fs.Close();
        }

        public static string AttachDatabase(string nomBaseDonnees)
        {
            string result = "OK";
            string cnxString = "Data Source=" + serverName + " ;Initial Catalog=master ;Integrated Security=True";
            SqlConnection con = new SqlConnection(cnxString);
            string filename1 = cheminDataBase + nomBaseDonnees + ".mdf";
            string filename2 = cheminDataBase + nomBaseDonnees + "_log.ldf";
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select name from sys.databases", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string[] array = dt
                    .AsEnumerable()
                    .Select(row => row.Field<string>("Name"))
                    .ToArray();
                if (!array.Contains(nomBaseDonnees, StringComparer.OrdinalIgnoreCase))
                {
                    SqlCommand cmd = new SqlCommand("sp_attach_db");
                    { 
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    }
                    cmd.Parameters.AddWithValue("@dbname", nomBaseDonnees);
                    cmd.Parameters.AddWithValue("@filename1", filename1);
                    cmd.Parameters.AddWithValue("@filename2", filename2);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                con.Close();
                result = ex.Message;
                //MessageBox.Show(result);
            }
            return result;
        }

        public static void IsDataBaseExist(string nomBaseDonnees)
        {
            bool result = false;
            try
            {
                string MyConnectionString = "Data Source=" + serverName + " ;Initial Catalog=master ;Integrated Security=True";

                SqlConnection connex = new SqlConnection(MyConnectionString);

                string sqlCheck = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", nomBaseDonnees);
                using (connex)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCheck, connex))
                    {
                        connex.Open();
                        int databaseID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                        connex.Close();
                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }

            if (result)
            {
                Connect(nomBaseDonnees);
            }
            else
            {
                AttachDatabase(nomBaseDonnees);
            }
        }

        public static string Connect(string nomBaseDonnees)
        {
            connectionString = "Data Source=" + serverName + " ;Initial Catalog=" + nomBaseDonnees + " ;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
            }
            return connectionString;
        }
    }
}
