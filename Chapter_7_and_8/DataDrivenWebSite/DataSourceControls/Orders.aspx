<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="DataSourceControls.Orders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater 
                ID="StoreDataSourceRepeater" 
                SelectMethod="StoreDataSourceRepeater_GetData" 
                runat="server" 
                ItemType="DataSourceControls.Order">
                <ItemTemplate>
                    <div>
                        Quantity: <%#: Item.Quantity %>
                    </div>
                </ItemTemplate>
                
            </asp:Repeater>
            <asp:GridView runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="StoreDataSource">
                <Columns>
                    <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"></asp:BoundField>
                    <asp:BoundField DataField="ContactID" HeaderText="ContactID" SortExpression="ContactID"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                    <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:EntityDataSource runat="server" ID="StoreDataSource" DefaultContainerName="StoreEntities" ConnectionString="name=StoreEntities" EnableFlattening="False" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntitySetName="Orders"></asp:EntityDataSource>
        </div>
    </form>
</body>
</html>

