using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection("Data Source=HAPAIT;Initial Catalog=SeatPlan;Integrated Security=True");
    SqlCommand command = new SqlCommand();
    SqlDataReader dataReader;
    SqlDataAdapter sda;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "select * from LoginTable where Username = '" + UsernameTextBox.Text + "' and Password = '" + PasswordTextBox.Text +"'";
        dataReader = command.ExecuteReader();
        dataReader.Read();
        if (dataReader.HasRows)
        {
            connection.Close();
            Response.Redirect("SeatPlanPage.aspx");
        }
        else
        {
            connection.Close();
        }
    }
}