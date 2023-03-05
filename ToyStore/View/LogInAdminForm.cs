using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToyStore.View
{
    public partial class LogInAdminForm : Form
    {
        public LogInAdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            this.Visible = false;
            if (admin.ShowDialog() == DialogResult.Cancel)
            {
                this.DialogResult= DialogResult.Cancel;
            }
            this.Visible = true;
        }
    }
}
