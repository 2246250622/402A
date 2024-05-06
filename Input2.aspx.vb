Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.DirectoryServices
Imports System.Configuration
Imports System.Web.Security
Imports System.Net

Public Class Room
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

        Using connection As New SqlConnection(ConnectionString)
            connection.Open()

            Dim query As String = "INSERT INTO Messages (MessageText,SenderName ,RecipientName,  CreatedAt) VALUES (@MessageText,@SenderName, @RecipientName,  @CreatedAt); SELECT SCOPE_IDENTITY()"

            Using command As New SqlCommand(query, connection)
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

                ' ... do something with the message object if needed ...
                connection.Close()
                Msg = "Your message is successfully sent out! Thank You!❤️🌹"
                lbl_Msg.Font.Size = 24
                lbl_Msg.Visible = True
                lbl_Msg.Text = Msg
                messageText = ""
                senderName = ""
                recipientName = ""
                Msg = ""
                 Response.Redirect("input2.aspx")

            End Using
        End Using
        messageText = ""
        senderName = ""
        recipientName = ""
        Msg = ""
        txtMessage.Text = messageText
        txtSenderName.Text = senderName
        txtRecipientName.Text = recipientName
        lbl_Msg.Text = Msg
        Response.Redirect("input2.aspx")
    End Sub
End Class

Public Class ChatDataAccess
    Dim connectionString As String = "DefaultConnection"

    Public Function GetMessages() As List(Of Message)
        Dim messages As New List(Of Message)()

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT * FROM Messages ORDER BY CreatedAt"

            Using command As New SqlCommand(query, connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim message As New Message()
                        message.MessageId = Convert.ToInt32(reader("MessageId"))
                        message.MessageText = reader("MessageText").ToString()
                        message.SenderName = reader("SenderName").ToString()
                        message.RecipientName = reader("RecipientName").ToString()
                        message.CreatedAt = Convert.ToDateTime(reader("CreatedAt"))
                        messages.Add(message)
                    End While
                End Using
            End Using
        End Using

        Return messages
    End Function

    Public Sub InsertMessage(messageText As String, senderName As String, recipientName As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "INSERT INTO Messages (MessageText,SenderName, RecipientName, CreatedAt) VALUES (@messageText,@senderName, @recipientName, @CreatedAt)"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@MessageText", messageText)
                command.Parameters.AddWithValue("@SenderName", senderName)
                command.Parameters.AddWithValue("@RecipientName", recipientName)
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now)

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class

Public Class Message
    Public Property MessageId As Integer
    Public Property MessageText As String
    Public Property CreatedAt As DateTime
    Public Property SenderName As String
    Public Property RecipientName As String
End Class