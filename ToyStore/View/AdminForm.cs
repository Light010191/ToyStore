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
        SaleService saleService = SaleService.Instance;
        public AdminForm()
        {
            InitializeComponent();
            this.Load += AdminForm_Load;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            dateTimePicker1.MaxDate=DateTime.Now;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            Company selectedCompany = listBox1.SelectedItem as Company;
            selectedCompany.Toys.ToList().ForEach(t=>listBox3.Items.Add(t));
        }

        private async void AdminForm_Load(object sender, EventArgs e)
        {           
            UpdateForm();
            var sales =await saleService.GetAllSales();
            sales.ForEach(s=>listBox4.Items.Add(s));
        }        

        private async void button2_Click(object sender, EventArgs e)
        {
            if (!IsCheckedTextboxCompanys()) return;
            await companyService.AddObject(new Company
            {
                Name = textBox1.Text,
                Country = textBox2.Text,
                Email = textBox3.Text
            });
            UpdateForm();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!IsCheckedTextboxCompanys()) return;
            Company updateCompany = listBox1.SelectedItem as Company;
            updateCompany.Name = textBox1.Text;
            updateCompany.Country = textBox2.Text;
            updateCompany.Email = textBox3.Text;            
            await companyService.UpdateObject(updateCompany);
            UpdateForm();
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
                AgeOfChildrens = comboBox3.SelectedItem.ToString(),
                Amount = (int)numericUpDown3.Value
            },company.Id) ;
            UpdateForm();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var toy = listBox2.SelectedItem as Toy;
            if(toy == null) return;
            await toyService.AdditionAmountToy(toy,(int)numericUpDown4.Value);
            UpdateForm();
        }       
        private async void UpdateForm()
        {            
            comboBox2.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.Clear();

            var companys = await companyService.GetAllCompanys();
            companys.ForEach(c => { listBox1.Items.Add(c); comboBox2.Items.Add(c);});                       

            var toys = await toyService.GetAllToys();
            toys.ForEach(t => listBox2.Items.Add(t));
        }
        private bool IsCheckedTextboxCompanys()
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text)) return false;
            return true;
        }

    }
}
