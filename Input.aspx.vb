Imports System
Imports System.Data.SqlClient

Public Class Input
    Inherits System.Web.UI.Page

    Dim ConnectionString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub



    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim messageText As String = txtMessage.Text.Trim()
        Dim senderName As String = txtSenderName.Text.Trim()
        Dim recipientName As String = txtRecipientName.Text.Trim()
        Dim Msg As String = ""

        Try

            Dim connection As New SqlConnection(ConnectionString)
            connection.Open()
            Dim query As String = "INSERT INTO Messages (MessageText,SenderName ,RecipientName,  CreatedAt) VALUES (@MessageText,@SenderName, @RecipientName,  @CreatedAt); SELECT SCOPE_IDENTITY()"

            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@MessageText", messageText)
            command.Parameters.AddWithValue("@SenderName", senderName)
            command.Parameters.AddWithValue("@RecipientName", recipientName)
            command.Parameters.AddWithValue("@CreatedAt", DateTime.Now)

            Dim messageId As Integer = Convert.ToInt32(command.ExecuteScalar())

            ' Assuming you have a MessageId property in the Message class
            Dim message As New Message()
            message.MessageId = messageId
            message.MessageText = messageText
            message.SenderName = senderName
            message.RecipientName = recipientName
            message.CreatedAt = DateTime.Now

            connection.Close()
            Msg = "Your message is successfully sent out! Thank You!❤️🌹"
            lbl_Msg.Font.Size = 32
            lbl_Msg.Visible = True
            lbl_Msg.Text = Msg
            messageText = ""
            senderName = ""
            recipientName = ""
            Msg = ""
        Catch ex As Exception
            lbl_Msg.Font.Size = 32
            lbl_Msg.ForeColor = Drawing.Color.Red
            lbl_Msg.Visible = True
            lbl_Msg.Text = ex.ToString
        End Try

    End Sub

End Class

Public Class Message
    Public Property MessageId As Integer
    Public Property MessageText As String
    Public Property CreatedAt As DateTime
    Public Property SenderName As String
    Public Property RecipientName As String

    Public Property Msg As String
End Class
