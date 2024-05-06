<%@ Page Language="VB" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>QEH IND2024Admin</title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="MessageId" DataSourceID="SqlDataSource1" Width="1383px" PageSize="30" style="margin-right: 0px">
                <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PageButtonCount="1000" Visible="true"/>
                <Columns>
                    <asp:CommandField CancelText="Cancel" DeleteText="Delete" EditText="Edit" InsertText="Insert" NewText="New" SelectText="Select" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Update" ShowHeader="True" />
                    <asp:BoundField DataField="MessageId" HeaderText="MessageId" InsertVisible="False" ReadOnly="True" SortExpression="MessageId" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="MessageText" HeaderText="MessageText" SortExpression="MessageText" />
                    <asp:BoundField DataField="CreatedAt" HeaderText="CreatedAt" SortExpression="CreatedAt" />
                    <asp:BoundField DataField="SenderName" HeaderText="SenderName" SortExpression="SenderName" />
                    <asp:BoundField DataField="RecipientName" HeaderText="RecipientName" SortExpression="RecipientName" />
                </Columns>
                
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Messages] WHERE [MessageId] = @original_MessageId" InsertCommand="INSERT INTO [Messages] ([MessageText], [CreatedAt], [SenderName], [RecipientName]) VALUES (@MessageText, @CreatedAt, @SenderName, @RecipientName)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Messages] ORDER BY [MessageId] DESC" UpdateCommand="UPDATE [Messages] SET [MessageText] = @MessageText, [CreatedAt] = @CreatedAt, [SenderName] = @SenderName, [RecipientName] = @RecipientName WHERE [MessageId] = @original_MessageId">
                <DeleteParameters>
                    <asp:Parameter Name="original_MessageId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="MessageText" Type="String" />
                    <asp:Parameter Name="CreatedAt" Type="DateTime" />
                    <asp:Parameter Name="SenderName" Type="String" />
                    <asp:Parameter Name="RecipientName" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="MessageText" Type="String" />
                    <asp:Parameter Name="CreatedAt" Type="DateTime" />
                    <asp:Parameter Name="SenderName" Type="String" />
                    <asp:Parameter Name="RecipientName" Type="String" />
                    <asp:Parameter Name="original_MessageId" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
