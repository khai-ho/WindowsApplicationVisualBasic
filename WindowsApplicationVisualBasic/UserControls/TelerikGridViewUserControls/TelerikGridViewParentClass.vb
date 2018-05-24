Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Public MustInherit Class TelerikGridViewParentClass

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub addNetObjToGridView(netObject As NetworkObj, gridView As RadGridView)

        Dim attlist As List(Of propertySortingAttribute) = netObject.getPropSortAttrlist(netObject)
        attlist.Sort(Function(x As propertySortingAttribute, y As propertySortingAttribute) x.SortCode.CompareTo(y.SortCode))
        For Each att In attlist
            If att.PropInfo.PropertyType = GetType(Boolean) Then
                Dim gridViewDataColumns As New GridViewCheckBoxColumn
                gridViewDataColumns.FieldName = att.PropInfo.Name
                gridViewDataColumns.HeaderText = att.DisplayName
                gridView.Columns.Add(gridViewDataColumns)
            ElseIf att.PropInfo.PropertyType.IsEnum Then
                Dim gridViewDataColumns As New GridViewComboBoxColumn
                gridViewDataColumns.DataSource = [Enum].GetValues(att.PropInfo.PropertyType)
                gridViewDataColumns.FieldName = att.PropInfo.Name
                gridViewDataColumns.HeaderText = att.DisplayName
                gridView.Columns.Add(gridViewDataColumns)
            ElseIf att.DisplayName = "Colour" Then

            ElseIf att.PropInfo.PropertyType = GetType(Color) Then
                Dim gridViewDataColumns As New GridViewColorColumn
                gridViewDataColumns.FieldName = att.PropInfo.Name
                gridViewDataColumns.HeaderText = att.DisplayName
                gridView.Columns.Add(gridViewDataColumns)
            Else
                Dim gridViewDataColumns As New GridViewTextBoxColumn
                gridViewDataColumns.FieldName = att.PropInfo.Name
                gridViewDataColumns.HeaderText = att.DisplayName
                gridView.Columns.Add(gridViewDataColumns)
            End If
        Next
    End Sub

    Public Function determineColWidth(gridView As RadGridView) As Int16
        Dim width As Int16
        For Each column In gridView.Columns
            width += column.Width
        Next
        Return width
    End Function

End Class
