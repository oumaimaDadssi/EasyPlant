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

namespace EasyPlants.Consignes
{
    public partial class Retour : Form
    {
        int TypeAct;
        String Qry;
        String Type = "Retour Consigne";
        String Op = "Entré";

        public Retour()
        {

            InitializeComponent();
        }

        private void Retour_Load(object sender, EventArgs e)
        {
            DataGrid();
            MyPub.RemplirCbo("PointVente", CbSourDes);
            MyPub.RemplirCbo("MoyenTrans", CbMoyT);
            MyPub.RemplirCbo("Livreur", CbLiv);
            this.GridRetourons.KeyDown += new KeyEventHandler(GridRetourons_KeyDown);
            GridRetourons.DoubleClick += new EventHandler(GridRetourons_DoubleClick);
            GridRetourons.Click += new EventHandler(GridRetourons_Click);
            Grid.Visible = false;

        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            GridRetourons.Enabled = false;
            MyPub.ClearPanel(this.Panel1);
            MyPub.New(this);
           
            TxCode.Focus();
            Txnumero.Text = MyPub.DeterminerNum("OpStock");
            Txnumero.Enabled = false;

        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            TypeAct = 2;
            if (Txnumero.Text != string.Empty && TxNote.Text != string.Empty && CbMoyT.Text != string.Empty
                && CbSourDes.Text != string.Empty && TxLibelle.Text != string.Empty && TxPU.Text != string.Empty && TxQte.Text != string.Empty
               && CbLiv.Text != string.Empty  && TxCode.Text != string.Empty && DateRetourCnsigne.Text != string.Empty)
            { SaveData(); MyPub.Histo("Mise à jour Liste Retour consignes");
            }
            GridRetourons.Enabled = true;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Save(this);
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            TypeAct = 0;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Undo(this);
            GridRetourons.Enabled = true;
        }
        private void SaveData()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                string CodeMT = CbMoyT.Text.Substring(0, CbMoyT.Text.IndexOf(":")).Trim();
                string NomMt = CbMoyT.Text.Substring(CbMoyT.Text.IndexOf(":") + 2).Trim();
                int CodeLiv = Convert.ToInt32(CbLiv.Text.Substring(0, CbLiv.Text.IndexOf(":")).Trim());
                string NomLiv = CbLiv.Text.Substring(CbLiv.Text.IndexOf(":") + 2).Trim();
                string CodeDes = CbSourDes.Text.Substring(0, CbSourDes.Text.IndexOf(":")).Trim();
                string NomDes = CbSourDes.Text.Substring(CbSourDes.Text.IndexOf(":") + 2).Trim();
                string dateRetourCnsigne = DateRetourCnsigne.Text.ToString().Trim().Substring(0, 4) + "-" + DateRetourCnsigne.Text.ToString().Trim().Substring(8, 2) + "-" + DateRetourCnsigne.Text.ToString().Trim().Substring(5, 2);
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM OpStock WHERE Numero = '" + Txnumero.Text.Trim() + "' ";

                    SqlCommand cmd = new SqlCommand(Qry, cn);

                    cmd.ExecuteNonQuery();

                    Qry = "INSERT INTO OpStock (Numero,CodeArticle,Libelle,TypeDocument,Operation,Pvente,NomPvente,Qte,DateOp,Nomlivreur,CodeLivreur,CodeMtrans,NomMtrans,Pu) VALUES ('" + Txnumero.Text + "','" + TxCode.Text + "' ,'" + TxLibelle.Text + "','" + Type + "','" + Op + "','" + Convert.ToInt32(CodeDes) + "','" + NomDes + "', " + Convert.ToInt32(TxQte.Text) + ", '" + dateRetourCnsigne + "' ,'" + NomLiv + "' , " + CodeLiv.ToString() + " ," + Convert.ToInt32(CodeMT) + " , '" + NomMt + "' , " + Convert.ToDecimal(TxPU.Text) + " )";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();

                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM OpStock WHERE Numero = '" + Txnumero.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }
                RemplirGrid();
            }


        }

   
        private void DataGrid()
        {
            GridRetourons.ColumnCount = 5;
            GridRetourons.Columns[0].HeaderText = "Numero";
            GridRetourons.Columns[1].HeaderText = "Code";
            GridRetourons.Columns[2].HeaderText = "Libelle";
            GridRetourons.Columns[3].HeaderText = "Qte";
            GridRetourons.Columns[4].HeaderText = "PU ";

            GridRetourons.MasterTemplate.Columns[0].Width = 100;
            GridRetourons.MasterTemplate.Columns[1].Width = 100;
            GridRetourons.MasterTemplate.Columns[2].Width = 100;
            GridRetourons.MasterTemplate.Columns[3].Width = 100;
            GridRetourons.MasterTemplate.Columns[4].Width = 100;

        }
        private void RemplirGrid()
        {
            GridRetourons.Rows.Add(
                Txnumero.Text,
                  TxCode.Text,
                  TxLibelle.Text,
                  TxQte.Text,
                 TxPU.Text);
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = "";
            }
        }

     
  

        private void TxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("SupportPlants", this.Grid);
            }
        }

        private void TxLibelle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              
                Grid.BringToFront();
                Grid.Visible = true;
                MyPub.RemplirGrid("SupportPlants", this.Grid);
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

            TxCode.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
            TxLibelle.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();

          
            Grid.Visible = false;
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if (Grid.MasterView.CurrentRow != null)
            {
                FillText();
            }
        }

        private void GridRetourons_KeyDown(object sender, KeyEventArgs e)
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

        private void GridRetourons_DoubleClick(object sender, EventArgs e)
        {
            if (GridRetourons.MasterView.CurrentRow != null)
            {
                TypeAct = 2;
                MyPub.New(this);
                GridRetourons.Enabled = false;
                Txnumero.Enabled = false;
                TxLibelle.Focus();
            }
        }

        private void GridRetourons_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
            {
                if (GridRetourons.CurrentRow.Index < 0)
                { return; }
                Txnumero.Text = GridRetourons.Rows[GridRetourons.CurrentRow.Index].Cells[0].Value.ToString();
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM OpStock WHERE Numero = '" + Txnumero.Text.Trim() + "'", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        TxCode.Text = reader["CodeArticle"].ToString();
                        TxLibelle.Text = reader["Libelle"].ToString();
                        TxQte.Text = reader["Qte"].ToString();
                        TxPU.Text = reader["Pu"].ToString();

                    }
                }
            }
        }

        private void BtnImp_Click(object sender, EventArgs e)
        {
            this.GridRetourons.PrintPreview();
        }
    }
}
