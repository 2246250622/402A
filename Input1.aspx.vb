Imports System
Imports System.Data.SqlClient

Public Class Input1
    Inherits System.Web.UI.Page
    Dim ConnectionString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    Dim query As String = "INSERT INTO Messages (MessageText,SenderName ,RecipientName,  CreatedAt) VALUES (@MessageText,@SenderName, @RecipientName,  @CreatedAt); SELECT SCOPE_IDENTITY()"

    Dim recipientName As String
    Dim messageText As String
    Dim senderName As String

    Dim Msg As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub



    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click



    End Sub


End Class


