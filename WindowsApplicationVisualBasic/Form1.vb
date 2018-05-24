Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Reflection
Imports System.Xml.Serialization

Public Class Form1

    Private network1 As Network
    Private mousePlacement, mouseDisp, mouseClickPosition As Point
    Private currentActivity As String = "nothing"
    Private mouseDelta As Double
    Private MapWidth, MapHeight, MapLength, MapFrameX, MapFrameY As Double
    Private netObj As NetworkObj
    Private FrameLength = 0.1R, ZoomFactor = 0.9R
    Private bindingSource1 As BindingSource


    Private Sub printText(str As String)
        Label1.Text += str & vbCrLf
    End Sub

    Private Sub Button1_MouseClick(sender As Object, e As MouseEventArgs) Handles Button1.MouseClick
        If network1 IsNot Nothing Then
            Dim serialWriter As StreamWriter
            serialWriter = New StreamWriter("C:\Users\Khai\Downloads\serialXML.xml")
            Dim xmlWriter As New XmlSerializer(network1.GetType())
            xmlWriter.Serialize(serialWriter, network1)
            serialWriter.Close()
        End If
    End Sub

    Private Sub Button2_MouseClick(sender As Object, e As MouseEventArgs) Handles Button2.MouseClick
        Dim network As New Network
        Dim xmlSerializer As XmlSerializer = New XmlSerializer(network.GetType)
        Dim readStream As FileStream = New FileStream("C:\Users\Khai\Downloads\serialXML.xml", FileMode.Open)
        network = CType(xmlSerializer.Deserialize(readStream), Network)

        network1 = network
        network1.linkPipeToNode()
        network1.setNetworkFrame()
        network1.setColor(Color.Black)
        Map.Invalidate()
        readStream.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim nodes = New List(Of Node) From {
            New Node("name1", 1, 3.3, True, 4.4, 100, 100, 0, Color.AliceBlue),
            New Node("name2", 2, 3.3, True, 4.4, 200, 200, 0, Color.AntiqueWhite),
            New Node("name3", 3, 3.3, True, 4.4, 300, 100, 0, Color.Aqua)
        }
        Dim pipes = New List(Of Pipe) From {
            New Pipe("pipe1", 1, 2.2, True, nodes(0), nodes(2), 80, 600, 0.012, 3.3, 0),
            New Pipe("pipe2", 2, 2.2, False, nodes(0), nodes(1), 90, 600, 0.012, 3.3, 1),
            New Pipe("pipe3", 3, 2.2, False, nodes(1), nodes(2), 100, 600, 0.012, 3.3, 2)
        }
        network1 = New Network("network1", nodes, pipes)
        network1.setNetworkFrame()
        Map.Invalidate()
    End Sub

    Private Sub Button4_MouseClick(sender As Object, e As MouseEventArgs) Handles Button4.MouseClick
        If network1 IsNot Nothing Then
            Dim mapUC As New MapEventsForm
            mapUC.createForm()
            mapUC.MapEventsUserControl2.createUserControl(network1)
        End If
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Map.Paint
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

    Private Sub SplitContainer1_SizeChanged(sender As Object, e As EventArgs) Handles Map.SizeChanged
        MapHeight = Map.ClientSize.Height
        MapWidth = Map.ClientSize.Width
        If MapWidth < MapHeight Then
            MapLength = (1 - (2 * FrameLength)) * MapWidth
            MapFrameX = FrameLength * MapWidth
            MapFrameY = (MapHeight - MapLength) / 2
        Else
            MapLength = (1 - (2 * FrameLength)) * MapHeight
            MapFrameY = FrameLength * MapHeight
            MapFrameX = (MapWidth - MapLength) / 2
        End If
        Map.Invalidate()
    End Sub

    Private Sub Map_MouseDown(sender As Object, e As MouseEventArgs) Handles Map.MouseDown
        Dim g = Map.CreateGraphics

        'Unmark objects in map
        If netObj IsNot Nothing AndAlso Not (netObj.mouseOnObject(e.Location)) Then
            currentActivity = "nothing"
            netObj.color = Color.Black
            Map.Invalidate()
        End If

        'Mark objects in map
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

    Private Sub Map_MouseWheel(sender As Object, e As MouseEventArgs) Handles Map.MouseWheel
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
        Map.Invalidate()
    End Sub

    Private Sub Map_MouseMove(sender As Object, e As MouseEventArgs) Handles Map.MouseMove
        Dim g = Map.CreateGraphics
        If (network1 IsNot Nothing) Then
            'Move map
            If (e.Button = MouseButtons.Left) And currentActivity = "nothing" Then
                mousePlacement.X = (e.X - Network.XOFF) / Network.XSCALE
                mousePlacement.Y = (e.Y - Network.YOFF) / Network.YSCALE
                mouseDisp.X = mouseClickPosition.X - mousePlacement.X
                mouseDisp.Y = mouseClickPosition.Y - mousePlacement.Y

                Network.XMIN += mouseDisp.X
                Network.XMAX += mouseDisp.X

                Network.YMIN += mouseDisp.Y
                Network.YMAX += mouseDisp.Y
                Map.Invalidate()
            End If

            'Move object
            If (e.Button = MouseButtons.Left) And currentActivity = "movement" Then
                mousePlacement.X = (e.X - Network.XOFF) / Network.XSCALE
                mousePlacement.Y = (e.Y - Network.YOFF) / Network.YSCALE
                netObj.changeNodeCoordinate(mousePlacement)
                Map.Invalidate()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Map_MouseClick(sender As Object, e As MouseEventArgs) Handles Map.MouseClick

        'Left Click on NetObject in map to bring up DataGridView
        If network1 IsNot Nothing AndAlso e.Button = MouseButtons.Left Then
            DataGridView1.Columns.Clear()

            Dim dgvBindSource As BindingSource = Nothing

            If TypeOf netObj Is Node Then
                dgvBindSource = New BindingSource(network1.networkNodes, Nothing)
            ElseIf TypeOf netObj Is Pipe Then
                dgvBindSource = New BindingSource(network1.networkPipes, Nothing)
            End If

            If dgvBindSource IsNot Nothing Then
                DataGridView1.AutoGenerateColumns = False
                DataGridView1.AutoSize = True

                Dim attlist As List(Of propertySortingAttribute) = netObj.getPropSortAttrlist(netObj)
                attlist.Sort(Function(x As propertySortingAttribute, y As propertySortingAttribute) x.SortCode.CompareTo(y.SortCode))
                For Each att In attlist
                    Dim dgvColumn As New DataGridViewTextBoxColumn
                    dgvColumn.DataPropertyName = att.PropInfo.Name
                    dgvColumn.Name = att.PropInfo.Name
                    dgvColumn.HeaderText = att.DisplayName
                    DataGridView1.Columns.Add(dgvColumn)
                Next
            End If
            DataGridView1.DataSource = dgvBindSource
        End If

        'Right Click on Object in map to bring up ContextMenu
        If netObj IsNot Nothing AndAlso e.Button = MouseButtons.Right AndAlso (netObj.mouseOnObject(e.Location)) Then
            createRightClickContextMenu(netObj)
            printText("Hello")
        End If
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown

        'Left click on netObject in DataGridView to mark
        If e.Button = MouseButtons.Left Then
            Dim g = Map.CreateGraphics
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim obj As NetworkObj = TryCast(selectedRow.DataBoundItem, NetworkObj)
            If obj IsNot Nothing Then
                netObj.color = Color.Black
                netObj = obj
                obj.color = Color.Magenta
                Map.Invalidate()
            End If
        End If

        'Right click in DataGridView to bring up ContextMenu
        If e.Button = MouseButtons.Right Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim obj As NetworkObj = TryCast(selectedRow.DataBoundItem, NetworkObj)
            If obj IsNot Nothing Then
                createRightClickContextMenu(obj)
            End If
        End If
    End Sub

    Sub helloWorld(sender As Object, e As MouseEventArgs)

        '
        If e.Button = MouseButtons.Left Then
            Dim item = TryCast(sender, ToolStripItem)
            If item IsNot Nothing Then
                Dim attr = TryCast(item.Tag, PlottingAttribute)
                If attr IsNot Nothing Then
                    printText(attr.DisplayName)
                    printText(attr.obj.NetObjName)
                    printText(attr.PropInfo.GetValue(attr.obj))
                End If
            End If
        End If
    End Sub

    Sub propertiesItem(sender As Object, e As MouseEventArgs)
        Dim item = TryCast(sender, ToolStripItem)
        If item IsNot Nothing Then
            Dim obj = TryCast(item.Tag, NetworkObj)
            If obj IsNot Nothing Then
                Dim propertyForm As New PropertyGridForm
                propertyForm.createForm(obj)
            End If
        End If
    End Sub

    Sub netObjDataGrid(sender As Object, e As MouseEventArgs)

        If network1 IsNot Nothing Then
            Dim item = TryCast(sender, ToolStripItem)
            If item IsNot Nothing Then
                Dim obj = TryCast(item.Tag, NetworkObj)
                If obj IsNot Nothing Then

                    Dim newGridUserControl As New GridView(network1, obj)

                    Dim newForm As New Form

                    newForm.Controls.Add(newGridUserControl)
                    newGridUserControl.Dock = DockStyle.Fill
                    newForm.Show()
                End If
            End If
        End If

    End Sub

    Sub createRightClickContextMenu(obj As NetworkObj)
        Dim attrlist As List(Of PlottingAttribute) = obj.getPlotAttrlist(obj)
        ContextMenuStrip1.Items.Clear()
        For Each attr In attrlist
            attr.obj = obj
            Dim item = ContextMenuStrip1.Items.Add("Plot: " & attr.DisplayName)
            item.Tag = attr
            AddHandler item.MouseDown, AddressOf helloWorld
        Next
        Dim item2 = ContextMenuStrip1.Items.Add("View Data Grid")
        item2.Tag = obj
        AddHandler item2.MouseDown, AddressOf netObjDataGrid
        Dim item3 = ContextMenuStrip1.Items.Add("Properties")
        item3.Tag = obj
        AddHandler item3.MouseDown, AddressOf propertiesItem
        ContextMenuStrip1.Show(Form1.MousePosition)
    End Sub

    Private Sub Map_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Map.MouseDoubleClick
        If netObj IsNot Nothing AndAlso netObj.mouseOnObject(e.Location) Then
            Dim propertyForm As New PropertyGridForm
            propertyForm.createForm(netObj)
        End If
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim obj As NetworkObj = TryCast(selectedRow.DataBoundItem, NetworkObj)
        If obj IsNot Nothing Then
            Dim propertyForm As New PropertyGridForm
            propertyForm.createForm(obj)
        End If
    End Sub

    Private Sub Button5_MouseClick(sender As Object, e As MouseEventArgs) Handles Button5.MouseClick
        If network1 IsNot Nothing Then
            Dim newForm As New Form

            Dim newGridUserControl As New GridView(network1)

            newForm.Controls.Add(newGridUserControl)
            newGridUserControl.Dock = DockStyle.Fill

            newForm.Show()
        End If
    End Sub
End Class

