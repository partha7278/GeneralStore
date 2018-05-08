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
    public partial class ChangePassword : Form
    {
        Code.Query_DB qd = new Code.Query_DB();
        public ChangePassword(Code.Query_DB qdb)
        {
            InitializeComponent();
            qd = qdb;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OP.Text = "";
            NP.Text = "";
            NP2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (qd.PASSWORD == OP.Text)
            {
                if (NP.Text.Equals(NP2.Text))
                {
                    qd.PASSWORD = NP.Text;
                    if (qd.ChangePassword(qd))
                    {
                        MessageBox.Show("Password Changed Successfully");
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Password do not matched!!!!");
                    OP.Text = "";
                    NP.Text = "";
                    NP2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Incorrect Old PAssword");
                OP.Text = "";
                NP.Text = "";
                NP2.Text = "";
            }
        }
    }
}
