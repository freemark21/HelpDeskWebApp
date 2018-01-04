<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.Master" AutoEventWireup="true" CodeBehind="ReportsList.aspx.cs" Inherits="ASPdotNetProjectRyan.ReportsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Buttons">
        <asp:Button ID="btnInstitutionProb" runat="server" style="z-index: 1; left: 339px; top: 205px; position: absolute" Text="Problems by Institution" height="26px" width="209px" OnClick="btnInstitutionProb_Click" />
        <asp:Button ID="btnClientProb" runat="server" style="z-index: 1; left: 339px; top: 258px; position: absolute" Text="Problems by Client" height="26px" width="209px" OnClick="btnClientProb_Click" />
        <asp:Button ID="btnProductProb" runat="server" style="z-index: 1; left: 339px; top: 305px; position: absolute" Text="Problems by Product" height="26px" width="209px" OnClick="btnProductProb_Click" />
        <asp:Button ID="btnTechProb" runat="server" style="z-index: 1; left: 339px; top: 353px; position: absolute" Text="Problems by Technician" height="26px" OnClick="btnTechProb_Click" width="209px" />
        <asp:Button ID="btnMainMenu" runat="server" style="z-index: 1; left: 339px; top: 441px; position: absolute" Text="Return to Main Menu" OnClick="btnMainMenu_Click" height="26px" width="209px" />
    </div>
</asp:Content>
