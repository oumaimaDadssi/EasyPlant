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
    public partial class Variete : Form
    {
        int TypeAct;
        String Qry;
        public Variete()
        {
            InitializeComponent();
        }
        private void Variete_Load(object sender, EventArgs e)
        {
            this.Text = "Liste des Variétés";
            RemplirGrid(); RemplirFiche(); MyPub.RemplirCbo("TypeProduction", CbTypeP);
            MyPub.RemplirCbo("Espece", CbEspece);
            this.GridVar.KeyDown += new KeyEventHandler(GridVar_KeyDown);
            GridVar.DoubleClick += new EventHandler(GridVar_DoubleClick);
        }
        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;
            GridVar.Enabled = false;
            MyPub.ClearPanel(this.Panel1);
            MyPub.New(this);
            TxCode.Enabled = true;TxCode.Focus();
        }
        private void BtnQuitter_Click(object sender, EventArgs e)
        {this.Close();}

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            TypeAct = 2;
            if (TxCode.Text != string.Empty && TxLibelle.Text != string.Empty && CbTypeP.Text != string.Empty && CbEspece.Text != string.Empty)
            {
                SaveData();
            }
            GridVar.Enabled = true;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Save(this);
        }
        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            TypeAct = 0;
            MyPub.ClearPanel(this.Panel1);
            MyPub.Undo(this);
            GridVar.Enabled = true;
        }
        private void GridVar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
            {
                if (GridVar.CurrentRow.Index < 0)
                { return; }
                TxCode.Text = GridVar.Rows[GridVar.CurrentRow.Index].Cells[0].Value.ToString();
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ArticleVariete WHERE Code ='" + TxCode.Text.Trim() + "'", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TxLibelle.Text = reader["Libelle"].ToString();
                        TxMarge.Text = reader["Marge"].ToString();
                        TxPrixVente.Text = reader["PrixVente"].ToString();
                        TxMntM.Text = reader["MontantMarge"].ToString();
                        TxJoursG.Text = reader["NbJourGreffage"].ToString();
                        TxJoursPG.Text = reader["NbJourPorteGreffe"].ToString();
                        TxJoursCV.Text = reader["NbJourVariete"].ToString();
                        string var1 = reader["TypePlante"].ToString();
                        int itemIndex1 = this.CbTypeP.FindString(var1);
                        CbTypeP.SelectedIndex = itemIndex1;
                        string var2 = reader["CodeEspece"].ToString();
                        int itemIndex2 = this.CbEspece.FindString(var2);
                        CbEspece.SelectedIndex = itemIndex2;
                        this.GridFiche.Rows[0].Cells[1].Value = reader["CoutSemence"].ToString();
                        this.GridFiche.Rows[1].Cells[1].Value = reader["CoutTourbe"].ToString();
                        this.GridFiche.Rows[2].Cells[1].Value = reader["CoutPg"].ToString();
                        this.GridFiche.Rows[3].Cells[1].Value = reader["CoutEngrais"].ToString();
                        this.GridFiche.Rows[4].Cells[1].Value = reader["CoutMO"].ToString();
                        this.GridFiche.Rows[5].Cells[1].Value = reader["AutreCout"].ToString();
                    }
                }
            }
        }
        private void GridVar_KeyDown(object sender, KeyEventArgs e)
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
                string CodeP = CbTypeP.Text.Substring(0, CbTypeP.Text.IndexOf(":")).Trim();
                string NomP = CbTypeP.Text.Substring(CbTypeP.Text.IndexOf(":") + 2).Trim();
                string CodeE = CbEspece.Text.Substring(0, CbEspece.Text.IndexOf(":")).Trim();
                string NomE = CbEspece.Text.Substring(CbEspece.Text.IndexOf(":") + 2).Trim();
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM ArticleVariete WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    decimal Semence = (decimal)(GridFiche.Rows[0].Cells[1].Value);
                    decimal Tourbe = (decimal)(GridFiche.Rows[1].Cells[1].Value);
                    decimal Pg = (decimal)(GridFiche.Rows[2].Cells[1].Value);
                    decimal Engrais = (decimal)(GridFiche.Rows[3].Cells[1].Value);
                    decimal Mdv = (decimal)(GridFiche.Rows[4].Cells[1].Value);
                    decimal Autre = (decimal)(GridFiche.Rows[5].Cells[1].Value);
                    decimal Total = Semence+Tourbe+Pg+Engrais+Mdv+Autre;
                    Qry = "INSERT INTO ArticleVariete VALUES('" + TxCode.Text + "','" + MyPub.Mystr(TxLibelle.Text) + "','" + CodeE + "','" + NomE + "','" + CodeP + "','" + NomP + "'," + (TxJoursCV.Text) + "," + (TxJoursG.Text) + "," + (TxJoursPG.Text) + ","+ Semence + "," + Tourbe + "," + Pg + "," + Engrais + "," + Mdv + "," + Autre + "," + Total + "," + Convert.ToDecimal(TxMarge.Text) + ",'" + Convert.ToDecimal(TxMntM.Text) + "','" + Convert.ToDecimal(TxPrixVente.Text) + "')";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM ArticleVariete WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }
                this.GridFiche.Rows[0].Cells[1].Value=null;
                this.GridFiche.Rows[1].Cells[1].Value = null;
                this.GridFiche.Rows[2].Cells[1].Value = null;
                this.GridFiche.Rows[3].Cells[1].Value = null;
                this.GridFiche.Rows[4].Cells[1].Value = null;
                this.GridFiche.Rows[5].Cells[1].Value = null;
                RemplirGrid();
            }
        }
        private void RemplirGrid()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Code,Libelle,NomTypePlante,NomEspece,NbJourGreffage,NbJourPorteGreffe,NbJourVariete,Marge,PrixVente,CoutTotal,MontantMarge FROM ArticleVariete ", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.GridVar.MasterTemplate.AutoGenerateColumns = true;
                    this.GridVar.TableElement.BeginUpdate();
                    this.GridVar.MasterTemplate.LoadFrom(reader);
                    this.GridVar.MasterTemplate.Columns[0].Width = 80;
                    this.GridVar.MasterTemplate.Columns[1].Width = 180;
                    this.GridVar.MasterTemplate.Columns[2].Width = 100;
                    this.GridVar.MasterTemplate.Columns[3].Width = 80;
                    this.GridVar.MasterTemplate.Columns[4].Width = 60;
                    this.GridVar.MasterTemplate.Columns[5].Width = 60;
                    this.GridVar.MasterTemplate.Columns[6].Width = 60;
                    this.GridVar.MasterTemplate.Columns[7].Width = 80;
                    this.GridVar.MasterTemplate.Columns[8].Width = 80;
                    this.GridVar.MasterTemplate.Columns[9].Width = 80;
                    this.GridVar.MasterTemplate.Columns[10].Width = 80;
                    this.GridVar.MasterTemplate.Columns[4].TextAlignment= System.Drawing.ContentAlignment.MiddleCenter;
                    this.GridVar.MasterTemplate.Columns[5].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    this.GridVar.MasterTemplate.Columns[6].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;




                    this.GridVar.Columns["Code"].HeaderText = "Code";
                    this.GridVar.Columns["Libelle"].HeaderText = "Libelle Variete";
                    this.GridVar.Columns["NomEspece"].HeaderText = "Espèce";
                    this.GridVar.Columns["NomTypePlante"].HeaderText = "Type";
                    this.GridVar.Columns["NbJourGreffage"].HeaderText = "Jrs Greff";
                    this.GridVar.Columns["NbJourPorteGreffe"].HeaderText = "Jrs PG";
                    this.GridVar.Columns["NbJourVariete"].HeaderText = "Jrs CV";
                    this.GridVar.Columns["CoutTotal"].HeaderText = "Cout.V";
                    this.GridVar.Columns["Marge"].HeaderText = "Marge";
                    this.GridVar.Columns["MontantMarge"].HeaderText = "Mnt.Marge";
                    this.GridVar.Columns["PrixVente"].HeaderText = "Px.Vente"; 
                    this.GridVar.TableElement.EndUpdate();
                }
                reader.Close();
            }
            //this.GridVar.PrintPreview();
        }

        private void GridVar_DoubleClick(object sender, EventArgs e)
        {
            if (GridVar.MasterView.CurrentRow != null)
            {
                TypeAct = 2;
                MyPub.New(this);
                GridVar.Enabled = false;
                TxCode.Enabled = false;
                TxLibelle.Focus();
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (CbTypeP.SelectedText == "FRANC")
            {
                TxJoursG.Visible = false;
                TxJoursPG.Visible = false;
            }
        }
        private void TxJoursCV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void TxJoursPG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void TxJoursG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void RemplirFiche()
        {
            GridFiche.Rows.Add("Semence", 0);
            GridFiche.Rows.Add("Tourbe", 0);
            GridFiche.Rows.Add("Porte Greffe", 0);
            GridFiche.Rows.Add("Engrais", 0);
            GridFiche.Rows.Add("Main d'Oeuvre", 0);
            GridFiche.Rows.Add("Autres Frais", 0);
        }
    }
}
