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
using Telerik.WinForms.Documents.Model;
using Telerik.WinControls;

namespace EasyPlants.Consignes
{
    public partial class Achat : Form

    {
        int TypeAct, TypeGrid;
        String Qry ;
        //String Type = "Achat Consigne";
        //String Op = "Entré";

        public Achat()
        {
            InitializeComponent();
        }


        private void Achat_Load(object sender, EventArgs e)
        {
            MyPub.RemplirCbo("PointVente", CbPv);
            Grid.Visible = false;
            DataGrid();

        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            GridAchatCons.Enabled = false;
            MyPub.ClearPanel(this.Panel1);
            MyPub.New(this);
            Panel1.Enabled = true; Panel2.Enabled = true;
            TxTotttc.Enabled = false; TxTotht1.Enabled = false; TxPuttc.Enabled = false;

            Txnumero.Text = MyPub.DeterminerNum("AchatConsigne");
            Txnumero.Enabled = false;
            Txnumero.Focus();
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            TypeAct = 2;
            if (Txnumero.Text != string.Empty)
            {
                SaveData();
                MyPub.Histo("Mise à jour Liste Achat consignes");
            

            }
            GridAchatCons.Enabled = true;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Save(this);
        }

        private void DataGrid()
        {
            GridAchatCons.ColumnCount = 11;
            GridAchatCons.Columns[0].HeaderText = "Numero";
            GridAchatCons.Columns[1].HeaderText = "Désignation";
            GridAchatCons.Columns[2].HeaderText = "PU Ht";
            GridAchatCons.Columns[3].HeaderText = "PU TCC";
            GridAchatCons.Columns[4].HeaderText = "TVA";
            GridAchatCons.Columns[5].HeaderText = "M.TVA";
            GridAchatCons.Columns[6].HeaderText = "QTe";
            GridAchatCons.Columns[7].HeaderText = "Remise";
            GridAchatCons.Columns[8].HeaderText = "Mnt Remise";
            GridAchatCons.Columns[9].HeaderText = "Total Ht";
            GridAchatCons.Columns[10].HeaderText = "Total TTc";

            GridAchatCons.MasterTemplate.Columns[0].Width = 80;
            GridAchatCons.MasterTemplate.Columns[1].Width = 100;
            GridAchatCons.MasterTemplate.Columns[2].Width = 80;
            GridAchatCons.MasterTemplate.Columns[3].Width = 80;
            GridAchatCons.MasterTemplate.Columns[4].Width = 80;
            GridAchatCons.MasterTemplate.Columns[5].Width = 80;
            GridAchatCons.MasterTemplate.Columns[6].Width = 80;
            GridAchatCons.MasterTemplate.Columns[7].Width = 80;
            GridAchatCons.MasterTemplate.Columns[8].Width = 80;
            GridAchatCons.MasterTemplate.Columns[9].Width = 80;
            GridAchatCons.MasterTemplate.Columns[10].Width = 80;
        }

        private void RemplirGrid()
        {
            GridAchatCons.Rows.Add(
              Txnumero.Text,
              TxDesignation.Text,
              TxPuht.Text,
               TxPuttc.Text,
              TxTVA.Text,
              (decimal.Parse(TxTVA.Text) * decimal.Parse(TxPuht.Text)/ 100),
              TxQte.Text,
              TxRemise.Text,
              (decimal.Parse(TxRemise.Text) * decimal.Parse(TxPuht.Text) / 100),
              TxTotht1.Text,
              TxTotttc.Text
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
                string CodePv = CbPv.Text.Substring(0, CbPv.Text.IndexOf(":")).Trim();
                string NomPv = CbPv.Text.Substring(CbPv.Text.IndexOf(":") + 2).Trim();
         
                string datefactCnsigne = dateFacCon.Text.ToString().Trim().Substring(0, 4) + "-" + dateFacCon.Text.ToString().Trim().Substring(8, 2) + "-" + dateFacCon.Text.ToString().Trim().Substring(5, 2);
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM AchatConsigne WHERE Numero = '" + Txnumero.Text.Trim() + "' ";
            
                    SqlCommand cmd = new SqlCommand(Qry, cn);
              
                    cmd.ExecuteNonQuery();
    
                    Qry = "INSERT INTO AchatConsigne VALUES('" + Txnumero.Text + "','" + TxCodeF.Text + "','" + TxFourniseur.Text + "','" + CodePv + "','" + NomPv + "','" + datefactCnsigne + "' ,'" + Convert.ToDecimal(TxTotHt.Text) + "','" + Convert.ToDecimal(TxTotTva.Text) + "','" + Convert.ToDecimal(TxTotRemise.Text) +
            "','" + Convert.ToDecimal(TxTotNetHt.Text) + "','" + Convert.ToDecimal(TxTimbre.Text) + "','" + Convert.ToDecimal(TxTotNetTtc.Text) + "','" + TxRef.Text + "','" + TxNote.Text + "')";
                   
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
              

                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM AchatConsigne WHERE Numero = '" + Txnumero.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                 
                }
               
            }


        }

