<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GadgetStoreView.aspx.cs" Inherits="FirstDataDrivenWebApplication.GadgetStoreView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="gadgetStoreRepeater" ItemType="FirstDataDrivenWebApplication.GadgetStore" runat="server">
            <ItemTemplate>
                <li>
                    <label>
                       Name: <%#: Item.Name %> || Type: <%#: Item.Type %> || Stock Count: <%#: Item.Quantity %>
                    </label>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
