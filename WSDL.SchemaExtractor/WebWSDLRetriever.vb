Imports System.IO
Imports System.Net.Http

Public Class WebWSDLRetriever
    Implements IWSDLRetriever

    Private ReadOnly Property Client As New HttpClient

    Public Function RetrieveWSDL(source As String) As String Implements IWSDLRetriever.RetrieveWSDL
        If source Is Nothing Then
            Throw New ArgumentNullException(NameOf(source))
        End If

        Dim task = Client.GetStringAsync(source)
        Return task.Result
    End Function
End Class
