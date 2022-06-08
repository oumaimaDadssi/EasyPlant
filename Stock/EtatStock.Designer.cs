
namespace EasyPlants.Stock
{
    partial class EtatStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EtatStock));
            this.label1 = new System.Windows.Forms.Label();
            this.GridEtatStock = new Telerik.WinControls.UI.RadGridView();
            this.BtnImp = new Telerik.WinControls.UI.RadButton();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.GridEtatStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridEtatStock.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImp)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(420, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 51;
            this.label1.Text = "Etat Stock";
            // 
            // GridEtatStock
            // 
            this.GridEtatStock.BackColor = System.Drawing.SystemColors.Control;
            this.GridEtatStock.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically;
            this.GridEtatStock.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridEtatStock.EnableGestures = false;
            this.GridEtatStock.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridEtatStock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GridEtatStock.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridEtatStock.Location = new System.Drawing.Point(12, 52);
            // 
            // 
            // 
            this.GridEtatStock.MasterTemplate.AllowAddNewRow = false;
            this.GridEtatStock.MasterTemplate.AllowCellContextMenu = false;
            this.GridEtatStock.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.GridEtatStock.MasterTemplate.AllowColumnReorder = false;
            this.GridEtatStock.MasterTemplate.AllowDeleteRow = false;
            this.GridEtatStock.MasterTemplate.AllowEditRow = false;
            this.GridEtatStock.MasterTemplate.AllowSearchRow = true;
            this.GridEtatStock.MasterTemplate.EnableAlternatingRowColor = true;
            this.GridEtatStock.MasterTemplate.MultiSelect = true;
            this.GridEtatStock.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridEtatStock.Name = "GridEtatStock";
            this.GridEtatStock.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.GridEtatStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridEtatStock.Size = new System.Drawing.Size(945, 391);
            this.GridEtatStock.TabIndex = 49;
            // 
            // BtnImp
            // 
            this.BtnImp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnImp.Image = ((System.Drawing.Image)(resources.GetObject("BtnImp.Image")));
            this.BtnImp.Location = new System.Drawing.Point(719, 449);
            this.BtnImp.Name = "BtnImp";
            this.BtnImp.Size = new System.Drawing.Size(238, 48);
            this.BtnImp.TabIndex = 50;
            this.BtnImp.Text = "Imprimer Etat Stock";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(12, 9);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(945, 37);
            this.panel5.TabIndex = 52;
            // 
            // EtatStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 511);
            this.Controls.Add(this.BtnImp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GridEtatStock);
            this.Controls.Add(this.panel5);
            this.Name = "EtatStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etat du Stock";
            this.Load += new System.EventHandler(this.EtatStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridEtatStock.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridEtatStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView GridEtatStock;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton BtnImp;
        private System.Windows.Forms.Panel panel5;
    }
}