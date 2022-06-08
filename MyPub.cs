using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace EasyPlants
{
    public class MyPub
    {
        public static int TypeAct;
        public static String TableName;
        public static void ClearPanel(Control Parent)
        {
            foreach (Control cont in Parent.Controls)
            {
                if (cont is TextBox)
                    {cont.Text = string.Empty;}
                else if (cont is Telerik.WinControls.UI.RadTextBox)
                    {((Telerik.WinControls.UI.RadTextBox)cont).Text = string.Empty;}
                else if (cont is Telerik.WinControls.UI.RadDropDownList)
                    {((Telerik.WinControls.UI.RadDropDownList)cont).SelectedIndex = 0;}
                else if (cont is Telerik.WinControls.UI.RadCheckBox)
                    {((Telerik.WinControls.UI.RadCheckBox)cont).Checked = false;}
            }
        }
        public static void New(Control Parent)
        {
            foreach (Control cont in Parent.Controls)
            {
                if (cont is Telerik.WinControls.UI.RadPanel)
                    {((Telerik.WinControls.UI.RadPanel)cont).Enabled = true;}
                if (cont.Name.Equals("BtnNouveau"))
                    {cont.Enabled = false;}
                if (cont.Name.Equals("BtnEnregistrer"))
                    {cont.Enabled = true;}
                if (cont.Name.Equals("BtnQuitter"))
                    {cont.Visible = false;}
            }
        }
        public static void Save(Control Parent)
        {
            foreach (Control cont in Parent.Controls)
            {
                if (cont is Telerik.WinControls.UI.RadPanel)
                    {((Telerik.WinControls.UI.RadPanel)cont).Enabled = false;}
                if (cont.Name.Equals("BtnNouveau"))
                    {cont.Enabled = true;}
                if (cont.Name.Equals("BtnEnregistrer"))
                    {cont.Enabled = false;}
                if (cont.Name.Equals("BtnQuitter"))
                    {cont.Visible = true;}
            }
        }
        public static void Undo(Control Parent)
        {
            foreach (Control cont in Parent.Controls)
            {
                if (cont is Telerik.WinControls.UI.RadPanel)
                    {((Telerik.WinControls.UI.RadPanel)cont).Enabled = false;}
                if (cont.Name.Equals("BtnNouveau"))
                    {cont.Enabled = true;}
                if (cont.Name.Equals("BtnEnregistrer"))
                    {cont.Enabled = false;}
                if (cont.Name.Equals("BtnQuitter"))
                    {cont.Visible = true;}
            }
        }

        public static string Mystr(string pValue)
        {
            int i;
            string cH;
            cH = "";
            for (i = 0; i <= pValue.Length-1; i++)
            {
                if (pValue.Substring(i, 1) == "'")
                    {cH +=  "''";}
                else
                    {cH += pValue.Substring(i, 1);}
            }
            return cH;
        }


        public static string DeterminerNum(string pValue)
        {
            int Num; string Nums = "";
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Max(Numero) MaxNum FROM " + pValue + " ", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.IsDBNull(reader.GetOrdinal("MaxNum")))
                        Nums = DateTime.Today.Year.ToString() + "0001";
                    else
                    { 
                        Num = Convert.ToInt32(reader["MaxNum"]); Num++;Nums = Num.ToString();
                    }
                }
                reader.Close();
            }
            return Nums.ToString();
        }

        public static string NoSpace(string pValue)
        {
            int i;
            string cH;
            cH = "";
            for (i = 0; i <= pValue.Length - 1; i++)
            {
                if (pValue.Substring(i, 1) == null)
                { cH += string.Empty; }
                else
                { cH += pValue.Substring(i, 1); }
            }
            return cH;
        }

        public static void RemplirCbo(string TabCbo, Telerik.WinControls.UI.RadDropDownList CbVar)
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT Code,Libelle FROM " + TabCbo + " Order By Code", cn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                CbVar.Items.Add("");
                while (reader1.Read())
                {CbVar.Items.Add(reader1[0].ToString() + " : " + reader1[1].ToString());}
                reader1.Close();
            }
        }

        public static void RemplirGrid(string VarTable, Telerik.WinControls.UI.RadGridView VarGrid)
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT Code,Libelle FROM " + VarTable + " Order By Code", cn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.HasRows)
                {
                    VarGrid.MasterTemplate.AutoGenerateColumns = true;
                    VarGrid.TableElement.BeginUpdate();
                    VarGrid.MasterTemplate.LoadFrom(reader1);
                    VarGrid.MasterTemplate.Columns[0].Width = 80;
                    VarGrid.MasterTemplate.Columns[1].Width = 260;
                    VarGrid.Columns["Code"].HeaderText = "Code";
                    VarGrid.Columns["Libelle"].HeaderText = "Libelle";
                    VarGrid.TableElement.EndUpdate();
                }
                reader1.Close();
            }
        }

        public static string GetVar(string pvalue)
        {
            string VarVar;VarVar = "";
            using (SqlConnection connection = new SqlConnection(ParametrageBase.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + pvalue + "", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        VarVar = reader["CapaciteProduction"].ToString();
                    }
                }
            }
            return VarVar;
        }
        public static void SqlInsert(string[] vArray,string TabName)
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                string Qry = "INSERT INTO " + TabName + " VALUES(" + vArray + ")";
                SqlCommand cmd1 = new SqlCommand(Qry, cn);
                cmd1.ExecuteNonQuery();
            }
        }


        public static void Histo(string Hist)
        {
            using (SqlConnection cn = new SqlConnection(ParametrageBase.connectionString))
            {
                cn.Open();
                //var time = DateTime.Now.ToString("hh:mm:ss"); // includes leading zeros
                //var date = DateTime.Now.ToString("dd/MM/yyyy"); // includes leading zeros

                var now = DateTime.Now;
                var time = now.ToString("hh:mm:ss tt");
                var date = now.ToString("MM/dd/yy");


                //string time = DateTime.Now.ToShortTimeString();
                //string date = DateTime.Now.ToShortDateString();
                string Qry = "INSERT INTO Historique VALUES(" + MyPub.DeterminerNum("Historique") + ",'" + Login.vCodeUser + "','" + Login.vNomUser + "','" + MyPub.Mystr(Hist) + "','" + date + "','" + time + "')";
                //DateTime.Now.ToShortDateString()
                //
                SqlCommand cmd1 = new SqlCommand(Qry, cn);
                cmd1.ExecuteNonQuery();
            }
        }

    }
}
