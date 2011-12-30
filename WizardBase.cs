/*
© 2005, 2011 MAY-MART. All rights reserved.
The code is originally based on TSWizard library (http://www.codeproject.com/KB/dialog/tswizard.aspx).
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MayMart.WinFormsWizard
{
    [DefaultEvent("LoadSteps")]
    public partial class WizardBase : Form
    {
        private Image _imageLogo;
        private Image _imageSideBarImage;
        private StepLayout _designerStepLayout;
        
        //private AllowClose _allowClose = AllowClose.AlwaysAllow;

        private string _firstStepKey;

        private WizardStepBase _currentStep;
        private readonly Dictionary<string, WizardStepBase> _steps;

        [Browsable(true)]
        [Category("Wizard")]
        [Description("Gets or sets the image that is displayed in the upper-right corner of the wizard.")]
        public Image Logo
        {
            get
            {
                return _imageLogo;
            }
            set
            {
                _imageLogo = value;
                OnLogoChanged(null, EventArgs.Empty);
            }
        }

        [Browsable(true)]
        [Category("Wizard")]
        [Description("Gets or sets the image that is displayed along the left side of the wizard, seen only on Exterior pages.")]
        public Image SideBarImage
        {
            get
            {
                return _imageSideBarImage;
            }
            set
            {
                _imageSideBarImage = value;
                OnSideBarImageChanged(null, EventArgs.Empty);
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Design")]
        [Description("Allows you to switch the design-time view from page layout to another.")]
        public StepLayout StepLayout
        {
            get
            {
                return _designerStepLayout;
            }
            set
            {
                if (DesignMode)
                {
                    _designerStepLayout = value;
                    UpdateLayout(_designerStepLayout);
                }
            }
        }

        public WizardBase()
        {
            InitializeComponent();
            _steps = new Dictionary<string, WizardStepBase>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode)
            {
                ConfigureWizard();
                
                if (string.IsNullOrEmpty(_firstStepKey))
                    throw new InvalidOperationException("Wizard's first step not set.");

                ResetAllSteps();
                GotoStepByKey(_firstStepKey, StepDirection.InitialStep);
            }
            else
                UpdateLayout(_designerStepLayout);
        }

        protected virtual void ConfigureWizard()
        {
            // Nothing
        }

        public void RegisterStep<T>(T step, string name = null)
            where T : WizardStepBase
        {
            if (step == null)
                throw new ArgumentNullException("step");

            string key = GetStepKey<T>(name);

            if (_steps.ContainsKey(key))
                throw new InvalidOperationException("The step already registered.");

            _steps[key] = step;
            step.Wizard = this;
        }

        public void SetFirstStep<T>(string name = null)
            where T : WizardStepBase
        {
            _firstStepKey = GetStepKey<T>(name);
        }

        public WizardStepBase GetStep<T>(string name = null)
            where T : WizardStepBase
        {
            return _steps[GetStepKey<T>(name)];
        }

        public static string GetStepKey<T>(string name = null)
            where T : WizardStepBase
        {
            return string.Format("{0}${1}", typeof(T).Name, name);
        }

        public void ResetAllSteps()
        {
            foreach (var step in _steps.Values)
            {
                step.FireResetStepEvent();
            }
        }

        public void GotoNext()
        {
            if (_currentStep.NextStepMode != NextStepMode.Next || _currentStep.NextStepEnabled == false)
                throw new InvalidOperationException("Next step disabled.");

            GotoStepByKey(_currentStep.NextStepKey, StepDirection.NextStep);
        }

        public void Finish()
        {
            if (_currentStep.NextStepMode != NextStepMode.Finish || _currentStep.NextStepEnabled == false)
                throw new InvalidOperationException("Finish disabled.");

            DialogResult = DialogResult.OK;
            Close();
        }

        public void GotoBack()
        {
            GotoStepByKey(_currentStep.PreviousStepKey, StepDirection.PreviousStep);
        }

        public void GotoStep<T>(string name = null, StepDirection direction = StepDirection.Jump)
            where T : WizardStepBase
        {
            GotoStepByKey(GetStepKey<T>(name), direction);
        }

        private bool _callingFromPreview;
        private bool _haveBeenCalledFromPreview;

        private void GotoStepByKey(string key, StepDirection direction)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            if (!_steps.ContainsKey(key))
                throw new InvalidOperationException("The step is not registered.");

            WizardStepBase step = _steps[key];

            // Giving ability to preview current step change

            if (!_callingFromPreview)
            {
                try
                {
                    _callingFromPreview = true;

                    PreviewStepChange(_currentStep, step, direction);
                }
                finally
                {
                    _callingFromPreview = false;
                }
            }

            // Cancelling original step change if it was already changed in PreviewStepChange

            if (!_callingFromPreview && _haveBeenCalledFromPreview)
            {
                _haveBeenCalledFromPreview = false;
                return;
            }

            // Changing step

            try
            {
                SuspendLayout();

                try
                {
                    if (_currentStep != null)
                        DetatchStep();

                    _currentStep = step;
                    AttachStep(direction);
                }
                finally
                {
                    ResumeLayout(true);
                }
            }
            finally
            {
                _haveBeenCalledFromPreview = _callingFromPreview;
            }
        }

        protected virtual void PreviewStepChange(WizardStepBase stepFrom, WizardStepBase stepTo, StepDirection direction)
        {
            // Nothing
        }

        protected virtual void UpdateLayout(StepLayout layout)
        {
            if (!Enum.IsDefined(typeof(StepLayout), StepLayout))
                throw new InvalidEnumArgumentException("layout", (int)layout, typeof(StepLayout));

            SuspendLayout();

            try
            {
                switch (layout)
                {
                    case StepLayout.Interior:
                        wizardTop.Visible = true;
                        wizardTop.Dock = DockStyle.Top;
                        wizardTop.Height = 0x40;
                        topLine.Visible = true;
                        topLine.Dock = DockStyle.Top;
                        sidePanel.Visible = false;
                        panelStep.Dock = DockStyle.Fill;
                        panelStep.DockPadding.All = 8;
                        BackColor = SystemColors.Control;
                        panelStep.BackColor = SystemColors.Control;
                        break;

                    case StepLayout.Exterior:
                        wizardTop.Visible = false;
                        topLine.Visible = false;
                        panelStep.BackColor = Color.White;
                        panelStep.Dock = DockStyle.Fill;
                        sidePanel.Visible = true;
                        sidePanel.Dock = DockStyle.Left;
                        sidePanel.Width = 160;
                        break;
                }

                panelStep.BringToFront();
            }
            finally
            {
                ResumeLayout();
            }
        }

        private void AttachStep(StepDirection direction)
        {
            _currentStep.StepTitleChanged += OnStepTitleChanged;
            _currentStep.StepDescriptionChanged += OnStepDescriptionChanged;
            _currentStep.NextStepChanged += OnNextStepChanged;
            _currentStep.PreviousStepChanged += OnPreviousStepChanged;
            _currentStep.CanBeCancelledChanged += OnCanBeCancelledChanged;
            _currentStep.PageLayoutChanged += OnStepLayoutChanged;
            _currentStep.LogoChanged += OnLogoChanged;
            _currentStep.SideBarImageChanged += OnSideBarImageChanged;

            OnStepTitleChanged(this, EventArgs.Empty);
            OnStepDescriptionChanged(this, EventArgs.Empty);

            _currentStep.Dock = DockStyle.Fill;
            panelStep.Controls.Add(_currentStep);

            OnNextStepChanged(this, EventArgs.Empty);
            OnPreviousStepChanged(this, EventArgs.Empty);
            OnCanBeCancelledChanged(this, EventArgs.Empty);
            OnStepLayoutChanged(this, EventArgs.Empty);
            OnLogoChanged(this, EventArgs.Empty);
            OnSideBarImageChanged(this, EventArgs.Empty);

            _currentStep.FireShowEvent(new ShowStepEventArgs(direction));
        }

        private void DetatchStep()
        {
            _currentStep.StepTitleChanged -= OnStepTitleChanged;
            _currentStep.StepDescriptionChanged -= OnStepDescriptionChanged;
            _currentStep.NextStepChanged -= OnNextStepChanged;
            _currentStep.PreviousStepChanged -= OnPreviousStepChanged;
            _currentStep.CanBeCancelledChanged -= OnCanBeCancelledChanged;
            _currentStep.PageLayoutChanged -= OnStepLayoutChanged;
            _currentStep.LogoChanged -= OnLogoChanged;
            _currentStep.SideBarImageChanged -= OnSideBarImageChanged;

            panelStep.Controls.Remove(_currentStep);
        }

        private void OnButtonNextClick(object sender, EventArgs e)
        {
            if (!_currentStep.NextStepEnabled)
                return;

            if (_currentStep.NextStepMode == NextStepMode.Next)
            {
                _currentStep.NextClicked();
            }
            else
                _currentStep.FinishClicked();
        }

        private void OnButtonBackClick(object sender, EventArgs e)
        {
            _currentStep.BackClicked();
        }

        private void OnButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            if (!Modal)
                Close();
        }

        //private bool AskToClose()
        //{
        //    return (MessageBox.Show("Do you wish to quit the wizard now?\r\nYour changes won't be saved if you do", "Exit wizard?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        //}

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                if (_currentStep.CanBeCancelled)
                {
                    //if (AllowClose == AllowClose.Ask)
                    //    e.Cancel = !AskToClose();
                }
                else
                    e.Cancel = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (((_currentStep != null) && !_currentStep.CanBeCancelled) && (DialogResult == DialogResult.None))
            {
                e.Cancel = true;
            }
            else
            {
                if (_currentStep != null)
                {
                    _currentStep.OnFormClosing(e);
                }
                base.OnFormClosing(e);
            }
        }

        private void OnLogoChanged(object sender, EventArgs e)
        {
            if ((_currentStep == null) || (_currentStep.StepLogo == null))
            {
                pictureBoxLogo.Image = _imageLogo;
            }
            else
                pictureBoxLogo.Image = _currentStep.StepLogo;
        }

        private void OnSideBarImageChanged(object sender, EventArgs e)
        {
            if ((_currentStep == null) || (_currentStep.SideBarImage == null))
            {
                sidePanel.BackgroundImage = _imageSideBarImage;
            }
            else
                sidePanel.BackgroundImage = _currentStep.SideBarImage;
        }

        private void OnNextStepChanged(object sender, EventArgs e)
        {
            buttonNext.Text = _currentStep.NextStepMode == NextStepMode.Next ? "&Далее >" : "&Готово";
            buttonNext.Enabled = _currentStep.NextStepEnabled;
        }

        private void OnPreviousStepChanged(object sender, EventArgs e)
        {
            buttonBack.Enabled = !string.IsNullOrEmpty(_currentStep.PreviousStepKey);
        }

        private void OnCanBeCancelledChanged(object sender, EventArgs e)
        {
            buttonCancel.Enabled = _currentStep.CanBeCancelled;
        }

        private void OnStepLayoutChanged(object sender, EventArgs e)
        {
            UpdateLayout(_currentStep.StepLayout);
        }

        private void OnStepTitleChanged(object o, EventArgs e)
        {
            labelTitle.Text = _currentStep.StepTitle;
        }

        private void OnStepDescriptionChanged(object o, EventArgs e)
        {
            labelDescription.Text = _currentStep.StepDescription;
        }
    }
}

