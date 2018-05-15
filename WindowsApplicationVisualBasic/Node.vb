Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Xml.Serialization

Public Class Node

    Inherits NetworkObj

    Private pressure, elevation, diameter As Double
    Private xCoordinate, yCoordinate As Double

    <XmlAttribute("nodePressure")>
    <DisplayName("Pressure")>
    <propertySorting(3)>
    <Description("Indicates the pressure of the node")>
    <Category("Node")>
    <Plotting>
    Public Property nodePressure() As Double
        Get
            Return pressure
        End Get
        Set(ByVal value As Double)
            pressure = value
        End Set
    End Property
    <XmlAttribute("nodeElevation")>
    <DisplayName("Elevation")>
    <propertySorting(4)>
    <Description("Indicates the elevation of the node")>
    <Category("Node")>
    Public Property nodeElevation() As Double
        Get
            Return elevation
        End Get
        Set(ByVal value As Double)
            elevation = value
        End Set
    End Property
    <XmlAttribute("nodeDiameter")>
    <DisplayName("Diameter")>
    <propertySorting(5)>
    <Description("Indicates the diamter of the node")>
    <Category("Node")>
    Public Property nodeDiameter() As Double
        Get
            Return diameter
        End Get
        Set(ByVal value As Double)
            diameter = value
        End Set
    End Property
    <XmlAttribute("nodeXCoordinate")>
    <DisplayName("xCoordinate")>
    <propertySorting(6)>
    <Description("Indicates the x-Coordinate of the node")>
    <Category("Node")>
    Public Property nodeXCoordinate() As Int32
        Get
            Return xCoordinate
        End Get
        Set(ByVal value As Int32)
            xCoordinate = value
        End Set
    End Property
    <XmlAttribute("nodeYCoordinate")>
    <propertySorting(7)>
    <DisplayName("yCoordinate")>
    <Description("Indicates the y-Coordinate of the node")>
    <Category("Node")>
    Public Property nodeYCoordinate() As Int32
        Get
            Return yCoordinate
        End Get
        Set(ByVal value As Int32)
            yCoordinate = value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(node_name As String, node_nr As Int32, node_flowRate As Double, node_pressure As Double, node_xCoordinate As Int32, node_yCoordinate As Int32, node_elevation As Double)
        Me.NetObjName = node_name
        Me.NetObjNr = node_nr
        Me.NetObjFlowRate = node_flowRate
        pressure = node_pressure
        xCoordinate = node_xCoordinate
        yCoordinate = node_yCoordinate
        elevation = node_elevation
        diameter = 20
    End Sub
    Function getDispCoor() As Point
        Return Network.GEOToDSP(New Point(xCoordinate, yCoordinate))
    End Function
    Public Overrides Sub draw(g As Graphics)
        Dim pdis = getDispCoor()

        g.DrawEllipse(New Pen(Color.Aqua, 10), New Rectangle(pdis.X - diameter / 2, pdis.Y - diameter / 2, diameter, diameter))
        g.FillEllipse(New SolidBrush(color), New RectangleF(pdis.X - diameter / 2, pdis.Y - diameter / 2, diameter, diameter))
    End Sub
    Public Overrides Sub draw(g As Graphics, c As Color)
        Dim pdis = getDispCoor()

        g.FillEllipse(New SolidBrush(c), New RectangleF(pdis.X - diameter / 2, pdis.Y - diameter / 2, diameter, diameter))
    End Sub
    Public Overrides Function mouseOnObject(mp As Point) As Boolean
        Using gp As New GraphicsPath
            Dim pdis = getDispCoor()

            gp.AddEllipse(New RectangleF(pdis.X - diameter / 2, pdis.Y - diameter / 2, diameter, diameter))
            Return gp.IsVisible(mp)
        End Using
    End Function

    Public Overrides Sub changeNodeCoordinate(p As Point)
        xCoordinate = p.X
        yCoordinate = p.Y
    End Sub



End Class
