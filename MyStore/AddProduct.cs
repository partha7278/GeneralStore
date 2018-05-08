using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyStore
{
    public partial class AddProduct : Form
    {
        Code.Query_DB qd = new Code.Query_DB();
        public AddProduct()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PName.Text = "";
            PPrice.Text = "";
            PQuantity.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (qd.AddProduct(PName.Text, Convert.ToInt32(PPrice.Text), Convert.ToInt32(PQuantity.Text)))
            {
                PName.Text = "";
                PPrice.Text = "";
                PQuantity.Text = "";
                MessageBox.Show("Product add Sucessfuly");

            }
            else {
                MessageBox.Show("Something Gone Wrong");
            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
