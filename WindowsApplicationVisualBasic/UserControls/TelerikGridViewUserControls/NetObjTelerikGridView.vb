Imports Telerik.WinControls.UI
Public Class NetObjTelerikGridView

    'Comment this out and uncomment "Inherits System.Windows.Forms.UserControl"
    'to allow adding of controls in the designer of the control
    Inherits TelerikGridViewParentClass

    'Inherits System.Windows.Forms.UserControl


    Private Network As Network
    Private netObj As NetworkObj

    'Network will be not need to be passed in the future
    'as it will come from the SAInt API
    Public Sub New(Net As Network, netObject As NetworkObj)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Network = Net
        netObj = netObject
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If netObj IsNot Nothing Then

            Dim gridViewNetObjBindSource As BindingSource = Nothing

            If netObj.GetType = GetType(Node) Then
                gridViewNetObjBindSource = New BindingSource(Network.networkNodes, Nothing)
            ElseIf netObj.GetType = GetType(Pipe) Then
                gridViewNetObjBindSource = New BindingSource(Network.networkPipes, Nothing)
            End If

            RadGridView1.AutoGenerateColumns = False

            addNetObjToGridView(netObj, RadGridView1)

            RadGridView1.DataSource = gridViewNetObjBindSource

            RadGridView1.BestFitColumns()

            Dim widthView1 As Int16 = 0

            widthView1 = determineColWidth(RadGridView1)

            Me.ParentForm.Size = New Size(widthView1 + 60, 500)
        End If
    End Sub

End Class
