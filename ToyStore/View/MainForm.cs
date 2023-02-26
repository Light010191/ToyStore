using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToyStore.Controller;
using ToyStore.Model;

namespace ToyStore.View
{
    public partial class MainForm : Form
    {
        RegistrationForm registration;
        AdminForm admin;
        ClientService clientService = ClientService.Instanse;
        public MainForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registration = new RegistrationForm();
            this.Visible = false;
            if (registration.ShowDialog() == DialogResult.OK)
            {

            }
            this.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            admin = new AdminForm();
            this.Visible = false;
            if (admin.ShowDialog() == DialogResult.OK)
            {

            }
            this.Visible = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (await clientService.LogIn(textBox1.Text,textBox2.Text)==true)
            {
                new ClientForm().ShowDialog();
            }
            else MessageBox.Show("no");
        }
    }
}
