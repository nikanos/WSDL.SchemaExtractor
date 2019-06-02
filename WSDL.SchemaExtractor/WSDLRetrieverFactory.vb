Public Class WSDLRetrieverFactory
    Public Shared Function Create(source As String) As IWSDLRetriever
        Dim uriResult As Uri = Nothing
        If Uri.TryCreate(source, UriKind.Absolute, uriResult) AndAlso (uriResult.Scheme = Uri.UriSchemeHttp OrElse uriResult.Scheme = Uri.UriSchemeHttps) Then
            Return New WebWSDLRetriever()
        Else
            Return New FileWSDLRetriever()
        End If
    End Function
End Class
