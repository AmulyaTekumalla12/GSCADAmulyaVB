Imports System
Imports GrxCAD

Imports GrxCAD.Runtime

Imports GrxCAD.DatabaseServices
Imports GrxCAD.Geometry

Imports GrxCAD.ApplicationServices
Imports GrxCAD.EditorInput

' This line is not mandatory, but improves loading performances
'<Assembly: CommandClass(GetType(GRXTest.MyCommands))>
Class MainWindow
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Me.RunMRLCommand()
    End Sub
    '<CommandMethod("vbhello", CommandFlags.Modal)>
    Public Sub RunMRLCommand() ' This method can have any name
        Dim doc As GrxCAD.ApplicationServices.Document
        Dim ent As Entity


        doc = GrxCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument
        doc.Editor.WriteMessage("hello vb.net")
    End Sub
End Class
