using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Problem2 : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection("Data Source=HAPAIT;Initial Catalog=LabFinal;Integrated Security=True");
    SqlCommand command = new SqlCommand();
    SqlDataReader dataReader;
    SqlDataAdapter sda;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string i = GridView1.SelectedRow.Cells[0].ToString();

        connection.Open();
        command.Connection = connection;
        string s = "select * from perInfo where Name = '"+i+"'";
        sda = new SqlDataAdapter(s, connection);
        DataSet ds = new DataSet();
        sda.Fill(ds, "perInfo");
        ds.Tables[0].TableName = "PersonalInfo";


        ReportViewer1.Reset();
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("personalInfoReport.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("PersonalInfo", ds.Tables[0]));
        ReportViewer1.LocalReport.Refresh();
    }
}