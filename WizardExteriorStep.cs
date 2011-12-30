/*
© 2005, 2011 MAY-MART. All rights reserved.
The code is originally based on TSWizard library (http://www.codeproject.com/KB/dialog/tswizard.aspx).
*/

using System;

namespace MayMart.WinFormsWizard
{
    public partial class WizardExteriorStep : WizardStepBase
    {
        public WizardExteriorStep()
        {
            InitializeComponent();
            StepLayout = StepLayout.Exterior;
        }

        protected override void OnStepDescriptionChanged(EventArgs e)
        {
            labelDescription.Text = StepDescription;
            base.OnStepDescriptionChanged(e);
        }
    }
}

