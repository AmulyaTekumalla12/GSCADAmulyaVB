'Imports System
'Imports System.Collections.Generic
'Imports System.Linq
'Imports System.Text
'Imports appCAD = GrxCAD.Interop
'Imports Gssoft.Gscad
'Imports Gssoft.Gscad.Runtime
'Imports Gssoft.Gscad.DatabaseServices
'Imports Gssoft.Gscad.Geometry
'Imports Gssoft.Gscad.ApplicationServices
'Imports Gssoft.Gscad.EditorInput

Public Class GStarLayers
    Sub Main()
        'Dim app As appCAD.GcadApplication = New appCAD.GcadApplication()


        '' Open a drawing file
        'Dim doc As appCAD.GcadDocument = app.Documents.Open("C:\Users\gouth\OneDrive\Desktop\GCAD\Sample.dwg")

        '' Access layers
        'Dim layers As appCAD.GcadLayers = doc.Layers

        '' Save layers to a text file
        'Dim layerFile As String = "C:\Users\gouth\OneDrive\Desktop\GCAD\layers.txt"
        'Using writer As New System.IO.StreamWriter(layerFile)
        '    For Each layer As appCAD.GcadLayer In layers
        '        writer.WriteLine(layer.Name)
        '    Next
        'End Using

        '' Close the drawing without saving changes
        'doc.Close(False)

        '' Close gstarCAD
        'app.Quit()
    End Sub

End Class
