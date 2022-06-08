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

namespace EasyPlants.Paramétrage
{
    public partial class Planning : Form
    {
        public Planning()
        {
            InitializeComponent();
        }

        private void Planning_Load(object sender, EventArgs e)
        {
            RemplirGrid();
            this.Text = "Planning de Production";
        }
        private void RemplirGrid()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT  NumCommande,NomClient,DateCommande,NomVariete,QteCommande,NomTypeProduction,DateLivPr,DateSemisVarPr,DateSemisPgPr,DateGreffagePr FROM OrdreProduction", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.GridPlanning.MasterTemplate.AutoGenerateColumns = true;
                    this.GridPlanning.TableElement.BeginUpdate();
                    this.GridPlanning.MasterTemplate.LoadFrom(reader);
                    this.GridPlanning.MasterTemplate.Columns[0].Width = 80;
                    this.GridPlanning.MasterTemplate.Columns[1].Width = 80;
                    this.GridPlanning.MasterTemplate.Columns[2].Width = 120;
                    this.GridPlanning.MasterTemplate.Columns[3].Width = 100;
                    this.GridPlanning.MasterTemplate.Columns[4].Width = 80;
                    this.GridPlanning.MasterTemplate.Columns[5].Width = 100;
                    this.GridPlanning.MasterTemplate.Columns[6].Width = 120;
                    this.GridPlanning.MasterTemplate.Columns[7].Width = 120;
                    this.GridPlanning.MasterTemplate.Columns[8].Width = 120;
                    this.GridPlanning.MasterTemplate.Columns[9].Width = 120;





                    this.GridPlanning.Columns["NumCommande"].HeaderText = "Num Cmd";
                    this.GridPlanning.Columns["NomClient"].HeaderText = "Nom Client";
                    this.GridPlanning.Columns["DateCommande"].HeaderText = "Date Cmd";
                    this.GridPlanning.Columns["NomVariete"].HeaderText = "Nom Variété";
                    this.GridPlanning.Columns["QteCommande"].HeaderText = "Qte Cmd";
                    this.GridPlanning.Columns["NomTypeProduction"].HeaderText = "Type de Production";
                    this.GridPlanning.Columns["DateLivPr"].HeaderText = "Date Liv Prévu";
                    this.GridPlanning.Columns["DateSemisVarPr"].HeaderText = "Date Semis Var Prévu";
                    this.GridPlanning.Columns["DateSemisPgPr"].HeaderText = "Date Semis PG Prévu";
                    this.GridPlanning.Columns["DateGreffagePr"].HeaderText = "Date Greffage Prévu";
                    this.GridPlanning.TableElement.EndUpdate();
                }
                reader.Close();
            }
          
        }

        private void BtnImprimerBCde_Click(object sender, EventArgs e)
        {
            this.GridPlanning.PrintPreview();

        }
    }
}
