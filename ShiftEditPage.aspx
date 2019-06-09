<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShiftEditPage.aspx.cs" Inherits="ShiftEditPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: 36px; font-weight: bold; font-style: italic; color: #FFFFCC; background-color: #00CC99">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seat Planning System</h1>
        
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
        <asp:GridView ID="ShiftGridView" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataSourceID="ShiftDataSource" HorizontalAlign="Center" OnSelectedIndexChanged="ShiftGridView_SelectedIndexChanged" Width="281px">
            <Columns>
                <asp:BoundField DataField="Shift" HeaderText="Shift" SortExpression="Shift" />
                <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
            </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td>
                    <asp:Label ID="Label2" runat="server" Text="Shift" Width="30px"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="ShiftTextBox" runat="server" Width="150px" Wrap="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Label ID="Label1" runat="server" Text="Time" Width="30px"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="TimeTextBox" runat="server" Width="150px" Wrap="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Save" />
                            </td>
                            <td>
                    <asp:Button ID="DeleteButton" runat="server" OnClick="DeleteButton_Click" Text="Delete" />
                            </td>
                        </tr>
                    </table>
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="MessageLabel" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="ShiftDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SeatPlanConnectionString %>" SelectCommand="SELECT * FROM [Shift]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
