Public Class PruebaDinamicos

    Private Pintor As New DinamicControls(Me)

    Private Sub PruebaDinamicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim distribucionPaneles As Short() = {1, 3, 2}
        Pintor.GrupoPaneles(Me, 3, distribucionPaneles)

        Pintor.RadioBotonesContenedor(Me.Controls.Item(0), 3, 1)

        Pintor.BotonesContenedor(Me.Controls.Item(1), 9, 3)

        Pintor.EtiquetaDinamico(Me.Controls.Item(2), 100, 100, "LabelPrueba", New Point(100, 100), _
                                ContentAlignment.MiddleCenter, Color.Blue, "Hola Mundo!", BorderStyle.FixedSingle)

        Pintor.BotonDinamico(Me.Controls.Item(2), 50, 230, "BotonPrueba", New Point(200, 200), "Hola Mundo!")

        Pintor.CajaTextoDinamico(Me.Controls.Item(2), 20, 500, "EtiquetaPrueba", New Point(200, 100), HorizontalAlignment.Center, , BorderStyle.Fixed3D)
    End Sub
End Class