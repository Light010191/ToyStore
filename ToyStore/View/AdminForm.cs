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
    public partial class AdminForm : Form
    {
        CompanyService companyService = CompanyService.Instance;
        ToyService toyService = ToyService.Instance;        
        public AdminForm()
        {
            InitializeComponent();
            this.Load += AdminForm_Load; 
        }

        private async void AdminForm_Load(object sender, EventArgs e)
        {
            UpdateToysForm();
            UpdateCompanysForm();
        }        

        private async void button2_Click(object sender, EventArgs e)
        {
            if (!IsCheckedTextbox()) return;
            await companyService.AddObject(new Company
            {
                Name = textBox1.Text,
                Country = textBox2.Text,
                Email = textBox3.Text
            });
            UpdateCompanysForm();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!IsCheckedTextbox()) return;
            Company updateCompany = listBox1.SelectedItem as Company;
            updateCompany.Name = textBox1.Text;
            updateCompany.Country = textBox2.Text;
            updateCompany.Email = textBox3.Text;            
            await companyService.UpdateObject(updateCompany);
            UpdateCompanysForm();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var company = comboBox2.SelectedItem as Company;
            await toyService.AddToy(new Toy
            {
                Name = textBox4.Text,
                Weight = (double)numericUpDown1.Value,
                Price = numericUpDown2.Value,
                DateRelease = dateTimePicker1.Value.Date,
                AgeOfChildren = comboBox3.SelectedItem.ToString(),
                Company = company,
                Amount = (int)numericUpDown3.Value
            }) ;
            UpdateToysForm();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var toy = listBox2.SelectedItem as Toy;
            if(toy == null) return;
            await toyService.UpdateAmountToy(toy,(int)numericUpDown4.Value);
            UpdateToysForm();
        }
        private async void UpdateCompanysForm()
        {
            listBox1.Items.Clear(); 
            var companys = await companyService.GetAllCompanys();
            companys.ForEach(c => listBox1.Items.Add(c));            
        }
        private async void UpdateToysForm()
        {            
            comboBox2.Items.Clear();
            listBox2.Items.Clear();

            var companys = await companyService.GetAllCompanys();
            companys.ForEach(c =>  comboBox2.Items.Add(c));

            var toys = await toyService.GetAllToys();
            toys.ForEach(t => listBox2.Items.Add(t));
        }
        private bool IsCheckedTextbox()
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text)) return false;
            return true;
        }

    }
}
