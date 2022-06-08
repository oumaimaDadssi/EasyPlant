namespace EasyPlants
{
    partial class Famille
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Famille));
            this.GridFam = new Telerik.WinControls.UI.RadGridView();
            this.Panel1 = new Telerik.WinControls.UI.RadPanel();
            this.CbRayon = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.TxCode = new Telerik.WinControls.UI.RadTextBox();
            this.TxLibelle = new Telerik.WinControls.UI.RadTextBox();
            this.BtnQuitter = new Telerik.WinControls.UI.RadButton();
            this.BtnAnnuler = new Telerik.WinControls.UI.RadButton();
            this.BtnEnregistrer = new Telerik.WinControls.UI.RadButton();
            this.BtnNouveau = new Telerik.WinControls.UI.RadButton();
            this.radMaskedEditBox1 = new Telerik.WinControls.UI.RadMaskedEditBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridFam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridFam.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Panel1)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CbRayon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxLibelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnQuitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAnnuler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEnregistrer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNouveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMaskedEditBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridFam
            // 
            this.GridFam.BackColor = System.Drawing.SystemColors.Control;
            this.GridFam.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically;
            this.GridFam.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridFam.EnableGestures = false;
            this.GridFam.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridFam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GridFam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridFam.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.GridFam.MasterTemplate.AllowAddNewRow = false;
            this.GridFam.MasterTemplate.AllowCellContextMenu = false;
            this.GridFam.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.GridFam.MasterTemplate.AllowColumnReorder = false;
            this.GridFam.MasterTemplate.AllowDeleteRow = false;
            this.GridFam.MasterTemplate.AllowEditRow = false;
            this.GridFam.MasterTemplate.AllowSearchRow = true;
            this.GridFam.MasterTemplate.EnableAlternatingRowColor = true;
            this.GridFam.MasterTemplate.MultiSelect = true;
            this.GridFam.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridFam.Name = "GridFam";
            this.GridFam.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.GridFam.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridFam.Size = new System.Drawing.Size(620, 387);
            this.GridFam.TabIndex = 8;
            this.GridFam.Click += new System.EventHandler(this.GridFam_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Panel1.Controls.Add(this.radMaskedEditBox1);
            this.Panel1.Controls.Add(this.CbRayon);
            this.Panel1.Controls.Add(this.radLabel3);
            this.Panel1.Controls.Add(this.radLabel4);
            this.Panel1.Controls.Add(this.radLabel5);
            this.Panel1.Controls.Add(this.TxCode);
            this.Panel1.Controls.Add(this.TxLibelle);
            this.Panel1.Enabled = false;
            this.Panel1.Location = new System.Drawing.Point(12, 405);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(620, 94);
            this.Panel1.TabIndex = 7;
            // 
            // CbRayon
            // 
            this.CbRayon.EnableAlternatingItemColor = true;
            this.CbRayon.Location = new System.Drawing.Point(94, 53);
            this.CbRayon.Name = "CbRayon";
            this.CbRayon.Size = new System.Drawing.Size(418, 20);
            this.CbRayon.TabIndex = 21;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(47, 53);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(43, 18);
            this.radLabel3.TabIndex = 20;
            this.radLabel3.Text = "Rayon :";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(44, 14);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(41, 18);
            this.radLabel4.TabIndex = 11;
            this.radLabel4.Text = "Code : ";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(193, 16);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(44, 18);
            this.radLabel5.TabIndex = 10;
            this.radLabel5.Text = "Libelle :";
            // 
            // TxCode
            // 
            this.TxCode.Location = new System.Drawing.Point(94, 13);
            this.TxCode.MaxLength = 5;
            this.TxCode.Name = "TxCode";
            this.TxCode.Size = new System.Drawing.Size(77, 20);
            this.TxCode.TabIndex = 2;
            // 
            // TxLibelle
            // 
            this.TxLibelle.Location = new System.Drawing.Point(236, 14);
            this.TxLibelle.MaxLength = 50;
            this.TxLibelle.Name = "TxLibelle";
            this.TxLibelle.Size = new System.Drawing.Size(276, 20);
            this.TxLibelle.TabIndex = 3;
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Image = ((System.Drawing.Image)(resources.GetObject("BtnQuitter.Image")));
            this.BtnQuitter.Location = new System.Drawing.Point(433, 519);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(138, 49);
            this.BtnQuitter.TabIndex = 10;
            this.BtnQuitter.Text = "Quitter";
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // BtnAnnuler
            // 
            this.BtnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnnuler.Image")));
            this.BtnAnnuler.Location = new System.Drawing.Point(433, 519);
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
            this.BtnEnregistrer.Location = new System.Drawing.Point(258, 519);
            this.BtnEnregistrer.Name = "BtnEnregistrer";
            this.BtnEnregistrer.Size = new System.Drawing.Size(138, 49);
            this.BtnEnregistrer.TabIndex = 11;
            this.BtnEnregistrer.Text = "Enregistrer";
            this.BtnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // BtnNouveau
            // 
            this.BtnNouveau.Image = ((System.Drawing.Image)(resources.GetObject("BtnNouveau.Image")));
            this.BtnNouveau.Location = new System.Drawing.Point(73, 519);
            this.BtnNouveau.Name = "BtnNouveau";
            this.BtnNouveau.Size = new System.Drawing.Size(138, 49);
            this.BtnNouveau.TabIndex = 9;
            this.BtnNouveau.Text = "Nouveau";
            this.BtnNouveau.Click += new System.EventHandler(this.BtnNouveau_Click);
            // 
            // radMaskedEditBox1
            // 
            this.radMaskedEditBox1.Location = new System.Drawing.Point(518, 51);
            this.radMaskedEditBox1.Mask = "f";
            this.radMaskedEditBox1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.radMaskedEditBox1.Name = "radMaskedEditBox1";
            this.radMaskedEditBox1.Size = new System.Drawing.Size(98, 20);
            this.radMaskedEditBox1.TabIndex = 48;
            this.radMaskedEditBox1.TabStop = false;
            this.radMaskedEditBox1.Text = "0,00";
            // 
            // Famille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 580);
            this.Controls.Add(this.BtnQuitter);
            this.Controls.Add(this.BtnAnnuler);
            this.Controls.Add(this.BtnEnregistrer);
            this.Controls.Add(this.BtnNouveau);
            this.Controls.Add(this.GridFam);
            this.Controls.Add(this.Panel1);
            this.Name = "Famille";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liste des Familles d\'Articles";
            this.Load += new System.EventHandler(this.Famille_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridFam.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridFam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Panel1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CbRayon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxLibelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnQuitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAnnuler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEnregistrer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNouveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMaskedEditBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GridFam;
        private Telerik.WinControls.UI.RadPanel Panel1;
        private Telerik.WinControls.UI.RadDropDownList CbRayon;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox TxCode;
        private Telerik.WinControls.UI.RadTextBox TxLibelle;
        private Telerik.WinControls.UI.RadButton BtnQuitter;
        private Telerik.WinControls.UI.RadButton BtnAnnuler;
        private Telerik.WinControls.UI.RadButton BtnEnregistrer;
        private Telerik.WinControls.UI.RadButton BtnNouveau;
        private Telerik.WinControls.UI.RadMaskedEditBox radMaskedEditBox1;
    }
}