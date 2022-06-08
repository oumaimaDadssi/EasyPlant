namespace EasyPlants
{
    partial class DoubleForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoubleForm));
            this.GridDouble = new Telerik.WinControls.UI.RadGridView();
            this.Panel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.TxCode = new Telerik.WinControls.UI.RadTextBox();
            this.TxLibelle = new Telerik.WinControls.UI.RadTextBox();
            this.BtnQuitter = new Telerik.WinControls.UI.RadButton();
            this.BtnAnnuler = new Telerik.WinControls.UI.RadButton();
            this.BtnEnregistrer = new Telerik.WinControls.UI.RadButton();
            this.BtnNouveau = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.GridDouble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDouble.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Panel1)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxLibelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnQuitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAnnuler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEnregistrer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNouveau)).BeginInit();
            this.SuspendLayout();
            // 
            // GridDouble
            // 
            this.GridDouble.BackColor = System.Drawing.SystemColors.Control;
            this.GridDouble.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically;
            this.GridDouble.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridDouble.EnableGestures = false;
            this.GridDouble.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridDouble.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GridDouble.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridDouble.Location = new System.Drawing.Point(14, 12);
            // 
            // 
            // 
            this.GridDouble.MasterTemplate.AllowAddNewRow = false;
            this.GridDouble.MasterTemplate.AllowCellContextMenu = false;
            this.GridDouble.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.GridDouble.MasterTemplate.AllowColumnReorder = false;
            this.GridDouble.MasterTemplate.AllowDeleteRow = false;
            this.GridDouble.MasterTemplate.AllowEditRow = false;
            this.GridDouble.MasterTemplate.AllowSearchRow = true;
            this.GridDouble.MasterTemplate.EnableAlternatingRowColor = true;
            this.GridDouble.MasterTemplate.MultiSelect = true;
            this.GridDouble.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridDouble.Name = "GridDouble";
            this.GridDouble.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.GridDouble.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridDouble.Size = new System.Drawing.Size(534, 399);
            this.GridDouble.TabIndex = 7;
            this.GridDouble.Click += new System.EventHandler(this.GridDouble_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Panel1.Controls.Add(this.radLabel4);
            this.Panel1.Controls.Add(this.radLabel5);
            this.Panel1.Controls.Add(this.TxCode);
            this.Panel1.Controls.Add(this.TxLibelle);
            this.Panel1.Enabled = false;
            this.Panel1.Location = new System.Drawing.Point(14, 417);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(534, 51);
            this.Panel1.TabIndex = 8;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(13, 16);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(41, 18);
            this.radLabel4.TabIndex = 11;
            this.radLabel4.Text = "Code : ";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(180, 17);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(44, 18);
            this.radLabel5.TabIndex = 10;
            this.radLabel5.Text = "Libelle :";
            // 
            // TxCode
            // 
            this.TxCode.Location = new System.Drawing.Point(63, 15);
            this.TxCode.MaxLength = 5;
            this.TxCode.Name = "TxCode";
            this.TxCode.Size = new System.Drawing.Size(96, 20);
            this.TxCode.TabIndex = 2;
            // 
            // TxLibelle
            // 
            this.TxLibelle.Location = new System.Drawing.Point(230, 14);
            this.TxLibelle.MaxLength = 50;
            this.TxLibelle.Name = "TxLibelle";
            this.TxLibelle.Size = new System.Drawing.Size(297, 20);
            this.TxLibelle.TabIndex = 3;
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Image = ((System.Drawing.Image)(resources.GetObject("BtnQuitter.Image")));
            this.BtnQuitter.Location = new System.Drawing.Point(391, 493);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(138, 49);
            this.BtnQuitter.TabIndex = 10;
            this.BtnQuitter.Text = "Quitter";
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // BtnAnnuler
            // 
            this.BtnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnnuler.Image")));
            this.BtnAnnuler.Location = new System.Drawing.Point(391, 493);
            this.BtnAnnuler.Name = "BtnAnnuler";
            this.BtnAnnuler.Size = new System.Drawing.Size(138, 49);
            this.BtnAnnuler.TabIndex = 12;
            this.BtnAnnuler.Text = "Annuler";
            this.BtnAnnuler.Click += new System.EventHandler(this.BtnAnnuler_Click);
            // 
            // BtnEnregistrer
            // 
            this.BtnEnregistrer.Enabled = false;
            this.BtnEnregistrer.Image = ((System.Drawing.Image)(resources.GetObject("BtnEnregistrer.Image")));
            this.BtnEnregistrer.Location = new System.Drawing.Point(217, 493);
            this.BtnEnregistrer.Name = "BtnEnregistrer";
            this.BtnEnregistrer.Size = new System.Drawing.Size(138, 49);
            this.BtnEnregistrer.TabIndex = 11;
            this.BtnEnregistrer.Text = "Enregistrer";
            this.BtnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // BtnNouveau
            // 
            this.BtnNouveau.Image = ((System.Drawing.Image)(resources.GetObject("BtnNouveau.Image")));
            this.BtnNouveau.Location = new System.Drawing.Point(32, 493);
            this.BtnNouveau.Name = "BtnNouveau";
            this.BtnNouveau.Size = new System.Drawing.Size(138, 49);
            this.BtnNouveau.TabIndex = 9;
            this.BtnNouveau.Text = "Nouveau";
            this.BtnNouveau.Click += new System.EventHandler(this.BtnNouveau_Click);
            // 
            // DoubleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 554);
            this.Controls.Add(this.BtnQuitter);
            this.Controls.Add(this.BtnAnnuler);
            this.Controls.Add(this.BtnEnregistrer);
            this.Controls.Add(this.BtnNouveau);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.GridDouble);
            this.Name = "DoubleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoubleForm";
            this.Load += new System.EventHandler(this.DoubleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridDouble.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDouble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Panel1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxLibelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnQuitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAnnuler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEnregistrer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNouveau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GridDouble;
        private Telerik.WinControls.UI.RadPanel Panel1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox TxCode;
        private Telerik.WinControls.UI.RadTextBox TxLibelle;
        private Telerik.WinControls.UI.RadButton BtnQuitter;
        private Telerik.WinControls.UI.RadButton BtnAnnuler;
        private Telerik.WinControls.UI.RadButton BtnEnregistrer;
        private Telerik.WinControls.UI.RadButton BtnNouveau;
    }
}