using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestXL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ExcelFile.xls;Extended Properties=Excel 8.0;";
                OleDbConnection MyConnection;
                DataSet ds;
                OleDbDataAdapter MyCommand;
                MyConnection = new OleDbConnection(connStr);
                MyCommand = new OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                ds = new System.Data.DataSet();
                MyCommand.Fill(ds);
                
                GridView1.DataSource = ds.Tables[0];
                MyConnection.Close();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
            }
        }
    }
}