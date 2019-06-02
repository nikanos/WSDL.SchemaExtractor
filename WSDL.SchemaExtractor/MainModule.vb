Imports CommandLine


Module MainModule

    Sub Main(args As String())

        Dim commandLineParser As New Parser(Sub(opt)
                                                opt.HelpWriter = Console.Error
                                            End Sub)
        Dim opts As New Options()
        Dim conf As New Config()
        If commandLineParser.ParseArguments(args, opts) Then
            Dim wsdlRetriever As IWSDLRetriever = WSDLRetrieverFactory.Create(opts.InputSource)
            Dim wsdlData As String = wsdlRetriever.RetrieveWSDL(opts.InputSource)
            Dim wsdlParser As New WSDLParser(conf.SchemaMapping)

            Dim parsedSchemas As IEnumerable(Of ParsedSchema) = wsdlParser.Parse(wsdlData)
            Dim persister As ISchemaPersister = New FileSchemaPersister(opts.OutputDirectory)
            For Each result As ParsedSchema In parsedSchemas
                Console.WriteLine($"Extracting {result.SchemaFileName}")
                persister.PersistSchema(result)
            Next
        End If

    End Sub

End Module
