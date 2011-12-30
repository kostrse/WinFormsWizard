/*
© 2005, 2011 MAY-MART. All rights reserved.
The code is originally based on TSWizard library (http://www.codeproject.com/KB/dialog/tswizard.aspx).
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MayMart.WinFormsWizard
{
    [DefaultEvent("ShowStep")]
    public partial class WizardStepBase : UserControl
    {
        private static readonly object _eventResetStep = new object();
        private static readonly object _eventShowStep = new object();
        private static readonly object _eventFormClosing = new object();
        private static readonly object _eventLogoChanged = new object();
        private static readonly object _eventNextStepChanged = new object();
        private static readonly object _eventStepLayoutChanged = new object();
        private static readonly object _eventPreviousStepChanged = new object();
        private static readonly object _eventCanBeCancelledChanged = new object();
        private static readonly object _eventSideBarImageChanged = new object();
        private static readonly object _eventStepDescriptionChanged = new object();
        private static readonly object _eventStepTitleChanged = new object();
        private static readonly object _eventValidateStep = new object();
        
        private Image _imageStepLogo;
        private Image _sideBarImage;
        
        private StepLayout _stepLayout;

        private string _stepTitle;
        private string _stepDescription;

        private string _nextStepKey;
        private bool _nextStepEnabled;

        private bool _canBeCancelled = true;

        [Browsable(false)]
        public WizardBase Wizard { get; set; }

        [Browsable(true)]
        [Category("Wizard Step")]
        [Description("Gets or sets the title text that will be displayed in the white portion above the step.")]
        [DefaultValue("Step Title")]
        public string StepTitle
        {
            get
            {
                return _stepTitle;
            }
            set
            {
                _stepTitle = value;
                OnStepTitleChanged(EventArgs.Empty);
            }
        }

        [Browsable(true)]
        [Category("Wizard Step")]
        [Description("Gets or sets the description text that will be displayed in the white portion above the step.")]
        public string StepDescription
        {
            get
            {
                return _stepDescription;
            }
            set
            {
                _stepDescription = value;
                OnStepDescriptionChanged(EventArgs.Empty);
            }
        }

        [Browsable(true)]
        [Category("Wizard Step")]
        [Description("Gets or sets the custom logo for this step.")]
        [DefaultValue(null)]
        public Image StepLogo
        {
            get
            {
                return _imageStepLogo;
            }
            set
            {
                _imageStepLogo = value;
                OnLogoChanged(EventArgs.Empty);
            }
        }

        [Browsable(true)]
        [Category("Wizard Step")]
        [Description("Gets or sets the image to display in the sidebar for exterior pages.")]
        [DefaultValue(null)]
        public Image SideBarImage
        {
            get
            {
                return _sideBarImage;
            }
            set
            {
                _sideBarImage = value;
                OnSideBarImageChanged(EventArgs.Empty);
            }
        }

        [Browsable(false)]
        public NextStepMode NextStepMode { get; private set; }

        [Browsable(false)]
        public string NextStepKey
        {
            get
            {
                return NextStepMode == NextStepMode.Next ? _nextStepKey : null;
            }
        }

        [Browsable(false)]
        public bool NextStepEnabled
        {
            get
            {
                return _nextStepEnabled && (NextStepMode == NextStepMode.Finish || !string.IsNullOrEmpty(_nextStepKey));
            }
        }

        [Browsable(false)]
        public string PreviousStepKey { get; private set; }

        [Browsable(true)]
        [Category("Wizard Step")]
        [Description("Gets or sets whether this step can be cancelled/closed by user.")]
        [DefaultValue(true)]
        public bool CanBeCancelled
        {
            get
            {
                return _canBeCancelled;
            }
            set
            {
                _canBeCancelled = value;
                OnCanBeCancelledChanged(EventArgs.Empty);
            }
        }

        [Browsable(false)]
        public StepLayout StepLayout
        {
            get
            {
                return _stepLayout;
            }
            set
            {
                _stepLayout = value;
                OnStepLayoutChanged(EventArgs.Empty);
            }
        }

        [Description("Fired when closing form"), Category("Wizard Step"), Browsable(true)]
        public event FormClosingEventHandler FormClosing
        {
            add
            {
                Events.AddHandler(_eventFormClosing, value);
            }
            remove
            {
                Events.RemoveHandler(_eventFormClosing, value);
            }
        }

        [Browsable(true), Category("Wizard Step"), Description("Fired when the StepLogo property has changed")]
        public event EventHandler LogoChanged
        {
            add
            {
                Events.AddHandler(_eventLogoChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_eventLogoChanged, value);
            }
        }

        [Browsable(true)]
        [Category("Wizard Step")]
        [Description("Fired when the NextStep property has changed.")]
        public event EventHandler NextStepChanged
        {
            add
            {
                Events.AddHandler(_eventNextStepChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_eventNextStepChanged, value);
            }
        }

        [Browsable(true)]
        [Category("Wizard Step")]
        [Description("Fired when the PreviousStep property has changed.")]
        public event EventHandler PreviousStepChanged
        {
            add
            {
                Events.AddHandler(_eventPreviousStepChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_eventPreviousStepChanged, value);
            }
        }

        [Browsable(true)]
        [Category("Wizard Step")]
        [Description("Fired when the CanBeCancelled property has changed.")]
        public event EventHandler CanBeCancelledChanged
        {
            add
            {
                Events.AddHandler(_eventCanBeCancelledChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_eventCanBeCancelledChanged, value);
            }
        }

        [Browsable(true), Category("Wizard"), Description("Fired when the StepLayout property has changed")]
        public event EventHandler PageLayoutChanged
        {
            add
            {
                Events.AddHandler(_eventStepLayoutChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_eventStepLayoutChanged, value);
            }
        }

        [Browsable(true), Category("Wizard"), Description("Fired when the step needs to reset itself, this is fired when the wizard is reset and when the wizard is first shown")]
        public event EventHandler ResetStep
        {
            add
            {
                Events.AddHandler(_eventResetStep, value);
            }
            remove
            {
                Events.RemoveHandler(_eventResetStep, value);
            }
        }

        [Category("Wizard"), Browsable(true), Description("Fired every time the step is shown in the wizard")]
        public event ShowStepEventHandler ShowStep
        {
            add
            {
                Events.AddHandler(_eventShowStep, value);
            }
            remove
            {
                Events.RemoveHandler(_eventShowStep, value);
            }
        }

        [Category("Wizard Step"), Browsable(true), Description("Fired when the SideBarImage property has changed")]
        public event EventHandler SideBarImageChanged
        {
            add
            {
                Events.AddHandler(_eventSideBarImageChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_eventSideBarImageChanged, value);
            }
        }

        [Category("Wizard Step"), Browsable(true), Description("Fired when the StepTitle property has changed")]
        public event EventHandler StepTitleChanged
        {
            add
            {
                Events.AddHandler(_eventStepTitleChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_eventStepTitleChanged, value);
            }
        }

        [Category("Wizard Step"), Description("Fired when the StepDescription property has changed"), Browsable(true)]
        public event EventHandler StepDescriptionChanged
        {
            add
            {
                Events.AddHandler(_eventStepDescriptionChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_eventStepDescriptionChanged, value);
            }
        }


        [Browsable(true), Category("Wizard Step"), Description("Fired when moving to the next step")]
        public event CancelEventHandler ValidateStep
        {
            add
            {
                Events.AddHandler(_eventValidateStep, value);
            }
            remove
            {
                Events.RemoveHandler(_eventValidateStep, value);
            }
        }

        public WizardStepBase()
        {
            InitializeComponent();
        }

        public T GetWizard<T>()
            where T : WizardBase
        {
            return (T)Wizard;
        }

        public void SetNextStep<T>(string name = null)
            where T : WizardStepBase
        {
            NextStepMode = NextStepMode.Next;

            _nextStepKey = WizardBase.GetStepKey<T>(name);
            _nextStepEnabled = true;

            OnNextStepChanged(EventArgs.Empty);
        }

        public void DisableNextStep()
        {
            NextStepMode = NextStepMode.Next;
            _nextStepEnabled = false;

            OnNextStepChanged(EventArgs.Empty);
        }

        public void SetFinishStep()
        {
            NextStepMode = NextStepMode.Finish;
            _nextStepEnabled = true;

            OnNextStepChanged(EventArgs.Empty);
        }

        public void DisableFinishStep()
        {
            NextStepMode = NextStepMode.Finish;
            _nextStepEnabled = false;

            OnNextStepChanged(EventArgs.Empty);
        }

        public void SetPreviousStep<T>(string name = null)
            where T : WizardStepBase
        {
            PreviousStepKey = WizardBase.GetStepKey<T>(name);

            OnPreviousStepChanged(EventArgs.Empty);
        }

        public void DisablePreviousStep()
        {
            PreviousStepKey = null;

            OnPreviousStepChanged(EventArgs.Empty);
        }

        internal void FireResetStepEvent()
        {
            OnResetStep(EventArgs.Empty);
        }

        internal void FireShowEvent(ShowStepEventArgs e)
        {
            OnShowStep(e);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal virtual void OnFormClosing(FormClosingEventArgs e)
        {
            FormClosingEventHandler handler = (FormClosingEventHandler) Events[_eventFormClosing];
            
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnLogoChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) Events[_eventLogoChanged];

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnNextStepChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) Events[_eventNextStepChanged];

            if (handler != null)
                handler(this, e);
        }

        protected void OnCanBeCancelledChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[_eventCanBeCancelledChanged];

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnStepLayoutChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) Events[_eventStepLayoutChanged];

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnPreviousStepChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) Events[_eventPreviousStepChanged];

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnResetStep(EventArgs e)
        {
            EventHandler handler = (EventHandler) Events[_eventResetStep];

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnShowStep(ShowStepEventArgs e)
        {
            ShowStepEventHandler handler = (ShowStepEventHandler) Events[_eventShowStep];

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnStepTitleChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[_eventStepTitleChanged];

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnStepDescriptionChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[_eventStepDescriptionChanged];

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnSideBarImageChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) Events[_eventSideBarImageChanged];

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnValidateStep(CancelEventArgs e)
        {
            CancelEventHandler handler = (CancelEventHandler) Events[_eventValidateStep];

            if (handler != null)
                handler(this, e);
        }

        internal void NextClicked()
        {
            OnNext();
        }

        internal void FinishClicked()
        {
            OnFinish();
        }

        internal void BackClicked()
        {
            OnBack();
        }

        protected virtual void OnNext()
        {
            CancelEventArgs e = new CancelEventArgs();

            OnValidateStep(e);

            if (!e.Cancel)
                Wizard.GotoNext();
        }

        protected virtual void OnFinish()
        {
            CancelEventArgs e = new CancelEventArgs();

            OnValidateStep(e);

            if (!e.Cancel)
                Wizard.Finish();
        }

        protected virtual void OnBack()
        {
            Wizard.GotoBack();
        }
    }
}

