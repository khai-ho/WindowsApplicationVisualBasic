Imports System.Xml.Serialization
Imports System.ComponentModel
Imports System.Reflection
Imports WindowsApplicationVisualBasic

Public MustInherit Class NetworkObj
    Private name As String
    Private nr As Int32
    Private flowRate As Double
    Private isVisibile As Boolean = True

    <XmlAttribute("NetObjVisibility")>
    <DisplayName("Show")>
    <propertySorting(3)>
    <Description("Indicates whether the object is to be shown")>
    <Category("Network Object")>
    Public Property NetObjVisibility() As Boolean
        Get
            Return isVisibile
        End Get
        Set(ByVal value As Boolean)
            isVisibile = value
        End Set
    End Property

    <XmlAttribute("NetObjName")>
    <DisplayName("Name")>
    <propertySorting(0)>
    <Description("Indicates the name used by the object")>
    <Category("Network Object")>
    Public Property NetObjName() As String
        Get
            Return name
        End Get
        Set(ByVal value As String)
            name = value
        End Set
    End Property
    <XmlAttribute("NetObjNr")>
    <DisplayName("Number")>
    <propertySorting(1)>
    <Description("Indicates the number used by the object")>
    <Category("Network Object")>
    Public Property NetObjNr() As Int32
        Get
            Return nr
        End Get
        Set(ByVal value As Int32)
            nr = value
        End Set
    End Property
    <XmlAttribute("NetObjFlowRate")>
    <DisplayName("Flow Rate")>
    <Description("Indicates the flow rate of the object")>
    <propertySorting(2)>
    <Category("Network Object")>
    <Plotting>
    Public Property NetObjFlowRate() As Double
        Get
            Return flowRate
        End Get
        Set(ByVal value As Double)
            flowRate = value
        End Set
    End Property

    <XmlIgnore>
    Public color As Color = Color.Black

    Public MustOverride Sub draw(g As Graphics)
    Public MustOverride Sub draw(g As Graphics, c As Color)
    Public MustOverride Function mouseOnObject(mp As Point) As Boolean
    Public MustOverride Sub changeNodeCoordinate(p As Point)
    Public Function getPropSortAttrlist(netObj As NetworkObj) As List(Of propertySortingAttribute)
        Dim attlist As New List(Of propertySortingAttribute)
        For Each prop In netObj.GetType.GetProperties
            Dim att = TryCast(prop.GetCustomAttribute(GetType(propertySortingAttribute), True), propertySortingAttribute)
            If att IsNot Nothing Then
                att.DisplayName = TryCast(prop.GetCustomAttribute(GetType(ComponentModel.DisplayNameAttribute), True), ComponentModel.DisplayNameAttribute).DisplayName
                att.PropInfo = prop
                attlist.Add(att)
            End If
        Next
        Return attlist
    End Function

    Public Function getPlotAttrlist(netobj As NetworkObj) As List(Of PlottingAttribute)
        Dim attlist As New List(Of PlottingAttribute)
        For Each prop In netobj.GetType.GetProperties
            Dim att = TryCast(prop.GetCustomAttribute(GetType(PlottingAttribute), True), PlottingAttribute)
            If att IsNot Nothing Then
                att.DisplayName = TryCast(prop.GetCustomAttribute(GetType(ComponentModel.DisplayNameAttribute), True), ComponentModel.DisplayNameAttribute).DisplayName
                att.PropInfo = prop
                attlist.Add(att)
            End If
        Next
        Return attlist
    End Function

End Class

<AttributeUsage(AttributeTargets.Property)>
Public Class propertySortingAttribute
    Inherits Attribute
    Implements IComparable(Of propertySortingAttribute)

    Sub New(SortCode As Integer)
        mySortCode = SortCode
    End Sub

    Public Function CompareTo(other As propertySortingAttribute) As Integer Implements IComparable(Of propertySortingAttribute).CompareTo
        Return Me.SortCode.CompareTo(other.SortCode)
    End Function

    Private mySortCode As Integer
    Public Property SortCode() As Integer
        Get
            Return mySortCode
        End Get
        Set(ByVal value As Integer)
            mySortCode = value
        End Set
    End Property

    Private myPropInfo As PropertyInfo
    Public Property PropInfo() As PropertyInfo
        Get
            Return myPropInfo
        End Get
        Set(ByVal value As PropertyInfo)
            myPropInfo = value
        End Set
    End Property


    Private myDisplayName As String
    Public Property DisplayName() As String
        Get
            Return myDisplayName
        End Get
        Set(ByVal value As String)
            myDisplayName = value
        End Set
    End Property
End Class

<AttributeUsage(AttributeTargets.Property)>
Public Class PlottingAttribute
    Inherits Attribute
    Sub New()
    End Sub

    Private myPropInfo As PropertyInfo
    Public Property PropInfo() As PropertyInfo
        Get
            Return myPropInfo
        End Get
        Set(ByVal value As PropertyInfo)
            myPropInfo = value
        End Set
    End Property

    Private myDisplayName As String
    Public Property DisplayName() As String
        Get
            Return myDisplayName
        End Get
        Set(ByVal value As String)
            myDisplayName = value
        End Set
    End Property

    Private myObj As NetworkObj
    Public Property obj() As NetworkObj
        Get
            Return myObj
        End Get
        Set(ByVal value As NetworkObj)
            myObj = value
        End Set
    End Property
End Class