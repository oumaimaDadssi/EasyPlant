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

namespace EasyPlants
{
    public partial class DoubleForm : Form
    {
        int TypeAct;String Qry;readonly String VarTable;readonly String vTitle;
        public DoubleForm(String TableName, String FormTitle)
        {
            vTitle = FormTitle;VarTable = TableName;
            InitializeComponent();
        }
        private void DoubleForm_Load(object sender, EventArgs e)
        {
            this.Text = vTitle;RemplirGrid();
            this.GridDouble.KeyDown += new KeyEventHandler(GridDouble_KeyDown);
            GridDouble.DoubleClick += new EventHandler(GridDouble_DoubleClick);
        }
        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            TypeAct = 1;MyPub.ClearPanel(this.Panel1);MyPub.New(this);
            GridDouble.Enabled = false;TxCode.Enabled = true;TxCode.Focus();
        }
        private void BtnQuitter_Click(object sender, EventArgs e)
        {this.Close();}
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            TypeAct = 2;
            if (TxCode.Text != string.Empty && TxLibelle.Text != string.Empty)
            {SaveData();}
            MyPub.ClearPanel(this.Panel1);MyPub.Save(this);GridDouble.Enabled = true;
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {TypeAct = 0;MyPub.ClearPanel(this.Panel1);MyPub.Undo(this);GridDouble.Enabled = true;}
        private void GridDouble_Click(object sender, EventArgs e)
        {
            if (GridDouble.CurrentRow.Index < 0)
                {return;}
            TxCode.Text = GridDouble.Rows[GridDouble.CurrentRow.Index].Cells[0].Value.ToString();
            TxLibelle.Text = GridDouble.Rows[GridDouble.CurrentRow.Index].Cells[1].Value.ToString();
            TypeAct = 2;TxCode.Enabled = true;TxLibelle.Focus();
        }
        public void GridDouble_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult ds = RadMessageBox.Show(this, "Supprimer Cet Enregistrement ?", "Easy Plants", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                String Reponse = ds.ToString();
                if (Reponse == "Yes")
                {TypeAct = 3;SaveData();}
            }
        }
        private void SaveData()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                if (TypeAct == 1 || TypeAct == 2)
                {
                    Qry = "DELETE FROM " + VarTable + " WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                    Qry = "INSERT INTO " + VarTable + " VALUES('" + TxCode.Text + "','" + MyPub.Mystr(TxLibelle.Text) + "')";
                    SqlCommand cmd1 = new SqlCommand(Qry, cn);
                    cmd1.ExecuteNonQuery();
                }
                if (TypeAct == 3)
                {
                    Qry = "DELETE FROM " + VarTable + " WHERE Code = '" + TxCode.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(Qry, cn);
                    cmd.ExecuteNonQuery();
                }
                RemplirGrid();
            }
        }
        private void RemplirGrid()
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Code,Libelle FROM " + VarTable + " ", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.GridDouble.MasterTemplate.AutoGenerateColumns = true;
                    this.GridDouble.TableElement.BeginUpdate();
                    this.GridDouble.MasterTemplate.LoadFrom(reader);
                    this.GridDouble.MasterTemplate.Columns[0].Width = 120;
                    this.GridDouble.MasterTemplate.Columns[1].Width = 370;
                    this.GridDouble.Columns["Code"].HeaderText = "Code";
                    this.GridDouble.Columns["Libelle"].HeaderText = "Libelle";
                    this.GridDouble.TableElement.EndUpdate();
                }
                reader.Close();
            }
        }
        private void GridDouble_DoubleClick(object sender, EventArgs e)
        {
            if (GridDouble.MasterView.CurrentRow != null)
            {TypeAct = 2;MyPub.New(this);GridDouble.Enabled = false;TxCode.Enabled = false;TxLibelle.Focus();}
        }
    }
}
