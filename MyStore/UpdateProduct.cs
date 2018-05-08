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
    public partial class UpdateProduct : Form
    {
        Code.Query_DB qd = new Code.Query_DB();
        public UpdateProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PName.Text != "")
            {
                if (qd.UpdateProduct(PName.Text, PPrice.Text, PQuantity.Text, Convert.ToInt32(label6.Text)))
                {
                    MessageBox.Show("Update Sucessfully");
                    qd.GetProduct(dataGridView1);
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
        }


        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            qd.GetProduct(dataGridView1);
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            qd.GetProductBySearch(dataGridView1,Search.Text);
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           PName.Text= dataGridView1.SelectedCells[0].Value.ToString();
           PPrice.Text = dataGridView1.SelectedCells[2].Value.ToString();
           PQuantity.Text = dataGridView1.SelectedCells[1].Value.ToString();
           label6.Text = dataGridView1.SelectedCells[3].Value.ToString();
        }
    }
}
