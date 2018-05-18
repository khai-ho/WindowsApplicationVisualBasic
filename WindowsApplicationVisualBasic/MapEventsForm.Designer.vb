<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapEventsForm
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
        Me.MapEventsUserControl1 = New WindowsApplicationVisualBasic.MapEventsUserControl()
        Me.SuspendLayout()
        '
        'MapEventsUserControl1
        '
        Me.MapEventsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapEventsUserControl1.Location = New System.Drawing.Point(0, 0)
        Me.MapEventsUserControl1.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.MapEventsUserControl1.Name = "MapEventsUserControl1"
        Me.MapEventsUserControl1.Size = New System.Drawing.Size(669, 653)
        Me.MapEventsUserControl1.TabIndex = 0
        '
        'MapEventsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 653)
        Me.Controls.Add(Me.MapEventsUserControl1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "MapEventsForm"
        Me.Text = "MapEventsForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MapEventsUserControl1 As MapEventsUserControl
End Class
