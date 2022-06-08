namespace EasyPlants.SuiviCommandes
{
    partial class SuiviCommande
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuiviCommande));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnImprimerListeCommanade = new Telerik.WinControls.UI.RadButton();
            this.GridListeCommanades = new Telerik.WinControls.UI.RadGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimerListeCommanade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridListeCommanades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridListeCommanades.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(326, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Liste des Commandes";
            // 
            // BtnImprimerListeCommanade
            // 
            this.BtnImprimerListeCommanade.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnImprimerListeCommanade.Image = ((System.Drawing.Image)(resources.GetObject("BtnImprimerListeCommanade.Image")));
            this.BtnImprimerListeCommanade.Location = new System.Drawing.Point(626, 505);
            this.BtnImprimerListeCommanade.Name = "BtnImprimerListeCommanade";
            this.BtnImprimerListeCommanade.Size = new System.Drawing.Size(309, 48);
            this.BtnImprimerListeCommanade.TabIndex = 60;
            this.BtnImprimerListeCommanade.Text = "Imprimer Liste des Commandes";
            this.BtnImprimerListeCommanade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnImprimerListeCommanade.Click += new System.EventHandler(this.BtnImprimerBCde_Click);
            // 
            // GridListeCommanades
            // 
            this.GridListeCommanades.BackColor = System.Drawing.SystemColors.Control;
            this.GridListeCommanades.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically;
            this.GridListeCommanades.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridListeCommanades.EnableCustomDrawing = true;
            this.GridListeCommanades.EnableCustomFiltering = true;
            this.GridListeCommanades.EnableCustomGrouping = true;
            this.GridListeCommanades.EnableCustomSorting = true;
            this.GridListeCommanades.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridListeCommanades.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GridListeCommanades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridListeCommanades.Location = new System.Drawing.Point(12, 58);
            // 
            // 
            // 
            this.GridListeCommanades.MasterTemplate.AllowAddNewRow = false;
            this.GridListeCommanades.MasterTemplate.AllowCellContextMenu = false;
            this.GridListeCommanades.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.GridListeCommanades.MasterTemplate.AllowColumnReorder = false;
            this.GridListeCommanades.MasterTemplate.AllowDeleteRow = false;
            this.GridListeCommanades.MasterTemplate.AllowEditRow = false;
            this.GridListeCommanades.MasterTemplate.AllowSearchRow = true;
            this.GridListeCommanades.MasterTemplate.EnableAlternatingRowColor = true;
            this.GridListeCommanades.MasterTemplate.EnableCustomFiltering = true;
            this.GridListeCommanades.MasterTemplate.EnableCustomGrouping = true;
            this.GridListeCommanades.MasterTemplate.EnableCustomSorting = true;
            this.GridListeCommanades.MasterTemplate.EnablePaging = true;
            this.GridListeCommanades.MasterTemplate.MultiSelect = true;
            this.GridListeCommanades.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridListeCommanades.Name = "GridListeCommanades";
            this.GridListeCommanades.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.GridListeCommanades.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridListeCommanades.Size = new System.Drawing.Size(923, 432);
            this.GridListeCommanades.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 37);
            this.panel1.TabIndex = 61;
            // 
            // SuiviCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 560);
            this.Controls.Add(this.GridListeCommanades);
            this.Controls.Add(this.BtnImprimerListeCommanade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "SuiviCommande";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liste des Commandes";
            this.Load += new System.EventHandler(this.SuiviCommande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimerListeCommanade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridListeCommanades.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridListeCommanades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton BtnImprimerListeCommanade;
        private Telerik.WinControls.UI.RadGridView GridListeCommanades;
        private System.Windows.Forms.Panel panel1;
    }
}