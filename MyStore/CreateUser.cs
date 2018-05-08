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
    public partial class CreateUser : Form
    {
        Code.Query_DB qdb = new Code.Query_DB();
        public CreateUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UEmail.Text = "";
            UMobile.Text="";
            UAddress.Text = "";
            UName.Text = "";
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
                String EMAIL = UEmail.Text;
                if (!qdb.CheckUser(EMAIL))
                  {
                    String NAME = UName.Text;
                    String ADDRESS = UAddress.Text;
                    String MOBILE = UMobile.Text;
                    String GENDER=" ";
                    if (UMale.Checked) { GENDER = "Male"; }
                    if (UFemale.Checked) { GENDER = "Female"; }
                    
                    if (qdb.CreateUser(EMAIL, NAME, MOBILE, ADDRESS, GENDER))
                    {
                        MessageBox.Show("User Created");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("There is some problem in creating user");
                    }
                }
                else {
                    MessageBox.Show("User already Exist");
                }
            }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }
        

       
    }
}
