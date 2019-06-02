Imports System.Xml
Imports System.Xml.Linq

Imports <xmlns:xs="http://www.w3.org/2001/XMLSchema">

Public Class WSDLParser

    Private ReadOnly schemaMapping As IDictionary(Of String, String)

    Public Sub New(schemaMapping As IDictionary(Of String, String))
        Me.schemaMapping = schemaMapping
    End Sub

    Iterator Function Parse(wsdlData As String) As IEnumerable(Of ParsedSchema)

        If wsdlData Is Nothing Then
            Throw New ArgumentNullException(NameOf(wsdlData))
        End If

        Dim wsdlDocument As XDocument = XDocument.Parse(wsdlData)

        'Assume that wsdlData is a multiple part document if there are schemaLocation attributes in an xs:import element
        Dim isMultiplePartDocument As Boolean = wsdlDocument...<xs:import>.Any(Function(x) x.@schemaLocation IsNot Nothing)
        If isMultiplePartDocument Then
            Throw New WSDLParseException($"WSDL data does not seem to be a single-WSDL document")
        End If

        Dim schemas = From schema In wsdlDocument...<xs:schema>
                      Select schema

        For Each sch In schemas
            Dim targetNamespace As String = sch.@targetNamespace
            If Not schemaMapping.ContainsKey(targetNamespace) Then
                Throw New WSDLParseException($"Unmapped schema targetnamespace {targetNamespace} in configuration")
            End If

            Dim schemaImports = From import In sch...<xs:import>
                                Select import

            For Each schemaImport In schemaImports
                Dim ns As String = schemaImport.@namespace

                If Not schemaMapping.ContainsKey(ns) Then
                    Throw New WSDLParseException($"Unmapped import namespace {ns} in configuration")
                End If

                schemaImport.@schemaLocation = schemaMapping(ns)
            Next

            Yield New ParsedSchema With {
                .SchemaFileName = schemaMapping(targetNamespace),
                .SchemaData = sch
            }
        Next
    End Function
End Class
