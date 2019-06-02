
Imports Demo.WCF.Services

Public Class OrderService
    Implements IOrderService

    Public Function GetOders() As List(Of Order) Implements IOrderService.GetOders
        Throw New NotImplementedException()
    End Function

    Public Function GetOderLines(orderNumber As Integer) As List(Of OrderLine) Implements IOrderService.GetOderLines
        Throw New NotImplementedException()
    End Function
End Class
