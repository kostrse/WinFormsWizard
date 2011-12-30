namespace MayMart.WinFormsWizard
{
    public partial class WizardResultStep
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label labelMessageDescription;
        private System.Windows.Forms.Label labelMessageTitle;
        private System.Windows.Forms.PictureBox pictureBoxSymbol;

        private void InitializeComponent()
        {
            this.labelMessageTitle = new System.Windows.Forms.Label();
            this.labelMessageDescription = new System.Windows.Forms.Label();
            this.pictureBoxSymbol = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSymbol)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMessageTitle
            // 
            this.labelMessageTitle.AutoSize = true;
            this.labelMessageTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMessageTitle.Location = new System.Drawing.Point(43, 150);
            this.labelMessageTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.labelMessageTitle.Name = "labelMessageTitle";
            this.labelMessageTitle.Size = new System.Drawing.Size(88, 13);
            this.labelMessageTitle.TabIndex = 2;
            this.labelMessageTitle.Text = "(нет данных)";
            // 
            // labelMessageDescription
            // 
            this.labelMessageDescription.Location = new System.Drawing.Point(43, 169);
            this.labelMessageDescription.Margin = new System.Windows.Forms.Padding(3, 0, 40, 0);
            this.labelMessageDescription.Name = "labelMessageDescription";
            this.labelMessageDescription.Size = new System.Drawing.Size(361, 132);
            this.labelMessageDescription.TabIndex = 3;
            this.labelMessageDescription.Text = "(нет данных)";
            // 
            // pictureBoxSymbol
            // 
            this.pictureBoxSymbol.Image = global::MayMart.WinFormsWizard.Properties.Resources.Complete;
            this.pictureBoxSymbol.Location = new System.Drawing.Point(12, 150);
            this.pictureBoxSymbol.Name = "pictureBoxSymbol";
            this.pictureBoxSymbol.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSymbol.TabIndex = 1;
            this.pictureBoxSymbol.TabStop = false;
            // 
            // WizardResultStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxSymbol);
            this.Controls.Add(this.labelMessageDescription);
            this.Controls.Add(this.labelMessageTitle);
            this.Name = "WizardResultStep";
            this.StepDescription = "(нет данных)";
            this.Controls.SetChildIndex(this.labelMessageTitle, 0);
            this.Controls.SetChildIndex(this.labelMessageDescription, 0);
            this.Controls.SetChildIndex(this.pictureBoxSymbol, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSymbol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
