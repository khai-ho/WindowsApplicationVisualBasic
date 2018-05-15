Imports System.Reflection
Imports System.Xml.Serialization

Public Class Network
    Private name As String
    Private nodes As List(Of Node)
    Private pipes As List(Of Pipe)
    Public Shared XMAX, XMIN, YMAX, YMIN, XOFF, YOFF, XSCALE, YSCALE As Double

    Public Property networkNodes() As List(Of Node)
        Get
            Return nodes
        End Get
        Set(ByVal value As List(Of Node))
            nodes = value
        End Set
    End Property

    Public Property networkPipes() As List(Of Pipe)
        Get
            Return pipes
        End Get
        Set(ByVal value As List(Of Pipe))
            pipes = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(network_name As String, listOfNodes As List(Of Node), listOfPipes As List(Of Pipe))
        name = network_name
        nodes = listOfNodes
        pipes = listOfPipes
    End Sub

    Public Sub draw(g As Graphics)
        For Each pipe As Pipe In pipes
            pipe.draw(g)
        Next
        For Each node As Node In nodes
            node.draw(g)
        Next
    End Sub

    Public Function GetNetObj() As IEnumerable(Of NetworkObj)
        Dim lst As New List(Of NetworkObj)
        lst.AddRange(nodes)
        lst.AddRange(pipes)
        Return lst
    End Function
    Public Sub setNetworkFrame()
        XMIN = Aggregate order In nodes Into Min(order.nodeXCoordinate)
        XMAX = Aggregate order In nodes Into Max(order.nodeXCoordinate)
        YMIN = Aggregate order In nodes Into Min(order.nodeYCoordinate)
        YMAX = Aggregate order In nodes Into Max(order.nodeYCoordinate)
    End Sub

    Public Sub linkPipeToNode()
        For Each pipe In pipes
            pipe.Link2Nodes(nodes)
        Next
    End Sub

    Public Shared Function GEOToDSP(ByVal p As Point) As Point
        GEOToDSP = New Point(XOFF + XSCALE * p.X, YOFF + YSCALE * p.Y)
    End Function

    Public Shared Function DSPToGEO(ByVal p As Point) As Point
        DSPToGEO = New Point((p.X - XOFF) / XSCALE, (p.Y - YOFF) / YSCALE)
    End Function

    Public Sub setColor(c As Color)
        For Each pipe As Pipe In pipes
            pipe.color = c
        Next
        For Each node As Node In nodes
            node.color = c
        Next
    End Sub

    Public Sub sortColumns(dgv As DataGridView, netObj As NetworkObj)

        Dim experiment As PropertyInfo()
        experiment = netObj.GetType.GetProperties
        For Each objProperties In experiment
            Dim objAttributes As IEnumerable(Of Attribute)
            objAttributes = objProperties.GetCustomAttributes()

            Dim propertySort As propertySortingAttribute
            Dim xmlAttribute As XmlAttributeAttribute
            For Each objAttribute In objAttributes
                If objAttribute.GetType Is GetType(propertySortingAttribute) Then
                    propertySort = objAttribute
                End If
                If objAttribute.GetType Is GetType(XmlAttributeAttribute) Then
                    xmlAttribute = objAttribute
                End If
            Next

            If xmlAttribute IsNot Nothing AndAlso propertySort IsNot Nothing Then
                'Label1.Text += xmlAttribute.AttributeName & vbCrLf
                'Label1.Text += propertySort.SortCode.ToString & vbCrLf
                dgv.Columns(xmlAttribute.AttributeName).DisplayIndex = propertySort.SortCode
            End If
        Next

    End Sub
End Class
