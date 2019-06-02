Imports System.Configuration

Public Class Config
    Implements IConfig

    Public ReadOnly Property SchemaMapping As IDictionary(Of String, String) Implements IConfig.SchemaMapping
        Get
            'Get mapping XSD namespace -> XSD file name from configuration
            Dim mapping As Hashtable = CType(ConfigurationManager.GetSection("SchemaMapping"), Hashtable)

            Return mapping.
                Cast(Of DictionaryEntry).
                ToDictionary(Function(x) CStr(x.Key), Function(x) CStr(x.Value))
        End Get
    End Property
End Class
