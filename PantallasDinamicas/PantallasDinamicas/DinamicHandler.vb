Imports System.Reflection

Public Class DinamicHandler

    Public Sub DinamicAddHandler(ByVal Formulario As Form, ByVal Control As Control, _
                                 ByVal TipoEvento As String, ByVal Evento As String)

        Dim ev As EventInfo = Control.GetType.GetEvent(TipoEvento)

        Dim method As MethodInfo = Formulario.GetType().GetMethod(Evento, BindingFlags.NonPublic Or BindingFlags.Instance)

        Dim handler As [Delegate] = [Delegate].CreateDelegate(ev.EventHandlerType, Formulario, method)

        ev.AddEventHandler(Control, handler)
    End Sub
End Class