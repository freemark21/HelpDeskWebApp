<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemEntry.aspx.cs" Inherits="ASPdotNetProjectRyan.ProblemEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problem Entry</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTech" runat="server" style="z-index: 1; left: 214px; top: 130px; position: absolute" Text="Technician:"></asp:Label>
            <asp:Label ID="lblTicketNum" runat="server" style="z-index: 1; left: 224px; top: 180px; position: absolute" Text="Ticket No:"></asp:Label>
            <asp:Label ID="lblProblemNum" runat="server" style="z-index: 1; left: 204px; top: 242px; position: absolute" Text="Problem No:"></asp:Label>
            <asp:Label ID="lblProduct" runat="server" style="z-index: 1; left: 244px; top: 299px; position: absolute" Text="Product:"></asp:Label>
            <asp:Label ID="lblProblem" runat="server" style="z-index: 1; left: 239px; top: 354px; position: absolute" Text="Problem:"></asp:Label>
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 794px; top: 235px; position: absolute" ForeColor="#CC3300"></asp:Label>
            <asp:DropDownList ID="drpTech" runat="server" style="z-index: 1; left: 357px; top: 129px; position: absolute">
            </asp:DropDownList>
            <asp:TextBox ID="txtTicketNum" runat="server" style="z-index: 1; left: 357px; top: 179px; position: absolute" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtProblemNum" runat="server" style="z-index: 1; left: 357px; top: 241px; position: absolute" ReadOnly="True"></asp:TextBox>
            <asp:DropDownList ID="drpProductList" runat="server" style="z-index: 1; left: 357px; top: 298px; position: absolute">
            </asp:DropDownList>
            <asp:TextBox ID="txtProblem" runat="server" style="z-index: 1; left: 357px; top: 353px; position: absolute" Height="150px"></asp:TextBox>
            <asp:Label ID="lblTitle" runat="server" style="z-index: 1; left: 298px; top: 65px; position: absolute" Text="Problem Entry" Font-Bold="True" Font-Size="Larger"></asp:Label>
            <asp:Button ID="btnSubmit" runat="server" style="z-index: 1; left: 236px; top: 562px; position: absolute; right: 1470px;" Text="Submit" OnClick="btnSubmit_Click" height="26px" width="90px" />
            <asp:Button ID="btnReset" runat="server" style="z-index: 1; left: 544px; top: 562px; position: absolute" Text="Reset" OnClick="btnReset_Click" width="90px" />
            <asp:Button ID="btnReturnServ" runat="server" style="z-index: 1; left: 272px; top: 634px; position: absolute" Text="Return to Service Events" OnClick="btnReturnServ_Click" />
        </div>
    </form>
</body>
</html>
