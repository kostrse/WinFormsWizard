using MayMart.WinFormsWizard.Controls;

namespace MayMart.WinFormsWizard
{
    public partial class WizardBase
    {
        private System.ComponentModel.Container components;
        private System.Windows.Forms.Button buttonBack;
        private BevelLine bottomLine;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Panel panelStep;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelTitle;
        private BevelLine topLine;
        private System.Windows.Forms.Panel wizardTop;

        private void InitializeComponent()
        {
            this.wizardTop = new System.Windows.Forms.Panel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.bottomLine = new MayMart.WinFormsWizard.Controls.BevelLine();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.panelStep = new System.Windows.Forms.Panel();
            this.topLine = new MayMart.WinFormsWizard.Controls.BevelLine();
            this.wizardTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardTop
            // 
            this.wizardTop.BackColor = System.Drawing.SystemColors.Window;
            this.wizardTop.Controls.Add(this.labelDescription);
            this.wizardTop.Controls.Add(this.labelTitle);
            this.wizardTop.Controls.Add(this.pictureBoxLogo);
            this.wizardTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.wizardTop.Location = new System.Drawing.Point(0, 0);
            this.wizardTop.Name = "wizardTop";
            this.wizardTop.Size = new System.Drawing.Size(644, 64);
            this.wizardTop.TabIndex = 0;
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.Location = new System.Drawing.Point(16, 30);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(482, 28);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Step Description";
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(8, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(61, 13);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Step Title";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxLogo.Location = new System.Drawing.Point(504, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(140, 64);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLogo.TabIndex = 2;
            this.pictureBoxLogo.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(561, 9);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6, 3, 8, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Отмена";
            this.buttonCancel.Click += new System.EventHandler(this.OnButtonCancelClick);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.Location = new System.Drawing.Point(393, 9);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "< &Назад";
            this.buttonBack.Click += new System.EventHandler(this.OnButtonBackClick);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(474, 9);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(3, 3, 6, 8);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.Text = "&Далее >";
            this.buttonNext.Click += new System.EventHandler(this.OnButtonNextClick);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.bottomLine);
            this.bottomPanel.Controls.Add(this.buttonCancel);
            this.bottomPanel.Controls.Add(this.buttonBack);
            this.bottomPanel.Controls.Add(this.buttonNext);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 482);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(644, 40);
            this.bottomPanel.TabIndex = 8;
            // 
            // bottomLine
            // 
            this.bottomLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomLine.Location = new System.Drawing.Point(0, 0);
            this.bottomLine.Name = "bottomLine";
            this.bottomLine.Size = new System.Drawing.Size(644, 1);
            this.bottomLine.TabIndex = 2;
            this.bottomLine.Text = "lineFrame2";
            // 
            // sidePanel
            // 
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 65);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(200, 417);
            this.sidePanel.TabIndex = 9;
            this.sidePanel.Visible = false;
            // 
            // panelStep
            // 
            this.panelStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStep.Location = new System.Drawing.Point(200, 65);
            this.panelStep.Name = "panelStep";
            this.panelStep.Padding = new System.Windows.Forms.Padding(8);
            this.panelStep.Size = new System.Drawing.Size(444, 417);
            this.panelStep.TabIndex = 10;
            // 
            // topLine
            // 
            this.topLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLine.Location = new System.Drawing.Point(0, 64);
            this.topLine.Name = "topLine";
            this.topLine.Size = new System.Drawing.Size(644, 1);
            this.topLine.TabIndex = 1;
            this.topLine.Text = "lineFrame1";
            // 
            // WizardBase
            // 
            this.AcceptButton = this.buttonNext;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(644, 522);
            this.Controls.Add(this.panelStep);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topLine);
            this.Controls.Add(this.wizardTop);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(304, 232);
            this.Name = "WizardBase";
            this.ShowIcon = false;
            this.Text = "Wizard Title";
            this.wizardTop.ResumeLayout(false);
            this.wizardTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.bottomPanel.ResumeLayout(false);
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
