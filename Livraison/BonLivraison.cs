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

namespace EasyPlants.Livraison
{
    public partial class BonLivraison : Form
    {
        int TypeAct;
        int TypeGrid;
        String Qry;
        public BonLivraison()
        {
            InitializeComponent();
        }

        private void BonLivraison_Load(object sender, EventArgs e)
        {
            MyPub.RemplirCbo("PointVente", CbPv);
            MyPub.RemplirCbo("Livreur", CbLIV);
            DataGrid();
            Grid.Visible = false;
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            MyPub.ClearPanel(this.Panel1);
            MyPub.New(this); 
            TxTotttc.Enabled = false; TxTotht1.Enabled = false; TxPuttc.Enabled = false;
            Panel1.Enabled = true; Panel2.Enabled = true;
            Txnumero.Text = MyPub.DeterminerNum("Bliv"); 
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
            }
            GridBL.Enabled = true;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Save(this);
            RemplirGrid();

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

        private void TxCodeV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 1;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("ArticleVariete", this.Grid);
            }
        }

        private void TxLibelleV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 1;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("Bliv", this.Grid);
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                Grid.Visible = false; Txnumero.Focus();
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
                TxCodeV.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
                TxLibelleV.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();
              
            }
            else if (TypeGrid == 2)
            {
               TxCodeF.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
               TxFourniseur.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();
                TxQte.Focus();
            }
            else
            {
                TxCodeC.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
                TxNomC.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();
                TxQte.Focus();
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

        private void SaveData()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                string CodePv = CbPv.Text.Substring(0, CbPv.Text.IndexOf(":")).Trim();
                string NomPv = CbPv.Text.Substring(CbPv.Text.IndexOf(":") + 2).Trim();
                string Codel = CbLIV.Text.Substring(0, CbLIV.Text.IndexOf(":")).Trim();
                string Noml = CbLIV.Text.Substring(CbLIV.Text.IndexOf(":") + 2).Trim();

                string c = dateBL.Text.ToString().Trim().Substring(0, 4) + "-" + dateBL.Text.ToString().Trim().Substring(8, 2) + "-" + dateBL.Text.ToString().Trim().Substring(5, 2);
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM Bliv WHERE Numero = '" + Txnumero.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    Qry = "INSERT INTO Blivf VALUES('" + Txnumero.Text + "','" + TxCodeC.Text + "','" + TxNomC.Text + "','" + TxCodeF.Text + "','" + TxFourniseur.Text + "','"+ NomPv + "','" + c + "' ," + Convert.ToDecimal(TxTotHt.Text) + "," + Convert.ToDecimal(TxTotRemise.Text) + "," + Convert.ToDecimal(TxTotTva.Text) +
            "," + Convert.ToDecimal(TxTimbre.Text)  + "," + Convert.ToDecimal(TxTotNetHt.Text) + "," + Convert.ToDecimal(TxAccompte.Text) + "," + Convert.ToDecimal(TxPayer.Text) +",'"+ Noml + "')";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM Bliv WHERE Numero = '" + Txnumero.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }
     
            }
        }
    

        private void BtnList_Click(object sender, EventArgs e)
        {

            TypeGrid = 1;
            Grid.BringToFront();
            Grid.Visible = true;
            MyPub.RemplirGrid("Client", this.Grid);
        }



        private void DataGrid()
        {
            GridBL.ColumnCount = 11;
            GridBL.Columns[0].HeaderText = "Numero";
            GridBL.Columns[1].HeaderText = "Désignation";
            GridBL.Columns[2].HeaderText = "PU Ht";
            GridBL.Columns[3].HeaderText = "PU TCC";
            GridBL.Columns[4].HeaderText = "TVA";
            GridBL.Columns[5].HeaderText = "M.TVA";
            GridBL.Columns[6].HeaderText = "QTe";
            GridBL.Columns[7].HeaderText = "Remise";
            GridBL.Columns[8].HeaderText = "Mnt Remise";
            GridBL.Columns[9].HeaderText = "Total Ht";
            GridBL.Columns[10].HeaderText = "Total TTc";

            GridBL.MasterTemplate.Columns[0].Width = 80;
            GridBL.MasterTemplate.Columns[1].Width = 100;
            GridBL.MasterTemplate.Columns[2].Width = 80;
            GridBL.MasterTemplate.Columns[3].Width = 80;
            GridBL.MasterTemplate.Columns[4].Width = 80;
            GridBL.MasterTemplate.Columns[5].Width = 80;
            GridBL.MasterTemplate.Columns[6].Width = 80;
            GridBL.MasterTemplate.Columns[7].Width = 80;
            GridBL.MasterTemplate.Columns[8].Width = 80;
            GridBL.MasterTemplate.Columns[9].Width = 80;
            GridBL.MasterTemplate.Columns[10].Width = 80;
        }
        private void RemplirGrid()
        {
            GridBL.Rows.Add(
                Txnumero.Text,
                TxLibelleV.Text,
                TxPuht.Text,
                TxPuttc.Text,
                TxTVA.Text,
                (decimal.Parse(TxTVA.Text) * decimal.Parse(TxPuht.Text) / 100),
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

        private void btnlis_Click(object sender, EventArgs e)
        {
            TypeGrid = 3;
            Grid.BringToFront();
            Grid.Visible = true;
            MyPub.RemplirGrid("Client", this.Grid);
        }

        private void BtnCalcul_Click(object sender, EventArgs e)
        {
            decimal HT = GridBL.Rows.Sum(t => Convert.ToDecimal(t.Cells[2].Value));
            TxTotHt.Text = HT.ToString();

            decimal MntReemise = GridBL.Rows.Sum(t => Convert.ToDecimal(t.Cells[8].Value));
            TxTotRemise.Text = MntReemise.ToString();

            decimal TotNetHT = GridBL.Rows.Sum(t => Convert.ToDecimal(t.Cells[9].Value));
            TxTotNetHt.Text = TotNetHT.ToString();

            decimal TotTVA = GridBL.Rows.Sum(t => Convert.ToDecimal(t.Cells[4].Value));
            TxTotTva.Text = TotTVA.ToString();

            decimal TotNetTTC = GridBL.Rows.Sum(t => Convert.ToDecimal(t.Cells[10].Value)) + Convert.ToDecimal(TxTimbre.Text);

            TxTotNetTtc.Text = TotNetTTC.ToString();

            TxPayer.Text = Convert.ToString(Convert.ToDecimal(TxTotNetTtc.Text) - Convert.ToDecimal(TxAccompte.Text));
        }

        private void Remise_TextChanged(object sender, EventArgs e)
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
            if (TxPuht.Text.Length > 0 && TxTVA.Text.Length > 0 && TxQte.Text.Length > 0 && TxRemise.Text.Length > 0)
            {

                decimal TVA = (Convert.ToDecimal(TxTVA.Text) * Convert.ToDecimal(TxPuht.Text)) / 100;
                TxPuttc.Text = Convert.ToString(Convert.ToDecimal(TxPuht.Text)) + TVA;
                decimal remise = (Convert.ToDecimal(TxRemise.Text) * Convert.ToDecimal(TxPuht.Text)) / 100;
                decimal tottc = Convert.ToInt32(TxQte.Text) * Convert.ToDecimal(TxPuttc.Text);
                TxTotttc.Text = Convert.ToString(tottc - remise);

            }
        }

        private void TxRemise_TextChanged(object sender, EventArgs e)
        {
            if (TxPuht.Text.Length > 0 && TxTVA.Text.Length > 0 && TxQte.Text.Length > 0 && TxRemise.Text.Length > 0)
            {

                decimal TVA = (Convert.ToDecimal(TxTVA.Text) * Convert.ToDecimal(TxPuht.Text)) / 100;
                TxPuttc.Text = Convert.ToString(Convert.ToDecimal(TxPuht.Text)) + TVA;
                decimal remise = (Convert.ToDecimal(TxRemise.Text) * Convert.ToDecimal(TxPuht.Text)) / 100;
                decimal tottc = Convert.ToInt32(TxQte.Text) * Convert.ToDecimal(TxPuttc.Text);
                TxTotttc.Text = Convert.ToString(tottc - remise);

            }
        }
    }
    }

