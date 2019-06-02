Imports System.Text
Imports System.IO

Public Class FileSchemaPersister
    Implements ISchemaPersister

    Private ReadOnly Property OutputDirectory As String

    Public Sub New(outputDirectory As String)
        Me.OutputDirectory = outputDirectory
    End Sub

    Public Sub PersistSchema(parsedSchema As ParsedSchema) Implements ISchemaPersister.PersistSchema
        If parsedSchema Is Nothing Then
            Throw New ArgumentNullException(NameOf(parsedSchema))
        End If

        Dim outputFile = If(Not String.IsNullOrEmpty(OutputDirectory), Path.Combine(OutputDirectory, parsedSchema.SchemaFileName), parsedSchema.SchemaFileName)
        File.WriteAllText(outputFile, parsedSchema.SchemaData.ToString(), Encoding.UTF8)
    End Sub
End Class
