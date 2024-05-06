<%@ Page Language="VB" AutoEventWireup="false" CodeFile="display.aspx.vb" Inherits="display" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<style>


</style>
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script>
  // Function to fetch temperature data and update the HTML
  function fetchTemperature() {
    $.ajax({
      url: 'https://data.weather.gov.hk/weatherAPI/opendata/weather.php?dataType=rhrread&lang=tc',
      dataType: 'json',
      success: function(data) {
        // Find the temperature data for '京士柏'
        var temperatureData = data.temperature.data.find(function(item) {
          return item.place === '京士柏';
        });
        
        // Update the HTML with the temperature value and date/time
        if (temperatureData) {
          var temperature = temperatureData.value;
          var dateTime = new Date(data.updateTime).toLocaleString('zh-cn');
          $('#temperature').text(temperature + '°C');
          $('#datetime').text(dateTime);
        } else {
          $('#temperature').text('无法获取温度数据');
          $('#datetime').text('');
        }

          // ...

  if (data.icon) {
    var icon = data.icon;
    $('#weatherIcon').attr('src', './img/pic' + icon + '.png');
  } else {
    // Handle the case when data.icon is not available
  }
  
  // ...
      },
      error: function() {
        $('#temperature').text('无法检索温度数据');
        $('#datetime').text('');
      }
    });
  }

  

  // Fetch temperature initially when the page loads
  $(document).ready(function() {
    fetchTemperature();
  });

  // Fetch temperature every 10 minutes
  setInterval(fetchTemperature, 600000); // 10 minutes = 600,000 milliseconds
</script>


</head>
<body >
  <br><br><br><br>
    <h3 style="text-align: center;position: fixed;top: 50%;left: 50%;transform: translate(-50%, -50%)"><img id="weatherIcon" src="" alt="Weather Icon" style="width:60px;height:60px"><br>即時溫度: <span id="temperature"></span><br>(更新時間: <span id="datetime"></span>) <span id="icon"></span></h3>
</body>
</html>
