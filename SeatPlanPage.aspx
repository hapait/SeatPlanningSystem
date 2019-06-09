<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeatPlanPage.aspx.cs" Inherits="Test1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seat Planning Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: 36px; font-weight: bold; font-style: italic; color: #FFFFCC; background-color: #00CC99">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seat Planning System</h1>
        <table style="width: 100%; border:outset; border-radius:3px">
            <tr id="r1">
                <td>&nbsp;</td>
                <td>
                    &nbsp;<asp:Button ID="buildingEditButton" runat="server" OnClick="buildingEditButton_Click" Text="Edit Building Info" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="shiftEditButton" runat="server" OnClick="shiftEditButton_Click" Text="Edit Shift Info" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="LogoutButton" runat="server" Text="Logout" OnClick="LogoutButton_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr id="r2">
                <td>&nbsp;</td>
                <td>
                    
                    &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:Label ID="Label1" runat="server" Text="Starting Roll" Width="100px"></asp:Label>
                    <asp:TextBox ID="StartRollTextBox" runat="server"></asp:TextBox>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Ending Roll" Width="100px"></asp:Label>
                    <asp:TextBox ID="EndRollTextBox" runat="server"></asp:TextBox>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ArrangeSeatsButton" runat="server" Text="Auto Arrange Seats" OnClick="ArrangeSeatsButton_Click" />

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ResetButton" runat="server" OnClick="ResetButton_Click" Text="Reset" />

                    <br />
                    <br />

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr id="r3">
                <td>&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel1" runat="server">

                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="800px" Width="1300px">
                            <LocalReport ReportPath="MyReport.rdlc">
                                <DataSources>
                                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="MyDataSetM" />
                                </DataSources>
                            </LocalReport>
                        </rsweb:ReportViewer>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="MyDataSetTableAdapters.BuildingTableAdapter"></asp:ObjectDataSource>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SeatPlanConnectionString %>" SelectCommand="SELECT * FROM [buildInfo]"></asp:SqlDataSource>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="SeatPlanDataSetTableAdapters.buildInfoTableAdapter"></asp:ObjectDataSource>

                    </asp:Panel>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr id="r4">
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

        
    </div>
    </form>
</body>
</html>
