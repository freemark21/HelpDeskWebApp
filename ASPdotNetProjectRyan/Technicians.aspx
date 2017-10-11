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
            <asp:Label ID="lblLname" runat="server" style="z-index: 1; left: 124px; top: 174px; position: absolute" Text="Last Name"></asp:Label>
            <asp:Label ID="lblFname" runat="server" style="z-index: 1; left: 123px; top: 138px; position: absolute" Text="First Name"></asp:Label>
            <asp:Label ID="lblMinit" runat="server" style="z-index: 1; left: 125px; top: 213px; position: absolute" Text="Middle Init"></asp:Label>
            <asp:Label ID="lblEmail" runat="server" style="z-index: 1; left: 158px; top: 257px; position: absolute" Text="Email"></asp:Label>
            <asp:Label ID="lblDept" runat="server" style="z-index: 1; left: 120px; top: 302px; position: absolute" Text="Department"></asp:Label>
            <asp:Label ID="lblPhone" runat="server" style="z-index: 1; left: 142px; top: 347px; position: absolute" Text="Phone #"></asp:Label>
            <asp:Label ID="lblHrRate" runat="server" style="z-index: 1; left: 109px; top: 393px; position: absolute" Text="Hourly Rate"></asp:Label>
            <asp:DropDownList ID="drpTechID" runat="server" style="z-index: 1; left: 240px; top: 89px; position: absolute" AutoPostBack="True" OnSelectedIndexChanged="drpTechID_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:TextBox ID="txtLname" runat="server" style="z-index: 1; left: 240px; top: 171px; position: absolute" TabIndex="2"></asp:TextBox>
            <asp:TextBox ID="txtFname" runat="server" style="z-index: 1; left: 240px; top: 135px; position: absolute" TabIndex="1"></asp:TextBox>
            <asp:TextBox ID="txtMinit" runat="server" style="z-index: 1; left: 240px; top: 210px; position: absolute" TabIndex="3"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; left: 240px; top: 254px; position: absolute" TabIndex="4"></asp:TextBox>
            <asp:TextBox ID="txtDept" runat="server" style="z-index: 1; left: 240px; top: 299px; position: absolute" TabIndex="5"></asp:TextBox>
            <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 240px; top: 344px; position: absolute" TabIndex="6"></asp:TextBox>
            <asp:TextBox ID="txtHrRate" runat="server" style="z-index: 1; left: 240px; top: 390px; position: absolute" TabIndex="7"></asp:TextBox>
            <asp:Button ID="btnDelete" runat="server" height="29px" style="z-index: 1; left: 212px; top: 446px; position: absolute" Text="Delete" width="77px" OnClick="btnDelete_Click" TabIndex="8" />
            <asp:Button ID="btnAdd" runat="server" height="29px" style="z-index: 1; left: 316px; top: 446px; position: absolute" Text="Add" width="77px" OnClick="btnAdd_Click" TabIndex="9" />
            <asp:Button ID="btnReset" runat="server" height="29px" style="z-index: 1; left: 419px; top: 446px; position: absolute" Text="Reset" width="77px" OnClick="btnReset_Click" TabIndex="10" />
            <asp:Button ID="btnMainMenu" runat="server" style="z-index: 1; left: 208px; top: 489px; position: absolute; width: 193px" Text="Return to Main Menu" OnClick="btnMainMenu_Click" TabIndex="11" />
        </div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" style="z-index: 1; left: 23px; top: 52px; position: absolute"></asp:Label>
    </form>
</body>
</html>
