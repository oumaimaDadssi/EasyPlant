using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Telerik.WinControls;

namespace EasyPlants.Stock
{
    public partial class AjoutArticle : Form
    {
        int TypeAct;
        String Qry;
        int TypeGrid;
        public AjoutArticle()
        {
            InitializeComponent();
        }

        private void AjoutArticle_Load(object sender, EventArgs e)
        {
            MyPub.RemplirCbo("Colisage", CbUachat);
            MyPub.RemplirCbo("Colisage", CbUvente);
            MyPub.RemplirCbo("TypeProduit", CbType);
            Grid.Visible = false;
            DataGrid();
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            GridAjoutArticle.Enabled = false;
            MyPub.ClearPanel(this.Panel1);
            MyPub.New(this);
            TxCode.Text = MyPub.DeterminerNum("Article");
            TxCode.Enabled = true; TxCode.Focus();
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            TypeAct = 2;
            if (TxCode.Text != string.Empty  && TxLibelle.Text != string.Empty && TxCodeFamille.Text != string.Empty
                && TxFamille.Text != string.Empty && TxCodeFournisseur.Text != string.Empty && TxFournisseur.Text != string.Empty && TxPAHT.Text != string.Empty
                && TxTVA.Text != string.Empty && TxPATTC.Text != string.Empty && TxFodec.Text != string.Empty && TxCoef.Text != string.Empty)
            {
                SaveData();
                MyPub.Histo("Mise à jour liste des articles");
            }
            GridAjoutArticle.Enabled = true;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Save(this);
          
        }

