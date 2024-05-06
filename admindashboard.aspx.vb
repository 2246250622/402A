Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.DirectoryServices
Imports System.Configuration
Imports System.Web.Security
Imports System.Net
Imports System.Net.Mail

Partial Class admindashboard
    Inherits System.Web.UI.Page
    Dim ConnectionString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    Dim conn As New SqlConnection(ConnectionString)
    Dim OtherConnectionString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    Dim oconn As New SqlConnection(OtherConnectionString)
    Dim myCommand, myCommand1 As New SqlCommand
    Dim dr As SqlDataReader


        Protected Sub SubmitOrder_Click(sender As Object, e As EventArgs)
        Dim selectedDateValue As Date = DateTextBox.SelectedDate
        Dim cmd As New SqlCommand("INSERT INTO [booking] (Date, StartTime, EndDataTime, ContractNo, Remark, SubmitDateTime) VALUES (@Date, @StartTime, @EndTime, @ContractNo, @Remark, GETDATE())", conn)
        
        cmd.Parameters.AddWithValue("@Date", selectedDateValue)
        cmd.Parameters.AddWithValue("@StartTime", StartTimeTextBox.Text)
        cmd.Parameters.AddWithValue("@EndTime", EndTimeTextBox.Text)
        cmd.Parameters.AddWithValue("@ContractNo", ContractNoTextBox.Text)
        cmd.Parameters.AddWithValue("@Remark", RemarkTextBox.Text)


        Try
            conn.Open()
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            Response.Write("<script type='text/javascript'>alert('Your action has been completed!'); window.location = 'https://qehcndsvr2/402A/admindashboard.aspx';")
            Response.Write("</" + "script>")
        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('Something Wrong'); window.location = 'https://qehcndsvr2/402A/admindashboard.aspx';")
            Response.Write("</" + "script>")
        Finally
            conn.Close()
        End Try

        
        ' Handle the case when conversion fails
        ' You can show an error message or take appropriate action

    End Sub

   

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Request.QueryString("Maintenance") = Nothing Then
        '    Response.Redirect("Maintenance.html")
        'End If
    End Sub
End Class


