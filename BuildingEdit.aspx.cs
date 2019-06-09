using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BuildingEdit : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection("Data Source=HAPAIT;Initial Catalog=SeatPlan;Integrated Security=True");
    SqlCommand command = new SqlCommand();
    SqlDataReader dataReader;
    SqlDataAdapter sda;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //initBuildingDropDown();

            refreshTable();
        }
    }

    public void refreshTable()
    {
        connection.Open();
        string selectSQL = "SELECT distinct Name from Building ";
        //string selectSQL = "SELECT * from Building where Name = '" + buildingName + "'";

        SqlCommand cmd = new SqlCommand(selectSQL, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "Building");

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        connection.Close();
    }
    protected void addButton_Click(object sender, EventArgs e)
    {
        string name = nameTextBox.Text;

        connection.Open();
        command.Connection = connection;
        command.CommandText = "insert into Building(Name,RoomNo,Capacity,Shift) values('" + name + "','" + 0 + "','" + 0 + "','" + 1 + "')";
        command.ExecuteNonQuery();
        connection.Close();

        refreshTable();

    }
    protected void updateButton_Click(object sender, EventArgs e)
    {
        string newname = updateTextBox.Text;
        string oldname = GridView1.SelectedRow.Cells[1].Text;

        connection.Open();
        command.Connection = connection;
        command.CommandText = "update Building set Name = '" + newname + "' where Name = '" + oldname + "'";
        command.ExecuteNonQuery();
        connection.Close();

        refreshTable();

    }
    protected void deleteButton_Click(object sender, EventArgs e)
    {
        string name = deleteTextBox.Text;
        connection.Open();
        command.Connection = connection;
        command.CommandText = "delete from Building where Name = '" + name + "'";
        command.ExecuteNonQuery();
        connection.Close();

        refreshTable();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        updateTextBox.Text = GridView1.SelectedRow.Cells[1].Text;
        deleteTextBox.Text = GridView1.SelectedRow.Cells[1].Text;
    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("BuildingEditPage.aspx");
    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("SeatPlanPage.aspx");
    }
}