Imports System.Drawing.Drawing2D

Public Class MapEventsUserControl

    Private network1 As Network
    Private mousePlacement, mouseDisp, mouseClickPosition As Point
    Private currentActivity As String = "nothing"
    Private mouseDelta As Double
    Private MapWidth, MapHeight, MapLength, MapFrameX, MapFrameY As Double
    Private netObj As NetworkObj
    Private FrameLength = 0.1R, ZoomFactor = 0.9R
    Private bindingSource1 As BindingSource


    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Sub createUserControl(network As Network)
        network1 = network
    End Sub
    Sub labelText(s As String)
        Label1.Text += (s & vbCrLf)
    End Sub
    Private Sub MapEventsUserControl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If (Not (network1 Is Nothing)) Then
            Dim DX, Dy As Double
            DX = Network.XMAX - Network.XMIN
            Dy = Network.YMAX - Network.YMIN

            Network.XOFF = MapFrameX - MapLength * Network.XMIN / DX
            Network.YOFF = MapHeight - MapFrameY + MapLength * Network.YMIN / Dy
            Network.XSCALE = MapLength / DX
            Network.YSCALE = -MapLength / Dy

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            e.Graphics.PageUnit = GraphicsUnit.Pixel
            network1.draw(e.Graphics)
        End If
    End Sub

    Private Sub MapEventsUserControl_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        MapHeight = Me.ClientSize.Height
        MapWidth = Me.ClientSize.Width
        If MapWidth < MapHeight Then
            MapLength = (1 - (2 * FrameLength)) * MapWidth
            MapFrameX = FrameLength * MapWidth
            MapFrameY = (MapHeight - MapLength) / 2
        Else
            MapLength = (1 - (2 * FrameLength)) * MapHeight
            MapFrameY = FrameLength * MapHeight
            MapFrameX = (MapWidth - MapLength) / 2
        End If
        Me.Invalidate()
    End Sub

    Private Sub MapEventsUserControl_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        mousePlacement.X = (e.X - Network.XOFF) / Network.XSCALE
        mousePlacement.Y = (e.Y - Network.YOFF) / Network.YSCALE

        Dim dxNorth = Network.YMAX - mousePlacement.Y
        Dim dxSouth = mousePlacement.Y - Network.YMIN
        Dim dxEast = Network.XMAX - mousePlacement.X
        Dim dxWest = mousePlacement.X - Network.XMIN
        If e.Delta > 0 Then

            Network.XMIN = mousePlacement.X - dxWest * ZoomFactor
            Network.XMAX = mousePlacement.X + dxEast * ZoomFactor
            Network.YMIN = mousePlacement.Y - dxSouth * ZoomFactor
            Network.YMAX = mousePlacement.Y + dxNorth * ZoomFactor

        ElseIf e.Delta < 0 Then

            Network.XMIN = mousePlacement.X - dxWest / ZoomFactor
            Network.XMAX = mousePlacement.X + dxEast / ZoomFactor
            Network.YMIN = mousePlacement.Y - dxSouth / ZoomFactor
            Network.YMAX = mousePlacement.Y + dxNorth / ZoomFactor

        End If
        Me.Invalidate()
    End Sub

    Private Sub MapEventsUserControl_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Dim g = Me.CreateGraphics
        If netObj IsNot Nothing AndAlso Not (netObj.mouseOnObject(e.Location)) Then
            currentActivity = "nothing"
            netObj.color = Color.Black
            Me.Invalidate()
        End If

        If (network1 IsNot Nothing) Then
            mouseClickPosition = network1.DSPToGEO(New Point(e.X, e.Y))
            For Each obj In network1.GetNetObj
                If obj.mouseOnObject(e.Location) Then
                    obj.color = Color.Magenta
                    obj.draw(g)
                    netObj = obj
                    currentActivity = "movement"
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub MapEventsUserControl_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Dim g = Me.CreateGraphics
        If (network1 IsNot Nothing) Then
            If (e.Button = MouseButtons.Left) And currentActivity = "nothing" Then
                mousePlacement.X = (e.X - Network.XOFF) / Network.XSCALE
                mousePlacement.Y = (e.Y - Network.YOFF) / Network.YSCALE
                mouseDisp.X = mouseClickPosition.X - mousePlacement.X
                mouseDisp.Y = mouseClickPosition.Y - mousePlacement.Y

                Network.XMIN += mouseDisp.X
                Network.XMAX += mouseDisp.X

                Network.YMIN += mouseDisp.Y
                Network.YMAX += mouseDisp.Y
                Me.Invalidate()
            End If
            If (e.Button = MouseButtons.Left) And currentActivity = "movement" Then
                mousePlacement.X = (e.X - Network.XOFF) / Network.XSCALE
                mousePlacement.Y = (e.Y - Network.YOFF) / Network.YSCALE
                netObj.changeNodeCoordinate(mousePlacement)
                Me.Invalidate()
            End If
        End If
    End Sub
End Class
