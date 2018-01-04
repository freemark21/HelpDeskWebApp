<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.Master" AutoEventWireup="true" CodeBehind="ReportDisplay.aspx.cs" Inherits="ASPdotNetProjectRyan.ReportDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>

        <asp:GridView ID="gvReportDisplay" runat="server" style="z-index: 1; left: 144px; top: 186px; position: absolute; height: 190px; width: 525px">
    </asp:GridView>

        <asp:Button ID="btnReportsList" runat="server" style="z-index: 1; left: 307px; top: 522px; position: absolute" Text="Return to Reports List" OnClick="btnReportsList_Click" />

        <asp:Label ID="lblReportTitle" runat="server" style="z-index: 1; left: 362px; top: 117px; position: absolute" Font-Bold="True" Font-Size="X-Large"></asp:Label>

    </div>
    <asp:Label ID="lblError" runat="server" ForeColor="#CC3300" style="z-index: 1; left: 173px; top: 443px; position: absolute"></asp:Label>
</asp:Content>
