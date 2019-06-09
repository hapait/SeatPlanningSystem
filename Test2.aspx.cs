using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class Test2 : System.Web.UI.Page
{
    //SqlConnection connection = new SqlConnection("Data Source=HAPAIT;Initial Catalog=SeatPlan;Integrated Security=True");
    SqlConnection connection = new SqlConnection("Data Source=HAPAIT;Initial Catalog=LabFinal;Integrated Security=True");
    SqlCommand command = new SqlCommand();
    SqlDataReader dataReader;
    SqlDataAdapter sda;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            refreshTable2();
        }
        
    }

    public void refreshTable2()
    {
        //clearRanges();
        //clearShifts();
        connection.Open();
        string s = "select * from CourseTable";
        sda = new SqlDataAdapter(s, connection);
        DataSet ds = new DataSet();
        sda.Fill(ds, "Coursetable");
        ds.Tables[0].TableName = "TestDataTable";

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {


        }

        ReportViewer1.Reset();
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("TestReport.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TestReportDataSet", ds.Tables[0]));
        ReportViewer1.LocalReport.Refresh();
    }

    public void refreshTable()
    {
        clearRanges();
        clearShifts();
        connection.Open();
        string s = "select BuildingName,RoomNo,Capacity, ShiftsTable.Shift,ShiftsTable.Time, Range from buildInfo cross join ShiftsTable";
        sda = new SqlDataAdapter(s, connection);
        DataSet ds = new DataSet();
        sda.Fill(ds, "buildInfo");
        ds.Tables[0].TableName = "TestDataTable";

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++ )
        {


        }

        ReportViewer1.Reset();
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("TestReport.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TestReportDataSet", ds.Tables[0]));
        ReportViewer1.LocalReport.Refresh();
    }
    public void clearRanges()
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "update buildInfo set Range = null where Range is not null";
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void clearShifts()
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "delete from buildInfo where Shift > 1";
        command.ExecuteNonQuery();
        connection.Close();
    }
}