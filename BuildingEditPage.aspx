<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuildingEditPage.aspx.cs" Inherits="BuildingEditPage" %>

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
                <td>
                    <asp:Button ID="seatPlanPageButton" runat="server" Text="Seat Plan Page" OnClick="seatPlanPageButton_Click" />
                </td>
                <td>
                    <asp:Button ID="shiftEditPageButton" runat="server" Text="Edit Shift Info" OnClick="shiftEditPageButton_Click" />
                </td>
                <td>
                    <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;<br />
                    <br />
                </td>
                <td>&nbsp;<asp:Label ID="Label1" runat="server" Text="Building Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="BuildingDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="BuildingDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BuildingEditButton" runat="server" OnClick="BuildingEditButton_Click" Text="Add or Delete Building" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width:20%">
                    <br />
                </td>
                <td style="width:40%">
                    <br />
                    <br />
                    <asp:GridView ID="BuildingGridView" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="BuildingGridView_SelectedIndexChanged">
                    </asp:GridView>
                    <br />
                    <br />
                    <br />
                </td>
                <td style="width:40%">
                    <table style="width: 100%; height: 155px;">
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Building Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="BuildingNameTextBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Room No"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="RoomNoTextBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Capacity"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="CapacityTextBox" runat="server"></asp:TextBox>
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
                    <asp:Label ID="MessageLabel" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