        private void DataGrid()
        {
            GridAjoutArticle.ColumnCount = 8;
            GridAjoutArticle.Columns[0].HeaderText = "Code";
            GridAjoutArticle.Columns[1].HeaderText = "Désignation";
            GridAjoutArticle.Columns[2].HeaderText = "PU Ht";
            GridAjoutArticle.Columns[3].HeaderText = "PU TCC";
            GridAjoutArticle.Columns[4].HeaderText = "TVA";
            GridAjoutArticle.Columns[5].HeaderText = "Famille";
            GridAjoutArticle.Columns[6].HeaderText = "Fournisseur";
            GridAjoutArticle.Columns[7].HeaderText = "Type Article";


            GridAjoutArticle.MasterTemplate.Columns[0].Width = 130;
            GridAjoutArticle.MasterTemplate.Columns[1].Width = 150;
            GridAjoutArticle.MasterTemplate.Columns[2].Width = 130;
            GridAjoutArticle.MasterTemplate.Columns[3].Width = 130;
            GridAjoutArticle.MasterTemplate.Columns[4].Width = 120;
            GridAjoutArticle.MasterTemplate.Columns[5].Width = 120;
            GridAjoutArticle.MasterTemplate.Columns[6].Width = 120;
            GridAjoutArticle.MasterTemplate.Columns[7].Width = 120;

        }
        private void RemplirGrid()
        {
            GridAjoutArticle.Rows.Add(
               TxCode.Text,
               TxLibelle.Text,
               TxPAHT.Text,
               TxPATTC.Text,
               TxFamille.Text,
               TxFournisseur.Text,
               CbType.Text
                );
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = "";
            }
        }
        private void SaveData()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                string CodeUvente = CbUvente.Text.Substring(0, CbUvente.Text.IndexOf(":")).Trim();
                string NomUvente = CbUvente.Text.Substring(CbUvente.Text.IndexOf(":") + 2).Trim();
                string CodeUachat = CbUachat.Text.Substring(0, CbUachat.Text.IndexOf(":")).Trim();
                string NomUachat = CbUachat.Text.Substring(CbUachat.Text.IndexOf(":") + 2).Trim();
                string CodeTypeArticle = CbType.Text.Substring(0, CbType.Text.IndexOf(":")).Trim();
                string NomTypeArticle = CbType.Text.Substring(CbType.Text.IndexOf(":") + 2).Trim();
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM Article WHERE Numero = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    Qry = "INSERT INTO Article VALUES ('" + TxCode.Text + "','" + TxLibelle.Text + "'," + Convert.ToDecimal(TxPAHT.Text) + "," + Convert.ToDecimal(TxTVA.Text) + ",'" + Convert.ToDecimal(TxFodec.Text) + "'," + Convert.ToDecimal(TxPATTC.Text) + ",'" + NomTypeArticle + "','" + TxFamille.Text + "','" + TxFournisseur.Text +
                        "','" + NomUachat + "','" + NomUvente + "'," + TxCoef.Text + ")";

                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM Article WHERE Numero = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }
                RemplirGrid();
            }

        }

    

        private void GridAjoutArticle_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
            {
                if (GridAjoutArticle.CurrentRow.Index < 0)
                { return; }
                TxCode.Text = GridAjoutArticle.Rows[GridAjoutArticle.CurrentRow.Index].Cells[0].Value.ToString();
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Article WHERE Numero ='" + TxCode.Text.Trim() + "'", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TxCode.Text = reader["Numero"].ToString();
                        TxLibelle.Text = reader["Libelle"].ToString();
                        TxPAHT.Text = reader["PaHt"].ToString();
                        TxPATTC.Text = reader["PaTtc"].ToString();
                        TxTVA.Text = reader["Tva"].ToString();
                        TxFamille.Text = reader["Famille"].ToString();
                        TxFournisseur.Text = reader["Fournisseur"].ToString();
                        string var1 = reader["TypeArticle"].ToString();
                        int itemIndex1 = this.CbType.FindString(var1);
                        CbType.SelectedIndex = itemIndex1;
             
                    }
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {

            TypeAct = 0;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Undo(this);
            GridAjoutArticle.Enabled = true;
        }

        private void GridAjoutArticle_KeyDown(object sender, KeyEventArgs e)
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

        private void GridAjoutArticle_DoubleClick(object sender, EventArgs e)
        {
            if (GridAjoutArticle.MasterView.CurrentRow != null)
            {
                TypeAct = 2;
                MyPub.New(this);
                GridAjoutArticle.Enabled = false;
                TxCode.Enabled = false;
                TxLibelle.Focus();
            }
        }

        private void TxCodeFamille_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 2;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("Famille", this.Grid);
            }
        }

        private void TxFamille_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 2;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("Famille", this.Grid);
            }
        }

        private void TxCodeFournisseur_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 1;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("Fournisseur", this.Grid);
            }
        }

        private void TxFournisseur_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 1;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("Fournisseur", this.Grid);
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Grid.Visible = false; TxCode.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                FillText();
            }
        }
        private void FillText()
        {
            if (TypeGrid == 1)
            {
                TxCodeFournisseur.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
                TxFournisseur.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();
               
            }
            else
            {
                TxCodeFamille.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
                TxFamille.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();
                
            }
            Grid.Visible = false;
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if (Grid.MasterView.CurrentRow != null)
            {
                FillText();
            }
        }

        private void TxPAHT_TextChanged(object sender, EventArgs e)
        {
            if (TxPAHT.Text.Length > 0 && TxTVA.Text.Length > 0)
            {
                decimal TVA = (Convert.ToDecimal(TxTVA.Text) * Convert.ToDecimal(TxPAHT.Text)) / 100;
                TxPATTC.Text = Convert.ToString(Convert.ToDecimal(TxPAHT.Text)) + TVA;
            }
        }

        private void TxTVA_TextChanged(object sender, EventArgs e)
        {
            if (TxPAHT.Text.Length > 0 && TxTVA.Text.Length > 0)
            {
                decimal TVA = (Convert.ToDecimal(TxTVA.Text) * Convert.ToDecimal(TxPAHT.Text)) / 100;
                TxPATTC.Text = Convert.ToString(Convert.ToDecimal(TxPAHT.Text)) + TVA;
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            this.GridAjoutArticle.PrintPreview();
        }

        private void radLabel8_Click(object sender, EventArgs e)
        {

        }

        private void TxCodeFamille_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxFamille_TextChanged(object sender, EventArgs e)
        {

        }

        private void radLabel16_Click(object sender, EventArgs e)
        {

        }

        private void CbUachat_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void radLabel12_Click(object sender, EventArgs e)
        {

        }

        private void TxFodec_TextChanged(object sender, EventArgs e)
        {

        }
    }
}