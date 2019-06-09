<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPage.aspx.cs" Inherits="EditPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Master">
        <table style="align-content:center;">
            <tr>
                <td id="EditShiftsCol" style="align-content:center; vertical-align:central">
                    <asp:Panel ID="EditShiftPanel" runat="server" BackColor="#009999" BorderColor="#009999" BorderStyle="Outset" Height="200px" Width="400px">

                    </asp:Panel>
                    <asp:Panel ID="EditBuildPanel" runat="server" BackColor="#009999" BorderColor="#009999" BorderStyle="Outset" Height="200px" Width="400px">

                    </asp:Panel>
                    <asp:Panel ID="EditRoomPanel" runat="server" BackColor="#009999" BorderColor="#009999" BorderStyle="Outset" Height="200px" Width="400px">

                    </asp:Panel>
                </td>
                <td id="InfoGridCol">
                    <asp:Panel ID="BuildInfoGridViewPanel" runat="server" BackColor="#009999" BorderColor="#009999" BorderStyle="Outset" Height="600px" Width="600px">
                        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
