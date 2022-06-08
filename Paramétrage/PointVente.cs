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
    public partial class PointVente : Form
    {
        int TypeAct;
        String Qry;

        public PointVente()
        {
            InitializeComponent();
        }
        private void PointVente_Load(object sender, EventArgs e)
        {
            RemplirGrid();
            this.GridPv.KeyDown += new KeyEventHandler(GridPv_KeyDown);
            GridPv.DoubleClick += new EventHandler(GridPv_DoubleClick);
        }
        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            MyPub.ClearPanel(this.Panel1);
            MyPub.New(this);
            GridPv.Enabled = false;
            TxCode.Enabled = true;
            TxCode.Focus();
        }
        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            TypeAct = 2;
            if (TxCode.Text != string.Empty && TxLibelle.Text != string.Empty)
            {
                SaveData();
            }
            MyPub.ClearPanel(this.Panel1);
            MyPub.Save(this);
            GridPv.Enabled = true;
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            TypeAct = 0;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Undo(this);
            GridPv.Enabled = true;
        }
        private void GridPv_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
            {
                if (GridPv.CurrentRow.Index < 0)
                {
                    return;
                }
                TxCode.Text = GridPv.Rows[GridPv.CurrentRow.Index].Cells[0].Value.ToString();
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM PointVente WHERE Code ='" + TxCode.Text.Trim() + "'", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TxLibelle.Text = reader["Libelle"].ToString();
                        TxAdresse.Text = reader["Adresse"].ToString();
                        TxVille.Text = reader["Ville"].ToString(); ;
                    }
                }
            }
        }
        public void GridPv_KeyDown(object sender, KeyEventArgs e)
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
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM PointVente WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    Qry = "INSERT INTO PointVente VALUES('" + TxCode.Text + "','" + MyPub.Mystr(TxLibelle.Text) + "','" + MyPub.Mystr(TxAdresse.Text) + "','" + MyPub.Mystr(TxVille.Text) + "')";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM PointVente WHERE Code = '" + TxCode.Text.Trim() + "' ";
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
                SqlCommand cmd = new SqlCommand("SELECT Code,Libelle,Adresse,Ville FROM PointVente ", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.GridPv.MasterTemplate.AutoGenerateColumns = true;
                    this.GridPv.TableElement.BeginUpdate();
                    this.GridPv.MasterTemplate.LoadFrom(reader);
                    this.GridPv.MasterTemplate.Columns[0].Width = 70;
                    this.GridPv.MasterTemplate.Columns[1].Width = 150;
                    this.GridPv.MasterTemplate.Columns[2].Width = 180;
                    this.GridPv.MasterTemplate.Columns[3].Width = 160;
                    this.GridPv.Columns["Code"].HeaderText = "Code";
                    this.GridPv.Columns["Libelle"].HeaderText = "Libelle";
                    this.GridPv.Columns["Adresse"].HeaderText = "Adresse";
                    this.GridPv.Columns["Ville"].HeaderText = "Ville";
                    this.GridPv.TableElement.EndUpdate();
                }
                reader.Close();
            }
            //this.GridPv.PrintPreview();
        }
        private void GridPv_DoubleClick(object sender, EventArgs e)
        {
            if (GridPv.MasterView.CurrentRow != null)
            {
                TypeAct = 2;
                MyPub.New(this);
                GridPv.Enabled = false;
                TxCode.Enabled = false;
                TxLibelle.Focus();
            }
        }
    }

}
