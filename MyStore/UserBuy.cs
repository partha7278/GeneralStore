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
    public partial class UserBuy : Form
    {
        Code.Query_DB qd = new Code.Query_DB();
        String cus;
        String dat;
        int id;
        public UserBuy(String customer,String date,String ida)
        {
            InitializeComponent();
            cus = customer;
            dat = date;
            id = Convert.ToInt32(ida);
        }

        private void UserBuy_Load(object sender, EventArgs e)
        {
            qd.GetUserSell(dataGridView1,id);
            label4.Text=cus;
            label2.Text = dat;
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            qd.GetUserSaleBySearch(dataGridView1, id,textBox3.Text);
        }
    }
}
