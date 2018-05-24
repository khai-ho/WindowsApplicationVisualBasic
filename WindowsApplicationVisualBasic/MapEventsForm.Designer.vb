<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MapEventsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MapEventsUserControl2 = New WindowsApplicationVisualBasic.MapEventsUserControl()
        Me.SuspendLayout()
        '
        'MapEventsUserControl2
        '
        Me.MapEventsUserControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapEventsUserControl2.Location = New System.Drawing.Point(0, 0)
        Me.MapEventsUserControl2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MapEventsUserControl2.Name = "MapEventsUserControl2"
        Me.MapEventsUserControl2.Size = New System.Drawing.Size(1338, 1256)
        Me.MapEventsUserControl2.TabIndex = 0
        '
        'MapEventsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1338, 1256)
        Me.Controls.Add(Me.MapEventsUserControl2)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "MapEventsForm"
        Me.Text = "MapEventsForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MapEventsUserControl2 As MapEventsUserControl
End Class
