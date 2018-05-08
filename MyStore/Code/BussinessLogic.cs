using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace MyStore
{
    class BussinessLogic
    {
        string con = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        OleDbConnection cn;
        OleDbCommand cmd;
        void openConnection()
        {
            cn = new OleDbConnection(con);
            cn.Open();
        }
        void closeConnection()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        public OleDbDataReader SelectQuery(String query)
        {
            openConnection();
            cmd = new OleDbCommand(query, cn);
            return cmd.ExecuteReader();
        }
        public int NonQuery(String query)
        {
            openConnection();
            cmd = new OleDbCommand(query, cn);
            int temp = cmd.ExecuteNonQuery();
            closeConnection();
            return temp;
        }
        public void FillComboBox(ComboBox cb, string query)
        {
            openConnection();
            OleDbDataReader rec = SelectQuery(query);
            while (rec.Read())
            {
                cb.Items.Add(rec[0].ToString());
            }
        }
        public void filldataGrid(DataGridView dg, String query)
        {
            openConnection();
            cmd = new OleDbCommand(query, cn);
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dg.DataSource = ds.Tables[0];


        }

    }
}

