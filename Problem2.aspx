<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Problem2.aspx.cs" Inherits="Problem2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="CourseNo" HeaderText="CourseNo" SortExpression="CourseNo" />
                <asp:BoundField DataField="Tutorial" HeaderText="Tutorial" SortExpression="Tutorial" />
                <asp:BoundField DataField="MidTerm" HeaderText="MidTerm" SortExpression="MidTerm" />
                <asp:BoundField DataField="Final" HeaderText="Final" SortExpression="Final" />
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                <asp:BoundField DataField="LG" HeaderText="LG" SortExpression="LG" />
                <asp:BoundField DataField="GP" HeaderText="GP" SortExpression="GP" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LabFinalConnectionString %>" SelectCommand="SELECT * FROM [CourseTable]"></asp:SqlDataSource>

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="435px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="874px">
            <LocalReport ReportPath="personalInfoReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSetforperinfo" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LabFinalConnectionString %>" SelectCommand="SELECT * FROM [CourseTable]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
