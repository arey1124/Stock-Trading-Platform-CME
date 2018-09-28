using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StockTradingPlatform.Models;

namespace StockTradingPlatform.Admin
{
    public partial class AllTransactions : System.Web.UI.Page
    {
        StpDBEntities ob = new StpDBEntities();
        public string fname { get; set; }
        public string lname { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*var user = Session["user"] as tblUser;
            this.fname = user.fname;
            this.lname = user.lname;
            DataTable dt = new DataTable();
            DataRow dr;
            DataColumn dc;
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "Transaction Id";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "Buyer Req Id";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "Buyer Name";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "Seller Req Id";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "Seller Name";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "Stock";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Double");
            dc.ColumnName = "Buy Price (Rs.)";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Double");
            dc.ColumnName = "Sell Price (Rs.)";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "Quantity";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.DateTime");
            dc.ColumnName = "Time";
            dt.Columns.Add(dc);
            int i = 0;
            foreach (tblTransactions item in ob.tblTransactions)
            {
                dr = dt.NewRow();
                dr["Transaction Id"] = item.transactionId;
                dr["Buyer Req Id"] = item.buyerReqId;
                dr["Buyer Name"] = ob.getUserName(item.buyerReqId).FirstOrDefault().ToString();
                dr["Seller Req Id"] = item.sellerReqId;
                dr["Seller Name"] = ob.getUserName(item.sellerReqId).FirstOrDefault().ToString();
                dr["Stock"] = ob.getStockName(item.buyerReqId).FirstOrDefault().ToString();
                dr["Buy Price (Rs.)"] = item.buyPrice;
                dr["Sell Price (Rs.)"] = item.sellPrice;
                dr["Quantity"] = item.quantity;
                dr["Time"] = item.time;
                dt.Rows.InsertAt(dr, i++);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*if(TextBox1.Text!=null || TextBox1.Text.Trim() != "")
            {
                string s = TextBox1.Text.Trim().ToLower();
                DataTable dt = new DataTable();
                DataRow dr;
                DataColumn dc;
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Int32");
                dc.ColumnName = "Transaction Id";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Int32");
                dc.ColumnName = "Buyer Req Id";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = "Buyer Name";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Int32");
                dc.ColumnName = "Seller Req Id";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = "Seller Name";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = "Stock";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Double");
                dc.ColumnName = "Buy Price (Rs.)";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Double");
                dc.ColumnName = "Sell Price (Rs.)";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Int32");
                dc.ColumnName = "Quantity";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.DateTime");
                dc.ColumnName = "Time";
                dt.Columns.Add(dc);
                int i = 0;
                foreach (tblTransactions item in ob.tblTransactions)
                {
                    if (ob.getUserName(item.buyerReqId).FirstOrDefault().ToString().ToLower().Contains(s) || ob.getUserName(item.sellerReqId).FirstOrDefault().ToString().ToLower().Contains(s) || ob.getStockName(item.buyerReqId).FirstOrDefault().ToString().ToLower().Contains(s))
                    {
                        dr = dt.NewRow();
                        dr["Transaction Id"] = item.transactionId;
                        dr["Buyer Req Id"] = item.buyerReqId;
                        dr["Buyer Name"] = ob.getUserName(item.buyerReqId).FirstOrDefault().ToString();
                        dr["Seller Req Id"] = item.sellerReqId;
                        dr["Seller Name"] = ob.getUserName(item.sellerReqId).FirstOrDefault().ToString();
                        dr["Stock"] = ob.getStockName(item.buyerReqId).FirstOrDefault().ToString();
                        dr["Buy Price (Rs.)"] = item.buyPrice;
                        dr["Sell Price (Rs.)"] = item.sellPrice;
                        dr["Quantity"] = item.quantity;
                        dr["Time"] = item.time;
                        dt.Rows.InsertAt(dr, i++);
                    }
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }*/
        }
    }
}