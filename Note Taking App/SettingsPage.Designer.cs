namespace Note_Taking_App
{
    partial class SettingsPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fontSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.fontSizeLabel = new System.Windows.Forms.Label();
            this.ThemeDropdown = new System.Windows.Forms.ComboBox();
            this.themeLabel = new System.Windows.Forms.Label();
            this.fontLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.fontDropdown = new System.Windows.Forms.ComboBox();
            this.applySettingsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // fontSizeNumeric
            // 
            this.fontSizeNumeric.Location = new System.Drawing.Point(67, 95);
            this.fontSizeNumeric.Name = "fontSizeNumeric";
            this.fontSizeNumeric.Size = new System.Drawing.Size(120, 20);
            this.fontSizeNumeric.TabIndex = 0;
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.Location = new System.Drawing.Point(12, 97);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(49, 13);
            this.fontSizeLabel.TabIndex = 1;
            this.fontSizeLabel.Text = "Font size";
            // 
            // ThemeDropdown
            // 
            this.ThemeDropdown.FormattingEnabled = true;
            this.ThemeDropdown.Items.AddRange(new object[] {
            "Bright",
            "Dark"});
            this.ThemeDropdown.Location = new System.Drawing.Point(67, 144);
            this.ThemeDropdown.Name = "ThemeDropdown";
            this.ThemeDropdown.Size = new System.Drawing.Size(121, 21);
            this.ThemeDropdown.TabIndex = 2;
            // 
            // themeLabel
            // 
            this.themeLabel.AutoSize = true;
            this.themeLabel.Location = new System.Drawing.Point(13, 144);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(40, 13);
            this.themeLabel.TabIndex = 3;
            this.themeLabel.Text = "Theme";
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(13, 45);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(28, 13);
            this.fontLabel.TabIndex = 4;
            this.fontLabel.Text = "Font";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Turquoise;
            this.topPanel.Location = new System.Drawing.Point(-5, -8);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(391, 16);
            this.topPanel.TabIndex = 5;
            // 
            // fontDropdown
            // 
            this.fontDropdown.FormattingEnabled = true;
            this.fontDropdown.Items.AddRange(new object[] {
            "Segoe UI",
            "Arial",
            "Century"});
            this.fontDropdown.Location = new System.Drawing.Point(66, 42);
            this.fontDropdown.Name = "fontDropdown";
            this.fontDropdown.Size = new System.Drawing.Size(121, 21);
            this.fontDropdown.TabIndex = 6;
            // 
            // applySettingsBtn
            // 
            this.applySettingsBtn.Location = new System.Drawing.Point(298, 268);
            this.applySettingsBtn.Name = "applySettingsBtn";
            this.applySettingsBtn.Size = new System.Drawing.Size(75, 23);
            this.applySettingsBtn.TabIndex = 7;
            this.applySettingsBtn.Text = "Apply";
            this.applySettingsBtn.UseVisualStyleBackColor = true;
            this.applySettingsBtn.Click += new System.EventHandler(this.applySettingsBtn_Click);
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 303);
            this.Controls.Add(this.applySettingsBtn);
            this.Controls.Add(this.fontDropdown);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.themeLabel);
            this.Controls.Add(this.ThemeDropdown);
            this.Controls.Add(this.fontSizeLabel);
            this.Controls.Add(this.fontSizeNumeric);
            this.Name = "SettingsPage";
            this.Text = "SettingsPage";
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown fontSizeNumeric;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.ComboBox ThemeDropdown;
        private System.Windows.Forms.Label themeLabel;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ComboBox fontDropdown;
        private System.Windows.Forms.Button applySettingsBtn;
    }
}