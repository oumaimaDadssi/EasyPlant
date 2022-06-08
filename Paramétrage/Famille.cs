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
    public partial class Famille : Form
    {
        int TypeAct;
        String Qry;

        public Famille()
        {
            InitializeComponent();
        }
        private void Famille_Load(object sender, EventArgs e)
        {
            RemplirGrid(); MyPub.RemplirCbo("Rayon", CbRayon);
            this.GridFam.KeyDown += new KeyEventHandler(GridFam_KeyDown);
            GridFam.DoubleClick += new EventHandler(GridFam_DoubleClick);
        }
        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            GridFam.Enabled = false;
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
            if (TxCode.Text != string.Empty && TxLibelle.Text != string.Empty && CbRayon.Text != string.Empty)
            {
                SaveData();
            }
            GridFam.Enabled = true;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Save(this);
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            TypeAct = 0;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Undo(this);
            GridFam.Enabled = true;
        }
        private void GridFam_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
            {
                if (GridFam.CurrentRow.Index < 0)
                { return; }
                TxCode.Text = GridFam.Rows[GridFam.CurrentRow.Index].Cells[0].Value.ToString();
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Famille WHERE Code ='" + TxCode.Text.Trim() + "'", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TxLibelle.Text = reader["Libelle"].ToString();
                        string var = reader["CodeRayon"].ToString();
                        int itemIndex = this.CbRayon.FindString(var);
                        CbRayon.SelectedIndex = itemIndex;
                    }
                }
            }
        }
        public void GridFam_KeyDown(object sender, KeyEventArgs e)
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
                string CodeP = CbRayon.Text.Substring(0, CbRayon.Text.IndexOf(":")).Trim();
                string NomP = CbRayon.Text.Substring(CbRayon.Text.IndexOf(":") + 2).Trim();
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM Famille WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    Qry = "INSERT INTO Famille VALUES('" + TxCode.Text + "','" + MyPub.Mystr(TxLibelle.Text) + "','" + CodeP + "','" + NomP + "')";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM Famille WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }
                RemplirGrid();
                //MyPub.RemplirCbo("Rayon", CbRayon);
            }
        }
        private void RemplirGrid()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Code,Libelle,NomRayon FROM Famille ", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.GridFam.MasterTemplate.AutoGenerateColumns = true;
                    this.GridFam.TableElement.BeginUpdate();
                    this.GridFam.MasterTemplate.LoadFrom(reader);
                    this.GridFam.MasterTemplate.Columns[0].Width = 100;
                    this.GridFam.MasterTemplate.Columns[1].Width = 220;
                    this.GridFam.MasterTemplate.Columns[2].Width = 220;
                    this.GridFam.Columns["Code"].HeaderText = "Code";
                    this.GridFam.Columns["Libelle"].HeaderText = "Libelle Famille";
                    this.GridFam.Columns["NomRayon"].HeaderText = "Nom Rayon";
                    this.GridFam.TableElement.EndUpdate();
                }
                reader.Close();
            }
            //this.GridFam.PrintPreview();
        }
        private void GridFam_DoubleClick(object sender, EventArgs e)
        {
            if (GridFam.MasterView.CurrentRow != null)
            {
                TypeAct = 2;
                MyPub.New(this);
                GridFam.Enabled = false;
                TxCode.Enabled=false;
                TxLibelle.Focus();
            }
        }
    }
}
