<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceEvents.aspx.cs" Inherits="ASPdotNetProject.ServiceEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmServiceEvents" runat="server">
    <div>
        <asp:Label ID="lblServiceEvents" runat="server" Font-Bold="True" Font-Size="Larger" style="z-index: 1; left: 240px; top: 71px; position: absolute" Text="Service Events"></asp:Label>
        <asp:Label ID="lblEventDate" runat="server" style="z-index: 1; left: 192px; top: 130px; position: absolute" Text="Event Date:"></asp:Label>
        <asp:TextBox ID="txtEventDate" runat="server" Enabled="False" style="z-index: 1; left: 324px; top: 126px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblClientID" runat="server" style="z-index: 1; left: 242px; top: 171px; position: absolute; height: 24px; width: 65px" Text="Client:"></asp:Label>
        <asp:DropDownList ID="drpClientID" runat="server" style="z-index: 1; left: 324px; top: 170px; position: absolute"></asp:DropDownList>
        <asp:Label ID="lblContact" runat="server" style="z-index: 1; left: 225px; top: 213px; position: absolute" Text="Contact:"></asp:Label>
        <asp:TextBox ID="txtContact" runat="server" style="z-index: 1; left: 324px; top: 212px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblPhone" runat="server" style="z-index: 1; left: 240px; top: 266px; position: absolute" Text="Phone:"></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 324px; top: 265px; position: absolute"></asp:TextBox>
        <asp:Button ID="btnNext" runat="server" style="z-index: 1; left: 187px; top: 357px; position: absolute; height: 41px; width: 92px" Text="Next" OnClick="btnNext_Click" />
        <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 333px; top: 358px; position: absolute; height: 41px; width: 92px" Text="Clear" OnClick="btnClear_Click" />
        <asp:Button ID="btnMainMenu" runat="server" style="z-index: 1; left: 220px; top: 433px; position: absolute; height: 36px; width: 183px" Text="Return to Main Menu" OnClick="btnMainMenu_Click" />
    </div>
        <asp:Label ID="lblError" runat="server" ForeColor="#CC3300" style="z-index: 1; left: 655px; top: 217px; position: absolute"></asp:Label>
    </form>
</body>
</html>
