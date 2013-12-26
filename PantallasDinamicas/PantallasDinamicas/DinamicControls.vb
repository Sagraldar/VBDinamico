Public Class DinamicControls

    Private Formulario As Form

    Public Sub New(ByVal Formulario As Form)
        Me.Formulario = Formulario
    End Sub

    '           ELEMENTOS SOLITARIOS

    '   BUTTON
    Public Sub BotonDinamico(ByVal Contenedor As Control, _
                             ByVal x As Integer, _
                             ByVal y As Integer, _
                             ByVal Nombre As String, _
                             ByVal Size As Point, _
                             Optional ByVal Texto As String = Nothing)
        Dim BotonDin As New Button          '   INSTANCIAMOS UN NUEVO BOTON GENÉRICO

        BotonDin.Left = x                   '   POSICIÓN CON RESPECTO AL BORDE LATERAL IZQUIERDO DEL CONTENEDOR
        BotonDin.Top = y                    '   POSICIÓN CON RESPECTO AL BORDE SUPERIOR DEL CONTENEDOR
        BotonDin.Name = Nombre              '   COLOCAMOS LAS PROPIEDADES DEL CONTROL
        BotonDin.Size = Size                '   TAMAÑO DEL CONTROL DEFINIDO POR UN OBJETO POINT
        BotonDin.Text = Texto               '   TEXTO QUE CONTENDRÁ EL CONTROL, POR DEFECTO NO LLEVA TEXTO

        Contenedor.Controls.Add(BotonDin)   '   AÑADIMOS EL CONTROL AL CONTENEDOR QUE LE PASEMOS POR PARÁMETRO


    End Sub

    '   LABEL
    Public Sub EtiquetaDinamico(ByVal Contenedor As Control, _
                             ByVal x As Integer, _
                             ByVal y As Integer, _
                             ByVal Nombre As String, _
                             ByVal Size As Point, _
                             ByVal Alineacion As ContentAlignment, _
                             ByVal Color As Color, _
                             Optional ByVal Texto As String = Nothing, _
                             Optional ByVal Borde As BorderStyle = BorderStyle.None)
        Dim EtiquetaDin As New Label            '   INSTANCIAMOS UNA NUEVA ETIQUETA GENÉRICA

        EtiquetaDin.Left = x                    '   POSICIÓN CON RESPECTO AL BORDE LATERAL IZQUIERDO DEL CONTENEDOR
        EtiquetaDin.Top = y                     '   POSICIÓN CON RESPECTO AL BORDE SUPERIOR DEL CONTENEDOR
        EtiquetaDin.Name = Nombre               '   COLOCAMOS LAS PROPIEDADES DEL CONTROL
        EtiquetaDin.Size = Size                 '   TAMAÑO DEL CONTROL DEFINIDO POR UN OBJETO POINT
        EtiquetaDin.TextAlign = Alineacion      '   ALICNEACIÓN DEL TEXTO INTERIOR DE LA ETIQUETA
        EtiquetaDin.ForeColor = Color           '   COLOR DEL TEXTO INTERIOR DE LA ETIQUETA
        '   ATRIBUTOS OPCIONALES
        EtiquetaDin.BorderStyle = Borde         '   BORDE QUE POSEE EL CONTROL, POR DEFECTO NO TIENE NINGUNO
        EtiquetaDin.Text = Texto                '   TEXTO QUE CONTENDRÁ EL CONTROL, POR DEFECTO NO LLEVA TEXTO

        Contenedor.Controls.Add(EtiquetaDin)    '   AÑADIMOS EL CONTROL AL CONTENEDOR QUE LE PASEMOS POR PARÁMETRO
    End Sub

    '   TEXTBOX                                                                 'HACER
    Public Sub CajaTextoDinamico(ByVal Contenedor As Control, _
                             ByVal x As Integer, _
                             ByVal y As Integer, _
                             ByVal Nombre As String, _
                             ByVal Size As Point, _
                             ByVal Alineacion As HorizontalAlignment, _
                             Optional ByVal Texto As String = Nothing, _
                             Optional ByVal Borde As BorderStyle = BorderStyle.None)
        Dim CajaTextoDin As New TextBox             '   INSTANCIAMOS UNA NUEVA CAJA DE TEXTO GENÉRICA

        CajaTextoDin.Left = x                       '   POSICIÓN CON RESPECTO AL BORDE LATERAL IZQUIERDO DEL CONTENEDOR
        CajaTextoDin.Top = y                        '   POSICIÓN CON RESPECTO AL BORDE SUPERIOR DEL CONTENEDOR
        CajaTextoDin.Name = Nombre                  '   COLOCAMOS LAS PROPIEDADES DEL CONTROL
        CajaTextoDin.Size = Size                    '   TAMAÑO DEL CONTROL DEFINIDO POR UN OBJETO POINT
        'CajaTextoDin.Font = TextoProp               '   PROPIEDADES DE LA LETRA DEFINIDAS POR UN OBJETO FONT
        CajaTextoDin.TextAlign = Alineacion         '   ALINEACIÓN DEL TEXTO INTERIOR DE LA ETIQUETA
        '   ATRIBUTOS OPCIONALES
        CajaTextoDin.BorderStyle = Borde            '   BORDE QUE POSEE EL CONTROL, POR DEFECTO NO TIENE NINGUNO
        CajaTextoDin.Text = Texto                   '   TEXTO QUE CONTENDRÁ EL CONTROL, POR DEFECTO NO LLEVA TEXTO

        Contenedor.Controls.Add(CajaTextoDin)       '   AÑADIMOS EL CONTROL AL CONTENEDOR QUE LE PASEMOS POR PARÁMETRO
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

        Dim margenIz As Integer = 2
        Dim margenSup As Integer = 2

        Dim nFilas As Short = (nBotones / nColumnas)

        Dim ancho As Short = (Contenedor.Width - nColumnas * 2 - 4) / nColumnas
        Dim alto As Short = (Contenedor.Height - nFilas * 2 - 4) / nFilas

        Dim fila As Short = 1
        Dim columna As Short = 1

        For indice As Integer = 0 To nBotones - 1

            BotonDinamico(Contenedor, margenIz, margenSup, _
                          "boton" & (indice + 1).ToString(), _
                          New Point(ancho, alto), _
                          "boton" & (indice + 1).ToString())

            columna += 1
            margenIz += 2 + ancho

            If columna > nColumnas Then
                columna = 1
                fila += 1
                margenSup += 2 + alto
                margenIz = 2
            End If
        Next
    End Sub

    Public Sub RadioBotonesContenedor(ByVal Contenedor As Control, _
                                 ByVal nRadioBotones As Short, ByVal nColumnas As Short)

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