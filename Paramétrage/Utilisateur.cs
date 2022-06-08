using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Telerik.WinControls;

namespace EasyPlants
{
    public partial class Utilisateur : Form
    {
        int TypeAct;
        String Qry;

        public Utilisateur()
        {
            InitializeComponent();
        }
        private void Utilisateur_Load(object sender, EventArgs e)
        {
            RemplirGrid(); MyPub.RemplirCbo("Profil", CbProfil);
            this.GridvUser.KeyDown += new KeyEventHandler(GridvUser_KeyDown);
            GridvUser.DoubleClick += new EventHandler(GridvUser_DoubleClick);
        }
        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            GridvUser.Enabled = false;
            MyPub.ClearPanel(this.Panel1);
            MyPub.New(this);
            TxCode.Enabled = true;
            TxCode.Focus();
        }
        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            TypeAct = 2;
            if (TxCode.Text != string.Empty && TxNom.Text != string.Empty && CbProfil.Text != string.Empty)
            {SaveData();}
            GridvUser.Enabled = true;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Save(this);
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            TypeAct = 0;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Undo(this);
            GridvUser.Enabled = true;
        }
        private void GridvUser_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
            {
                if (GridvUser.CurrentRow.Index < 0)
                {return;}
                TxCode.Text = GridvUser.Rows[GridvUser.CurrentRow.Index].Cells[0].Value.ToString();
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilisateur WHERE Code ='" + TxCode.Text.Trim() + "'", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    { 
                        TxPassWord.Text = reader["Pwd"].ToString();
                        TxNom.Text = reader["Nom"].ToString();
                        ChkDesactive.Checked= Convert.ToBoolean(reader["Desactive"]);
                        string var = reader["CodeProfil"].ToString();
                        int itemIndex = this.CbProfil.FindString(var);
                        CbProfil.SelectedIndex = itemIndex;
                    }
                }
            }
        }
        public void GridvUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult ds = RadMessageBox.Show(this, "Supprimer Cet Enregistrement ?", "Easy Plants", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                String Reponse = ds.ToString();
                if (Reponse == "Yes")
                {
                    TypeAct = 3;
                    SaveData();
                }
            }
        }
        private void SaveData()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                string CodeP = CbProfil.Text.Substring(0, CbProfil.Text.IndexOf(":")).Trim();
                string NomP = CbProfil.Text.Substring(CbProfil.Text.IndexOf(":") + 2).Trim();
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM Utilisateur WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    Qry = "INSERT INTO Utilisateur VALUES('" + TxCode.Text + "','" + TxPassWord.Text + "','" + MyPub.Mystr(TxNom.Text) + "','" + CodeP + "','" + NomP + "','" + ChkDesactive.Checked +"')";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM Utilisateur WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }
                RemplirGrid();
            }

        }
        private void RemplirGrid()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Code,Pwd,Nom,NomProfil,Desactive FROM Utilisateur ", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.GridvUser.MasterTemplate.AutoGenerateColumns = true;
                    this.GridvUser.TableElement.BeginUpdate();
                    this.GridvUser.MasterTemplate.LoadFrom(reader);
                    this.GridvUser.MasterTemplate.Columns[0].Width = 80;
                    this.GridvUser.MasterTemplate.Columns[1].Width = 170;
                    this.GridvUser.MasterTemplate.Columns[2].Width = 100;
                    this.GridvUser.MasterTemplate.Columns[3].Width = 170;
                    this.GridvUser.MasterTemplate.Columns[4].Width = 80;
                    this.GridvUser.Columns["Code"].HeaderText = "Code";
                    this.GridvUser.Columns["Nom"].HeaderText = "Nom Compte";
                    this.GridvUser.Columns["Pwd"].HeaderText = "Mot de Passe";
                    this.GridvUser.Columns["NomProfil"].HeaderText = "Nom Profil";
                    this.GridvUser.Columns["Desactive"].HeaderText = "Desactive";
                    this.GridvUser.TableElement.EndUpdate();
                }
                reader.Close();
            }
            //this.GridvUser.PrintPreview();
        }
        private void GridvUser_DoubleClick(object sender, EventArgs e)
        {
            if (GridvUser.MasterView.CurrentRow != null)
            {
                TypeAct = 2;
                MyPub.New(this);
                GridvUser.Enabled = false;
                TxCode.Enabled = false;
                TxNom.Focus();
            }
        }
    }

}
