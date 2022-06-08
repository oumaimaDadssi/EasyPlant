
namespace EasyPlants.Paramétrage
{
    partial class Planning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Planning));
            this.GridPlanning = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BtnImprimerBCde = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.GridPlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPlanning.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimerBCde)).BeginInit();
            this.SuspendLayout();
            // 
            // GridPlanning
            // 
            this.GridPlanning.Location = new System.Drawing.Point(12, 64);
            // 
            // 
            // 
            this.GridPlanning.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridPlanning.Name = "GridPlanning";
            this.GridPlanning.Size = new System.Drawing.Size(1031, 431);
            this.GridPlanning.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(379, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Planning De Production ";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(12, 21);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1031, 37);
            this.panel6.TabIndex = 60;
            // 
            // BtnImprimerBCde
            // 
            this.BtnImprimerBCde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnImprimerBCde.Image = ((System.Drawing.Image)(resources.GetObject("BtnImprimerBCde.Image")));
            this.BtnImprimerBCde.Location = new System.Drawing.Point(833, 501);
            this.BtnImprimerBCde.Name = "BtnImprimerBCde";
            this.BtnImprimerBCde.Size = new System.Drawing.Size(210, 51);
            this.BtnImprimerBCde.TabIndex = 60;
            this.BtnImprimerBCde.Text = "Imprimer Planning ";
            this.BtnImprimerBCde.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // Planning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnImprimerBCde);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.GridPlanning);
            this.Name = "Planning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planning de Production";
            this.Load += new System.EventHandler(this.Planning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridPlanning.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPlanning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimerBCde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GridPlanning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private Telerik.WinControls.UI.RadButton BtnImprimerBCde;
    }
}