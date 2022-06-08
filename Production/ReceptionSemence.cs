using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPlants.Production
{
    public partial class ReceptionSemence : Form
    {
        int TypeAct;
        string Qry;
        public ReceptionSemence()
        {
            InitializeComponent();
        }

        private void ReceptionSemence_Load(object sender, EventArgs e)
        {
            MyPub.RemplirCbo("Semencier", CbSemencier);
            MyPub.RemplirCbo("Colisage", CbEmballage);
            MyPub.RemplirCbo("Unite", CbUnite);
            DataGridS();
        }

        private void DataGridS()
        {
            GridRecepS.ColumnCount = 5;
            GridRecepS.Columns[0].HeaderText = "Numero  ";
            GridRecepS.Columns[1].HeaderText = "Emballage";
            GridRecepS.Columns[2].HeaderText = "Unité";
            GridRecepS.Columns[3].HeaderText = "N Graine";
            GridRecepS.Columns[4].HeaderText = "Semencier";


            GridRecepS.MasterTemplate.Columns[0].Width = 80;
            GridRecepS.MasterTemplate.Columns[1].Width = 100;
            GridRecepS.MasterTemplate.Columns[2].Width = 80;
            GridRecepS.MasterTemplate.Columns[3].Width = 80;
            GridRecepS.MasterTemplate.Columns[4].Width = 80;

        }

    
        private void SaveDataS()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                string CodeE = CbEmballage.Text.Substring(0, CbEmballage.Text.IndexOf(":")).Trim();
                string NomE = CbEmballage.Text.Substring(CbEmballage.Text.IndexOf(":") + 2).Trim();
                string CodeU = CbUnite.Text.Substring(0, CbUnite.Text.IndexOf(":")).Trim();
                string NomU = CbUnite.Text.Substring(CbUnite.Text.IndexOf(":") + 2).Trim();
                string CodeSem = CbSemencier.Text.Substring(0, CbSemencier.Text.IndexOf(":")).Trim();
                string NomSem = CbSemencier.Text.Substring(CbSemencier.Text.IndexOf(":") + 2).Trim();

                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM ReceptionSemence WHERE NumeroCommande = '" + TxNumRec.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    Qry = "INSERT INTO ReceptionSemence VALUES('" + TxNumRec.Text + "','" + NomSem + "','" + NomE + "','" + NomU + "','" + TxNbrGraine.Text + "')";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM ReceptionSemence WHERE NumeroCommande = '" + TxNumRec.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        private void RemplirGridS()
        {
            string CodeE = CbEmballage.Text.Substring(0, CbEmballage.Text.IndexOf(":")).Trim();
            string NomE = CbEmballage.Text.Substring(CbEmballage.Text.IndexOf(":") + 2).Trim();
            string CodeU = CbUnite.Text.Substring(0, CbUnite.Text.IndexOf(":")).Trim();
            string NomU = CbUnite.Text.Substring(CbUnite.Text.IndexOf(":") + 2).Trim();
            string CodeSem = CbSemencier.Text.Substring(0, CbSemencier.Text.IndexOf(":")).Trim();
            string NomSem = CbSemencier.Text.Substring(CbSemencier.Text.IndexOf(":") + 2).Trim();
            GridRecepS.Rows.Add(
                TxNumRec.Text,
                NomE,
               NomU,
           TxNbrGraine.Text,
           NomSem

                 );
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = "";
            }
        }

        private void BtnEnregistrerSem_Click(object sender, EventArgs e)
        {
            TypeAct = 2;
            if (TxNumRec.Text != string.Empty)
            {
                SaveDataS();
            }
         
            MyPub.Save(this);
          
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;        
            MyPub.New(this);
            TxNumRec.Text = MyPub.DeterminerNum("CommandePlants");
            TxNumRec.Enabled = false; 
            BtnEnregistrerSem.Enabled = true;
            BtnValiderS.Enabled = true;
         
        }

        private void BtnValiderS_Click(object sender, EventArgs e)
        {
            RemplirGridS();
        }

        private void BtnImprimerBCde_Click(object sender, EventArgs e)
        {
            this.GridRecepS.PrintPreview();
        }
    }
}
