using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace MyStore.Code
{

    public class Query_DB
    {
        BussinessLogic bl = new BussinessLogic();

        public int ID { 
            get;
            set;
        }
        public String EMAIL
        {
            get;
            set;
        }
        public String PASSWORD
        {
            get;
            set;
        }
        public int TYPE
        {
            get;
            set;
        }

        public bool VerifyUser(Query_DB qdb)
        {
            bool temp = false;
            string query = string.Format("select count(*) from Admin where Email='{0}' and Password = '{1}'", qdb.EMAIL, qdb.PASSWORD);
            OleDbDataReader rec = bl.SelectQuery(query);
            while (rec.Read())
            {
                if (rec[0].ToString().Equals("1"))
                {
                    temp = true;
                }
            }
            return temp;
        }

        

        public Query_DB GetUserDetails(Query_DB cdb)
        {

            string query = string.Format("select ID,Email,Password,Type from Admin where Email='{0}' and Password = '{1}'", cdb.EMAIL, cdb.PASSWORD);
            OleDbDataReader rec = bl.SelectQuery(query);

            while (rec.Read())
            {
                if (!rec[0].ToString().Equals(" ") && Convert.ToInt32(rec[0].ToString()) >= 1)
                {
                    Query_DB utb = new Query_DB();
                    utb.ID = Convert.ToInt32(rec[0].ToString());
                    utb.EMAIL = rec[1].ToString();
                    
                    utb.PASSWORD = rec[2].ToString();
                    
                    utb.TYPE = Convert.ToInt32(rec[3].ToString());
                    return utb;
                }
            }
            return null;
        }

        public bool CheckUser(String email)
        {
            bool temp = false;
            string query = string.Format("select count(*) from UserData where UEmail= '{0}' ", email);
            OleDbDataReader rec = bl.SelectQuery(query);
            while (rec.Read())
            {
                if (Convert.ToInt32((rec[0].ToString())) >= 1)
                {
                    temp = true;
                }

            }
            return temp;
        }



        public int CheckUserExist(String name,String mobile)
        {
            
            string query = string.Format("select ID from UserData where UName= '{0}' and UMobile='{1}' ", name,mobile);
            OleDbDataReader rec = bl.SelectQuery(query);
            while (rec.Read())
            {
                if (Convert.ToInt32((rec[0].ToString())) >= 1)
                {
                    return Convert.ToInt32(rec[0].ToString());
                }
                else {
                    return 0;
                }
            }
            return 0;
        }


        public int GetMaxID(String tab)
        {

            String query = String.Format("Select Max(id) From {0}", tab);
            OleDbDataReader rec = bl.SelectQuery(query);
            while (rec.Read())
            {
                if (!rec[0].ToString().Equals(""))
                {
                    return Convert.ToInt32(rec[0].ToString());
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }


        public bool CreateUser(String email, String name, String mobile, String address, String gender)
        {

            bool temp = false;
            String query = String.Format("insert into UserData values({0}+1,'{1}','{2}','{3}','{4}','{5}')",GetMaxID("UserData"), email,name,mobile,address,gender);
            if (bl.NonQuery(query) == 1)
            {
                temp = true;
            }
            return temp;
        }


        public bool ChangePassword(Query_DB cdb)
        {
            bool temp = false;
            string query = string.Format("update Admin set [Password]='{0}' where [ID]={1}", cdb.PASSWORD, cdb.ID);
            if (bl.NonQuery(query) == 1)
            {
                temp = true;
            }
            return temp;
        }


        public bool CreateSell(String date,int uid,int discount,int total,int aby)
        {

            bool temp = false;
            String query = String.Format("insert into Sell values({0}+1,'{1}',{2},{3},{4},{5})", GetMaxID("Sell"),date,uid,discount,total,aby);
            if (bl.NonQuery(query) == 1)
            {
                temp = true;
            }
            return temp;
        }





        public bool CreateSellProduct(int sid, int pid, int qty, int price)
        {

            bool temp = false;
            String query = String.Format("insert into SellProduct values({0}+1,{1},{2},{3},{4})", GetMaxID("SellProduct"), sid, pid,qty,price);
            if (bl.NonQuery(query) == 1)
            {
                temp = true;
            }
            return temp;
        }



        public bool AddProduct(String name,int price,int qty) {

            String query = String.Format("insert into Product values({0}+1,'{1}',{2},{3})",GetMaxID("Product"), name, price, qty);
            if (bl.NonQuery(query) == 1) {
                return true;
            }
            return false;
        }

        public void GetProduct(DataGridView dg)
        {
            string query = "select PName,PPrice,PQuantity,ID as pid from Product";
            bl.filldataGrid(dg, query);
        }

        public void GetProductBySearch(DataGridView dg,String se)
        {
            string query = "select PName,PPrice,PQuantity,ID as pid from Product where PName like('%" + se + "%')";
            bl.filldataGrid(dg, query);
        }

        public void GetSell(DataGridView dg)
        {
            string query = "select UName,Date,Discount,Total,Sell.ID as pid,Email as ad from Sell,UserData,Admin  where Sell.Uid=UserData.ID and Admin.ID=Sell.ABy";
            bl.filldataGrid(dg, query);
        }

        public void GetSaleBySearch(DataGridView dg,String se)
        {
            string query = "select UName,Date,Discount,Total,Sell.ID as pid,Email as ad from Sell,UserData,Admin  where Sell.Uid=UserData.ID and Admin.ID=Sell.ABy and UName like('%" + se + "%')";
            bl.filldataGrid(dg, query);
        }

        public void GetUserSell(DataGridView dg,int id)
        {
            string query = "select PName,Quantity,Price,(Price*Quantity) as total from SellProduct,Product  where SellProduct.Productid=Product.ID and Sellid="+ id +"";
            bl.filldataGrid(dg, query);
        }

        public void GetUserSaleBySearch(DataGridView dg,int id, String se)
        {
            string query = "select PName,Quantity,Price,(Price*Quantity) as total from SellProduct,Product  where SellProduct.Productid=Product.ID and Sellid=" + id + " and PName like('%" + se + "%')";
            bl.filldataGrid(dg, query);
        }

        public void GetUser(DataGridView dg)
        {
            string query = "select UName,UMobile from UserData";
            bl.filldataGrid(dg, query);
        }

        public void GetUserBySearch(DataGridView dg,String ae)
        {
            string query = "select UName,UMobile from UserData where UName like ('%"+ae+"%')";
            bl.filldataGrid(dg, query);
        }

        public void GetSellProduct(DataGridView dg,int sid)
        {
            string query = "select PName,Quantity,Price,(Quantity*Price) as total from SellProduct,Product where SellProduct.Sellid=" + sid + " and SellProduct.Productid=Product.ID";
            bl.filldataGrid(dg, query);
        }

        public bool UpdateProduct(String name,String price,String qty,int id) {

            string query = string.Format("update Product set [PName]='{0}',[PPrice]={1},[PQuantity]={2} where ID={3}", name, price, qty,id);
            if (bl.NonQuery(query) == 1)
            {
                return true;
            }

            return false;
        }


    }
}
