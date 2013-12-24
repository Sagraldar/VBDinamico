Public Class PintorControles

    Public Sub New()

    End Sub

    '       ELEMENTOS SOLITARIOS

    '   BUTTON

    Public Sub BotonDinamico(ByVal Contenedor As Control, ByVal x As Integer, ByVal y As Integer, ByVal nombre As String, ByVal tamanno As Point)
        Dim Boton As New Button

        Boton.Name = nombre
        Boton.Top = y
        Boton.Left = x
        Boton.Size = tamanno

        Contenedor.Controls.Add(Boton)
    End Sub


    '   LABEL

    Public Sub EtiquetaDinamico(ByVal Contenedor As Control, ByVal x As Integer, ByVal y As Integer, ByVal Texto As String, _
                                ByVal Alineacion As ContentAlignment, ByVal Nombre As String, ByVal Tamanno As Point, _
                                ByVal Borde As BorderStyle)
        Dim Etiqueta As New Label

        Etiqueta.Name = Nombre
        Etiqueta.Top = y
        Etiqueta.Left = x
        Etiqueta.Size = Tamanno


        Etiqueta.BorderStyle = Borde

        Etiqueta.TextAlign = Alineacion

        Etiqueta.Text = Texto

        Contenedor.Controls.Add(Etiqueta)
    End Sub

    '   TERMINAR LA CLASE PARA QUE PUEDA GENERAR TODO UN SISTEMA DE PANELES VERTICALES Y HORIZONTALES
    Public Sub GrupoPaneles(ByVal Formulario As Form, ByVal nPaneles As Short, _
                             ByVal distribucion As Short(), Optional ByVal orientacion As Boolean = False)
        Dim altoForm As Integer = Formulario.Height
        Dim anchoForm As Integer = Formulario.Width

        Dim margenIz As Integer = 0
        Dim margenSup As Integer = 0

        Dim suma As Short = distribucion(0) + distribucion(1) + distribucion(2)

        For panelCreado As Short = 0 To nPaneles - 1
            Dim Panel As New Panel

            Panel.Top = margenSup
            Panel.Left = margenIz

            Panel.Height = altoForm
            Panel.Width = anchoForm * distribucion(panelCreado) / suma
            Panel.BorderStyle = BorderStyle.FixedSingle

            Panel.Name = "Panel" + panelCreado.ToString

            margenIz += Panel.Width

            Formulario.Controls.Add(Panel)
        Next
    End Sub

    Public Sub BotonesContenedor(ByVal Contenedor As Control, _
                                 ByVal nBotones As Short, ByVal nColumnas As Short)
        'esto es un bucle en plan guarro, no salen bien alineados, pero porque lo he hecho muy rápido.

        Dim margenIz As Integer = 2
        Dim MargenSup As Integer = 2

        Dim nFilas As Short = (nBotones / nColumnas)

        Dim ancho As Short = (Contenedor.Width - nColumnas * 2 - 4) / nColumnas
        Dim alto As Short = (Contenedor.Height - nFilas * 2 - 4) / nFilas

        Dim fila As Short = 1
        Dim columna As Short = 1

        For indice As Integer = 0 To nBotones - 1
            'creamos el boton y le asignamos el evento click
            Dim boton As New Button

            'le damos tamaño y forma

            boton.Size = New Size(ancho, alto)

            boton.Top = MargenSup
            boton.Left = margenIz

            'le damos un nombre para identificarlo
            boton.Name = "boton" & (indice + 1).ToString()
            'le damos a cada uno un texto
            boton.Text = "boton" & (indice + 1).ToString()

            columna += 1
            margenIz += 2 + ancho

            If columna > nColumnas Then
                columna = 1
                fila += 1
                MargenSup += 2 + alto
                margenIz = 2
            End If

            '   AGREGAMOS LOS BOTONES DENTRO DEL CONTENEDOR
            Contenedor.Controls.Add(boton)
        Next
    End Sub

    Public Sub RadioBotonesContenedor(ByVal Contenedor As Control, _
                                 ByVal nRadioBotones As Short, ByVal nColumnas As Short)
        'esto es un bucle en plan guarro, no salen bien alineados, pero porque lo he hecho muy rápido.

        Dim margenIz As Integer = 0
        Dim MargenSup As Integer = 0

        Dim nFilas As Short = (nRadioBotones / nColumnas)

        Dim ancho As Short = Contenedor.Width / nColumnas
        Dim alto As Short = Contenedor.Height / nFilas

        Dim fila As Short = 1
        Dim columna As Short = 1

        For indice As Integer = 0 To nRadioBotones - 1
            'creamos el boton y le asignamos el evento click
            Dim RadioBoton As New RadioButton
            'le damos tamaño y forma

            RadioBoton.Size = New Size(ancho, alto)

            RadioBoton.Appearance = Appearance.Button

            RadioBoton.Top = MargenSup
            RadioBoton.Left = margenIz

            'le damos un nombre para identificarlo
            RadioBoton.Name = "boton" & (indice + 1).ToString()
            'le damos a cada uno un texto
            RadioBoton.Text = "boton" & (indice + 1).ToString()

            columna += 1
            margenIz += ancho

            If columna > nColumnas Then
                columna = 1
                fila += 1
                MargenSup += alto
                margenIz = 0
            End If

            '   AGREGAMOS LOS BOTONES DENTRO DEL CONTENEDOR
            Contenedor.Controls.Add(RadioBoton)
        Next
    End Sub
End Class