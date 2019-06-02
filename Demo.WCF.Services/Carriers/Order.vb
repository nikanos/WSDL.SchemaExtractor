Imports System.Runtime.Serialization


<DataContract>
Public Class Order
    'Marking a DataMember as Required will remove the minOccurs="0" in the scema defition
    <DataMember(IsRequired:=True)>
    Public Property OrderNumber As Integer

    'Marking a DataMember as Required will remove the minOccurs="0" in the scema defition
    'Since strings are nullable, nillable="true" attribute will be present in the schema definition
    <DataMember(IsRequired:=True)>
    Public Property Description As String
End Class
