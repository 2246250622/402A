<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RoomAdmin.aspx.vb" Inherits="RoomAdmin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bullet Chat</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        #messageContainer {
            height: 300px;
            overflow-y: scroll;
        }
        .message {
            margin-bottom: 10px;
            padding: 10px;
            background-color: #f8f9fa;
            border: 1px solid #dee2e6;
            border-radius: 4px;
        }
        .message-sender {
            font-weight: bold;
        }
        .message-body {
            margin-top: 5px;
        }
        .message-text {
            margin-bottom: 5px;
        }
        .message-meta {
            font-size: 12px;
            color: #868e96;
        }
        .message-recipient {
            margin-right: 10px;
            font-weight: bold;
        }
        .message-created-at {
            font-style: italic;
        }
    </style>
    <script>
        function scrollToBottom() {
            var messageContainer = document.getElementById("messageContainer");
            messageContainer.scrollTop = messageContainer.scrollHeight;
        }
        window.onload = scrollToBottom;
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="card">
                <div class="card-body">
                    <div id="messageContainer" class="overflow-auto">
                        <asp:Repeater ID="rptMessages" runat="server">
                            <ItemTemplate>
                                <div class="message">
                                    <div class="message-sender"><%# Eval("SenderName") %></div>
                                    <div class="message-body">
                                        <div class="message-text"><%# Eval("MessageText") %></div>
                                        <div class="message-meta">
                                            <span class="message-recipient">To: <%# Eval("RecipientName") %></span>
                                            <span class="message-created-at"><%# Eval("CreatedAt") %></span>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <br />
            <div class="input-group">
                <asp:TextBox ID="txtSenderName" runat="server" CssClass="form-control" Width="200" placeholder="Sender Name"></asp:TextBox>
                <asp:TextBox ID="txtRecipientName" runat="server" CssClass="form-control" Width="200" placeholder="Recipient Name"></asp:TextBox>
                <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" Width="500" placeholder="Enter your message"></asp:TextBox>
                <div class="input-group-append">
                    <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>