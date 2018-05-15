<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertyGridForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.PropertyGrid1.Size = New System.Drawing.Size(414, 527)
        Me.PropertyGrid1.TabIndex = 7
        '
        'PropertyGridForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 527)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Name = "PropertyGridForm"
        Me.Text = "PropertyGridForm"
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents PropertyGrid1 As PropertyGrid
End Class
