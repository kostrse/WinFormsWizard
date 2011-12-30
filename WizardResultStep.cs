/*
© 2005, 2011 MAY-MART. All rights reserved.
The code is originally based on TSWizard library (http://www.codeproject.com/KB/dialog/tswizard.aspx).
*/

using System;
using MayMart.WinFormsWizard.Properties;

namespace MayMart.WinFormsWizard
{
    public partial class WizardResultStep : WizardExteriorStep
    {
        private bool _success = true;

        public bool Success
        {
            get
            {
                return _success;
            }
            set
            {
                pictureBoxSymbol.Image = value ? Resources.Complete : Resources.Warning;
                _success = value;
            }
        }

        public string MessageTitle
        {
            get
            {
                return labelMessageTitle.Text;
            }
            set
            {
                labelMessageTitle.Text = value;
            }
        }

        public string MessageDescription
        {
            get
            {
                return labelMessageDescription.Text;
            }
            set
            {
                labelMessageDescription.Text = value;
            }
        }

        public WizardResultStep()
        {
            InitializeComponent();
            Success = true;
        }
    }
}

