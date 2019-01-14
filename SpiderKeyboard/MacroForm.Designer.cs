namespace SpiderKeyboard
{
    partial class MacroForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 130);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type your macro.\r\nAllowed characters are:\r\nA - Z\r\n0 - 9\r\nArrows\r\nShift, CapsLock," +
    " Tab\r\nCtrl, Alt\r\nEnter, Space, Backspace, Canc, Esc\r\n\r\nTouch paddle or close for" +
    "m to end recording macro.";
            // 
            // MacroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MacroForm";
            this.Text = "MacroForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MacroForm_FormClosing);
            this.Load += new System.EventHandler(this.MacroForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MacroForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}