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
    public partial class ViewSale : Form
    {
        Code.Query_DB qd = new Code.Query_DB();
        public ViewSale()
        {
           
            InitializeComponent();
        }

        private void ViewSale_Load(object sender, EventArgs e)
        {
            qd.GetSell(dataGridView1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            qd.GetSaleBySearch(dataGridView1, textBox3.Text);
        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("hi hello");

            UserBuy ub = new UserBuy(dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString());
            ub.Show();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
