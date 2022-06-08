using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;
using Telerik.WinControls;

namespace EasyPlants.Paramétrage
{
    public partial class Coordonnees : Form
    {
        String Qry;
        public Coordonnees()
        {
            InitializeComponent();
        }

        private void Coordonnees_Load(object sender, EventArgs e)
        {
            RemplirPanel();
        }

        private void RemplirPanel()
        {
            using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Preference", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TxNom.Text = reader["Societe"].ToString();
                        TxAdresse.Text = reader["Adresse"].ToString();
                        TxVille.Text = reader["Ville"].ToString();
                        TxCp.Text = reader["CodeP"].ToString();
                        TxTel.Text = reader["Tel"].ToString();
                        TxFax.Text = reader["Fax"].ToString();
                        TxGsm.Text = reader["Gsm"].ToString();
                        TxSiteWeb.Text = reader["SiteWeb"].ToString();
                        TxEmail.Text = reader["Email"].ToString();
                        TxMatFiscal.Text = reader["CodeTva"].ToString();
                        TxRc.Text = reader["Rc"].ToString();
                        TxCodeDouane.Text = reader["CodeDouane"].ToString();
                        TxBanque.Text = reader["Banque"].ToString();
                        TxRib.Text = reader["RIB"].ToString();
                        TxResponsable.Text = reader["Responsable"].ToString();
                        TxFonction.Text = reader["Titre"].ToString();
                        TxActivite.Text = reader["Activite"].ToString();
                        ChkPreImp.Checked = Convert.ToBoolean(reader["PreImprime"]);
                        ChkEntete.Checked = Convert.ToBoolean(reader["ImprimerEntete"]);
                        TxMpass1.Text= reader["Mpass"].ToString();
                        TxMpass2.Text = reader["Mpass"].ToString();
                    }
                }
            }
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void SaveData()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                Qry = "TRUNCATE TABLE Preference";
                SqlCommand cmd = new SqlCommand(Qry, cn);
                cmd.ExecuteNonQuery();

                Qry = "INSERT INTO Preference VALUES('" + MyPub.Mystr(TxNom.Text) + "','" + MyPub.Mystr(TxAdresse.Text) + "','" + MyPub.Mystr(TxVille.Text) + "','" + TxTel.Text + "','" + TxFax.Text + "','" + TxGsm.Text + "'" +
                      ",'" + TxMatFiscal.Text + "','" + TxRc.Text + "','" + TxCodeDouane.Text + "','" + TxEmail.Text + "','" + TxSiteWeb.Text + "','" + ChkEntete.Checked + "','" + TxCp.Text + "','" + TxActivite.Text + "','" + TxRib.Text + "'" +
                      ",'" + TxResponsable.Text + "','" + TxFonction.Text + "','" + ChkPreImp.Checked + "','" + TxMpass1.Text + "','" + TxBanque.Text + "')";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
            }
        }
    }
}
