using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MayMart.WinFormsWizard
{
    public partial class WizardStepBase
    {
        private Container components;

        private void InitializeComponent()
        {
            this.components = new Container();
            base.SuspendLayout();
            this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xcc);
            base.Name = "BaseStep";
            base.Size = new Size(0x225, 290);
            base.ResumeLayout(false);
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
