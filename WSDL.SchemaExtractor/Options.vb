Imports CommandLine
Imports CommandLine.Text

Public Class Options
    Implements IOptions

    <[Option]("i"c, "input", Required:=True, HelpText:="Input single WSDL (file or URL)")>
    Public Property InputSource As String Implements IOptions.InputSource

    <[Option]("o"c, "outputDir", Required:=False, HelpText:="Output Directory")>
    Public Property OutputDirectory As String Implements IOptions.OutputDirectory

    <HelpOption>
    Public Function GetUsage() As String
        Dim help As New HelpText With {
            .Heading = New HeadingInfo("WSDL.SchemaExtractor"),
            .AdditionalNewLineAfterOption = False,
            .AddDashesToOption = True
        }
        help.AddOptions(Me)
        Return help
    End Function
End Class
