<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Technicians.aspx.cs" Inherits="ASPdotNetProject.Technicians" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Technicians</title>
</head>
<body>
    <form id="frmTechnicians" runat="server">
        <div>
            <asp:Label ID="lblTechID" runat="server" style="z-index: 1; left: 93px; top: 92px; position: absolute" Text="Technician ID"></asp:Label>
            <asp:Label ID="lblLname" runat="server" style="z-index: 1; left: 121px; top: 135px; position: absolute" Text="Last Name"></asp:Label>
            <asp:Label ID="lblFname" runat="server" style="z-index: 1; left: 117px; top: 175px; position: absolute" Text="First Name"></asp:Label>
            <asp:Label ID="lblMinit" runat="server" style="z-index: 1; left: 116px; top: 213px; position: absolute" Text="Middle Init"></asp:Label>
            <asp:Label ID="lblEmail" runat="server" style="z-index: 1; left: 158px; top: 257px; position: absolute" Text="Email"></asp:Label>
            <asp:Label ID="lblDept" runat="server" style="z-index: 1; left: 114px; top: 302px; position: absolute" Text="Department"></asp:Label>
            <asp:Label ID="lblPhone" runat="server" style="z-index: 1; left: 142px; top: 347px; position: absolute" Text="Phone #"></asp:Label>
            <asp:Label ID="lblHrRate" runat="server" style="z-index: 1; left: 109px; top: 393px; position: absolute" Text="Hourly Rate"></asp:Label>
            <asp:DropDownList ID="drpTechID" runat="server" style="z-index: 1; left: 240px; top: 89px; position: absolute" AutoPostBack="True" OnSelectedIndexChanged="drpTechID_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:TextBox ID="txtLname" runat="server" style="z-index: 1; left: 240px; top: 132px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtFname" runat="server" style="z-index: 1; left: 240px; top: 172px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtMinit" runat="server" style="z-index: 1; left: 240px; top: 210px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; left: 240px; top: 254px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDept" runat="server" style="z-index: 1; left: 240px; top: 299px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 240px; top: 344px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtHrRate" runat="server" style="z-index: 1; left: 240px; top: 390px; position: absolute"></asp:TextBox>
            <asp:Button ID="btnAccept" runat="server" style="z-index: 1; left: 105px; top: 446px; position: absolute" Text="Accept" />
            <asp:Button ID="btnCancel" runat="server" height="29px" style="z-index: 1; left: 212px; top: 446px; position: absolute" Text="Cancel" width="77px" />
            <asp:Button ID="btnAdd" runat="server" height="29px" style="z-index: 1; left: 316px; top: 446px; position: absolute" Text="Add New" width="77px" />
            <asp:Button ID="btnReset" runat="server" height="29px" style="z-index: 1; left: 419px; top: 446px; position: absolute" Text="Reset" width="77px" />
            <asp:Button ID="btnMainMenu" runat="server" style="z-index: 1; left: 208px; top: 489px; position: absolute; width: 193px" Text="Return to Main Menu" OnClick="btnMainMenu_Click" />
        </div>
    </form>
</body>
</html>
