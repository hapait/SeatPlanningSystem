<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestEditPage.aspx.cs" Inherits="TestEditPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>All Buildibgs</asp:ListItem>
        </asp:DropDownList>
    </div>
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" BackColor="#333333" Height="128px">
        </asp:Panel>
    </form>
</body>
</html>
