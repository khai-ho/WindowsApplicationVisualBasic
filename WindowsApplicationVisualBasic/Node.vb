Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Xml.Serialization

Public Class Node

    Inherits NetworkObj

    <XmlIgnore>
    Private colour As Color = Color.Black
    Private pressure, elevation, diameter As Double
    Private xCoordinate, yCoordinate As Double
    Private colourCode As Int32

#Region "Nodes Getters Setters"
    <XmlAttribute("nodePressure")>
    <DisplayName("Pressure")>
    <propertySorting(4)>
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
    <propertySorting(5)>
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
    <propertySorting(6)>
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
    <propertySorting(7)>
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
    <propertySorting(8)>
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


    <XmlAttribute("nodeColour")>
    <DisplayName("Colour")>
    <propertySorting(9)>
    <Description("Indicates the color of the node")>
    <Category("Node")>
    Public Property nodeColour() As Int32
        Get
            Return colour.ToArgb
        End Get
        Set(ByVal value As Int32)
            colour = Color.FromArgb(value)
        End Set
    End Property

    <XmlIgnore>
    <DisplayName("Color")>
    <propertySorting(10)>
    <Description("Indicates the color of the node")>
    <Category("Node")>
    Public Property nodeColor() As Color
        Get
            Return colour
        End Get
        Set(ByVal value As Color)
            colour = value
        End Set
    End Property
#End Region

    Public Sub New()
    End Sub
    Public Sub New(node_name As String, node_nr As Int32, node_flowRate As Double, bool As Boolean, node_pressure As Double, node_xCoordinate As Int32, node_yCoordinate As Int32, node_elevation As Double, clr As Color)
        Me.NetObjName = node_name
        Me.NetObjNr = node_nr
        Me.NetObjFlowRate = node_flowRate
        Me.NetObjVisibility = bool
        pressure = node_pressure
        xCoordinate = node_xCoordinate
        yCoordinate = node_yCoordinate
        elevation = node_elevation
        diameter = 20
        colour = clr
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
