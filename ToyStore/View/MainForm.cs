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
        ClientService clientService = ClientService.Instanse;
        public MainForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registration = new RegistrationForm();
            this.Visible = false;
            if (registration.ShowDialog() == DialogResult.OK)
            {

            }
            this.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogInAdminForm logInAdmin= new LogInAdminForm();
            this.Visible = false;
            if (logInAdmin.ShowDialog() == DialogResult.OK)
            {

            }
            this.Visible = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (await clientService.LogIn(textBox1.Text,textBox2.Text)==true)
            {
                new ClientForm().ShowDialog();
            }
            else MessageBox.Show("Try again");
            textBox1.Text = "";
            textBox2.Text = "";
            this.Visible = true;
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudyForm studyForm = new StudyForm();
            this.Visible = false;
            if (studyForm.ShowDialog() == DialogResult.OK)
            {

            }
            this.Visible = true;
        }
    }
}
