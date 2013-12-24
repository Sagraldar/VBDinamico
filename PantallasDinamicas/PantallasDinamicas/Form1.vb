Public Class Form1

    Private Pintor As New PintorControles

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim distribucionPaneles As Short() = {1, 3, 2}
        Pintor.GrupoPaneles(Me, 3, distribucionPaneles)

        Pintor.RadioBotonesContenedor(Me.Controls.Item(0), 3, 1)

        Pintor.BotonesContenedor(Me.Controls.Item(1), 9, 3)

        Pintor.EtiquetaDinamico(Me.Controls.Item(2), 100, 100, "Hola Mundo!", _
                                ContentAlignment.MiddleCenter, "LabelPrueba", _
                                New Point(100, 100), BorderStyle.FixedSingle)

        Pintor.BotonDinamico(Me.Controls.Item(2), 50, 300, "BotonPrueba", New Point(200, 200))
    End Sub
End Class