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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ToyStore.View
{
    public partial class StudyForm : Form
    {
        CompanyService companyService = CompanyService.Instance;
        ToyService toyService = ToyService.Instance;
        SaleService saleService = SaleService.Instance;
        public StudyForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var toys = await toyService.GetAllToys();
            var sales = await saleService.GetAllSales();
            listBox1.Items.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    toys.OrderBy(t => t.DateRelease.Date).ToList().ForEach(t => listBox1.Items.Add(t));
                    break;
                case 1:
                    toys.OrderBy(t => t.Company.Name).ToList().ForEach(t => listBox1.Items.Add(t));
                    break;
                case 2:
                    toys.OrderBy(t => t.Weight).ToList().ForEach(t => listBox1.Items.Add(t));
                    break;
                case 3:
                    toys.OrderBy(t => t.Price).ToList().ForEach(t => listBox1.Items.Add(t));
                    break;                
                case 4:
                    sales.OrderBy(s => s.DateSale).ToList().ForEach(s => listBox1.Items.Add(s));
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var selectedCompany = comboBox2.SelectedItem as Company;
            if (selectedCompany == null) return;
            selectedCompany.Toys.ToList().ForEach(c => listBox1.Items.Add(c));

        }

        private async void StudyForm_Load(object sender, EventArgs e)
        {
            var companys = await companyService.GetAllCompanys();
            companys.ForEach(c => { comboBox2.Items.Add(c); comboBox4.Items.Add(c); comboBox5.Items.Add(c); });
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;            
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var toys = await toyService.GetAllToys();
            toys.Where(t => t.DateRelease == dateTimePicker1.Value.Date).ToList().ForEach(t => listBox1.Items.Add(t));
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var toys = await toyService.GetAllToys();
            toys.ForEach(t => listBox1.Items.Add(t));
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            var toys = await toyService.GetAllToys();
                        
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    label2.Text = $"Самый дорогой вид игрушек" + toys.FirstOrDefault(t => t.Price == toys.Max(p => p.Price));                    
                    break;
                case 1:
                    label2.Text = $"Самый дешевый вид игрушек" + toys.FirstOrDefault(t => t.Price == toys.Min(p => p.Price));
                    break;
                case 2:                   
                    label2.Text = Environment.NewLine + "средняя стоимость игрушек для 1-3 лет = " + toys.Where(t => t.AgeOfChildrens == "1-3").Average(t => t.Price);

                    label2.Text += Environment.NewLine + "средняя стоимость игрушек для 3-5 лет = " + toys.Where(t => t.AgeOfChildrens == "3-5").Average(t => t.Price);

                    label2.Text += Environment.NewLine + "средняя стоимость игрушек для 5-7 лет = " + toys.Where(t => t.AgeOfChildrens == "5-7").Average(t => t.Price);

                    label2.Text += Environment.NewLine + "средняя стоимость игрушек для 7-10 лет = " + toys.Where(t => t.AgeOfChildrens == "7-10").Average(t => t.Price);

                    label2.Text += Environment.NewLine + "средняя стоимость игрушек для 10+ лет = " + toys.Where(t => t.AgeOfChildrens == "10+").Average(t => t.Price);

                    label2.Text += Environment.NewLine + "Общая средняя стоимость игрушек = "+ toys.Average(t=>t.Price);
                    break;                    
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var toys = await toyService.GetAllToys();
            toys.Where(t=>t.Price>=numericUpDown1.Value && t.Price<=numericUpDown2.Value).ToList().ForEach(t => listBox1.Items.Add(t));
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var toys = await toyService.GetAllToys();
            var selectedCompany = comboBox4.SelectedItem as Company;
            toys.Where(t => t.Weight >= (double)numericUpDown3.Value && t.Weight <= (double)numericUpDown4.Value && t.Company.ToString() == selectedCompany.ToString())
                .ToList().ForEach(t => listBox1.Items.Add(t));
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            var sales = await saleService.GetAllSales();
            var toys = await toyService.GetAllToys();
            Dictionary<string,int> counts = new Dictionary<string,int>();
            foreach (var toy in toys) 
            {
                if (counts.ContainsKey(toy.Name)) continue;
                else counts.Add(toy.Name, 0);
                foreach (var sale in sales)
                {                    
                    if (toy.Name==sale.ToyName)
                    {
                        counts[toy.Name] += sale.Amount; 
                    }                    
                }                
            }
            var res = counts.Values.Max();
            foreach(var test in counts)
            {
                if(test.Value == res)
                label2.Text += "Самая продаваемая игрушка - " + toys.FirstOrDefault(t=>t.Name==test.Key)+". Продано: "+test.Value + "шт" + Environment.NewLine;
            } 
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var toys =await toyService.GetAllToys();
            var companys = await companyService.GetAllCompanys();
            var selectedCompany = comboBox5.SelectedItem as Company;
            var price = toys.Where(t => t.Company.Name == selectedCompany.Name).Average(t => t.Price);
            toys.Where(t=>t.Price>price).ToList().ForEach(t => listBox1.Items.Add(t));
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var toys = await toyService.GetAllToys();            
            var sales = await saleService.GetAllSales();
            sales = sales.Where(s => s.DateSale.Date >= dateTimePicker2.Value.Date && s.DateSale.Date <= dateTimePicker3.Value.Date).ToList();
            List<decimal> price= new List<decimal>();
            foreach (var t in toys) 
            {               
                sales.Where(s => t.Name == s.ToyName).ToList().ForEach(s =>
                {
                    int count = 0;
                    while (count < s.Amount)
                    {
                        price.Add(t.Price);
                        count++;
                    }
                });
            }
            label2.Text = "Средняя стоимость игрушек проданных в данном промежутке: " + price.Average();
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var toys = await toyService.GetAllToys();
            var sales = await saleService.GetAllSales();
            List<Toy> toyList = new List<Toy>();

            switch (comboBox6.SelectedIndex)
            {
                case 0:                    
                    toys.Where(t => t.AgeOfChildrens == "1-3").ToList().ForEach(t =>
                    {
                        sales.Where(s => t.Name == s.ToyName).ToList().ForEach(s => toyList.Add(new Toy
                        {
                            Name = t.Name,
                            AgeOfChildrens = t.AgeOfChildrens,
                            Price = t.Price,
                            Amount = s.Amount,
                            Weight = t.Weight,
                            DateRelease = t.DateRelease
                        }));
                    });
                    label2.Text = ""+ toyList.FirstOrDefault(t=>t.Amount==toyList.Max(s => s.Amount));
                    break;
                case 1:
                    toys.Where(t => t.AgeOfChildrens == "3-5").ToList().ForEach(t =>
                    {
                        sales.Where(s => t.Name == s.ToyName).ToList().ForEach(s => toyList.Add(new Toy
                        {
                            Name = t.Name,
                            AgeOfChildrens = t.AgeOfChildrens,
                            Price = t.Price,
                            Amount = s.Amount,
                            Weight = t.Weight,
                            DateRelease = t.DateRelease                            
                        }));                    
                    });
                    label2.Text = "" + toyList.FirstOrDefault(t => t.Amount == toyList.Max(s => s.Amount));
                    break;
                case 2:
                    toys.Where(t => t.AgeOfChildrens == "5-7").ToList().ForEach(t =>
                    {
                        sales.Where(s => t.Name == s.ToyName).ToList().ForEach(s => toyList.Add(new Toy
                        {
                            Name = t.Name,
                            AgeOfChildrens = t.AgeOfChildrens,
                            Price = t.Price,
                            Amount = s.Amount,
                            Weight = t.Weight,
                            DateRelease = t.DateRelease
                        }));
                    });
                    label2.Text = "" + toyList.FirstOrDefault(t => t.Amount == toyList.Max(s => s.Amount));
                    break;
                case 3:
                    toys.Where(t => t.AgeOfChildrens == "7-10").ToList().ForEach(t =>
                    {
                        sales.Where(s => t.Name == s.ToyName).ToList().ForEach(s => toyList.Add(new Toy
                        {
                            Name = t.Name,
                            AgeOfChildrens = t.AgeOfChildrens,
                            Price = t.Price,
                            Amount = s.Amount,
                            Weight = t.Weight,
                            DateRelease = t.DateRelease
                        }));
                    });
                    label2.Text = "" + toyList.FirstOrDefault(t => t.Amount == toyList.Max(s => s.Amount));
                    break;
                case 4:
                    toys.Where(t => t.AgeOfChildrens == "10+").ToList().ForEach(t =>
                    {
                        sales.Where(s => t.Name == s.ToyName).ToList().ForEach(s => toyList.Add(new Toy
                        {
                            Name = t.Name,
                            AgeOfChildrens = t.AgeOfChildrens,
                            Price = t.Price,
                            Amount = s.Amount,
                            Weight = t.Weight,
                            DateRelease = t.DateRelease
                        }));
                    });
                    label2.Text = "" + toyList.FirstOrDefault(t => t.Amount == toyList.Max(s => s.Amount));
                    break;
            }            
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text)) return;
            var toys = await toyService.GetAllToys();
            var toy = toys.FirstOrDefault(t => t.Name == textBox2.Text && t.Company.Country == textBox3.Text);
            toys.Where(t => t.Price > toy.Price && t.Company.Name == textBox1.Text).ToList().ForEach(t => listBox1.Items.Add(t));
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            label15.Text = "";
            var toys = await toyService.GetAllToys();
            int countToys = 0;
            int count = 0;
            switch (comboBox7.SelectedIndex)
            {

                case 0:
                    countToys = toys.Where(t => t.AgeOfChildrens == "1-3").Count();
                    count =  toys.Where(t => t.AgeOfChildrens == "1-3" && t.Price<numericUpDown5.Value).Count();
                    label15.Text = "Доля игрушек для 1-3 лет меньше заданной стоимости : " + 100 * count / countToys + "%";
                    break;                    
                case 1:
                    countToys = toys.Where(t => t.AgeOfChildrens == "3-5").Count();
                    count = toys.Where(t => t.AgeOfChildrens == "3-5" && t.Price < numericUpDown5.Value).Count();
                    label15.Text = "Доля игрушек для 3-5 лет меньше заданной стоимости : " + 100 * count / countToys + "%";
                    break; 
                case 2:
                    countToys = toys.Where(t => t.AgeOfChildrens == "5-7").Count();
                    count = toys.Where(t => t.AgeOfChildrens == "5-7" && t.Price < numericUpDown5.Value).Count();
                    label15.Text = "Доля игрушек для 5-7 лет меньше заданной стоимости : " + 100 * count / countToys + "%";
                    break;                    
                case 3:
                    countToys = toys.Where(t => t.AgeOfChildrens == "7-10").Count();
                    count = toys.Where(t => t.AgeOfChildrens == "7-10" && t.Price < numericUpDown5.Value).Count();
                    label15.Text = "Доля игрушек для 7-10 лет меньше заданной стоимости : " + 100 * count / countToys + "%";
                    break;                    
                case 4:
                    countToys = toys.Where(t => t.AgeOfChildrens == "10+").Count();
                    count = toys.Where(t => t.AgeOfChildrens == "10+" && t.Price < numericUpDown5.Value).Count();
                    label15.Text = "Доля игрушек для 10+ лет меньше заданной стоимости : " + 100 * count / countToys + "%";
                    break;                    
                case 5:
                    countToys = toys.Count();
                    count = toys.Where(t => t.Price < numericUpDown5.Value).Count();
                    label15.Text = "Доля игрушек меньше заданной стоимости : " + 100 * count / countToys + "%";
                    break;
            }
            
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            label15.Text = "";
            var sales = await saleService.GetAllSales();
            int countSaleToys = 0;
            int countSaleToys2 = 0;
            sales.ForEach(s => countSaleToys+=s.Amount);
            sales.Where(s=>s.DateSale.Date>=dateTimePicker4.Value.Date && s.DateSale.Date <= dateTimePicker5.Value.Date).ToList().ForEach(s => countSaleToys2 += s.Amount);
            label15.Text = "Доля игрушек проданных за заданный период : " + 100 * countSaleToys2 / countSaleToys + "%";
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            label15.Text = "";
            if (string.IsNullOrEmpty(textBox4.Text)) return;
            var toys = await toyService.GetAllToys();
            int countToys = 1;
            int countToys2 = 1;
            int countToys3 = 1;
            int allCountToys = toys.Count();
            if (toys.Where(t => t.Company.Name == textBox4.Text && t.Price < numericUpDown6.Value).Count() > 0)
             countToys = toys.Where(t => t.Company.Name == textBox4.Text && t.Price < numericUpDown6.Value).Count();
            if (toys.Where(t => t.Company.Name == textBox4.Text).Count() > 0)
                countToys3 = toys.Where(t => t.Company.Name == textBox4.Text).Count();
            if (toys.Where(t => t.Price < numericUpDown6.Value).Count()>0) 
                countToys2 = toys.Where(t => t.Price < numericUpDown6.Value).Count();
            label15.Text = "Доля игрушек поступивших от заданного поставщика чья стоимость ниже заданной : " + 100 *  countToys / countToys3 + "%" +
                "Доля игрушек чья стоимость ниже заданной : " + 100 * countToys2 / allCountToys + "%";
        }
    }
}
