namespace MayMart.WinFormsWizard
{
    public partial class WizardExteriorStep
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label labelDescription;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.labelDescription.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0xcc);
            this.labelDescription.Location = new System.Drawing.Point(8, 8);
            this.labelDescription.BackColor = System.Drawing.SystemColors.Window;
            this.labelDescription.Size = new System.Drawing.Size(428, 48);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Enter Step Description Here";
            base.Controls.Add(this.labelDescription);
            // 
            // WizardExteriorStep
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Name = "WizardExteriorStep";
            this.Size = new System.Drawing.Size(444, 417);
            this.ResumeLayout(false);
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
