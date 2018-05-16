Public Class PropertyGridForm
    Sub createForm(obj As NetworkObj)
        PropertyGrid1.SelectedObject = obj
        Height = 100 + obj.GetType.GetProperties.GetLength(0) * 25
        Show()
    End Sub

    Private Sub PropertyGridForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        StartPosition = FormStartPosition.Manual
        Location = Form1.MousePosition
    End Sub
End Class