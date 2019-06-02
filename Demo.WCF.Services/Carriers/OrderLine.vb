Imports System.Runtime.Serialization

<DataContract>
Public Class OrderLine
    <DataMember>
    Public Property OrderNumber As Integer
    <DataMember>
    Public Property OrderLineNumber As Integer
    <DataMember>
    Public Property Description As String
End Class
