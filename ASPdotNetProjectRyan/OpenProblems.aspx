<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenProblems.aspx.cs" Inherits="ASPdotNetProjectRyan.OpenProblems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Open Problem(s) List</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:GridView ID="gvOpenProb" runat="server" style="z-index: 1; left: 130px; top: 160px; position: absolute; height: 346px; width: 826px;">
        </asp:GridView>
        <asp:Button ID="btnReturn" runat="server" style="z-index: 1; left: 410px; top: 558px; position: absolute" Text="Return to Main Menu" OnClick="btnReturn_Click" />
        <asp:Label ID="lblOpenProb" runat="server" Font-Bold="True" Font-Size="Larger" style="z-index: 1; left: 382px; top: 72px; position: absolute" Text="Open Problem(s) List"></asp:Label>
        <asp:Label ID="lblError" runat="server" ForeColor="#CC3300" style="z-index: 1; left: 322px; top: 631px; position: absolute"></asp:Label>
        </div>
    </form>
</body>
</html>
