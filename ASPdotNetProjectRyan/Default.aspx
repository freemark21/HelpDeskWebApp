<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPdotNetProject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Menu</title>
</head>
<body>
    <form id="frmMainMenu" runat="server">
        <div>
            <asp:Label ID="lblMainMenu" runat="server" style="z-index: 1; left: 487px; top: 87px; position: absolute" Text="Main Menu" Font-Size="XX-Large"></asp:Label>
            <asp:Button ID="btnServiceEvents" runat="server" style="z-index: 1; left: 480px; top: 152px; position: absolute; height: 28px; bottom: 333px; width: 160px; right: 624px;" Text="Service Events" OnClick="btnServiceEvents_Click" />
            <asp:Button ID="btnProblemRes" runat="server" Enabled="True" style="z-index: 1; left: 480px; top: 222px; position: absolute; width: 160px; height: 28px" Text="Problem Resolution" OnClick="btnProblemRes_Click" />
            <asp:Button ID="btnReports" runat="server" style="z-index: 1; left: 480px; top: 290px; position: absolute; width: 160px; height: 28px" Text="Reports" OnClick="btnReports_Click" />
            <asp:Button ID="btnMngTechs" runat="server" style="z-index: 1; left: 480px; top: 358px; position: absolute; width: 160px; height: 28px" Text="Manage Technicians" OnClick="btnMngTechs_Click" />
        </div>
    </form>
</body>
</html>
