using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ebookParser
{
    public partial class View : Form
    {
        Controller _c = new Controller();

        public View()
        {
            InitializeComponent();
        }

        private void selectDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog(this))
            {
                _c.setDirectory(folderBrowserDialog1.SelectedPath);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _c.parseDirectoryContent();
        }
    }
}
