<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuildingEdit.aspx.cs" Inherits="BuildingEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: 36px; font-weight: bold; font-style: italic; color: #FFFFCC; background-color: #00CC99">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seat Planning System</h1>
        
        <br />
        <br />
        <br />
        <br />
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="backButton" runat="server" Text="Back " OnClick="backButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
                    <br />
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    <br />
                    <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <br />
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
                    <br />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <br />
        <asp:TextBox ID="updateTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="updateButton" runat="server" Text="updateButton" OnClick="updateButton_Click" />
                    <br />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <br />
        <asp:TextBox ID="deleteTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="deleteButton" runat="server" Text="deleteButton" OnClick="deleteButton_Click" />
                    <br />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
