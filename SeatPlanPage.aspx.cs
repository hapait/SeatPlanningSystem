using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Test1 : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection("Data Source=HAPAIT;Initial Catalog=SeatPlan;Integrated Security=True");
    SqlCommand command = new SqlCommand();
    SqlDataReader dataReader;
    SqlDataAdapter sda;

    string[] times = new string[20];

    public class Information
    {
        public string buildingNames { get; set; }
        public string roomNos { get; set; }
        public int capacity { get; set; }
    }

    public class ShiftInfo
    {
        public int shift { get; set; }
        public string time { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //initShiftToOne();
            for (int x = 0; x < 20; x++ )
            {
                times[x] = "0";
            }
        }
    }

    public void initShiftToOne(){
        connection.Open();
        command.Connection = connection;
        command.CommandText = "delete from Building where Shift >1";
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void clearRange()
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "update Building set Range = '" + "' where Range is not null";
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void insertShiftRange(string s)
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = s;
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void updateRange(string s)
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = s;
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Information> loadData()
    {

        List<Information> informationList = new List<Information>();
        connection.Open();
        command.Connection = connection;
        command.CommandText = "select Name, RoomNo, Capacity from Building";
        dataReader = command.ExecuteReader();
        while (dataReader.Read())
        {
            Information information = new Information();

            information.buildingNames = dataReader.GetString(0);
            information.roomNos = dataReader.GetString(1);
            information.capacity = dataReader.GetInt32(2);

            informationList.Add(information);
        }
        connection.Close();

        return informationList;
    }

    public List<ShiftInfo> loadShift() 
    {
        List<ShiftInfo> shiftList = new List<ShiftInfo>();
        connection.Open();
        command.Connection = connection;
        command.CommandText = "select Shift, Time from Shift";
        dataReader = command.ExecuteReader();
        int i = 0;
        while (dataReader.Read())
        {
            ShiftInfo sInfo = new ShiftInfo();

            sInfo.shift = dataReader.GetInt32(0);
            sInfo.time = dataReader.GetString(1);
            times[i] = sInfo.time;
            i++;
        }
        connection.Close();

        return shiftList;
    }

    public void loadTime()
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "select count()";
    }

    protected void ArrangeSeatsButton_Click(object sender, EventArgs e)
    {
        int start, end, sum, shift, one;
        start = Convert.ToInt32(StartRollTextBox.Text);
        end = Convert.ToInt32(EndRollTextBox.Text);
        
        initShiftToOne();
        
        connection.Open();
        command.Connection = connection;
        command.CommandText = "select sum(Capacity) from buildInfo";
        dataReader = command.ExecuteReader();
        dataReader.Read();
        sum = Convert.ToInt32(dataReader.GetValue(0));
        connection.Close();

        shift = (end - start+1)/sum;
        
        one = (end - start)%sum == 0? 0 : 1;
        
        shift += one;

        List<Information> information = loadData();
        List<ShiftInfo> shiftInformation = loadShift();

        //LogoutLabel.Text = shiftInformation[1].time;
        
        string range;
        int r;

        foreach (Information inf in information)
        {
            if (start >= end)
            {
                break;
            }
            r = start + inf.capacity - 1;
            if (r > end)
            {
                r = end;
            }
            range = start + "-" + r;
            string s = "update Building set Range = '"+range+"',Time = '"+times[0]+"' where Name = '"+inf.buildingNames+"' and RoomNo = '"+inf.roomNos+"' and Capacity = '"+inf.capacity+"'";

            updateRange(s);

            start = r + 1;
        }

        int i;
        for (i = 2; i <= shift; i++)
        {
            foreach (Information inf in information)
            {
                if (start >= end)
                {
                    break;
                }
                r = start + inf.capacity - 1;
                if (r > end)
                {
                    r = end;
                }
                range = start + "-" + r;

                string s = "insert into Building(Name, RoomNo, Capacity, Shift, Time, Range) values ('"+inf.buildingNames+"','"+inf.roomNos+"','"+inf.capacity.ToString()+"','"+i.ToString()+"','"+times[i-1]+"','"+range+"')";

                insertShiftRange(s);

                start = r;
            }
        }
        
        Response.Redirect("SeatPlanPage.aspx");
    }


    protected void ResetButton_Click(object sender, EventArgs e)
    {
        initShiftToOne();
        clearRange();
        Response.Redirect("SeatPlanPage.aspx");
    }
    protected void buildingEditButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("BuildingEditPage.aspx");
    }
    protected void shiftEditButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShiftEditPage.aspx");
    }
    protected void LogoutButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}