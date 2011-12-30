/*
© 2005, 2011 MAY-MART. All rights reserved.
The code is originally based on TSWizard library (http://www.codeproject.com/KB/dialog/tswizard.aspx).
*/

using System;

namespace MayMart.WinFormsWizard
{
    public class ShowStepEventArgs : EventArgs
    {
        public StepDirection Direction { get; private set; }

        public ShowStepEventArgs(StepDirection direction)
        {
            Direction = direction;
        }
    }
}

