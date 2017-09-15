<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceEvents.aspx.cs" Inherits="ASPdotNetProject.ServiceEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmServiceEvents" runat="server">
    <div>
        <asp:Label ID="lblServiceEvents" runat="server" Font-Bold="True" Font-Size="Larger" style="z-index: 1; left: 680px; top: 77px; position: absolute" Text="Service Events"></asp:Label>
        <asp:Label ID="lblEventDate" runat="server" style="z-index: 1; left: 622px; top: 136px; position: absolute" Text="Event Date:"></asp:Label>
        <asp:TextBox ID="txtEventDate" runat="server" Enabled="False" style="z-index: 1; left: 720px; top: 134px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblClientID" runat="server" style="z-index: 1; left: 657px; top: 180px; position: absolute; height: 19px; width: 35px" Text="Client:"></asp:Label>
        <asp:DropDownList ID="drpClientID" runat="server" style="z-index: 1; left: 720px; top: 177px; position: absolute"></asp:DropDownList>
        <asp:Label ID="lblContact" runat="server" style="z-index: 1; left: 641px; top: 230px; position: absolute" Text="Contact:"></asp:Label>
        <asp:TextBox ID="txtContact" runat="server" style="z-index: 1; left: 720px; top: 229px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblPhone" runat="server" style="z-index: 1; left: 651px; top: 283px; position: absolute" Text="Phone:"></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 720px; top: 281px; position: absolute"></asp:TextBox>
        <asp:Button ID="btnNext" runat="server" style="z-index: 1; left: 601px; top: 367px; position: absolute; height: 41px; width: 92px" Text="Next" />
        <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 809px; top: 365px; position: absolute; height: 41px; width: 92px" Text="Clear" />
        <asp:Button ID="btnMainMenu" runat="server" style="z-index: 1; left: 662px; top: 460px; position: absolute; height: 36px; width: 183px" Text="Return to Main Menu" OnClick="btnMainMenu_Click" />
    </div>
    </form>
</body>
</html>
