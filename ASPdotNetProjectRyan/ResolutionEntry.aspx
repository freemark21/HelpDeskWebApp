<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResolutionEntry.aspx.cs" Inherits="ASPdotNetProjectRyan.ResolutionEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblResolutionEntry" runat="server" style="z-index: 1; left: 383px; top: 72px; position: absolute" Text="Resolution Entry" Font-Bold="True" Font-Size="Larger"></asp:Label>
            <asp:Label ID="lblTicketNum" runat="server" style="z-index: 1; left: 134px; top: 143px; position: absolute" Text="Ticket No:"></asp:Label>
            <asp:Label ID="lblProbNum" runat="server" style="z-index: 1; left: 114px; top: 191px; position: absolute" Text="Problem No:"></asp:Label>
            <asp:Label ID="lblResNum" runat="server" style="z-index: 1; left: 92px; top: 232px; position: absolute" Text="Resolution No:"></asp:Label>
            <asp:Label ID="lblResolution" runat="server" style="z-index: 1; left: 127px; top: 277px; position: absolute" Text="Resolution:"></asp:Label>
            <asp:Label ID="lblTech" runat="server" style="z-index: 1; left: 124px; top: 409px; position: absolute" Text="Technician:"></asp:Label>
            <asp:Label ID="lblHours" runat="server" style="z-index: 1; left: 172px; top: 458px; position: absolute" Text="Hours:"></asp:Label>
            <asp:Label ID="lblSupplies" runat="server" style="z-index: 1; left: 150px; top: 507px; position: absolute" Text="Supplies:"></asp:Label>
            <asp:Label ID="lblDateFixed" runat="server" style="z-index: 1; left: 124px; top: 562px; position: absolute" Text="Date Fixed:"></asp:Label>
            <asp:Label ID="lblMileage" runat="server" style="z-index: 1; left: 414px; top: 458px; position: absolute" Text="Mileage:"></asp:Label>
            <asp:Label ID="lblMisc" runat="server" style="z-index: 1; left: 444px; top: 507px; position: absolute" Text="Misc:"></asp:Label>
            <asp:Label ID="Label12" runat="server" style="z-index: 1; left: 647px; top: 458px; position: absolute" Text="Cost/Mile:"></asp:Label>
            <asp:Label ID="lblDateOnsite" runat="server" style="z-index: 1; left: 377px; top: 560px; position: absolute" Text="Date Onsite:"></asp:Label>
            <asp:TextBox ID="txtTicketNum" runat="server" ReadOnly="True" style="z-index: 1; left: 261px; top: 142px; position: absolute; width: 81px"></asp:TextBox>
            <asp:TextBox ID="txtProbNum" runat="server" ReadOnly="True" style="z-index: 1; left: 261px; top: 190px; position: absolute" width="81px"></asp:TextBox>
            <asp:TextBox ID="txtResNum" runat="server" ReadOnly="True" style="z-index: 1; left: 261px; top: 231px; position: absolute" width="81px"></asp:TextBox>
            <asp:TextBox ID="txtResolution" runat="server" style="z-index: 1; left: 261px; top: 279px; position: absolute; height: 112px; width: 491px; right: 1036px"></asp:TextBox>
            <asp:DropDownList ID="drpTech" runat="server" style="z-index: 1; left: 261px; top: 408px; position: absolute; width: 215px">
            </asp:DropDownList>
            <asp:TextBox ID="txtHours" runat="server" style="z-index: 1; left: 261px; top: 457px; position: absolute; width: 99px"></asp:TextBox>
            <asp:TextBox ID="txtSupplies" runat="server" style="z-index: 1; left: 261px; top: 506px; position: absolute; width: 99px"></asp:TextBox>
            <asp:TextBox ID="txtDateFixed" runat="server" style="z-index: 1; left: 261px; top: 561px; position: absolute; width: 99px"></asp:TextBox>
            <asp:TextBox ID="txtMileage" runat="server" style="z-index: 1; left: 513px; top: 457px; position: absolute; width: 99px"></asp:TextBox>
            <asp:TextBox ID="txtMisc" runat="server" style="z-index: 1; left: 513px; top: 506px; position: absolute; width: 99px"></asp:TextBox>
            <asp:TextBox ID="txtCostMile" runat="server" style="z-index: 1; left: 759px; top: 457px; position: absolute" width="99px"></asp:TextBox>
            <asp:TextBox ID="txtDateOnsite" runat="server" style="z-index: 1; left: 513px; top: 558px; position: absolute" width="99px"></asp:TextBox>
            <asp:CheckBox ID="chkNoCharge" runat="server" style="z-index: 1; left: 682px; top: 523px; position: absolute; width: 164px" Text="No Charge" />
            <asp:Button ID="btnSubmit" runat="server" style="z-index: 1; left: 257px; top: 622px; position: absolute" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnReset" runat="server" height="35px" style="z-index: 1; left: 630px; top: 622px; position: absolute" Text="Reset" width="90px" OnClick="btnReset_Click" />
            <asp:Button ID="btnReturnOpen" runat="server" style="z-index: 1; left: 323px; top: 682px; position: absolute" Text="Return to Open Problems" OnClick="btnReturnOpen_Click" />
            <asp:Label ID="lblError" runat="server" ForeColor="#CC3300" style="z-index: 1; left: 586px; top: 169px; position: absolute"></asp:Label>
        </div>
    </form>
</body>
</html>
