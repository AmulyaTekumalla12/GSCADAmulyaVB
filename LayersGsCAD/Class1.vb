Imports Gssoft.Gscad.Runtime

Public Class Class1

    <CommandMethod("GStarCAD", CommandFlags.Session)>
    Public Sub GADeatiling()
        Dim objRCCAutomCmd As Layers = New Layers()
        objRCCAutomCmd.Show()
    End Sub
End Class
