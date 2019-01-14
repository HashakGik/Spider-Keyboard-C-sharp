using System;
using System.Windows.Forms;

namespace SpiderKeyboard
{
    /// <summary>
    /// Macro recording form. Listens to keyboard inputs until a paddle key is pressed or the form is closed.
    /// </summary>
    public partial class MacroForm : Form
    {
        private int macroId;
        private SpiderController s;
        private string macro;
        public MacroForm(int id, SpiderController s)
        {
            this.macroId = id;
            this.macro = "";
            this.s = s;
            this.s.OnMacroInterrupt += CloseOnPaddle;

            InitializeComponent();
        }

        private void MacroForm_Load(object sender, EventArgs e)
        {
            this.Text = "Record macro " + (this.macroId + 1);
            this.s.StartRecording();
        }

        private void MacroForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string tmp;
            this.s.StopRecording();
            if (this.macro == "")
                MessageBox.Show("No macro was recorded");
            else
            {
                tmp = "Do you want to bind ";
                for (int i = 0; i <= this.macroId; i++)
                    tmp += ".";
                for (int i = this.macroId + 1; i < 6; i++)
                    tmp += "-";

                tmp += " with \"" + this.macro + "\"?";

                DialogResult d = MessageBox.Show(tmp, "Recorded macro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                    this.s.SetMacro(this.macroId, this.macro);
            }
        }

        private void CloseOnPaddle()
        {
            this.Invoke((MethodInvoker)delegate { this.Close(); });
        }

        /// <summary>
        /// Key up event handler. Decodes the key released and converts it into a string suitable for SendKeys.Send().
        /// Not all characters are supported.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MacroForm_KeyUp(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString();

            if (e.Control)
                this.macro += "^";
            if (e.Alt)
                this.macro += "%";
            if (e.Shift)
                this.macro += "+";

            if (key.Length == 1 && key[0] >= 'A' && key[0] <= 'Z')
                this.macro += key.ToLower();
            else if (key.StartsWith("D") || key.StartsWith("NumPad"))
                this.macro += key[key.Length - 1];
            else if (key == "Return")
                this.macro += "~";
            else if (key == "ShiftKey")
                this.macro += "+";
            else if (key == "Menu")
                this.macro += "%";
            else if (key == "ControlKey")
                this.macro += "^";
            else if (key == "Tab")
                this.macro += "{TAB}";
            else if (key == "Back")
                this.macro += "{BS}";
            else if (key == "Escape")
                this.macro += "{ESC}";
            else if (key == "Add")
                this.macro += "{ADD}";
            else if (key == "Subtract")
                this.macro += "{SUBTRACT}";
            else if (key == "Multiply")
                this.macro += "{MULTIPLY}";
            else if (key == "Divide")
                this.macro += "{DIVIDE}";
            else if (key == "NumLock")
                this.macro += "{NUMLOCK}";
            else if (key == "Up")
                this.macro += "{UP}";
            else if (key == "Down")
                this.macro += "{DOWN}";
            else if (key == "Left")
                this.macro += "{LEFT}";
            else if (key == "Right")
                this.macro += "{RIGHT}";
            else if (key == "Space")
                this.macro += " ";
            else if (key == "Del")
                this.macro += "{DEL}";
            else if (key == "CapsLock")
                this.macro += "{CAPSLOCK}";
        }
    }
}
