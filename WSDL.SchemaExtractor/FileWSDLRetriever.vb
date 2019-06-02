Imports System.IO

Public Class FileWSDLRetriever
    Implements IWSDLRetriever

    Public Function RetrieveWSDL(source As String) As String Implements IWSDLRetriever.RetrieveWSDL
        Return File.ReadAllText(source)
    End Function
End Class
