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

namespace EasyPlants.Stock
{
    public partial class EtatStock : Form
    {
        public EtatStock()
        {
            InitializeComponent();
        }

        private void RemplirGrid()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Numero,CodeArticle,Libelle,TypeDocument,Operation,Qte,DateOp FROM OpStock ", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.GridEtatStock.MasterTemplate.AutoGenerateColumns = true;
                    this.GridEtatStock.TableElement.BeginUpdate();
                    this.GridEtatStock.MasterTemplate.LoadFrom(reader);
                    this.GridEtatStock.MasterTemplate.Columns[0].Width = 100;
                    this.GridEtatStock.MasterTemplate.Columns[1].Width = 100;
                    this.GridEtatStock.MasterTemplate.Columns[2].Width = 180;
                    this.GridEtatStock.MasterTemplate.Columns[3].Width = 100;
                    this.GridEtatStock.MasterTemplate.Columns[4].Width = 180;
                    this.GridEtatStock.MasterTemplate.Columns[5].Width = 100;
                    this.GridEtatStock.MasterTemplate.Columns[6].Width = 180;
                    this.GridEtatStock.Columns["Numero"].HeaderText = "Numero";
                    this.GridEtatStock.Columns["CodeArticle"].HeaderText = "Code Article";
                    this.GridEtatStock.Columns["Libelle"].HeaderText = "Libelle";
                    this.GridEtatStock.Columns["TypeDocument"].HeaderText = "Type Document";
                    this.GridEtatStock.Columns["Operation"].HeaderText = "Operation";
                    this.GridEtatStock.Columns["Qte"].HeaderText = "Qte";
                    this.GridEtatStock.Columns["DateOp"].HeaderText = "Date";

                    this.GridEtatStock.TableElement.EndUpdate();
                }
                reader.Close();
            }
            //this.GridEtatStock.PrintPreview();



        }

        private void EtatStock_Load(object sender, EventArgs e)
        {
            RemplirGrid();


            panel5.Enabled = true;
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImp_Click(object sender, EventArgs e)
        {
            this.GridEtatStock.PrintPreview();
        }
    }
}
