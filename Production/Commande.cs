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

namespace EasyPlants.Production
{
    public partial class Commande : Form
    {
        int TypeAct;int TypeGrid;
        string Qry;

        public Commande()
        {
            InitializeComponent();
        }
        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            MyPub.ClearPanel(this.dateTimeDGR);
            MyPub.New(this);
            TxPuttc.Enabled = false; TxTotBrut.Enabled = false; TxPuttc.Enabled = false;
            dateTimeDGR.Enabled = true;Panel1.Enabled = true;Panel2.Enabled = true;  //Panel6.Enabled = true;
            Txnumero.Text = MyPub.DeterminerNum("CommandePlants");
          
            Txnumero.Enabled = false;  

            LbCapacite.Text = "Capacité de Production : " + MyPub.GetVar("ParamProduction");
            TxCode.Focus();
            BtnEnregistrerSem.Enabled = true;
            BtnRecSem.Enabled = true;
            BtnResCons.Enabled = true;
            BtnCalcul.Enabled = true;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            TypeAct = 2;
            if (Txnumero.Text != string.Empty )
            {
                SaveData();
            }
            MyPub.ClearPanel(this.dateTimeDGR);
            MyPub.Save(this);
            dateTimeDGR.Enabled = false; Panel2.Enabled = false;  //Panel5.Enabled = false; //Panel6.Enabled = false;
          
     
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            TypeAct = 0;
            MyPub.ClearPanel(this.dateTimeDGR);
            MyPub.Undo(this); 
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {this.Close();}

