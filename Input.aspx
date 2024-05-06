<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Input.aspx.vb" Inherits="Input" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>QEH IND 2024</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        #img01 {
            width: 100%;
            height: auto;
            margin: auto;
            display: block;
        }

        .center01 {
            margin: auto;
            width: 90%;
            align-content: center;
            padding: 5px;
        }

        .padding01 {
            padding: 5px;
        }

        .wording01 {
            font-size: xx-large;
            padding: 5px;
        }

        .wording02 {
            font-size: x-large;
            padding: 0.5px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server" class="center01">
        <div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <img src="./img/IND_bulletchat_banner_v1.png" alt="" id="img01" />
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <marquee direction="left" height="35" scrollamount="10" behavior="SCROLL">
                        <h4 class="">🌹😊Welcome to leave message! ❤️🌻歡迎留言!❤️🌹</h4>
                    </marquee>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 wording01">
                    <label for="floatingInput">To (致送給) :</label>
                    <asp:TextBox ID="txtRecipientName" runat="server" class="form-control wording01" placeholder="e.g. ALL Nurses" MaxLength="10" AutoPostBack="True"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 wording01">
                    <label for="floatingPassword">Enter your message (請留言)</label>
                    <asp:TextBox ID="txtMessage" runat="server" class="form-control wording01" placeholder="e.g. Happy International Nurses Day!" MaxLength="50" TextMode="MultiLine" Height="200px"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 wording01">
                    <label for="floatingPassword">Your Name (你的名字)</label>
                    <asp:TextBox ID="txtSenderName" runat="server" class="form-control wording01" placeholder="e.g. CHAN TAI MAN" MaxLength="10" AutoPostBack="True"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 padding01">
                    <asp:Button class="btn btn-primary w-100 py-2 wording02" Text="Send" ID="btnSend" runat="server" OnClick="btnSend_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 wording01">
                    <asp:TextBox runat="server" ID="lbl_Msg" Text="" Visible="false" BorderWidth="0" Style="width: 100%"></asp:TextBox>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
