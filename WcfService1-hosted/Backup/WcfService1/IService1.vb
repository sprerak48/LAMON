' NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in Web.config.
Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports System.IO
Imports System.Xml
Imports System.Xml.Linq
Imports System.Runtime.Serialization
<ServiceContract()> _
Public Interface IService1

    <WebInvoke(Method:="POST", UriTemplate:="Get_process", BodyStyle:=WebMessageBodyStyle.Bare, RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml)> _
 <OperationContract()> _
Function Get_process(ByVal xmlstring As XElement) As XElement

    <WebInvoke(Method:="POST", UriTemplate:="insert_process", BodyStyle:=WebMessageBodyStyle.Bare, RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml)> _
<OperationContract()> _
Function insert_process(ByVal xmlstring As XElement) As XElement

    <OperationContract()> _
    Function GetData(ByVal value As Integer) As String

    <OperationContract()> _
    Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType

    ' TODO: Add your service operations here

End Interface

' Use a data contract as illustrated in the sample below to add composite types to service operations.
<DataContract()> _
Public Class CompositeType

    Private boolValueField As Boolean
    Private stringValueField As String

    <DataMember()> _
    Public Property BoolValue() As Boolean
        Get
            Return Me.boolValueField
        End Get
        Set(ByVal value As Boolean)
            Me.boolValueField = value
        End Set
    End Property

    <DataMember()> _
    Public Property StringValue() As String
        Get
            Return Me.stringValueField
        End Get
        Set(ByVal value As String)
            Me.stringValueField = value
        End Set
    End Property

End Class
