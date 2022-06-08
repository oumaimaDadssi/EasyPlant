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
    public partial class RservationConsigne : Form
    {
        int TypeAct;
        string Qry;
        public RservationConsigne()
        {
            InitializeComponent();
        }

        private void RservationConsigne_Load(object sender, EventArgs e)
        {
            DataGridS();
        }
        private void DataGridS()
        {
            GridResrvCon.ColumnCount = 4;
            GridResrvCon.Columns[0].HeaderText = "Numero  ";
            GridResrvCon.Columns[1].HeaderText = "Motte";
            GridResrvCon.Columns[2].HeaderText = "Qte";
            GridResrvCon.Columns[3].HeaderText = "Prix";
 
            GridResrvCon.MasterTemplate.Columns[0].Width = 80;
            GridResrvCon.MasterTemplate.Columns[1].Width = 100;
            GridResrvCon.MasterTemplate.Columns[2].Width = 80;
            GridResrvCon.MasterTemplate.Columns[3].Width = 80;
         

        }
        private void RemplirGridS()
        {
            GridResrvCon.Rows.Add(
               TxNumCon.Text,
               TxMotte.Text,
               TxQte.Text,
               TxPrix.Text

                 );
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = "";
            }
        }

        private void BtnValiderS_Click(object sender, EventArgs e)
        {
            RemplirGridS();
        }

        private void BtnEnregistrerSem_Click(object sender, EventArgs e)
        {

            TypeAct = 2;
            if (TxNumCon.Text != string.Empty)
            {
                SaveDataS();
            }

            MyPub.Save(this);
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            MyPub.New(this);
            TxNumCon.Text = MyPub.DeterminerNum("CommandePlants");
            TxNumCon.Enabled = false;
            BtnEnregistrerSem.Enabled = true;
            BtnValiderS.Enabled = true;
        }
        private void SaveDataS()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
          

                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM ReservationConsigne WHERE Numero = '" + TxNumCon.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    Qry = "INSERT INTO ReservationConsigne VALUES('" + TxNumCon.Text + "'," + TxMotte.Text + "," + TxQte.Text + "," + Convert.ToDecimal(TxPrix.Text) +")";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM ReservationConsigne WHERE NumeroCommande = '" + TxNumCon.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        private void BtnImprimerBCde_Click(object sender, EventArgs e)
        {
            this.GridResrvCon.PrintPreview();
        }
    }
}
