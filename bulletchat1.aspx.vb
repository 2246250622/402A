Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports System.Diagnostics

Partial Public Class bulletchat1
    Inherits System.Web.UI.Page

    Dim ConnectionString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FetchComments()
        End If
    End Sub

    Protected Sub FetchComments()
        Dim comments As New List(Of Comment)()

        Using conn As New SqlConnection(ConnectionString)
            Try
                conn.Open()
                Dim sql As String = "SELECT TOP 8 MessageText, SenderName, RecipientName FROM Messages ORDER BY CreatedAt DESC"
                Using cmd As New SqlCommand(sql, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim comment As New Comment()
                            comment.MessageText = reader("MessageText").ToString()
                            comment.SenderName = reader("SenderName").ToString()
                            comment.RecipientName = reader("RecipientName").ToString()
                            comments.Add(comment)



                        End While
                    End Using
                End Using
            Catch ex As Exception
                ' Handle any errors occurred during database operations
                ' You can log the error or display an error message to the user
                ' For simplicity, this example just returns an empty response
                Response.Write("")
                Response.End()
            Finally
                ' Ensure that the connection is closed and disposed
                conn.Close()
            End Try
        End Using

        ' Serialize comments to JSON
        Dim serializer As New JavaScriptSerializer()
        Dim commentsJson As String = serializer.Serialize(comments)

        ' Set the value of the hidden field to the comments JSON
        hfComments.Value = commentsJson

        
    End Sub

End Class
