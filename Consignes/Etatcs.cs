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

namespace EasyPlants.Consignes
{
    //int TypeAct;
    //String Qry;
    public partial class Etatcs : Form
    {
        public Etatcs()
        {
            InitializeComponent();
        }

        private void Etatcs_Load(object sender, EventArgs e)
        {
            RemplirGrid();
            //MyPub.RemplirCbo("PointVente", CbPv);
            //Panel1.Enabled = true;

        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RemplirGrid()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Numero,CodeArticle,Libelle,TypeDocument,Operation,Qte,DateOp FROM OpStock where TypeDocument='Sortie Consigne' OR TypeDocument='Retour Consigne' ", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.GridEtat.MasterTemplate.AutoGenerateColumns = true;
                    this.GridEtat.TableElement.BeginUpdate();
                    this.GridEtat.MasterTemplate.LoadFrom(reader);
                    this.GridEtat.MasterTemplate.Columns[0].Width = 100;
                    this.GridEtat.MasterTemplate.Columns[1].Width = 100;
                    this.GridEtat.MasterTemplate.Columns[2].Width = 180;
                    this.GridEtat.MasterTemplate.Columns[3].Width = 100;
                    this.GridEtat.MasterTemplate.Columns[4].Width = 180;
                    this.GridEtat.MasterTemplate.Columns[5].Width = 100;
                    this.GridEtat.MasterTemplate.Columns[6].Width = 180;
                    this.GridEtat.Columns["Numero"].HeaderText = "Numero";
                    this.GridEtat.Columns["CodeArticle"].HeaderText = "Code Article";
                    this.GridEtat.Columns["Libelle"].HeaderText = "Libelle";
                    this.GridEtat.Columns["TypeDocument"].HeaderText = "Type Document";
                    this.GridEtat.Columns["Operation"].HeaderText = "Operation";
                    this.GridEtat.Columns["Qte"].HeaderText = "Qte";
                    this.GridEtat.Columns["DateOp"].HeaderText = "Date";

                    this.GridEtat.TableElement.EndUpdate();
                }
                reader.Close();
            }
            //this.GridEtat.PrintPreview();



        }

        private void BtnA_Click(object sender, EventArgs e)
        {

        }

        private void BtnImp_Click(object sender, EventArgs e)
        {
            this.GridEtat.PrintPreview();
        }
    }

  }


 
