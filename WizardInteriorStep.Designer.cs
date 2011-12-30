using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MayMart.WinFormsWizard
{
    public partial class WizardInteriorStep
    {
        private IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // WizardInteriorStep
            // 
            this.Name = "WizardInteriorStep";
            this.Size = new System.Drawing.Size(644, 417);
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
