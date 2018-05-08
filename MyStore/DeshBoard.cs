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
    public partial class DeshBoard : Form
    {
        Code.Query_DB pb = new Code.Query_DB();
        public DeshBoard(Code.Query_DB qd)
        {
            InitializeComponent();
            pb = qd;
        }

        private void DeshBoard_Load(object sender, EventArgs e)
        {
            pb.GetUser(dataGridView2);
            pb.GetProduct(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int user=pb.CheckUserExist(BName.Text, BMobile.Text);
            if (BName.Text != "" || BMobile.Text != "")
            {
                if (user > 0)
                {
                    if (pb.CreateSell(DateTime.Now.ToString(), user, Convert.ToInt32(label10.Text), Convert.ToInt32(label7.Text), pb.ID))
                    {
                        int b = 0;
                        int sid = pb.GetMaxID("Sell");
                        //String name;
                        int qty, price, pid;
                        foreach (DataGridViewRow p in dataGridView3.Rows)
                        {
                            // name= dataGridView3.Rows[b].Cells["PName"].Value.ToString();
                            qty = Convert.ToInt32(dataGridView3.Rows[b].Cells["PQty"].Value.ToString());
                            price = Convert.ToInt32(dataGridView3.Rows[b].Cells["PPrice"].Value.ToString());
                            //total=Convert.ToInt32(dataGridView3.Rows[b].Cells["Total"].Value.ToString());
                            pid = Convert.ToInt32(dataGridView3.Rows[b].Cells["pid"].Value.ToString());
                            if (pb.CreateSellProduct(sid, pid, qty, price))
                            {
                            }
                            else { MessageBox.Show("there is an erroe " + b); }
                            b++;
                        }
                        Bill bi = new Bill(b, BName.Text, (Convert.ToInt32(label7.Text)), sid);
                        bi.Show();
                        BName.Text = "";
                        BMobile.Text = "";
                        textBox5.Text = "0";
                        textBox4.Text = "0";
                        dataGridView3.Rows.Clear();
                        dataGridView3.Refresh();
                        label7.Text = "0";
                        minus.Text = "( 0 - 0 )";

                    }
                }
                else
                {
                    //String ot= "none";
                    if (pb.CreateUser(" ", BName.Text, BMobile.Text, " ", " "))
                    {
                        user = pb.CheckUserExist(BName.Text, BMobile.Text);
                        if (user > 0)
                        {
                            if (pb.CreateSell(DateTime.Now.ToString(), user, Convert.ToInt32(label10.Text), Convert.ToInt32(label7.Text), pb.ID))
                            {
                                int b = 0;
                                int sid = pb.GetMaxID("Sell");
                                //String name;
                                int qty, price, pid;
                                foreach (DataGridViewRow p in dataGridView3.Rows)
                                {
                                    // name= dataGridView3.Rows[b].Cells["PName"].Value.ToString();
                                    qty = Convert.ToInt32(dataGridView3.Rows[b].Cells["PQty"].Value.ToString());
                                    price = Convert.ToInt32(dataGridView3.Rows[b].Cells["PPrice"].Value.ToString());
                                    //total=Convert.ToInt32(dataGridView3.Rows[b].Cells["Total"].Value.ToString());
                                    pid = Convert.ToInt32(dataGridView3.Rows[b].Cells["pid"].Value.ToString());
                                    if (pb.CreateSellProduct(sid, pid, qty, price))
                                    {
                                    }
                                    else { MessageBox.Show("SellProduct insert Erroe " + b); }
                                    b++;
                                }
                                Bill bi = new Bill(b + 1, BName.Text, (Convert.ToInt32(label7.Text)), sid);
                                bi.Show();
                                BName.Text = "";
                                BMobile.Text = "";
                                textBox5.Text = "0";
                                textBox4.Text = "0";
                                dataGridView3.Rows.Clear();
                                dataGridView3.Refresh();
                                label7.Text = "0";
                                minus.Text = "( 0 - 0 )";
                            }

                        }


                    }
                }
            }
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUser cu = new CreateUser();
            cu.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword(pb);
            cp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateUser cu = new CreateUser();
            cu.Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProduct ap = new AddProduct();
            ap.Show();
        }

        private void viewSellToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewSale vs = new ViewSale();
            vs.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateProduct up = new UpdateProduct();
            up.Show();
        }

        private void BName_TextChanged(object sender, EventArgs e)
        {
            pb.GetUserBySearch(dataGridView2,BName.Text);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BName.Text=dataGridView2.SelectedCells[0].Value.ToString();
            BMobile.Text = dataGridView2.SelectedCells[1].Value.ToString(); 
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            pb.GetProductBySearch(dataGridView1, Search.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Search.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedCells[2].Value.ToString();
            label8.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
            label11.Text = dataGridView1.SelectedCells[3].Value.ToString();
            
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (Convert.ToInt32(textBox1.Text) > 0)
                {
                    label9.Text = (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text)).ToString();
                    string[] row = new string[] { Search.Text, textBox1.Text, textBox2.Text, label9.Text,label11.Text };
                    if ((Convert.ToInt32(textBox1.Text)) <= (Convert.ToInt32(label8.Text)))
                    {
                        dataGridView3.Rows.Add(row);

                        Search.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        int a = 0;
                        int total = 0;
                        foreach (DataGridViewRow pb in dataGridView3.Rows)
                        {
                            total += Convert.ToInt32(dataGridView3.Rows[a].Cells["Total"].Value.ToString());
                            a++;
                        }
                        textBox4.Text = total.ToString();
                        int btotal = Convert.ToInt32(textBox4.Text);
                        int discount = 0;
                        if (Convert.ToInt32(textBox5.Text) > 0)
                        {
                            discount = (int)((btotal * Convert.ToInt32(textBox5.Text)) / 100);
                        }
                        label10.Text = discount.ToString();
                        minus.Text = "( " + btotal.ToString() + " - " + discount.ToString() + " )";
                        label7.Text = (btotal - discount).ToString();

                    }
                    else
                    {
                        MessageBox.Show("Please select less Quantity than stock");
                    }
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView3.SelectedRows.Count > 0)
            {
                dataGridView3.Rows.RemoveAt(this.dataGridView3.SelectedRows[0].Index);
            }

            int a = 0;
            int total = 0;
            foreach (DataGridViewRow pb in dataGridView3.Rows)
            {
                total += Convert.ToInt32(dataGridView3.Rows[a].Cells["Total"].Value.ToString());
                a++;
            }
            textBox4.Text = total.ToString();
            int btotal = Convert.ToInt32(textBox4.Text);
            int discount = 0;
            if (Convert.ToInt32(textBox5.Text) > 0)
            {
                discount = (int)((btotal * Convert.ToInt32(textBox5.Text)) / 100);
            }
            label10.Text = discount.ToString();
            minus.Text = "( " + btotal.ToString() + " - " + discount.ToString() + " )";
            label7.Text = (btotal - discount).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
            minus.Text = "( 0 - 0 )";
            label7.Text = "0";
            textBox4.Text = "0";
            label10.Text ="0";

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int btotal = Convert.ToInt32(textBox4.Text);
            int discount = 0;
            if (textBox5.Text != "")
            {
                if (Convert.ToInt32(textBox5.Text) > 0)
                {
                    discount = (int)((btotal * Convert.ToInt32(textBox5.Text)) / 100);
                }
                minus.Text = "( " + btotal.ToString() + " - " + discount.ToString() + " )";
                label7.Text = (btotal - discount).ToString();
                label10.Text = discount.ToString();
            }
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contact c = new Contact();
            c.Show();
        }

   
    }
}
