using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShiftEditPage : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection("Data Source=HAPAIT;Initial Catalog=SeatPlan;Integrated Security=True");
    SqlCommand command = new SqlCommand();
    SqlDataReader dataReader;
    SqlDataAdapter sda;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ShiftGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShiftTextBox.Text = ShiftGridView.SelectedRow.Cells[1].Text;
        TimeTextBox.Text = ShiftGridView.SelectedRow.Cells[2].Text;
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        string s = ShiftTextBox.Text;
        string t = TimeTextBox.Text;
        if (s != "" && t != "")
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from Shift where Shift = '"+s+"' and Time = '"+t+"'";
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
                command.CommandText = "select * from Shift where Shift = '" + s + "' or Time = '" + t + "'";
                dataReader = command.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    connection.Close();

                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "update Shift set Shift = '" + s + "', Time = '" + t + "' where Shift = '" + s + "' or Time = '" + t + "'";
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageLabel.Text = "Successfully Updated";
                }
                else
                {
                    connection.Close();

                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "insert into Shift(Shift,Time) values('" + s + "','" + t + "')";
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageLabel.Text = "Successful";

                }                
                Response.Redirect("ShiftEditPage.aspx");

            }
            
        }
    }
    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        string s = ShiftTextBox.Text;
        string t = TimeTextBox.Text;
        if (s != "" && t != "")
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from Shift where Shift = '" + s + "' and Time = '" + t + "'";
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
                command.CommandText = "delete from Shift where Shift = '"+s+"' and Time = '"+t+"'";
                command.ExecuteNonQuery();
                connection.Close();

                MessageLabel.Text = "Successful";

                Response.Redirect("ShiftEditPage.aspx");

            }

        }
    }
}