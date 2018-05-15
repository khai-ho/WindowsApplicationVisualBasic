Imports System.ComponentModel
Imports System.Xml.Serialization

Public Class Pipe
    Inherits NetworkObj

    <XmlIgnore>
    Public fromNode, toNode As Node
    Private length, diameter, roughness, slope As Double
    Private fromNodeName, toNodeName As String
#Region "Pipes Getters & Setters"
    <XmlAttribute("pipeLength")>
    <DisplayName("Length")>
    <propertySorting(5)>
    <Description("Indicates the length of the pipe")>
    <Category("Pipe")>
    Public Property pipeLength() As Double
        Get
            Return length
        End Get
        Set(ByVal value As Double)
            length = value
        End Set
    End Property
    <XmlAttribute("pipeDiameter")>
    <DisplayName("Diameter")>
    <propertySorting(6)>
    <Description("Indicates the diameter of the pipe")>
    <Category("Pipe")>
    Public Property pipeDiameter() As Double
        Get
            Return diameter
        End Get
        Set(ByVal value As Double)
            diameter = value
        End Set
    End Property
    <XmlAttribute("pipeRoughness")>
    <DisplayName("Roughness")>
    <propertySorting(7)>
    <Description("Indicates the roughness of the pipe")>
    <Category("Pipe")>
    Public Property pipeRoughness() As Double
        Get
            Return roughness
        End Get
        Set(ByVal value As Double)
            roughness = value
        End Set
    End Property
    <XmlAttribute("pipeSlope")>
    <DisplayName("Slope")>
    <propertySorting(8)>
    <Description("Indicates the slope of the pipe")>
    <Category("Pipe")>
    Public Property pipeSlope() As Double
        Get
            Return slope
        End Get
        Set(ByVal value As Double)
            slope = value
        End Set
    End Property
    <XmlAttribute("pipeFromNodeName")>
    <DisplayName("FromNode")>
    <propertySorting(3)>
    <Description("Indicates the from which node the pipe is connected to")>
    <Category("Pipe")>
    Public Property pipeFromNodeName() As String

        Get
            If (fromNode IsNot Nothing) Then
                Return fromNode.NetObjName
            End If
            Return ""
        End Get

        Set(ByVal value As String)
            fromNodeName = value
        End Set

    End Property
    <XmlAttribute("pipeToNodeName")>
    <DisplayName("ToNode")>
    <propertySorting(4)>
    <Description("Indicates the to which node the pipe is connected to")>
    <Category("Pipe")>
    Public Property pipeToNodeName() As String
        Get
            If (toNode IsNot Nothing) Then
                Return toNode.NetObjName
            End If
            Return ""
        End Get

        Set(ByVal value As String)
            toNodeName = value
        End Set
    End Property
#End Region
    Public Sub New()
    End Sub
    Public Sub New(pipe_name As String, pipe_nr As Int32, pipe_flowRate As Double, pipe_fromNode As Node, pipe_toNode As Node, pipe_length As Double, pipe_diameter As Double, pipe_roughness As Double, pipe_slope As Double)
        Me.NetObjName = pipe_name
        Me.NetObjNr = pipe_nr
        Me.NetObjFlowRate = pipe_flowRate
        fromNode = pipe_fromNode
        toNode = pipe_toNode
        length = pipe_length
        diameter = pipe_diameter
        roughness = pipe_roughness
        slope = pipe_slope
    End Sub
    Sub Link2Nodes(nodes As IEnumerable(Of Node))
        Dim lmbFrom = Function(x) x.NetObjName().ToLower = fromNodeName.ToLower
        Dim lmbTo = Function(x) x.NetObjName().ToLower = toNodeName.ToLower


        fromNode = nodes.ToList.Find(lmbFrom)
        toNode = nodes.ToList.Find(lmbTo)
    End Sub
    Public Overrides Sub draw(g As Graphics)
        Dim fromNodeDispCoor = fromNode.getDispCoor
        Dim toNodeDispCoor = toNode.getDispCoor
        g.DrawLine(New Pen(color, 1), New Point(fromNodeDispCoor.X, fromNodeDispCoor.Y), New Point(toNodeDispCoor.X, toNodeDispCoor.Y))
    End Sub
    Public Overrides Sub draw(g As Graphics, c As Color)
        Dim fromNodeDispCoor = fromNode.getDispCoor
        Dim toNodeDispCoor = toNode.getDispCoor
        g.DrawLine(New Pen(c, 1), New Point(fromNodeDispCoor.X, fromNodeDispCoor.Y), New Point(toNodeDispCoor.X, toNodeDispCoor.Y))
    End Sub
    Public Overrides Function mouseOnObject(mp As Point) As Boolean
        Using gp As New Drawing2D.GraphicsPath
            Dim fromNodeDispCoor = fromNode.getDispCoor
            Dim toNodeDispCoor = toNode.getDispCoor
            gp.AddLine(New Point(fromNodeDispCoor.X, fromNodeDispCoor.Y), New Point(toNodeDispCoor.X, toNodeDispCoor.Y))
            Using p As New Pen(Color.Black, 5)
                Return gp.IsOutlineVisible(mp, p)
            End Using
        End Using
    End Function

    Public Overrides Sub changeNodeCoordinate(p As Point)

        Dim fN = New Point((fromNode.nodeXCoordinate - toNode.nodeXCoordinate) / 2, (fromNode.nodeYCoordinate - toNode.nodeYCoordinate) / 2)
        fromNode.changeNodeCoordinate(p - fN)
        toNode.changeNodeCoordinate(p + fN)

    End Sub
End Class
