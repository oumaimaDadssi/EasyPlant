using System.IO;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace EasyPlants
{
    public partial class Login : Form
    {
        public static string vCodeUser;
        public static string vNomUser;

        public Login()
        {
            InitializeComponent();
        }
   
        private void RdbAnnuler_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RdbLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CbDataBase.Text) | string.IsNullOrEmpty(TxServerName.Text))
            {
                MessageBox.Show("Vérifiez Base de Données ou Nom du Serveur ! ", "Easy Plants");
            }
            else
            {
                ParametrageBase.IsDataBaseExist(CbDataBase.Text);
                if (string.IsNullOrEmpty(TxUser.Text))
                {
                    MessageBox.Show("Vérifier Code Utilisateur ! ", "Easy Plants");
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Utilisateur WHERE Code ='" + TxUser.Text + "' AND Pwd = '" + TxPassWord.Text + "'", connection);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            this.Hide();
                            Main f2 = new Main();
                            f2.Show();
                            reader.Close();
                        }
                        else
                        {
                            MessageBox.Show("Code ou Mot de Passe Inexistant ", "Easy Plants");
                        }
                        reader.Close();
                    }
                }
        }

    }

        private void Login_Load(object sender, EventArgs e)
        {
            ParametrageBase.ParametrerBase();
            TxServerName.Text = ParametrageBase.serverName;
            DirectoryInfo fileListing = new DirectoryInfo(ParametrageBase.cheminDataBase);
            foreach (FileInfo file in fileListing.GetFiles("*.MDF"))
            {
                string strPath = file.Name;
                string filename;
                filename = Path.GetFileNameWithoutExtension(strPath);
                CbDataBase.Items.Add(filename);
                CbDataBase.SelectedIndex = 1;
                TxUser.Text = "99";
                //TxPassWord.Text = "99";
            }
            if (ParametrageBase.connectionMode == "SQL")
            {
                RdbSql.CheckState = CheckState.Checked;
            }
            else
            {
                RdbWin.CheckState = CheckState.Checked;
            }

        }
    }
}