        private void TxQte_TextChanged(object sender, EventArgs e)
        {
            if (TxQte.Text.Length > 0 && TxPuht.Text.Length > 0)
            {
                TxTotht1.Text = Convert.ToString(Convert.ToInt32(TxQte.Text) * Convert.ToDecimal(TxPuht.Text));
            }
        }

        private void TxPuht_TextChanged(object sender, EventArgs e)
        {
            if (TxQte.Text.Length > 0 && TxPuht.Text.Length > 0)
            {
                TxTotht1.Text = Convert.ToString(Convert.ToInt32(TxQte.Text) * Convert.ToDecimal(TxPuht.Text));
            }
        }

        private void TxTVA_TextChanged(object sender, EventArgs e)
        {
            if (TxPuht.Text.Length > 0 && TxTVA.Text.Length > 0 && TxQte.Text.Length > 0 && TxRemise.Text.Length> 0 )
            {

                decimal TVA = (Convert.ToDecimal(TxTVA.Text) * Convert.ToDecimal(TxPuht.Text)) / 100;
                TxPuttc.Text = Convert.ToString(Convert.ToDecimal(TxPuht.Text)) + TVA;
                decimal remise = (Convert.ToDecimal(TxRemise.Text) * Convert.ToDecimal(TxPuht.Text)) / 100;
                decimal tottc = Convert.ToInt32(TxQte.Text) * Convert.ToDecimal(TxPuttc.Text);
                TxTotttc.Text = Convert.ToString(tottc - remise);

            }
        }

   

        private void TxFourniseur_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 2;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("Fournisseur", this.Grid);
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Grid.Visible = false; TxCodeF.Focus();
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
                TxCodeArticle.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
                TxDesignation.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();
              
            }
            else
            {
                TxCodeF.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
                TxFourniseur.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();
                TxQte.Focus();
            }
            Grid.Visible = false;
        }

        private void TxCodeArticle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 1;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("SupportPlants", this.Grid);
            }
        }

        private void TxDesignation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 1;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("SupportPlants", this.Grid);
            }
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if (Grid.MasterView.CurrentRow != null)
            {
                FillText();
            }
        }

        private void TxRemise_TextChanged(object sender, EventArgs e)
        {
            if (TxPuht.Text.Length > 0 && TxTVA.Text.Length > 0 && TxQte.Text.Length > 0 && TxRemise.Text.Length > 0)
            {

                decimal TVA = (Convert.ToDecimal(TxTVA.Text) * Convert.ToDecimal(TxPuht.Text)) / 100;
                TxPuttc.Text = Convert.ToString(Convert.ToDecimal(TxPuht.Text)) + TVA;
                decimal remise = (Convert.ToDecimal(TxRemise.Text) * Convert.ToDecimal(TxPuht.Text)) / 100;
                TxTotttc.Text = Convert.ToString(Convert.ToInt32(TxQte.Text) * Convert.ToDecimal(TxPuttc.Text) - remise);

            }
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            RemplirGrid();
            GridAchatCons.Enabled = true;
            BtnNouveau.Enabled = true;
            MyPub.ClearPanel(this.Panel2);
        }

        private void BtnCalcul_Click(object sender, EventArgs e)
        {

            decimal HT = GridAchatCons.Rows.Sum(t => Convert.ToDecimal(t.Cells[2].Value));
            TxTotHt.Text = HT.ToString();

            decimal MntReemise = GridAchatCons.Rows.Sum(t => Convert.ToDecimal(t.Cells[8].Value));
            TxTotRemise.Text = MntReemise.ToString();

            decimal TotNetHT = GridAchatCons.Rows.Sum(t => Convert.ToDecimal(t.Cells[9].Value));
            TxTotNetHt.Text =TotNetHT.ToString();

            decimal TotTVA = GridAchatCons.Rows.Sum(t => Convert.ToDecimal(t.Cells[4].Value));
            TxTotTva.Text = TotTVA.ToString();

            decimal TotNetTTC = GridAchatCons.Rows.Sum(t => Convert.ToDecimal(t.Cells[10].Value)) + Convert.ToDecimal(TxTimbre.Text);
            
            TxTotNetTtc.Text = TotNetTTC.ToString();
        }

        private void GridAchatCons_KeyDown(object sender, KeyEventArgs e)
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

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            TypeAct = 0;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Undo(this);
            GridAchatCons.Enabled = true;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxCodeF_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txnumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxFourniseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxCodeF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 2;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("Fournisseur", this.Grid);
            }
        }

 
    }
}


