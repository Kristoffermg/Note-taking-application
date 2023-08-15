namespace Note_Taking_App
{
    partial class Form1
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
            this.NoteInput = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.HeaderNotes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // NoteInput
            // 
            this.NoteInput.Location = new System.Drawing.Point(281, 47);
            this.NoteInput.Name = "NoteInput";
            this.NoteInput.Size = new System.Drawing.Size(736, 542);
            this.NoteInput.TabIndex = 1;
            this.NoteInput.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 595);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // HeaderNotes
            // 
            this.HeaderNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HeaderNotes.Location = new System.Drawing.Point(12, 12);
            this.HeaderNotes.Name = "HeaderNotes";
            this.HeaderNotes.Size = new System.Drawing.Size(240, 577);
            this.HeaderNotes.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 645);
            this.Controls.Add(this.HeaderNotes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NoteInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderNotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox NoteInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView HeaderNotes;
    }
}

