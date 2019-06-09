<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: 36px; font-weight: bold; font-style: italic; color: #FFFFCC; background-color: #00CC99">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seat Planning System</h1>
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <br />
                    <br />
                    <br />
                    <br />

                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width:33%">&nbsp;</td>
                <td style ="width:34%">
                    <div id="LoginDiv" style="font-size: larger">

                        &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label1" runat="server" Text="Username" Width="80px"></asp:Label>
                                &nbsp;
                                    <asp:TextBox ID="UsernameTextBox" runat="server" Width="150px"></asp:TextBox>
                                <br />
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label2" runat="server" Text="Password" Width="80px"></asp:Label>
                                &nbsp;
                                    <asp:TextBox ID="PasswordTextBox" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                                <br />
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" Width="50px" />
                                <br />

                    </div>
                </td>
                <td style="width:33%">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
