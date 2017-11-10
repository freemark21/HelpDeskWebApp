<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemEntry.aspx.cs" Inherits="ASPdotNetProjectRyan.ProblemEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problem Entry</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTicketNum" runat="server" Text="Ticket No:"></asp:Label>
            <asp:TextBox ID="txtTicketNum" runat="server" ReadOnly="true"></asp:TextBox>
            <asp:Label ID="lblProblemNum" runat="server" Text="Problem No:"></asp:Label>
            <asp:TextBox ID="txtProblemNum" runat="server" ReadOnly="true"></asp:TextBox>
            <asp:Label ID="lblProduct" runat="server" Text="Product:"></asp:Label>
            <asp:DropDownList ID="drpProductList" runat="server"></asp:DropDownList>
            <asp:Label ID="lblProblem" runat="server" Text="Problem:"></asp:Label>
            <asp:TextBox ID="txtProblem" runat="server" Height="200px" Width="200px"></asp:TextBox>
            <asp:Label ID="lblTech" runat="server" Text="Technician:"></asp:Label>
            <asp:DropDownList ID="drpTech" runat="server"></asp:DropDownList>
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
