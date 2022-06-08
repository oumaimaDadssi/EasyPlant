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

namespace EasyPlants.SuiviCommandes
{
    public partial class SuiviCommande : Form
    {
        public SuiviCommande()
        {
            InitializeComponent();
        }

        private void SuiviCommande_Load(object sender, EventArgs e)
        {
            RemplirGrid();
            this.Text = "Liste des commandes";
        }

        private void RemplirGrid()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Numero,CodeClient,NomClient,Adresse,Ville,CodeTvaCIN,NomCommercial,DateCommande,MontantNet,Acompte,Reste FROM CommandePlants", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.GridListeCommanades.MasterTemplate.AutoGenerateColumns = true;
                    this.GridListeCommanades.TableElement.BeginUpdate();
                    this.GridListeCommanades.MasterTemplate.LoadFrom(reader);
                    this.GridListeCommanades.MasterTemplate.Columns[0].Width = 80;
                    this.GridListeCommanades.MasterTemplate.Columns[1].Width = 80;
                    this.GridListeCommanades.MasterTemplate.Columns[2].Width = 120;
                    this.GridListeCommanades.MasterTemplate.Columns[3].Width = 100;
                    this.GridListeCommanades.MasterTemplate.Columns[4].Width = 80;
                    this.GridListeCommanades.MasterTemplate.Columns[5].Width = 100;
                    this.GridListeCommanades.MasterTemplate.Columns[6].Width = 120;
                    this.GridListeCommanades.MasterTemplate.Columns[7].Width = 120;
                    this.GridListeCommanades.MasterTemplate.Columns[8].Width = 120;
                    this.GridListeCommanades.MasterTemplate.Columns[9].Width = 120;


                    this.GridListeCommanades.Columns["Numero"].HeaderText = "Numéro";
                    this.GridListeCommanades.Columns["CodeClient"].HeaderText = "Code Client";
                    this.GridListeCommanades.Columns["NomClient"].HeaderText = "Nom Client";
                    this.GridListeCommanades.Columns["Adresse"].HeaderText = "Adresse";
                    this.GridListeCommanades.Columns["Ville"].HeaderText = "Ville";
                    this.GridListeCommanades.Columns["CodeTvaCIN"].HeaderText = "CIN";
                    this.GridListeCommanades.Columns["NomCommercial"].HeaderText = "Nom Commercial";
                    this.GridListeCommanades.Columns["DateCommande"].HeaderText = "Date Commande";
                    this.GridListeCommanades.Columns["MontantNet"].HeaderText = "Montant Net";
                    this.GridListeCommanades.Columns["Acompte"].HeaderText = "Accompte";
                    this.GridListeCommanades.Columns["Reste"].HeaderText = "Reste";
                    this.GridListeCommanades.TableElement.EndUpdate();
                }
                reader.Close();
            }


        }

        private void BtnImprimerBCde_Click(object sender, EventArgs e)
        {
            this.GridListeCommanades.PrintPreview();

        }

        //    private void GridListeCommanades_DoubleClick(object sender, EventArgs e)
        //    {
        //        using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
        //        {
        //            if (GridListeCommanades.CurrentRow.Index < 0)
        //            { return; }
        //            connection.Open();
        //            SqlCommand cmd = new SqlCommand("INSERT INTO OdreProduction(Numero,NumCommande,DateOrdre,CodeClient,NomClient");

        //            SqlDataReader reader = cmd.ExecuteReader();
        //        }
        //}
    }
}