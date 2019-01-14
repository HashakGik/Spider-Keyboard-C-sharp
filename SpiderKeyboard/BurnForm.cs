using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Ports;

namespace SpiderKeyboard
{
    /// <summary>
    /// Firmware burining form. Runs avrdude on a separate process and reports its output.
    /// </summary>
    public partial class BurnForm : Form
    {
        public BurnForm()
        {
            InitializeComponent();

            this.comboBox2.SelectedIndex = 0;

            foreach (string s in SerialPort.GetPortNames())
                this.comboBox1.Items.Add(s);

            if (this.comboBox1.Items.Count > 0)
            {
                this.button1.Enabled = true;
                this.comboBox1.SelectedIndex = 0;
            }
            else
                this.button1.Enabled = false;
        }

        /// <summary>
        /// OK button event handler. Since the operation is dangerous, asks to confirm the burning process before starting it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string micro = "";
            string file = "deps/hex/";
            int baud = 0;
            DialogResult r = MessageBox.Show("You are about to burn the Spider Keyer firmware on an Arduino Nano. The operation cannot be undone and you might render your Arduino Nano unusable. Are you sure?", "Burn firmware", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                // There are three possible versions of Arduino Nano and its clones, each with a different firmware to be burned and different avrdude parameters.
                switch (this.comboBox2.SelectedIndex)
                {
                    case 0: // 328
                        micro = "atmega328p";
                        baud = 115200;
                        file += "328P/";
                        break; // 328 old
                    case 1:
                        micro = "atmega328p";
                        baud = 57600;
                        file += "328Pold/";
                        break;
                    case 2: // 168
                        micro = "atmega168p";
                        baud = 19200;
                        file += "168/";
                        break;
                }

                // Apparently the "SpiderKeyer.ino.with_bootloader.eightanaloginputs.hex" file does NOT include a bootloader and it will require an ISP to program the microprocessor again.
                file += "SpiderKeyer.ino.eightanaloginputs.hex";

                Process p = new System.Diagnostics.Process();
                ProcessStartInfo si = new ProcessStartInfo();

                si.CreateNoWindow = true;
                si.RedirectStandardOutput = true;
                si.RedirectStandardError = true;
                si.UseShellExecute = false;
                si.Arguments = "-Cdeps/avrdude.conf -v -p" + micro + " -carduino -P" + this.comboBox1.SelectedItem + " -b" + baud + " -D -Uflash:w:" + file + ":i";
                si.FileName = "deps/avrdude.exe";

                p.StartInfo = si;

                this.Cursor = Cursors.WaitCursor;

                p.Start();

               p.WaitForExit();

                this.Cursor = Cursors.Default;

                // avrdude exit code is NOT related to the burning outcome, so there is no need to check it.

                this.textBox1.Text = p.StandardOutput.ReadToEnd();
                this.textBox1.Text += p.StandardError.ReadToEnd();
            }
        }
    }
}
