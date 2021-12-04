using System;
using System.Windows.Forms;

namespace IW4DumpHelperWinForms
{
    class ConsoleController
    {
        private TextBox CMD;

        public ConsoleController(TextBox cmdBox)
        {
            CMD = cmdBox;
            CMD.TextChanged += new EventHandler(OnTextChanged);
        }



        public void Clear(bool ShowInfo = false)
        {
            CMD.Text = "";
            if (ShowInfo)
            {
                MessageBox.Show("Console Cleared!", "Console Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Println(string text)
        {
            CMD.Text += text + "\r\n";
        }


        private void OnTextChanged(object sender, EventArgs e)
        {
            CMD.SelectionStart = CMD.Text.Length;
            CMD.ScrollToCaret();
        }
    }
}
