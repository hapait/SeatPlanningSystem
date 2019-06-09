using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BuildingEditPage : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection("Data Source=HAPAIT;Initial Catalog=SeatPlan;Integrated Security=True");
    SqlCommand command = new SqlCommand();
    SqlDataReader dataReader;
    SqlDataAdapter sda;

    string buildingName;

    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!this.IsPostBack)
        {
            initBuildingDropDown();

            refreshTable();
        }
    }

    public void initBuildingDropDown()
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "select Name from Building group by Name";
        dataReader = command.ExecuteReader();
        while (dataReader.Read())
        {
            BuildingDropDownList.Items.Add(dataReader.GetString(0));
        }
        connection.Close();

        BuildingDropDownList.SelectedIndex = 0;

    }
    public void refreshTable()
    {
        buildingName = BuildingDropDownList.SelectedItem.ToString();

        connection.Open();
        string selectSQL = "SELECT RoomNo, Capacity from Building where Name = '" + buildingName + "'";
        //string selectSQL = "SELECT * from Building where Name = '" + buildingName + "'";
        
        SqlCommand cmd = new SqlCommand(selectSQL, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds,"Building");

        BuildingGridView.DataSource = ds.Tables[0];
        BuildingGridView.DataBind();
        connection.Close();
    }
    protected void BuildingDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        refreshTable();
        
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        string bn = BuildingDropDownList.SelectedItem.ToString();
        string rn = RoomNoTextBox.Text;
        string c = CapacityTextBox.Text;
        if (rn != "" && c != "")
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from Building where Name = '" + bn + "' and RoomNo = '" + rn + "' and Capacity = '"+c+"'";
            dataReader = command.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                connection.Close();
                MessageLabel.Text = "Already Exist";
            }
            else
            {
                connection.Close();

                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Building where Name = '" + bn + "' and (RoomNo = '" + rn + "' or Capacity = '"+c+"')";
                dataReader = command.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    connection.Close();

                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "update Building set RoomNo = '" + rn + "', Capacity = '" + c + "' where Name = '" + bn + "' and (RoomNo = '" + rn + "' or Capacity = '" + c + "')";
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageLabel.Text = "Successfully Updated";
                }
                else
                {
                    connection.Close();

                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "insert into Building(Name,RoomNo,Capacity,Shift) values('" + bn + "','" + rn + "','"+c+"','"+1+"')";
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageLabel.Text = "Successful";

                }
                Response.Redirect("BuildingEditPage.aspx");

            }

        }
    }
    protected void BuildingGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        BuildingNameTextBox.Text = BuildingDropDownList.SelectedItem.ToString();
        RoomNoTextBox.Text = BuildingGridView.SelectedRow.Cells[1].Text;
        CapacityTextBox.Text = BuildingGridView.SelectedRow.Cells[2].Text;
    }
    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        string bn = BuildingDropDownList.SelectedItem.ToString();
        string rn = RoomNoTextBox.Text;
        string c = CapacityTextBox.Text;
        if (rn != "" && c != "")
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from Building where Name = '" + bn + "' and RoomNo = '" + rn + "' and Capacity = '"+c+"'";
            dataReader = command.ExecuteReader();
            dataReader.Read();
            if (!dataReader.HasRows)
            {
                connection.Close();
                MessageLabel.Text = "Doesn't Exist";
            }
            else
            {
                connection.Close();

                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Building where Name = '" + bn + "' and RoomNo = '" + rn + "' and Capacity = '"+c+"'";
                command.ExecuteNonQuery();
                connection.Close();

                MessageLabel.Text = "Successful";

                Response.Redirect("BuildingEditPage.aspx");

            }

        }
    }
    protected void BuildingEditButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("BuildingEdit.aspx");
    }
    protected void seatPlanPageButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("SeatPlanPage.aspx");
    }
    protected void shiftEditPageButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShiftEditPage.aspx");
    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}