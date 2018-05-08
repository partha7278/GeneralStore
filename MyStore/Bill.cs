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
    public partial class Bill : Form
    {
        Code.Query_DB qd = new Code.Query_DB();
        int s;
        public Bill(int item,String user,int bil,int sid)
        {
            InitializeComponent();
            label4.Text = DateTime.Now.ToString();
            label3.Text = user;
            label7.Text = item.ToString();
            textBox4.Text = bil.ToString();
            s = sid;

        }

        private void Bill_Load(object sender, EventArgs e)
        {
            qd.GetSellProduct(dataGridView3,s);

        }
    }
}
