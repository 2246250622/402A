<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bulletchat.aspx.vb" Inherits="bulletchat" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>IND 2024</title>
    <style>
      #wrapper {
      height: 2140px;
      width: 100%;
      position: relative;
      overflow: hidden;
      /*background: url(http://www.drama-asia.se/wp-content/uploads/2016/06/14375197_1349947520504_800x600.jpg);*/
      
      color: #000000;
      font-size: 35px;
      text-shadow: 1px 1px #000;
    }
    .right {
      position: absolute;
      visibility: hidden;
      white-space: nowrap;
      /*left: 700px;*/
      transform: translateX(6000px);
    }
    .left {
      position: absolute;
      white-space: nowrap;
      user-select: none;
      transition: transform 17s linear; /* 时间相同 越长的弹幕滑动距离越长 所以越快~ */
    }
    h1 {
  position: relative;
  display: inline-block;
  color: #000000;
  font-size: 35px;
  text-shadow: 1px 1px #000;
  padding: 100px;
  background: transparent url('./img/cloud.png') no-repeat center;
  background-size: 100% 100%;
}

h1::after {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: transparent url('./img/cloud.png') no-repeat center;
  background-size: 100% 100%;
  mix-blend-mode: multiply;
}
h2 {
  position: relative;
  display: inline-block;
  color: #000000;
  font-size: 35px;
  text-shadow: 1px 1px #000;
  padding: 50px;
  
  background: transparent url('./img/cloud_yellow.png') no-repeat center;
  background-size: 100% 100%;
}

h2::after {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: transparent url('./img/cloud_yellow.png') no-repeat center;
  background-size: 100% 100%;
  mix-blend-mode: multiply;
}



    </style>



    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/jquery-latest.js"></script>
    <script src="js/barrage.js"></script>
    <link rel="stylesheet" type="text/css" href="css/mystyle.css">
</head>
<body>
    <form id="form1" runat="server">


        <div id="wrapper">
        <span style="display: inline-block;padding-left: 580px;padding-top: 1400px;" id="new"  ></span>
        <span style="display: inline-block;float:right;padding-right: 1300px;padding-top: 1400px;" id="new2"  ></span></div>
        
        

        <asp:HiddenField ID="hfComments" runat="server" />
    </form>

    <script>
function fetchComments() {
    $.ajax({
        type: 'GET',
        url: 'GetComments.aspx',
        success: function (data) {
    //console.log('Data:', data);
    //console.log('Data type:', typeof data);

    var comments;

    if (typeof data === 'string') {
        comments = data.split(',');
    } else if (Array.isArray(data)) {
        comments = data;
    } else {
        console.log('Invalid data type.');
        return;
    }

    //console.log('Comments:', comments);

    // Extract the MessageText from each comment
    var messageTexts = comments.map(function(comment) {
        return comment.MessageText;
    });

    var senderNames = comments.map(function(comment) {
        return comment.SenderName;
    });

    var recipientNames = comments.map(function(comment) {
        return comment.RecipientName;
    });


    // Combine messageTexts, senderNames, and recipientNames into a single array of objects
var danmuPool = [];
for (var i = 0; i < messageTexts.length; i++) {
    danmuPool.push({
        MessageText: messageTexts[i],
        SenderName: senderNames[i],
        RecipientName: recipientNames[i]

        
    });
    console.log(messageTexts.length);
}

// Update the comments and display them in the console
$('#wrapper').barrage({
    danmuPool: danmuPool,
    danmuTpl: function (danmu) {
        return '<center><div class="barrage-item"><h1 type="text" id="text" style="text-align:center" value="' + '">' +'<div style="text-align: left;">To:'+danmu.RecipientName+'</div><br>'+ danmu.MessageText+'<br>' +'<div style="text-align: right;">'+danmu.SenderName+ '</div></h1></div></center>';
    }
});

    // Update the comments and display them in the console
    let a = recipientNames[recipientNames.length - 1];
    let b = messageTexts[messageTexts.length - 1];
    let c = senderNames[senderNames.length - 1];
    document.getElementById("new").innerHTML = '<center><div class="barrage-item"><h2 type="text" id="text" style="text-align:center" value="' + '">' +'<div style="text-align: left;">To:'+a+'</div><br>'+ b+'<br>' +'<div style="text-align: right;">'+c+ '</div></h2></div></center>';

    let d = recipientNames[recipientNames.length - 2];
    let e = messageTexts[messageTexts.length - 2];
    let f = senderNames[senderNames.length - 2];
    document.getElementById("new2").innerHTML = '<center><div class="barrage-item"><h2 type="text" id="text" style="text-align:center" value="' + '">' +'<div style="text-align: left;">To:'+d+'</div><br>'+ e+'<br>' +'<div style="text-align: right;">'+f+ '</div></h2></div></center>';
},
        error: function () {
            console.log('Error fetching comments.');
        }
    });
}

$(document).ready(function () {
    // Fetch comments initially
    fetchComments();

    // Fetch comments every 10 seconds
    setInterval(fetchComments, 5000);

    //var comments = $('#<%= hfComments.ClientID %>').val().split(',');


});
  

  </script>
</body>
</html>