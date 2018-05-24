Imports Telerik.WinControls.UI
Public Class NetworkTelerikGridView

    'Comment this out and uncomment "Inherits System.Windows.Forms.UserControl"
    'to allow adding of controls in the designer of the control
    Inherits TelerikGridViewParentClass

    'Inherits System.Windows.Forms.UserControl


    Private Network As Network

    'Network will be not need to be passed in the future
    'as it will come from the SAInt API
    Public Sub New(Net As Network)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Network = Net
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        If Network IsNot Nothing Then

            If Network IsNot Nothing Then
                Dim gridViewNodeBindSource As BindingSource = Nothing
                Dim gridViewLineBindSource As BindingSource = Nothing

                gridViewNodeBindSource = New BindingSource(Network.networkNodes, Nothing)
                gridViewLineBindSource = New BindingSource(Network.networkPipes, Nothing)

                RadGridView1.AutoGenerateColumns = False
                RadGridView2.AutoGenerateColumns = False

                addNetObjToGridView(Network.networkNodes(0), RadGridView1)
                addNetObjToGridView(Network.networkPipes(0), RadGridView2)

                RadGridView1.DataSource = gridViewNodeBindSource
                RadGridView2.DataSource = gridViewLineBindSource

                RadGridView1.BestFitColumns()
                RadGridView2.BestFitColumns()

                Dim widthView1 As Int16 = 0
                Dim widthView2 As Int16 = 0

                widthView1 = determineColWidth(RadGridView1)
                widthView2 = determineColWidth(RadGridView2)

                If widthView1 > widthView2 Then
                    Me.ParentForm.Size = New Size(widthView1 + 60, 1000)
                Else
                    Me.ParentForm.Size = New Size(widthView2 + 60, 1000)
                End If
            End If

        End If
    End Sub
End Class

