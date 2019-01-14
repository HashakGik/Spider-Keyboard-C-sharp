namespace SpiderKeyboard
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macro1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macro2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macro3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macro4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macro5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.speedUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.manualRadio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.potRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.iambicComboBox = new System.Windows.Forms.ComboBox();
            this.tailUpDown = new System.Windows.Forms.NumericUpDown();
            this.sidetoneUpDown = new System.Windows.Forms.NumericUpDown();
            this.weightingUpDown = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tailUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidetoneUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightingUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.recordMacroToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 98);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // recordMacroToolStripMenuItem
            // 
            this.recordMacroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.macro1ToolStripMenuItem,
            this.macro2ToolStripMenuItem,
            this.macro3ToolStripMenuItem,
            this.macro4ToolStripMenuItem,
            this.macro5ToolStripMenuItem});
            this.recordMacroToolStripMenuItem.Name = "recordMacroToolStripMenuItem";
            this.recordMacroToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.recordMacroToolStripMenuItem.Text = "Record macro";
            // 
            // macro1ToolStripMenuItem
            // 
            this.macro1ToolStripMenuItem.Name = "macro1ToolStripMenuItem";
            this.macro1ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.macro1ToolStripMenuItem.Text = "Macro 1 (.-----)";
            this.macro1ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuMacro1_Click);
            // 
            // macro2ToolStripMenuItem
            // 
            this.macro2ToolStripMenuItem.Name = "macro2ToolStripMenuItem";
            this.macro2ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.macro2ToolStripMenuItem.Text = "Macro 2 (..----)";
            this.macro2ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuMacro2_Click);
            // 
            // macro3ToolStripMenuItem
            // 
            this.macro3ToolStripMenuItem.Name = "macro3ToolStripMenuItem";
            this.macro3ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.macro3ToolStripMenuItem.Text = "Macro 3 (...---)";
            this.macro3ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuMacro3_Click);
            // 
            // macro4ToolStripMenuItem
            // 
            this.macro4ToolStripMenuItem.Name = "macro4ToolStripMenuItem";
            this.macro4ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.macro4ToolStripMenuItem.Text = "Macro 4 (....--)";
            this.macro4ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuMacro4_Click);
            // 
            // macro5ToolStripMenuItem
            // 
            this.macro5ToolStripMenuItem.Name = "macro5ToolStripMenuItem";
            this.macro5ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.macro5ToolStripMenuItem.Text = "Macro 5 (.....-)";
            this.macro5ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuMacro5_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.speedUpDown);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.manualRadio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.potRadio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.iambicComboBox);
            this.panel1.Controls.Add(this.tailUpDown);
            this.panel1.Controls.Add(this.sidetoneUpDown);
            this.panel1.Controls.Add(this.weightingUpDown);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 211);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 189);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(226, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(226, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerMacroToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // registerMacroToolStripMenuItem
            // 
            this.registerMacroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this.registerMacroToolStripMenuItem.Name = "registerMacroToolStripMenuItem";
            this.registerMacroToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.registerMacroToolStripMenuItem.Text = "&Record macro";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem3.Text = "Macro 1 (.-----)";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuMacro1_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem4.Text = "Macro 2 (..----)";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuMacro2_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem5.Text = "Macro 3 (...---)";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuMacro3_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem6.Text = "Macro 4 (....--)";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuMacro4_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem7.Text = "Macro 5 (.....-)";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuMacro5_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.optionsToolStripMenuItem.Text = "Burn firmware";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Iambic mode";
            // 
            // speedUpDown
            // 
            this.speedUpDown.Enabled = false;
            this.speedUpDown.Location = new System.Drawing.Point(94, 50);
            this.speedUpDown.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.speedUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.speedUpDown.Name = "speedUpDown";
            this.speedUpDown.Size = new System.Drawing.Size(120, 20);
            this.speedUpDown.TabIndex = 2;
            this.speedUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.speedUpDown.ValueChanged += new System.EventHandler(this.speedUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sidetone (Hz)";
            // 
            // manualRadio
            // 
            this.manualRadio.AutoSize = true;
            this.manualRadio.Location = new System.Drawing.Point(3, 50);
            this.manualRadio.Name = "manualRadio";
            this.manualRadio.Size = new System.Drawing.Size(92, 17);
            this.manualRadio.TabIndex = 1;
            this.manualRadio.Text = "Speed (WPM)";
            this.manualRadio.UseVisualStyleBackColor = true;
            this.manualRadio.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Weighting (%)";
            // 
            // potRadio
            // 
            this.potRadio.AutoSize = true;
            this.potRadio.Checked = true;
            this.potRadio.Location = new System.Drawing.Point(3, 27);
            this.potRadio.Name = "potRadio";
            this.potRadio.Size = new System.Drawing.Size(163, 17);
            this.potRadio.TabIndex = 0;
            this.potRadio.TabStop = true;
            this.potRadio.Text = "Speed set from potentiometer";
            this.potRadio.UseVisualStyleBackColor = true;
            this.potRadio.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tail time (ms)";
            // 
            // iambicComboBox
            // 
            this.iambicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iambicComboBox.FormattingEnabled = true;
            this.iambicComboBox.Items.AddRange(new object[] {
            "Curtis A",
            "Curtis B"});
            this.iambicComboBox.Location = new System.Drawing.Point(93, 161);
            this.iambicComboBox.Name = "iambicComboBox";
            this.iambicComboBox.Size = new System.Drawing.Size(121, 21);
            this.iambicComboBox.TabIndex = 4;
            this.iambicComboBox.SelectedIndexChanged += new System.EventHandler(this.iambicComboBox_SelectedIndexChanged);
            // 
            // tailUpDown
            // 
            this.tailUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tailUpDown.Location = new System.Drawing.Point(94, 80);
            this.tailUpDown.Maximum = new decimal(new int[] {
            1275,
            0,
            0,
            0});
            this.tailUpDown.Name = "tailUpDown";
            this.tailUpDown.Size = new System.Drawing.Size(120, 20);
            this.tailUpDown.TabIndex = 1;
            this.tailUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tailUpDown.ValueChanged += new System.EventHandler(this.tailUpDown_ValueChanged);
            // 
            // sidetoneUpDown
            // 
            this.sidetoneUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sidetoneUpDown.Location = new System.Drawing.Point(94, 134);
            this.sidetoneUpDown.Maximum = new decimal(new int[] {
            2550,
            0,
            0,
            0});
            this.sidetoneUpDown.Name = "sidetoneUpDown";
            this.sidetoneUpDown.Size = new System.Drawing.Size(120, 20);
            this.sidetoneUpDown.TabIndex = 3;
            this.sidetoneUpDown.Value = new decimal(new int[] {
            750,
            0,
            0,
            0});
            this.sidetoneUpDown.ValueChanged += new System.EventHandler(this.sidetoneUpDown_ValueChanged);
            // 
            // weightingUpDown
            // 
            this.weightingUpDown.Location = new System.Drawing.Point(94, 107);
            this.weightingUpDown.Name = "weightingUpDown";
            this.weightingUpDown.Size = new System.Drawing.Size(120, 20);
            this.weightingUpDown.TabIndex = 2;
            this.weightingUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.weightingUpDown.ValueChanged += new System.EventHandler(this.weightingUpDown_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 211);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tailUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidetoneUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightingUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown speedUpDown;
        private System.Windows.Forms.RadioButton manualRadio;
        private System.Windows.Forms.RadioButton potRadio;
        private System.Windows.Forms.NumericUpDown tailUpDown;
        private System.Windows.Forms.NumericUpDown weightingUpDown;
        private System.Windows.Forms.NumericUpDown sidetoneUpDown;
        private System.Windows.Forms.ComboBox iambicComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerMacroToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordMacroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem macro1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem macro2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem macro3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem macro4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem macro5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}

