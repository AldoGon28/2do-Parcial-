Imports System.Data.SqlClient

Module ManejoBD
    Public Server = "DESKTOP-EJTBDBM\SQLEXPRESS"
    Public Database = "PROBLEMA1"
    Public Cadena As String = "Data Source='" & Server & "'; Initial Catalog='" & Database & "'; Integrated Security=True;"

    Public Conexion As New SqlConnection
    Public estadoBD As Boolean

    Friend Sub Registrar(total As Object, descT As Double, tot As Object)
        If estadoBD = True Then
            Try
                Dim sql = "INSERT INTO Vuelo (Subtotal, Descuento, Total) VALUES (" & total & ", " & descT & ", " & tot & ");"
                Dim Comando As New SqlCommand(sql, Conexion)
                Comando.ExecuteNonQuery()
                MsgBox("El dato se guardo exitosamente")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No esta conectado a la base de datos.")
        End If
    End Sub

    Friend Sub obtenerReporte()
        If estadoBD = True Then
            Try
                Dim sql = "SELECT * FROM Vuelo"
                Dim Comando As New SqlDataAdapter(sql, Conexion)
                Dim TablaDatos As New DataSet
                Comando.Fill(TablaDatos, "Datos")
                Reporte.DataGridView1.DataSource = TablaDatos.Tables("Datos")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Friend Sub Modificar(codigo As String, subt As Double, desc As Double, total As Double)
        If estadoBD = True Then
            Try
                Dim sql = "UPDATE Vuelo SET Subtotal = " & subt & ", Descuento= " & desc & ", Total = " & total & " WHERE Codigo = " & codigo & ";"
                Dim Comando As New SqlCommand(sql, Conexion)
                Comando.ExecuteNonQuery()
                MsgBox("Se modifico el dato exitosamente")
                Reporte.Limpiar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No esta conectado a la base de datos.")
        End If
    End Sub

    Friend Sub Eliminar(codigo As String)
        If estadoBD = True Then
            Try
                Dim sql = "DELETE Vuelo WHERE Codigo = " & codigo & ";"
                Dim Comando As New SqlCommand(sql, Conexion)
                Comando.ExecuteNonQuery()
                MsgBox("Se elimino el dato exitosamente")
                Reporte.Limpiar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No esta conectado a la base de datos.")
        End If
    End Sub
End Module
