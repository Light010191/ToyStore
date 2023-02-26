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
    public partial class RegistrationForm : Form
    {
        ClientService clientService = ClientService.Instanse;
        public RegistrationForm()
        {
            InitializeComponent();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await clientService.AddObject(new Client
            {
                Name = textBox1.Text,
                Email = textBox2.Text,
                Login = textBox3.Text,
                Password = textBox4.Text
            });
            this.DialogResult = DialogResult.OK;
        }
    }
}
