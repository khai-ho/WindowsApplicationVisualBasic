<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Map = New System.Windows.Forms.Panel()
        Me.NodeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NodeBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PipeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Map.SuspendLayout()
        CType(Me.NodeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NodeBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PipeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 145)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 25)
        Me.Label1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(4, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(184, 137)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(196, 4)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(184, 137)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Load"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(388, 4)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(184, 137)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Original"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Map)
        Me.SplitContainer1.Size = New System.Drawing.Size(2946, 1421)
        Me.SplitContainer1.SplitterDistance = 1014
        Me.SplitContainer1.TabIndex = 5
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridView1.RowTemplate.Height = 33
        Me.DataGridView1.Size = New System.Drawing.Size(1014, 1421)
        Me.DataGridView1.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(48, 418)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Map
        '
        Me.Map.Controls.Add(Me.Button3)
        Me.Map.Controls.Add(Me.Label1)
        Me.Map.Controls.Add(Me.Button1)
        Me.Map.Controls.Add(Me.Button2)
        Me.Map.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Map.Location = New System.Drawing.Point(0, 0)
        Me.Map.Margin = New System.Windows.Forms.Padding(4)
        Me.Map.Name = "Map"
        Me.Map.Size = New System.Drawing.Size(1928, 1421)
        Me.Map.TabIndex = 0
        '
        'NodeBindingSource
        '
        Me.NodeBindingSource.DataSource = GetType(WindowsApplicationVisualBasic.Node)
        '
        'NodeBindingSource1
        '
        Me.NodeBindingSource1.DataSource = GetType(WindowsApplicationVisualBasic.Node)
        '
        'PipeBindingSource
        '
        Me.PipeBindingSource.DataSource = GetType(WindowsApplicationVisualBasic.Pipe)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(245, 48)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2946, 1421)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Map.ResumeLayout(False)
        Me.Map.PerformLayout()
        CType(Me.NodeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NodeBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PipeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Map As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents NodeBindingSource As BindingSource
    Friend WithEvents NodeBindingSource1 As BindingSource
    Friend WithEvents PipeBindingSource As BindingSource
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
End Class
