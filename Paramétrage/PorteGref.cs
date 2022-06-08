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
using Telerik.WinControls;

namespace EasyPlants.Paramétrage
{
    public partial class PorteGref : Form
    {
        int TypeAct;
        String Qry;
        public PorteGref()
        {
            InitializeComponent();
        }
        private void PorteGref_Load(object sender, EventArgs e)
        {
            this.Text = "Liste des Portes Greffes";
            RemplirGrid(); RemplirFiche();
            this.GridPg.KeyDown += new KeyEventHandler(GridPg_KeyDown);
            GridPg.DoubleClick += new EventHandler(GridPg_DoubleClick);
        }
        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            GridPg.Enabled = false;
            MyPub.ClearPanel(this.Panel1);
            MyPub.New(this);
            TxCode.Enabled = true; TxCode.Focus();
        }
        private void BtnQuitter_Click(object sender, EventArgs e)
        { this.Close(); }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            TypeAct = 2;
            if (TxCode.Text != string.Empty && TxLibelle.Text != string.Empty)
            {
                SaveData();
            }
            GridPg.Enabled = true;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Save(this);
        }
        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            TypeAct = 0;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Undo(this);
            GridPg.Enabled = true;
        }
        private void GridPg_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
            {
                if (GridPg.CurrentRow.Index < 0)
                { return; }
                TxCode.Text = GridPg.Rows[GridPg.CurrentRow.Index].Cells[0].Value.ToString();
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ArticlePg WHERE Code ='" + TxCode.Text.Trim() + "'", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TxLibelle.Text = reader["Libelle"].ToString();
                        TxMarge.Text = reader["Marge"].ToString();
                        TxPrixVente.Text = reader["PrixVente"].ToString();
                        TxMntM.Text = reader["MontantMarge"].ToString();
                        TxJoursProd.Text = reader["NbJourProduction"].ToString();
                        this.GridFichePg.Rows[0].Cells[1].Value = reader["CoutSemence"].ToString();
                        this.GridFichePg.Rows[1].Cells[1].Value = reader["CoutTourbe"].ToString();
                        this.GridFichePg.Rows[2].Cells[1].Value = reader["CoutEngrais"].ToString();
                        this.GridFichePg.Rows[3].Cells[1].Value = reader["CoutMO"].ToString();
                        this.GridFichePg.Rows[4].Cells[1].Value = reader["AutreCout"].ToString();
                    }
                }
            }
        }

        private void GridPg_KeyDown(object sender, KeyEventArgs e)
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
        private void SaveData()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM ArticlePg WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    decimal Semence = (decimal)(GridFichePg.Rows[0].Cells[1].Value);
                    decimal Tourbe = (decimal)(GridFichePg.Rows[1].Cells[1].Value);
                    decimal Engrais = (decimal)(GridFichePg.Rows[2].Cells[1].Value);
                    decimal Mdv = (decimal)(GridFichePg.Rows[3].Cells[1].Value);
                    decimal Autre = (decimal)(GridFichePg.Rows[4].Cells[1].Value);
                    decimal Total = Semence + Tourbe + Engrais + Mdv + Autre;
                    Qry = "INSERT INTO ArticlePg VALUES('" + TxCode.Text + "','" + MyPub.Mystr(TxLibelle.Text) + "'," + (TxJoursProd.Text) + "," + Semence + "," + Tourbe + "," + Engrais + "," + Mdv + "," + Autre + "," + Total + "," + Convert.ToDecimal(TxMarge.Text) + ",'" + Convert.ToDecimal(TxMntM.Text) + "','" + Convert.ToDecimal(TxPrixVente.Text) + "')";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM ArticlePg WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }
                this.GridFichePg.Rows[0].Cells[1].Value = null;
                this.GridFichePg.Rows[1].Cells[1].Value = null;
                this.GridFichePg.Rows[2].Cells[1].Value = null;
                this.GridFichePg.Rows[3].Cells[1].Value = null;
                this.GridFichePg.Rows[4].Cells[1].Value = null;
                RemplirGrid();
            }
        }
        private void RemplirGrid()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Code,Libelle,NbJourProduction,Marge,PrixVente,CoutTotal,MontantMarge FROM ArticlePg ", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.GridPg.MasterTemplate.AutoGenerateColumns = true;
                    this.GridPg.TableElement.BeginUpdate();
                    this.GridPg.MasterTemplate.LoadFrom(reader);
                    this.GridPg.MasterTemplate.Columns[0].Width = 80;
                    this.GridPg.MasterTemplate.Columns[1].Width = 200;
                    this.GridPg.MasterTemplate.Columns[2].Width = 80;
                    this.GridPg.MasterTemplate.Columns[3].Width = 100;
                    this.GridPg.MasterTemplate.Columns[4].Width = 100;
                    this.GridPg.MasterTemplate.Columns[5].Width = 100;
                    this.GridPg.MasterTemplate.Columns[6].Width = 100;
                    this.GridPg.MasterTemplate.Columns[2].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

                    this.GridPg.Columns["Code"].HeaderText = "Code";
                    this.GridPg.Columns["Libelle"].HeaderText = "Libelle Variete";
                    this.GridPg.Columns["NbJourProduction"].HeaderText = "Jrs Prod.";
                    this.GridPg.Columns["CoutTotal"].HeaderText = "Cout.V";
                    this.GridPg.Columns["Marge"].HeaderText = "Marge";
                    this.GridPg.Columns["MontantMarge"].HeaderText = "Mnt.Marge";
                    this.GridPg.Columns["PrixVente"].HeaderText = "Px.Vente";
                    this.GridPg.TableElement.EndUpdate();
                }
                reader.Close();
            }
        }

        private void GridPg_DoubleClick(object sender, EventArgs e)
        {
            if (GridPg.MasterView.CurrentRow != null)
            {
                TypeAct = 2;
                MyPub.New(this);
                GridPg.Enabled = false;
                TxCode.Enabled = false;
                TxLibelle.Focus();
            }
        }

        private void TxJoursProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void RemplirFiche()
        {
            GridFichePg.Rows.Add("Semence", 0);
            GridFichePg.Rows.Add("Tourbe", 0);
            GridFichePg.Rows.Add("Porte Greffe", 0);
            GridFichePg.Rows.Add("Engrais", 0);
            GridFichePg.Rows.Add("Main d'Oeuvre", 0);
            GridFichePg.Rows.Add("Autres Frais", 0);
        }
    }
}