        private void SaveData()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                string CodeCom = CbCommercial.Text.Substring(0, CbCommercial.Text.IndexOf(":")).Trim();
                string NomCom =  CbCommercial.Text.Substring(CbCommercial.Text.IndexOf(":") + 2).Trim();
                //string Type = RadSem.Text.Substring(RadSem)
                string c = DateCmd.Text.ToString().Trim().Substring(0, 4) + "-" + DateCmd.Text.ToString().Trim().Substring(8, 2) + "-" + DateCmd.Text.ToString().Trim().Substring(5, 2);
                string dateLiv = dateTimeLivPrevu.Text.ToString().Trim().Substring(0, 4) + "-" + dateTimeLivPrevu.Text.ToString().Trim().Substring(8, 2) + "-" + dateTimeLivPrevu.Text.ToString().Trim().Substring(5, 2);
                string dateSv = dateTimeDSV.Text.ToString().Trim().Substring(0, 4) + "-" + dateTimeDSV.Text.ToString().Trim().Substring(8, 2) + "-" + dateTimeDSV.Text.ToString().Trim().Substring(5, 2);
                string datePG = dateTimeDPG.Text.ToString().Trim().Substring(0, 4) + "-" + dateTimeDPG.Text.ToString().Trim().Substring(8, 2) + "-" + dateTimeDPG.Text.ToString().Trim().Substring(5, 2);
                string dateG = dateTimeDGR.Text.ToString().Trim().Substring(0, 4) + "-" + dateTimeDGR.Text.ToString().Trim().Substring(8, 2) + "-" + dateTimeDGR.Text.ToString().Trim().Substring(5, 2);
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM CommandePlants WHERE Numero = '" + Txnumero.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    Qry = "INSERT INTO CommandePlants VALUES('" + Txnumero.Text + "','" + TxCode.Text + "','" + TxLibelle.Text + "','" + NomCom + "','" + CodeCom + "','" + TxNote.Text + "','" + c + "' ," + Convert.ToDecimal(TxTotHt.Text) + "," + Convert.ToDecimal(TxTotRemise.Text) + "," + Convert.ToDecimal(TxTimbre.Text) +
            "," + Convert.ToDecimal(TxTotNetTtc.Text) + "," + Convert.ToDecimal(TxAccompte.Text) + ",'" + dateLiv + "','" + dateSv+ "','" + datePG + "','" + dateG + "' )";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM CommandePlants WHERE Numero = '" + Txnumero.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }

            }
        }



        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if (Grid.MasterView.CurrentRow != null)
            {
                FillText();
            }
        }
        private void FillText()
        {
            if (TypeGrid==1)
            {
                TxCode.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
                TxLibelle.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();
                CbCommercial.Focus();
            }
            else
            {
                TxCodeV.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
                TxLibelleV.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();
                TxQte.Focus();
            }
            Grid.Visible = false;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Grid.Visible = false;TxCode.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                FillText();
            }
        }

        private void Commande_Load(object sender, EventArgs e)
        {
            MyPub.RemplirCbo("Utilisateur", CbCommercial);
            MyPub.RemplirCbo("SupportPlants", CbSupport);
            MyPub.RemplirCbo("TypeProduction", CbType);
        
            DataGrid();
           
        }

        private void TxCodeV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 2;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("ArticleVariete", this.Grid);
                Grid.Focus();
            }
        }

        private void TxLibelleV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypeGrid = 2;
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("ArticleVariete", this.Grid);
                Grid.Focus();
            }
        }

        //private void TxQte_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter && TxQte.ToString() != "0")
        //    {
        //        TxPu.Focus();
        //    }
        //}

        //private void TxPu_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        TxRem.Focus();
        //    }
        //}

        private void TxRem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CbSupport.Focus();
            }
        }

        private void CbSupport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CbType.Focus();
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
                TxTotBrut.Text = Convert.ToString(Convert.ToInt32(TxQte.Text) * Convert.ToDecimal(TxPuht.Text));
            }
        }

        private void TxPuht_TextChanged(object sender, EventArgs e)
        {
            if (TxQte.Text.Length > 0 && TxPuht.Text.Length > 0)
            {
                TxTotBrut.Text = Convert.ToString(Convert.ToInt32(TxQte.Text) * Convert.ToDecimal(TxPuht.Text));
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
                TxTotTTTC.Text = Convert.ToString(tottc - remise);

            }
        }

        private void MntRemise_TextChanged(object sender, EventArgs e)
        {
            if (TxPuht.Text.Length > 0 && TxTVA.Text.Length > 0 && TxQte.Text.Length > 0 && TxRemise.Text.Length > 0 && TxMntRemise.Text.Length>0)
            {

                decimal TVA = (Convert.ToDecimal(TxTVA.Text) * Convert.ToDecimal(TxPuht.Text)) / 100;
                TxPuttc.Text = Convert.ToString(Convert.ToDecimal(TxPuht.Text)) + TVA;
                decimal remise = (Convert.ToDecimal(TxRemise.Text) * Convert.ToDecimal(TxPuht.Text)) / 100;
                decimal tottc = Convert.ToInt32(TxQte.Text) * Convert.ToDecimal(TxPuttc.Text);
                TxTotTTTC.Text = Convert.ToString(tottc - remise);
                TxTotTTTC.Text = Convert.ToString(tottc - (Convert.ToDecimal(TxMntRemise.Text)));


            }

        }

        private void TxDateLiv_ValueChanged(object sender, EventArgs e)
        {
            //Variete selectedVariete = db.Varietes.FirstOrDefault();
            DateTime dateLiv = Convert.ToDateTime(dateTimeLivPrevu.Text);
            DateTime dateCV = Convert.ToDateTime(dateTimeDSV.Text);
            DateTime dateGreffage = dateLiv.AddDays(-20);
            DateTime dateSemiVariete = dateGreffage.AddDays(-10);
            DateTime datePorteGreffe = dateSemiVariete.AddDays(-15);
            dateTimeDGR.Value = dateGreffage.Date;
            dateTimeDSV.Value = dateSemiVariete.Date;
            dateTimeDPG.Value = datePorteGreffe.Date;
        }

        private void dateTimeLivPrevu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //Variete selectedVariete = db.Varietes.FirstOrDefault();
                DateTime dateLiv = Convert.ToDateTime(dateTimeLivPrevu.Text);
                DateTime dateCV = Convert.ToDateTime(dateTimeDSV.Text);
                DateTime dateGreffage = dateLiv.AddDays(-20);
                DateTime dateSemiVariete = dateGreffage.AddDays(-10);
                DateTime datePorteGreffe = dateSemiVariete.AddDays(-15);
                dateTimeDGR.Value = dateGreffage.Date;
                dateTimeDSV.Value = dateSemiVariete.Date;
                dateTimeDPG.Value = datePorteGreffe.Date;
            }
        }
        private void DataGrid()
        {
            GridCde.ColumnCount = 15;
            GridCde.Columns[0].HeaderText = "Numero";
            GridCde.Columns[1].HeaderText = "Nom Variété";
            GridCde.Columns[2].HeaderText = "PU Ht";
            GridCde.Columns[3].HeaderText = "PU TCC";
            GridCde.Columns[4].HeaderText = "TVA";
            GridCde.Columns[5].HeaderText = "M.TVA";
            GridCde.Columns[6].HeaderText = "QTe";
            GridCde.Columns[7].HeaderText = "Remise";
            GridCde.Columns[8].HeaderText = "Mnt Remise";
            GridCde.Columns[9].HeaderText = "Total Ht";
            GridCde.Columns[10].HeaderText = "Total TTc";
            GridCde.Columns[11].HeaderText = "Date Livraison";
            GridCde.Columns[12].HeaderText = "Date SV";
            GridCde.Columns[13].HeaderText = "Date PG";
            GridCde.Columns[14].HeaderText = "Date Greffage";

            GridCde.MasterTemplate.Columns[0].Width = 80;
            GridCde.MasterTemplate.Columns[1].Width = 100;
            GridCde.MasterTemplate.Columns[2].Width = 80;
            GridCde.MasterTemplate.Columns[3].Width = 80;
            GridCde.MasterTemplate.Columns[4].Width = 80;
            GridCde.MasterTemplate.Columns[5].Width = 80;
            GridCde.MasterTemplate.Columns[6].Width = 80;
            GridCde.MasterTemplate.Columns[7].Width = 80;
            GridCde.MasterTemplate.Columns[8].Width = 80;
            GridCde.MasterTemplate.Columns[9].Width = 80;
            GridCde.MasterTemplate.Columns[10].Width = 80;
            GridCde.MasterTemplate.Columns[11].Width = 80;
            GridCde.MasterTemplate.Columns[12].Width = 80;
            GridCde.MasterTemplate.Columns[13].Width = 80;
            GridCde.MasterTemplate.Columns[14].Width = 80;
        }
        private void RemplirGrid()
        {
            GridCde.Rows.Add(
                Txnumero.Text,
                TxLibelleV.Text,
                TxPuht.Text,
                TxPuttc.Text,
                TxTVA.Text,
                (decimal.Parse(TxTVA.Text) * decimal.Parse(TxPuht.Text) / 100),
                TxQte.Text,
                TxRemise.Text,
                (decimal.Parse(TxRemise.Text) * decimal.Parse(TxPuht.Text) / 100),
                 TxTotBrut.Text,
                 TxTotTTTC.Text,
                 dateTimeLivPrevu.Text,
                 dateTimeDSV.Text,
                 dateTimeDPG.Text,
                 dateTimeDGR.Text

                 );
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = "";
            }
        }
   
  

        private void radTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            TypeGrid = 1;
            Grid.BringToFront();
            Grid.Visible = true;
            MyPub.RemplirGrid("Client", this.Grid);
            Grid.Focus();
        }

        private void BtnRecSem_Click(object sender, EventArgs e)
        {
            ReceptionSemence Rec = new ReceptionSemence();
            Rec.Show();
        }

        private void BtnResCons_Click(object sender, EventArgs e)
        {
            RservationConsigne Res = new RservationConsigne();
            Res.Show();
        }

        private void dateTimeDGR_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnImprimerBCde_Click(object sender, EventArgs e)
        {
            this.GridCde.PrintPreview();
        }

        private void BtnCalcul_Click(object sender, EventArgs e)
        {
            decimal HT = GridCde.Rows.Sum(t => Convert.ToDecimal(t.Cells[2].Value));
            TxTotHt.Text = HT.ToString();

            decimal MntReemise = GridCde.Rows.Sum(t => Convert.ToDecimal(t.Cells[8].Value));
            TxTotRemise.Text = MntReemise.ToString();

            decimal TotNetHT = GridCde.Rows.Sum(t => Convert.ToDecimal(t.Cells[9].Value));
            TxTotNetHt.Text = TotNetHT.ToString();

            decimal TotTVA = GridCde.Rows.Sum(t => Convert.ToDecimal(t.Cells[4].Value));
            TxTotTva.Text = TotTVA.ToString();

            decimal TotNetTTC = GridCde.Rows.Sum(t => Convert.ToDecimal(t.Cells[10].Value)) + Convert.ToDecimal(TxTimbre.Text);

            TxTotNetTtc.Text = TotNetTTC.ToString();

            TxPayer.Text = Convert.ToString(Convert.ToDecimal(TxTotNetTtc.Text) - Convert.ToDecimal(TxAccompte.Text));
        }





        //private void dateTimeLivPrevu_ValueChanged(object sender, EventArgs e)
        //{
        //    //Variete selectedVariete = db.Varietes.FirstOrDefault();
        //    DateTime dateLiv = Convert.ToDateTime(dateTimeLivPrevu.Text);
        //    DateTime dateCV = Convert.ToDateTime(dateTimeDSV.Text);
        //    DateTime dateGreffage = dateLiv.AddDays(-20);
        //    DateTime dateSemiVariete = dateGreffage.AddDays(-10);
        //    DateTime datePorteGreffe = dateSemiVariete.AddDays(-15);
        //    dateTimeDGR.Value = dateGreffage.Date;
        //    dateTimeDSV.Value = dateSemiVariete.Date;
        //    dateTimeDPG.Value = datePorteGreffe.Date;
        //}



    }
    }
    
