Imports Gssoft.Gscad.Runtime
Imports Gssoft.Gscad.ApplicationServices
Imports Gssoft.Gscad.Colors
Imports Gssoft.Gscad.DatabaseServices
Imports Gssoft.Gscad.EditorInput
Imports Gssoft.Gscad.Geometry
Imports acApp = Gssoft.Gscad.ApplicationServices.Application
Imports System.Windows
Imports System.Windows.Forms

Public Class Layers

    Dim acDocMgr As DocumentCollection
    Dim doc As Document
    Dim db As Database
    Dim edt As Editor
    Dim selectedFile As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Using openFileDialog As New OpenFileDialog()

            Dim result As DialogResult = openFileDialog.ShowDialog()
            If result = DialogResult.OK AndAlso Not String.IsNullOrWhiteSpace(openFileDialog.FileName) AndAlso openFileDialog.FileName.Contains(".dwg") Then
                'selectedFile = openFileDialog.FileName
                Dim filePath As String = openFileDialog.FileName
                selectedFile = filePath
                acDocMgr = acApp.DocumentManager
                doc = acDocMgr.Open(filePath)
                db = doc.Database
                edt = doc.Editor
                Dim lt As LayerTable
                ' Get the layer table from the active document
                Using transaction = db.TransactionManager.StartTransaction()
                    lt = TryCast(transaction.GetObject(db.LayerTableId, OpenMode.ForRead), LayerTable)
                    ' Populate the list box with layers
                    For Each layerId As ObjectId In lt
                        Dim layer As LayerTableRecord = TryCast(transaction.GetObject(layerId, OpenMode.ForRead), LayerTableRecord)
                        If layer IsNot Nothing Then
                            ListBox1.Items.Add(layer.Name)
                        End If
                    Next
                    transaction.Commit()
                End Using
            Else
                MessageBox.Show("Please select dwg file/ No File selected")
            End If
        End Using


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Code to enable all layers
        If doc Is Nothing Then
            MessageBox.Show("Please select dwg file/ No File selected")
        Else
            Using transaction = db.TransactionManager.StartTransaction()
                Dim lt As LayerTable = TryCast(transaction.GetObject(db.LayerTableId, OpenMode.ForRead), LayerTable)
                For Each layerId As ObjectId In lt
                    Dim layer As LayerTableRecord = TryCast(transaction.GetObject(layerId, OpenMode.ForWrite), LayerTableRecord)
                    layer.IsOff = False
                Next

                transaction.Commit()
            End Using
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Code to disable all layers
        If doc Is Nothing Then
            MessageBox.Show("Please select dwg file/ No File selected")
        Else

            Using transaction = db.TransactionManager.StartTransaction()
                Dim lt As LayerTable = TryCast(transaction.GetObject(db.LayerTableId, OpenMode.ForRead), LayerTable)
                For Each layerId As ObjectId In lt
                    Dim layer As LayerTableRecord = TryCast(transaction.GetObject(layerId, OpenMode.ForWrite), LayerTableRecord)
                    layer.IsOff = True
                Next

                transaction.Commit()
            End Using
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If doc Is Nothing Then
            MessageBox.Show("Please select dwg file/ No File selected")
        Else
            Using transaction = db.TransactionManager.StartTransaction()
                Dim lt As LayerTable = TryCast(transaction.GetObject(db.LayerTableId, OpenMode.ForRead), LayerTable)
                For Each layerId As ObjectId In lt
                    For Each item As String In ListBox1.SelectedItems

                        Dim layer As LayerTableRecord = TryCast(transaction.GetObject(layerId, OpenMode.ForWrite), LayerTableRecord)
                        If item = layer.Name Then
                            layer.IsOff = False
                        End If
                    Next
                Next
                transaction.Commit()
            End Using
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If doc Is Nothing Then
            MessageBox.Show("Please select dwg file/ No File selected")
        Else
            Using transaction = db.TransactionManager.StartTransaction()
                Dim lt As LayerTable = TryCast(transaction.GetObject(db.LayerTableId, OpenMode.ForRead), LayerTable)
                For Each layerId As ObjectId In lt
                    For Each item As String In ListBox1.SelectedItems

                        Dim layer As LayerTableRecord = TryCast(transaction.GetObject(layerId, OpenMode.ForWrite), LayerTableRecord)
                        If item = layer.Name Then
                            layer.IsOff = True
                        End If
                    Next
                Next
                transaction.Commit()
            End Using
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim strLt = selectedFile.Split("\").Length
        Dim lastItem = selectedFile.Split("\")(strLt - 1)
        Dim firstItem = selectedFile.Split("\")(0)
        Dim filePath = ""
        For Each item As String In selectedFile.Split("\")
            If (item = lastItem) Then
            ElseIf (item = firstItem) Then
                filePath = filePath + item
            Else
                filePath = filePath + "\" + item
            End If

        Next

        doc.CloseAndSave(filePath + "\savedDrawing.dwg")
    End Sub
End Class