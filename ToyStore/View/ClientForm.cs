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
    public partial class ClientForm : Form
    {
        ToyService toyService = ToyService.Instance;
        SaleService saleService = SaleService.Instance;
        decimal summ;
        List<Toy> cart = new List<Toy>();
        public ClientForm()
        {
            InitializeComponent();
            listBox2.MouseDoubleClick += ListBox2_MouseDoubleClick;
            label1.Text = "";
        }

        private void ListBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
             UpdateForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Toy selectedToy = listBox1.SelectedItem as Toy;
            if (selectedToy == null) return;            
            cart.Add(new Toy {
                Id = selectedToy.Id,
                Name =selectedToy.Name,
                AgeOfChildrens = selectedToy.AgeOfChildrens,
                DateRelease=selectedToy.DateRelease,
                Company = selectedToy.Company,
                Price = selectedToy.Price,
                Weight =selectedToy.Weight,
                Amount= (int)numericUpDown1.Value                
            });
            listBox2.Items.Add(cart.LastOrDefault());
            summ += cart.LastOrDefault().Price * cart.LastOrDefault().Amount;
            label1.Text = $"{summ} $";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            foreach (var toy in cart)
            {
                await toyService.SubtractionAmountToy(toy.Id, toy.Amount);
                await saleService.AddSale(new Sales
                {
                    DateSale = DateTime.Now,
                    Amount = toy.Amount,
                    ToyName = toy.Name
                });
            }              
            listBox2.Items.Clear();
            summ = 0;
            this.DialogResult = DialogResult.OK;
        }       
        private async void UpdateForm()
        {
            var toys = await toyService.GetAllToys();
            toys.ForEach(t => listBox1.Items.Add(t));
        }
    }
}
