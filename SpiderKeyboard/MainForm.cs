using System;
using System.Windows.Forms;


namespace SpiderKeyboard
{
    /// <summary>
    /// Main form. Allows to set the SpiderKeyer's settings. When minimized, only a tray icon will be shown.
    /// From the menu can be recorded up to five macros and a brand new Arduino Nano can be burned with SpiderKeyer's firmware.
    /// 
    /// Settings and macros are stored permanently in the current user's settings.
    /// </summary>
    public partial class MainForm : Form
    {
        private SpiderController s;
        public MainForm()
        {
            this.s = new SpiderController();

            InitializeComponent();
            this.notifyIcon1.Icon = this.Icon;

            this.s.OnSpiderStatusChange += this.StatusChanged;

            this.toolStripStatusLabel1.Text = "Spider keyer not connected";

            this.notifyIcon1.Text = this.Text = Application.ProductName;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                this.notifyIcon1.Visible = false;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.s.Stop();

            this.notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            this.speedUpDown.Enabled = this.manualRadio.Checked;

            if (this.potRadio.Checked)
                this.s.SetSpeed(-1);

            Properties.Settings.Default.SpeedPot = this.potRadio.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = false;

            this.potRadio.Checked = Properties.Settings.Default.SpeedPot;
            this.manualRadio.Checked = !Properties.Settings.Default.SpeedPot;
            this.speedUpDown.Value = Properties.Settings.Default.Speed;
            this.tailUpDown.Value = Properties.Settings.Default.Tail;
            this.weightingUpDown.Value = Properties.Settings.Default.Weighting;
            this.sidetoneUpDown.Value = Properties.Settings.Default.Sidetone;
            this.iambicComboBox.SelectedIndex = (Properties.Settings.Default.Iambic)? 1 : 0;

            this.s.SetMacro(0, Properties.Settings.Default.Macro0);
            this.s.SetMacro(1, Properties.Settings.Default.Macro1);
            this.s.SetMacro(2, Properties.Settings.Default.Macro2);
            this.s.SetMacro(3, Properties.Settings.Default.Macro3);
            this.s.SetMacro(4, Properties.Settings.Default.Macro4);
        }

        private void StatusChanged(bool connected, string port)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (connected)
                    this.toolStripStatusLabel1.Text = "Spider keyer connected (" + port + ")";
                else
                    this.toolStripStatusLabel1.Text = "Spider keyer not connected";
            }
            );
        }

        private void sidetoneUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Sidetone = (int)this.sidetoneUpDown.Value;
            this.s.SetSidetone((int) this.sidetoneUpDown.Value);
            Properties.Settings.Default.Save();
        }

        private void iambicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Iambic = (this.iambicComboBox.SelectedIndex == 1);
            this.s.SetIambic((this.iambicComboBox.SelectedIndex == 1));
            Properties.Settings.Default.Save();
        }

        private void weightingUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Weighting = (int)this.weightingUpDown.Value;
            this.s.SetWeighting((int) this.weightingUpDown.Value);
            Properties.Settings.Default.Save();
        }

        private void tailUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Tail = (int)this.tailUpDown.Value;
            this.s.SetTailTime((int)this.tailUpDown.Value);
            Properties.Settings.Default.Save();
        }

        private void speedUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Speed = (int)this.speedUpDown.Value;
            this.s.SetSpeed((int)this.speedUpDown.Value);
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuMacro1_Click(object sender, EventArgs e)
        {
            MacroForm m = new MacroForm(0, this.s);

            m.ShowDialog();
            Properties.Settings.Default.Macro0 = this.s.GetMacro(0);
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuMacro2_Click(object sender, EventArgs e)
        {
            MacroForm m = new MacroForm(1, this.s);

            m.ShowDialog();
            Properties.Settings.Default.Macro0 = this.s.GetMacro(1);
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuMacro3_Click(object sender, EventArgs e)
        {
            MacroForm m = new MacroForm(2, this.s);

            m.ShowDialog();
            Properties.Settings.Default.Macro1 = this.s.GetMacro(2);
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuMacro4_Click(object sender, EventArgs e)
        {
            MacroForm m = new MacroForm(3, this.s);

            m.ShowDialog();
            Properties.Settings.Default.Macro2 = this.s.GetMacro(3);
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuMacro5_Click(object sender, EventArgs e)
        {
            MacroForm m = new MacroForm(4, this.s);

            m.ShowDialog();
            Properties.Settings.Default.Macro3 = this.s.GetMacro(4);
            Properties.Settings.Default.Save();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.Stop();
            BurnForm b = new BurnForm();
            b.ShowDialog();

            this.s.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
