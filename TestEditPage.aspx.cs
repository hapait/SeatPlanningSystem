using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

public partial class TestEditPage : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection("Data Source=HAPAIT;Initial Catalog=SeatPlan;Integrated Security=True");
    SqlCommand command = new SqlCommand();
    SqlDataReader dataReader;
    SqlDataAdapter sda;
    public class AllBuildings
    {
        public string Building_Name { get; set;}
        public int Number_Of_Rooms { get; set; }
        public int Capacity { get; set; }
    }

    public void initShiftToOne()
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "delete from buildInfo where Shift >1";
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void insertShiftRange(string s)
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "update buildInfo set Range = null where Range is not null";
        command.ExecuteNonQuery();
        connection.Close();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        Panel1.Visible = true;
        Panel2.Visible = false;
        List<AllBuildings> allBuildings = new List<AllBuildings>();
        List<string> bN = new List<string>();
        connection.Open();
        command.Connection = connection;
        command.CommandText = "select BuildingName from buildInfo group by BuildingName";
        dataReader = command.ExecuteReader();
        while (dataReader.Read())
        {
            string s = dataReader.GetString(0);
            //DropDownList1.Items.Add(s);
            bN.Add(s);
        }
        connection.Close();

        foreach (string blName in bN)
        {
            DropDownList1.Items.Add(blName);
            AllBuildings ab = new AllBuildings();
            
            ab.Building_Name = blName;
            ab.Number_Of_Rooms = getCount(blName);
            ab.Capacity = getCapacity(blName);

            allBuildings.Add(ab);
        }

        GridView1.DataSource = allBuildings;
        GridView1.DataBind();

        /*
        try
        {

            List<AllBuildings> ab = new List<AllBuildings>();
            List<string> bN = new List<string>();
            List<int> n = new List<int>();
            List<int> c = new List<int>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select BuildingName from buildInfo group by BuildingName";
            dataReader = command.ExecuteReader();
            dataReader.Read();
            while (dataReader.HasRows)
            {
                bN.Add(dataReader.GetString(0));
                DropDownList1.Items.Add(dataReader.GetString(0));
            }
            connection.Close();

            foreach (string s in bN)
            {
                //DropDownList1.Items.Add(s);
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select count(RoomNo) from buildInfo where BuildingName = '" + s + "'";
                dataReader = command.ExecuteReader();
                dataReader.Read();
                n.Add(dataReader.GetInt32(0));
                connection.Close();

                connection.Open();
                command.Connection = connection;
                command.CommandText = "select sum(Capacity) from buildInfo where BuildingName = '" + s + "'";
                dataReader = command.ExecuteReader();
                dataReader.Read();
                c.Add(dataReader.GetInt32(0));
                connection.Close();

            }

            AllBuildings x = new AllBuildings();

            x.bName = bN[0];
            x.noRooms = n[0];
            x.cap = c[0];
            ab.Add(x);

            

            GridView1.DataSource = bN;
            GridView1.DataBind();
        }
        catch (System.OutOfMemoryException ex)
        {
            Process currentProcess = Process.GetCurrentProcess();
            long memorySize = currentProcess.PrivateMemorySize64;
        }*/
    }

    public int getCount(string s)
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "select count(RoomNo) from buildInfo where BuildingName = '" + s + "'";
        dataReader = command.ExecuteReader();
        dataReader.Read();
        int c = dataReader.GetInt32(0);
        connection.Close();
        return c;
    }

    public int getCapacity(string s)
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "select sum(Capacity) from buildInfo where BuildingName = '" + s + "'";
        dataReader = command.ExecuteReader();
        dataReader.Read();
        int c = dataReader.GetInt32(0);
        connection.Close();
        return c;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
    }
}