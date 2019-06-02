
Imports System.ServiceModel

<ServiceContract>
Public Interface IOrderService
    <OperationContract>
    Function GetOders() As List(Of Order)

    <OperationContract>
    Function GetOderLines(orderNumber As Integer) As List(Of OrderLine)
End Interface
