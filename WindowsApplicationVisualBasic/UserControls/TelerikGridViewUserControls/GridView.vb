Imports Telerik.WinControls.UI
Public Class GridView

    Private Network As Network
    Private netObj As NetworkObj
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Sub New(net As Network)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Network = net

        If Network IsNot Nothing Then
            Dim gridViewUserControl As New NetworkTelerikGridView(Network)
            Me.Controls.Add(gridViewUserControl)
            gridViewUserControl.Dock = DockStyle.Fill
        End If
    End Sub

    Sub New(net As Network, netObject As NetworkObj)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Network = net
        netObj = netObject

        If Network IsNot Nothing AndAlso netObj IsNot Nothing Then
            Dim gridViewUserControl As New NetObjTelerikGridView(Network, netObj)
            Me.Controls.Add(gridViewUserControl)
            gridViewUserControl.Dock = DockStyle.Fill
        End If
    End Sub
End Class
