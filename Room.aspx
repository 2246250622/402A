<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Room.aspx.vb" Inherits="Room" %>
<html lang="en"><head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  <link rel="icon" href="/docs/4.0/assets/img/favicons/favicon.ico">

  <title>Signin Template for Bootstrap</title>

  <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">

  <!-- Bootstrap core CSS -->
  <link href="css/bootstrap.min.css" rel="stylesheet">

  <!-- Custom styles for this template -->
  <link href="css/sign-in.css" rel="stylesheet">
</head>

<body class="d-flex align-items-center py-4 bg-body-tertiary" data-new-gr-c-s-check-loaded="14.1169.0" data-gr-ext-installed="" style="background-color:#ffcad4">
   

    

  <form id="form1" runat="server"  class = 'form-signin w-100 m-auto'>
    <img class="mb-4" src="./img/IND_bulletchat_banner_v1.png" alt="" width="100%" >
    <marquee direction="left" height="30" scrollamount="5" behavior="SCROLL"><h4 class="">❤️🌻歡迎留言🌹😊Welcome to leave message! ❤️🌻歡迎留言😊🌹</h4><br></marquee>
<br>
    <div class="form-floating">
      <label for="floatingInput">To (致送給) :</label>
        <asp:TextBox ID="txtRecipientName" runat="server"  class="form-control"  placeholder="e.g. ALL Nurses" maxlength="20" required></asp:TextBox>

    </div><br>
    <div class="form-floating">
      <label for="floatingPassword">Enter your message (請留言)</label>
      <asp:TextBox ID="txtMessage" runat="server" class="form-control" placeholder="e.g. Happy International Nurses Day!"  maxlength="70" TextMode="MultiLine" required></asp:TextBox>

    </div><br>
    <div class="form-floating">
      <label for="floatingPassword">Your Name (你的名字)</label>
        <asp:TextBox ID="txtSenderName" runat="server" class="form-control" placeholder="e.g. CHAN TAI MAN" maxlength="20"   required ></asp:TextBox>

      </div><br>

      <div id="successMessage" class="alert alert-success" role="alert" runat="server" visible="false">
        Message sent successfully❤️🌹留言發送成功
    </div>
    <asp:Label ID="errorLabel" runat="server" Visible="False" />

    <div id="errorMessage" class="alert alert-warning" role="alert" runat="server" visible="false">
      Message contains inappropriate content. Please resubmit.<br />留言含不當內容，請重新輸入!
  </div>

    <asp:Button  class="btn btn-primary w-100 py-2" Text="Send (發送)" ID="btnSend" runat="server"  OnClick="btnSend_Click" />


  </form>

<script src="js/bootstrap.bundle.min.js"></script>

    </body>


</html>