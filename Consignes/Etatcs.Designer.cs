namespace EasyPlants.Consignes
{
    partial class Etatcs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Etatcs));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.BtnImp = new Telerik.WinControls.UI.RadButton();
            this.GridEtat = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridEtat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridEtat.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnImp
            // 
            this.BtnImp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnImp.Image = ((System.Drawing.Image)(resources.GetObject("BtnImp.Image")));
            this.BtnImp.Location = new System.Drawing.Point(798, 396);
            this.BtnImp.Name = "BtnImp";
            this.BtnImp.Size = new System.Drawing.Size(239, 49);
            this.BtnImp.TabIndex = 49;
            this.BtnImp.Text = "Imprimer Etat Consignes";
            this.BtnImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnImp.Click += new System.EventHandler(this.BtnImp_Click);
            // 
            // GridEtat
            // 
            this.GridEtat.BackColor = System.Drawing.SystemColors.Control;
            this.GridEtat.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically;
            this.GridEtat.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridEtat.EnableGestures = false;
            this.GridEtat.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridEtat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GridEtat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridEtat.Location = new System.Drawing.Point(1, 95);
            // 
            // 
            // 
            this.GridEtat.MasterTemplate.AllowAddNewRow = false;
            this.GridEtat.MasterTemplate.AllowCellContextMenu = false;
            this.GridEtat.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.GridEtat.MasterTemplate.AllowColumnReorder = false;
            this.GridEtat.MasterTemplate.AllowDeleteRow = false;
            this.GridEtat.MasterTemplate.AllowEditRow = false;
            this.GridEtat.MasterTemplate.AllowSearchRow = true;
            this.GridEtat.MasterTemplate.EnableAlternatingRowColor = true;
            this.GridEtat.MasterTemplate.MultiSelect = true;
            this.GridEtat.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridEtat.Name = "GridEtat";
            this.GridEtat.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.GridEtat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridEtat.Size = new System.Drawing.Size(1036, 295);
            this.GridEtat.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(403, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 24);
            this.label1.TabIndex = 61;
            this.label1.Text = "Etat Stock des Consignes";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(1, 40);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1036, 37);
            this.panel6.TabIndex = 62;
            // 
            // Etatcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 473);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.BtnImp);
            this.Controls.Add(this.GridEtat);
            this.Name = "Etatcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etat de Stock des Consignes";
            this.Load += new System.EventHandler(this.Etatcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BtnImp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridEtat.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridEtat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadButton BtnImp;
        private Telerik.WinControls.UI.RadGridView GridEtat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
    }
}