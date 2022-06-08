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

namespace EasyPlants.Consignes
{
    public partial class Sortie : Form
    {
        int TypeAct;
        String Qry ;
        String Type = "Sortie Consigne";
        String Op = "Sortie";
        public Sortie()
        {
            InitializeComponent();
        }

        private void Sortie_Load(object sender, EventArgs e)
        {
             DataGrid();
            MyPub.RemplirCbo("PointVente", CbSourDes);
            MyPub.RemplirCbo("MoyenTrans", CbMoyT);
            MyPub.RemplirCbo("Livreur", CbLiv);
            this.GridSortieCons.KeyDown += new KeyEventHandler(GridSortieCons_KeyDown);
            GridSortieCons.Click += new EventHandler(GridSortieCons_Click);
            Grid.Visible = false;
            RemplirGrid();
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            GridSortieCons.Enabled = false;
            MyPub.ClearPanel(this.Panel1);
            MyPub.New(this);
            Txnumero.Text = MyPub.DeterminerNum("OpStock");
            Txnumero.Enabled = false;
            TxCode.Focus();
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
               && CbLiv.Text != string.Empty && DateSortieCon.Text != string.Empty && TxCode.Text != string.Empty)
            { SaveData(); MyPub.Histo("Mise à jour Liste Sortie consignes");
            
            }
            GridSortieCons.Enabled = true;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Save(this);
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            TypeAct = 0;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Undo(this);
            GridSortieCons.Enabled = true;
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
                string dateSortieCnsigne = DateSortieCon.Text.ToString().Trim().Substring(0, 4) + "-" + DateSortieCon.Text.ToString().Trim().Substring(8, 2) + "-" + DateSortieCon.Text.ToString().Trim().Substring(5, 2);
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM OpStock WHERE Numero = '" + Txnumero.Text.Trim() + "' ";
                
                  SqlCommand cmd = new SqlCommand(Qry, cn);
          
                   cmd.ExecuteNonQuery();

                    Qry = "INSERT INTO OpStock (Numero,CodeArticle,Libelle,TypeDocument,Operation,Pvente,NomPvente,Qte,DateOp,Nomlivreur,CodeLivreur,CodeMtrans,NomMtrans,Pu) VALUES ('" + Txnumero.Text + "','" + TxCode.Text + "' ,'" + TxLibelle.Text + "','"+ Type +"','"+ Op +"','"+ Convert.ToInt32(CodeDes) + "','"+ NomDes + "', " + Convert.ToInt32(TxQte.Text) + ", '" + dateSortieCnsigne + "' ,'" + NomLiv + "' , " + CodeLiv.ToString() + " ," + Convert.ToInt32(CodeMT) + " , '" + NomMt + "' , " + Convert.ToDecimal(TxPU.Text) + " )";
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
            GridSortieCons.ColumnCount = 5;
            GridSortieCons.Columns[0].HeaderText = "Numero";
            GridSortieCons.Columns[1].HeaderText = "Code";
            GridSortieCons.Columns[2].HeaderText = "Libelle";
            GridSortieCons.Columns[3].HeaderText = "Qte";
            GridSortieCons.Columns[4].HeaderText = "PU ";

  
            GridSortieCons.MasterTemplate.Columns[0].Width = 100;
            GridSortieCons.MasterTemplate.Columns[1].Width = 100;
            GridSortieCons.MasterTemplate.Columns[2].Width = 100;
            GridSortieCons.MasterTemplate.Columns[3].Width = 100;
            GridSortieCons.MasterTemplate.Columns[4].Width = 100;

        }
        private void RemplirGrid()
        {
            GridSortieCons.Rows.Add(
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

      

        private void GridSortieCons_KeyDown(object sender, KeyEventArgs e)
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

     
        private void FillText()
        {

            TxCode.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
            TxLibelle.Text = Grid.Rows[Grid.CurrentRow.Index].Cells[1].Value.ToString();


            Grid.Visible = false;
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

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
             if (Grid.MasterView.CurrentRow != null)
            {
                FillText();
            }
        }

        private void GridSortieCons_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
            {
                if (GridSortieCons.CurrentRow.Index < 0)
                { return; }
                Txnumero.Text = GridSortieCons.Rows[GridSortieCons.CurrentRow.Index].Cells[0].Value.ToString();
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

    }
    }

